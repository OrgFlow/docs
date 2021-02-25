---
uid: command_stack_init
title: stack:init
stackBased: true
starterEdition: true
proEdition: true
enterpriseEdition: true
---

## Description

Initializes a new @concept_stack. This will probably be the very first command you run with OrgFlow. You only need to run this command once per stack (unless you choose to re-initialize an existing stack).

Can also be used to re-initialize an existing stack with the `--overwrite` option.

## Process

The `stack:init` command will create a stack that contains the minimum amount of data required for stack based commands to function:

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

  The name of the stack to be initialized.

- **`-e|--productionEnvironmentName=<environmentName>`**
  
  Required. Prompted for when not specified, and possible to do so. Defaults to `Production` if not specified.

  The name of the production environment to be added to the stack.

- **`-r|--gitRepoUrl=<gitUrl>`**
  
  Required. Prompted for when not specified, and possible to do so.

  The location of the remote Git repository to contain your metadata. See [the git clone docs](https://git-scm.com/docs/git-clone#_git_urls) for examples of valid values. OrgFlow supports all formats with the exception of relative local locations (e.g. `./path/to/repo.git/`).

- **`-b|--gitBranch=<branchName>`**
  
  Required. Prompted for when not specified, and possible to do so. Defaults to `Master` if not specified.

  The name of the branch to back the production environment. Metadata that is retrieved from the production organisation is committed to this branch, and metadata changes made in this branch can be deployed to the production Salesforce organisation. The branch will be created from the head of the default branch (only if the branch does not already exist on the remote).

- **`-a|--archivePath=<relativePath>`**
  
  Required. Prompted for when not specified, and possible to do so. Defaults to `/` if not specified.

  The path relative to the root of the repository that Salesforce metadata will be committed to. For example, specify `--archivePath=/` to put the metadata at the root fo the repo, or `--archivePath=src/` to put the metadata into a folder called `src`.

- **`-i|--include=[All|AllSafe|CustomObjectsOnly|ProductionImmutable|Nothing|UseExisting]`**
  
  Required. Prompted for when not specified, and possible to do so. Defaults to `AllSafe` if not specified.

  The metadata types and items that should be included when flowing metadata between Salesforce and your Git repository. See @concept_includespecs for more information.
  - `All`: Everything is included. This should be used with caution, because some metadata types (such as Profiles) are hard to deploy reliably.
  - `AllSafe`: Almost everything is included. The types that we know to be difficult to reliable deploy are excluded.
  - `CustomObjectsOnly`: Custom objects (and their nested types, such as fields, layouts etc.) are included.
  - `ProductionImmutable`: Only metadata that cannot be changed directly in the production Salesforce organization is included. For example: Apex classes and triggers.
  - `Nothing`: Nothing is included. This is useful because it allows you to initialize a stack without pulling any metadata in to the Git repository. Once the stack is initialized, you can manually update the `.orgflowinclude` file to include the metadata types and items that you choose before running @command_flow_in on the production environment to pull the metadata into your Git repository.
  - `UseExisting`: Use a @concept_orgflowincludefile that already exist in the remote Git repository. This option is only valid if the remote Git repository already contains a valid `.orgflowinclude` file. If the branch specified by `--gitBranch` already exists then this file must exist in that branch; if the branch doesn't already exist, then the file must present in the head of the default branch.

- **`-su|--signInUrl=<url>`**
  
  If specified, then this URL will be used when authenticating with the production Salesforce organization. This is useful if your organization is configured in a way that authentication is only possible via a 'My Domain' custom domain (e.g. `https://myorganisation.my.salesforce.com`).

  If not specified, the OrgFlow CLI will use `https://login.salesforce.com`.
  
- **`-u|--username=<username>`**
  
  Required. Prompted for when not specified, and possible to do so.

  The username to be used during authentication with the production Salesforce organization. This username will be used during the OAuth sign in process.
  
  This value is not saved for future re-use. If you'd like to do this, you can use the @command_stack_setcredentials command once your stack has been initialized.
  
- **`--apiVersion=<number>`**
  
  The API version to be used when connecting to Salesforce. You only need to make use of this option if you have a need to target a specific API version.

- **`--keepZipFiles`**
  
  If specified, the zip files that are downloaded from the Salesforce Metadata API are kept on disk as opposed to being deleted after they have been unzipped and processed.

- **`--overwrite`**
  
  If specified, indicates that an existing stack that shares the same name as the stack you are initializing can be overwritten. Stack names are case-insensitive.

  It is not possible to initialize a stack with the same name as a stack that already exists unless you specify this option.

  > [!WARNING]
  > This is a potentially destructive option. It indicates that an existing stack can be re-initialized, which involves overwriting all the stack, environment, and environment state records. This cannot be reverted.

[!include[HostOptions](partials/host-options.md)]

## Examples

To be interactively guided through the initialization process:

```bash
orgflow stack:init
```

***

Initialize a new stack called *NightlyBackup* with a production environment called *Prod*. Commit all metadata to a repository on GitHub, inside a folder called *metadata*. Use a custom URL to authenticate with Salesforce:

```bash
orgflow stack:init --name=NightlyBackup --productionEnvironmentName=Prod --gitRepoUrl="git@github.com:MyOrg/MyRepo.git" --archivePath=metadata --include=All --signInUrl="https://myorg.my.salesforce.com" --username=user@orgflow.io
```
