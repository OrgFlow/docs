---
uid: command_stack_create
title: stack:create
---

## Description

Create a new @concept_stack. This will probably be the very first command you run with OrgFlow. You only need to run this command once per stack.

## Process

The `stack:create` command will create a stack that contains the minimum amount of data required for stack based commands to function:

- A stack record is added to the stack state store, containing:
  - The remote Git repository's URL. This allows further OrgFlow commands to clone the repository.
  - A path relative to the root of the repository to indicate where metadata should be located within the repository (optional).
  - A flag indicating whether or not metadata should be committed in a way that maintains compatibility with other deployment tools (optional) .
  - The Sign-in URL for your production Salesforce organization (optional).
  - The preferred Salesforce API version to use (optional).
- The remote Git repository must already exist, but OrgFlow will configure it with a few pre-requisites:
  - The repository will be initialized with a first commit if required. The first commit will be a `.gitignore` file
  - The branch to back the production environment will be created from the head of the default branch (if the branch does not already exist).
  - A `.gitattributes` file will be added at the root of the metadata location in the repository. This file ensures that the metadata is committed in a way that is compatible with OrgFlow.
  - A @concept_orgflowincludefile will be added (optional).
- A production @concept_environment is added to the stack.
- The metadata from the production Salesforce organization is committed to the repository. We call this process a @concept_flowin.

## Options

- **`-n|--name=<stackName>`**

  Required. Prompted for when not specified, and possible to do so. Defaults to `Main` if not specified.

  The name of the stack to be initialized. Stack names are **not** case-sensitive.

- **`-e|--productionEnvironmentName=<environmentName>`**

  Required. Prompted for when not specified, and possible to do so. Defaults to `Production` if not specified.

  The name of the production environment to be added to the stack. Environment names are **not** case-sensitive.

- **`-r|--gitRepoUrl=<gitUrl>`**

  Required. Prompted for when not specified, and possible to do so.

  The location of the remote Git repository to contain your metadata. See [the git clone docs](https://git-scm.com/docs/git-clone#_git_urls) for examples of valid values. OrgFlow supports all formats with the exception of relative local locations (e.g. `./path/to/repo.git/`).

  >[!CAUTION]
  > Your Salesforce metadata will be committed to this repository, so be careful not to accidentally use a public repository if you are not comfortable making your Salesforce metadata visible to the public.

  >[!WARNING]
  > This value will be stored un-encrypted in our state store. Please do not use any URLs that contain authentication secrets (e.g. `https://<secrettoken>@github.com/myrepo.git`).

- **`-b|--gitBranch=<branchName>`**

  Required. Prompted for when not specified, and possible to do so. Defaults to `master` if not specified.

  The name of the branch to back the production environment. Metadata that is retrieved from the production organisation is committed to this branch, and metadata changes made in this branch can be deployed to the production Salesforce organisation. The branch will be created from the head of the default branch (only if the branch does not already exist on the remote).

- **`-a|--archivePath=<relativePath>`**

  Defaults to `/` if not specified.

  The path relative to the root of the repository that Salesforce metadata will be committed to. For example, specify `--archivePath=/` to put the metadata at the root fo the repo, or `--archivePath=src/` to put the metadata into a folder called `src`.

- **`-i|--include=<category>[,<category>,...]`**

  Prompted for when not specified, and possible to do so.

  The categories of metadata types that should added to the initial `.orgflowinclude` for the new stack (see @concept_orgflowincludefile for more information) and included when flowing changes between Salesforce and your Git repository.

  The following categories are supported:

  - `code`: Apex and VisualForce code components (cannot be modified in production)
  - `process`: Process customizations (rules, approval processes, flows and workflows)
  - `general`: Most commonly used point-and-click customizable configuration
  - `user`: Common user-created metadata such as reports, dashboards and documents (can significantly increase flow times)
  - `einstein`: Most commonly used Einstein AI component types
  - `tableau`: Most commonly used Tableau CRM analytics and BI component types
  - `sc`: Most commonly used Service Cloud component types
  - `ec`: Most commonly used Experience Cloud component types

  To create the stack with an empty `.orgflowinclude` file and manually add rules to it later, omit this argument and select no categories if prompted.

  If there is already a `.orgflowinclude` file in the Git repository, any existing rules will be preserved. Any new types specified by this argument will be **prepended** to the existing file so that any existing rules will take precedence.

- **`-su|--signInUrl=<url>`**

  If specified, then this URL will be used when authenticating with the production Salesforce organization. This is useful if your organization is configured in a way that authentication is only possible via a 'My Domain' custom domain (e.g. `https://myorganisation.my.salesforce.com`).

  If not specified, the OrgFlow CLI will use `https://login.salesforce.com`.

  > [!TIP]
  > If you have '[My Domain](https://trailhead.salesforce.com/content/learn/modules/identity_login/identity_login_my_domain)' enabled then you **should** supply this value as it allows a workaround for a known Salesforce issue when authenticating with a recently created sandbox.
  > If you have '[My Domain](https://trailhead.salesforce.com/content/learn/modules/identity_login/identity_login_my_domain)' enabled and you have your org configured to prevent log in the standard URL then you **must** supply this value.

- **`-u|--username=<username>`**

  Required. Prompted for when not specified, and possible to do so.

  The username to be used during authentication with the production Salesforce organization. This username will be used during the OAuth sign in process.

- **`--saveCredentials=[Local|StateStore]`**

  If specified, the credentials for Salesforce will be saved so that they can be re-used.

  - `Local`: The credentials are saved on (and can only be re-used by) the current device.
  - `StateStore`: The credentials are saved in the state store, and can be re-sued by anyone with access to the encryption key and current stack.

  If not specified (and possible to do so), the CLI will guide the user through storing credentials for re-use. This will happen *after* the stack initialization process has completed.

- **`--credentialsScope=[All|ProductionEnvironment]`**

  Defaults to `All`.

  - `All`: The credentials are saved at the stack level, and can be applied to every environment on the stack.
  - `ProductionEnvironment`: The credentials are only used to authenticate with the production environment.

- **`-k|--encryptionKey=<key>`**

  An encryption key will be generated for you if `--saveCredentials` is specified and `--encryptionKey` is omitted.

  The encryption key to be used to encrypt saved credentials (if any).

- **`--apiVersion=<number>`**

  The API version to be used when connecting to Salesforce. You only need to make use of this option if you have a need to target a specific API version.

- **`--keepZipFiles`**

  If specified, the zip files that are downloaded from the Salesforce Metadata API are kept on disk as opposed to being deleted after they have been unzipped and processed.

[!include[HostOptions](partials/host-options.md)]

## Examples

To be interactively guided through the Creation process:

```bash
orgflow stack:create
```

***

Create a new stack called *NightlyBackup* with a production environment called *Prod*. Commit all metadata to a repository on GitHub, inside a folder called *metadata*. Use a custom URL to authenticate with Salesforce:

```bash
orgflow stack:create --name=NightlyBackup --productionEnvironmentName=Prod --gitRepoUrl="git@github.com:MyOrg/MyRepo.git" --archivePath=metadata --include=All --signInUrl="https://myorg.my.salesforce.com" --username=user@orgflow.io
```
