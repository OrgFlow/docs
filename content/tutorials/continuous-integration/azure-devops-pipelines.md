---
uid: guide_ci_azuredevops
title: Azure DevOps Pipelines
---

The purpose of this guide is to provide a few examples of the things you can do with OrgFlow and Azure DevOps pipelines. It's by no means an exhaustive list, but instead is a good starting point for you to implement your own pipelines and processes. For simplicity, this guide assumes that the Azure DevOps pipelines are contained within the same repository as your Salesforce metadata (although this is not a necessity).

## Recommended approach

We recommend that you use the [OrgFlow CLI docker image](https://hub.docker.com/r/orgflow/cli) as the container to run your pipelines. This image is pre-configured to allow you to get up and running with OrgFlow in a matter of minutes. We recommend that you save your @concept_licensekey as a pipeline variable, and then pass the variables value as an environment variable (`ORGFLOW_LICENSEKEY`) when creating the container. For process commands that require a stack, we recommend that you create a pipeline variable to hold your stack name and pass the value to to the Docker container as an environment variable (`ORGFLOW_STACKNAME`)

### Salesforce authentication

OrgFlow will need to be able to authenticate with Salesforce in order to interact with it. Interactive authentication flows (such as OAuth) are not a viable option in automation contexts, so you will need to rely on username and password authentication. There are two ways to achieve this:

1. Save the username and password in OrgFlow's state store once for re-use on every execution:
   - Run @command_auth_salesforce_save with `--location=StateStore` for the stack you're automating. You only need to do this once per stack (and you don't necessarily need to run this command in the container either), as the Salesforce credentials will be saved in the state store which is persistent.
   - Store the encryption key that you used in the previous step as a pipeline variable.
   - Pass the encryption key secret's value as an environment variable (`ORGFLOW_ENCRYPTIONKEY`) when creating the container or running OrgFlow commands.
1. Save the production Salesforce username and password as repository secrets, and add a step to your pipeline to save the values in the container every time you spin it up. You'll need to do these steps every time you spin up a container, as the Salesforce credentials and encryption key will be saved on disk in the container, which is ephemeral.

    ```yaml
    - script: |
        # Create a new encryption key and then assign it to a variable:
        encryptionKey=`orgflow auth:key:create --output=flat`
        # Save the key to the container:
        orgflow auth:key:save -k=$encryptionKey
        # Encrypt and save the Salesforce username and password:
        orgflow auth:salesforce:save -u=$SALESFORCE_USERNAME -p=$SALESFORCE_PASSWORD
    displayName: Set Salesforce credentials
    env:
        SALESFORCE_USERNAME: $(SALESFORCE_USERNAME)
        SALESFORCE_PASSWORD: $(SALESFORCE_PASSWORD)
    ```

The method you choose will likely come down to the approach that you feel most comfortable with, but we recommend the second option.

### Git authentication

