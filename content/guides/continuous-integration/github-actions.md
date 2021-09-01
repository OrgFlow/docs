---
uid: guide_ci_github
title: GitHub Actions
---

The purpose of this guide is to provide a few examples of the things you can do with OrgFlow and GitHub Actions. It's by no means an exhaustive list, but instead is a good starting point for you to implement your own workflows and processes. For simplicity, This guide assumes that the GitHub workflows are contained within the same repository as your Salesforce metadata (although this is not necessity).

## Recommended approach

We recommend that you use the [OrgFlow CLI docker image](https://hub.docker.com/r/orgflow/cli) as the container to run your workflows. This image is pre-configured to allow you to get up and running with OrgFlow in a matter of minutes. We recommend that you save your @concept_licensekey as a repository secret, and then pass the secret's value as an environment variable (`ORGFLOW_LICENSEKEY`) when creating the container.

### Salesforce authentication

OrgFlow will need to be able to authenticate with Salesforce in order to interact with it. Interactive authentication flows (such as OAuth) are not a viable option in automation contexts, so you will need to rely on username and password authentication. There are two ways to achieve this:

1. Save the username and password in OrgFlow's state store once for re-use on every execution:
   - Run @command_auth_salesforce_save with `--location=StateStore` for the stack you're automating. You only need to do this once per stack (and you don't necessarily need to run this command in the container either), as the Salesforce credentials will be saved in the state store which is persistent.
   - Store the encryption key that you used in the previous step as a repository secret.
   - Pass the encryption key secret's value as an environment variable (`ORGFLOW_ENCRYPTIONKEY`) when creating the container or running OrgFlow commands.
2. Save the username and password as repository secrets, and add a step to your workflow to save the values in the container every time you spin it up. You'll need to do these steps every time you spin up a container, as the Salesforce credentials and encryption key will be saved on disk in the container, which is ephemeral.
   - Use @command_auth_key_create to create a new encryption key and then assign it to a variable (``encryptionKey=`orgflow auth:key:create --output=flat` ``).
   - Run @command_auth_key_save to save the key to the container (`orgflow auth:key:save -k=$encryptionKey`).
   - Run @command_auth_salesforce_save with `--location=Local`, passing in your Salesforce username and password from repository secrets.

The method you choose will likely come down to the approach that you feel most comfortable with, but we recommend the second option. You can use the `orgflow-action/set-salesforce-auth` action in the GitHub marketplace to handle this for you.

### Git authentication

A lot of OrgFlow commands need to be able to clone a remote Git repository. To do this over HTTPS, Git needs a username and a token/password. When running a workflow, GitHub [provides an access token for the repository](https://docs.github.com/en/actions/reference/authentication-in-a-workflow) that the workflow belongs to. We recommend that you use this token for authentication with the repository. The token is available via the `${{ github.token }}` variable. You can take advantage of the `GIT_ASKPASS` environment variable to pass this token into Git.

Next up, you need to configure a username. GitHub does not use the username for authentication if you're using a token, but Git requires one to be available. The easiest way to do this is to add it to Git config: `git config --global credential.$GITHUB_SERVER_URL.username ${{ github.actor }}`.

You can use the `orgflow-action/configure-git` action in the GitHub marketplace to handle this for you.

>[!NOTE]
> This technique will only work when communicating with the remote repository via HTTPS; the token will not work with other protocols (such as SSH). OrgFlow will use whatever URL you have set on the stack, so be sure that the correct URL has been saved on the stack. You can use the @command_auth_git_save to change the remote Git repository URL if you need to.

Some OrgFlow commands (@command_stack_create, @command_env_create, @command_env_flowin, and [env:flowmerge](xref:command_env_flowmerge)) require the ability to push changes back to the remote Git repository. For these commands, you will need to make sure that the token is scoped to allow this (`contents: write`).

>[!TIP]
> It's common for GitHub actions to clone the repository as part of the workflow. OrgFlow does not need the repository to already be on disk in order to operate, so feel free to remove that step.

See @guide_git_authentication for more information, or to see some other authentication techniques that you could use (for example if the remote Git repository URL is SSH).

## Example workflow

```yaml
# Flow in an environment (pull the metadata from Salesforce into Git).

name: OrgFlow flow:in demo
on:
  # This action is manually executed.
  workflow_dispatch:

permissions:
  contents: write

jobs:
  EnvironmentSetup:
    # Run in a container using the OrgFlow image.
    runs-on: ubuntu-latest
    container:
      image: orgflow/cli:latest
    env:
      # ORGFLOW_ACCEPTEULA: true #Uncomment to signify that you accept the End User License Agreement.
      ORGFLOW_STACKNAME: GitHubActionsDemo # Replace this with your stack name.
      ORGFLOW_LICENSEKEY: ${{ secrets.ORGFLOW_LICENSEKEY }} # Make sure to add a repository secret called ORGFLOW_LICENSEKEY with your license key in it.

    steps:
      - uses: orgflow-actions/configure-git@v1
        with:
          token: ${{ secrets.GITHUB_TOKEN }}
      - uses: orgflow-actions/set-salesforce-auth@v0.2
        with:
          username: ${{ secrets.SALESFORCE_USERNAME }}
          password: ${{ secrets.SALESFORCE_PASSWORD }}
      - name: flow:in
        run: |
          orgflow env:flowin -e=Production
```