A lot of OrgFlow commands need to be able to clone a remote Git repository. To do this over HTTPS, Git needs a username and a token/password. When running a pipeline, Azure DevOps [provides an access token for the repository](https://docs.microsoft.com/en-us/azure/devops/pipelines/process/access-tokens?view=azure-devops&tabs=yaml) that the pipeline belongs to. We recommend that you use this token for authentication with the repository. The token is available via the `$(System.AccessToken)` variable, but you must assign it to an environment variable to access it (as with any secret in Azure DevOps pipelines).

To allow Git to use the token, we recommend using `git config` to provide Git with an alternative repo URL that contains the token. The other two config value that you will need to set are `user.name` and `user.email`. Git simply requires that these values are set before it allows you to commit any changes, but their value is insignificant (feel free to set these two values to anything you like).

>[!NOTE]
> This technique will only work when communicating with the remote repository via HTTPS; the token will not work with other protocols (such as SSH). OrgFlow will use whatever URL you have set on the stack, so be sure that the correct URL has been saved on the stack. You can use the @command_auth_git_save to change the remote Git repository URL if you need to.

```yaml
- script: |
    # Configure Git to use a repo URL with the token (instead of the repo URL without the token). Remember to replace <myrepohostname> with your correct workspace name:
    git config --global url."https://<myrepohostname>:$SYSTEM_ACCESSTOKEN@dev.azure.com/".insteadOf "https://<myrepohostname>@dev.azure.com/"

    # Set some values for user.name and user.email:
    git config --global user.name "OrgFlow Default Committer"
    git config --global user.email "defaultcommitter@orgflow.io"
  displayName: 'Add Git credentials'
  env:
    # You need to pass the $(System.AccessToken) secret as an environment variable in order to be able to use it:
    SYSTEM_ACCESSTOKEN: $(System.AccessToken)
```

>[!TIP]
> By default, Azure DevOps pipelines will clone the repository as part of the pipeline. OrgFlow does not need the repository to already be on disk in order to operate, so feel free to disable that by configuring the checkout step: `- checkout: none`.

See @guide_git_authentication for more information, or to see some other authentication techniques that you could use (for example if the remote Git repository URL is SSH).

## Example pipeline

```yaml
# Flow in an environment (pull the metadata from Salesforce into Git).

pool:
  vmImage: ubuntu-latest

resources:
  containers:
    # Create a container definition called 'orgflow' so that it can be re-used (for example, if we had more than one job):
    - container: orgflow
      image: orgflow/cli:latest
      env:
        # ORGFLOW_ACCEPTEULA: true #Uncomment to signify that you accept the End User License Agreement.
        ORGFLOW_STACKNAME: $(ORGFLOW_STACKNAME)
        ORGFLOW_LICENSEKEY: $(ORGFLOW_LICENSEKEY)

jobs:
- job: env_flowin
  displayName: Flow Environment In
  # Use the pre-defined container definition that we created a little further up:
  container: orgflow
  steps:
  # OrgFlow checkouts the repo, so we don't have to:
  - checkout: none
  - script: echo $(matrix)
  # Take the Salesforce credentials from DevOps variables, and save them to the stack to support credential inference:
  - script: |
      encryptionKey=`orgflow auth:key:create --output=flat`
      orgflow auth:key:save -k=$encryptionKey
      orgflow auth:salesforce:save -u=$SALESFORCE_USERNAME -p=$SALESFORCE_PASSWORD
    displayName: Set Salesforce credentials
    env:
      SALESFORCE_USERNAME: $(SALESFORCE_USERNAME)
      SALESFORCE_PASSWORD: $(SALESFORCE_PASSWORD)
  # Configure Git to use the System.AccessToken system variable to authenticate with the repository:
  - script: |
      git config --global url."https://ideliverable:$SYSTEM_ACCESSTOKEN@dev.azure.com/".insteadOf "https://ideliverable@dev.azure.com/"
      git config --global user.name "OrgFlow Default Committer"
      git config --global user.email "defaultcommitter@orgflow.io"
    displayName: 'Add Git credentials'
    env:
      SYSTEM_ACCESSTOKEN: $(System.AccessToken)
  # Flow the environment in:
  - script: |
      # Create a pipeline variable called 'ENVIRONMENT' to control which environment gets flowed in. Allowing it to be set at runtime allows you to specify which environment you'd like to flow in:
      orgflow env:flowin -e=$(ENVIRONMENT)
    displayName: env:flowin
    env:
      # If OrgFlow fails, it will write a diagnostic bundle to disk. This environment variable controls where on disk it is written to, so that we can publish it as an artifact in the next step:
      ORGFLOW_DIAGNOSTICSFILEDIRECTORYPATH: $(Build.ArtifactStagingDirectory)
  # Publish diagnostic bundles (if any):
  - task: PublishPipelineArtifact@1
    displayName: Publish diagnostic bundles
    condition: always()
    inputs:
      targetPath: $(Build.ArtifactStagingDirectory)
```

## Advanced scenarios

### Running pipeline jobs for every environment in your stack

You may have pipelines that you want to run against multiple environments. For example, a pipeline that flows in all of your environments on a daily schedule.

Instead of copying and pasting the job for each environment, you can take advantage of the @command_env_list command to retrieve all of the environment names in a stack. Then you can use a matrix strategy to run the job once per environment.

The trick here is to use a tool called [jq](https://stedolan.github.io/jq/) to transform the output from @command_env_list into the format that Azure DevOps expects for a matrix definition. The correct jq syntax for this is `map( { (.name): {environment: .name} } ) | add`. On top of this, jq offers a robust filtering syntax, for example if you only wanted to include some environments.

jq is included in the official OrgFlow docker image.

```yaml
pool:
  vmImage: ubuntu-latest

resources:
  containers:
    # Create a container definition called 'orgflow' so that it can be re-used:
    - container: orgflow
      image: orgflow/cli:latest
      env:
        # ORGFLOW_ACCEPTEULA: true #Uncomment to signify that you accept the End User License Agreement.
        ORGFLOW_STACKNAME: $(ORGFLOW_STACKNAME)
        ORGFLOW_LICENSEKEY: $(ORGFLOW_LICENSEKEY)

jobs:
- job: env_list
  displayName: Build Environment Matrix
  container: orgflow
  steps:
  # We don't need a repo for this job:
  - checkout: none
  - script: |
      # List all the environments in the stack and output as JSON. Use jq to transform that JSON into the format expected from Azure DevOps for a matrix, and then assign the transformed output to an output variable:
      echo "##vso[task.setvariable variable=environmentMatrix;isOutput=true]`orgflow env:list --output=json | jq 'map( { (.name): {environment: .name} } ) | add' -c`"
    name: createMatrix

- job: env_flowin
  displayName: Flow Environment In
  container: orgflow
  dependsOn: env_list
  # This jobs will get executed once per value in the matrix:
  strategy:
    # Use the output from the previous job to define the matrix:
    matrix: $[ dependencies.env_list.outputs['createMatrix.environmentMatrix'] ]
  steps:
    .
    .
    .
```
