---
uid: command_env_setup
title: env:setup
stackBased: true
starterEdition: true
proEdition: true
enterpriseEdition: true
---

## Description

Adds a new @concept_environment to the selected @concept_stack.

By default, the Git branch and the Salesforce sandbox will be created by this command, however this can be avoided with the `--useExistingBranch` and `--useExistingSandbox` options.

## Process

An environment consists of several items:

- a Salesforce sandbox
- a branch on the remote Git repository
- an environment record in the @concept_statestore
- an @concept_environmentstate record in the state store
- a known point of parity between the sandbox and the Git branch

This command will make sure that all of these items are available, and in a state ready to be used by OrgFlow. The following steps are required to do this:

1. Provision a new sandbox (or optionally use an existing sandbox) in the target Salesforce organization. By default, a sandbox that is created will be cloned from the production Salesforce organization, but you can change this with the `--createFrom` option.
1. Create a new Git branch (or optionally use an existing branch) in the remote Git repository. By default, a Git branch that is created will be branched from the head of the branch that backs your @concept_productionenvironment, but you can change this with the `--createFrom` option.
1. Create a record for the environment in the state store. The record contains (among other things) the name of the environment, the name of the sandbox, and the name of the Git branch.
1. Perform a @concept_flowout on the environment. This creates a known point of parity between the sandbox and the Git branch, as well as the environment state record.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environment=<environmentName>`**
  
  Required. Prompted for if not supplied and possible to do so.

  The name of the environment to set up. Environment names are case-insensitive and must be unique within the stack they are contained in.
  
[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

- **`-b|--branchName=<branchName>`**
  
  Required. Prompted for if not supplied and possible to do so.

  The name of the Git branch that will be assigned to this environment. The value provided must be a valid value for a Git branch name, and it must also be a value that does not already exist in the remote Git repository (unless `--useExistingBranch` is specified).

  >[!TIP]
  >Unless `createFrom` is specified, the branch will be created from the HEAD of the branch that backs the @concept_productionenvironment. If you would prefer to create this branch from elsewhere in the commit history, you can do so by first manually creating the branch in the remote Git repository, and then running `env:setup` with the `--useExistingBranch` option.

- **`-sb|--sandboxName=<sandboxName>`**
  
  Required. Prompted for if not supplied and possible to do so.

  The name of the sandbox that will be associated to the environment to be created. An existing sandbox can be used if `--useExistingSandbox` is specified, otherwise the sandbox is created as a copy of the production Salesforce organization (unless `--createFrom` is specified).

- **`-d|--description=<text>`**
  
  If specified, the description of the sandbox that is created will be set to this value.
  
  Only effective if a sandbox is created during this process.

- **`-t|--licenseType=[developer|developerPro|partial|full]`**
  
  Default: `developer`

  The type of sandbox to create. The sandbox types available to you will depend on your Salesforce license and are subject to the limits that Salesforce enforce (for example maximum count of each type, or minimum refresh times).

  Only effective if a sandbox is created during this process.

- **`--createFrom=<environmentName>`**
  
  If specified, the environment that is created will be created as a copy of the environment specified. If not specified, the environment that is created will be created as a copy of the production environment. Environment names are case-insensitive.
  
  This affects:
  - The point in the Git history which the `--branchName` branch is created from (unless `useExistingBranch` is specified).
  - The source Salesforce organization that the `--sandboxName` sandbox is copied from (unless `useExistingSandbox` is specified).

  If a sandbox is cloned from another sandbox, Salesforce requires that the licenses of the two sandboxes are equal. For example, a `developerPro` sandbox can only be copied into another `developerPro` sandbox. This means that if you specify an environment other than the production environment (and do not specify `--useExistingSandbox`), then you will need to also make sure that the `--licenseType` is specified and that the value matches the license of the source sandbox.
  
  Only effective if a sandbox is created during this process.

- **`--apexClass=<className>`**
  
  If specified, Salesforce will execute the `runApexClass` method on the Apex class named, after the sandbox has created. The specified class must implement `SandboxPostCopy`.
  
  Only effective if a sandbox is created during this process.

- **`--template=<templateName>`**
  
  Required if `--licenseType=partial` (and `--useExistingSandbox` is not specified); optional if `--licenseType=full`; otherwise not valid.

  If specified, the [sandbox template](https://help.salesforce.com/articleView?id=sf.data_sandbox_templates.htm&type=5) that Salesforce should use when populating the data in the sandbox.
  
  Only effective if a sandbox is created during this process.

- **`--history=[allAvailable|none|10|20|30|60|90|120|150|180]`**
  
  Optional (and only valid) if `--licenseType=full`. Default: `none`.

  If specified, the data copied to the full sandbox that will be created will be:
  - `allAvailable`: all data from the source Salesforce organization will be copied.
  - `none`: no data from the source Salesforce organization will be copied.
  - `10`: only data created in the past 10 days will be copied.
  - `20`: only data created in the past 10 days will be copied.
  - `30`: only data created in the past 10 days will be copied.
  - `60`: only data created in the past 10 days will be copied.
  - `90`: only data created in the past 10 days will be copied.
  - `120`: only data created in the past 10 days will be copied.
  - `150`: only data created in the past 10 days will be copied.
  - `180`: only data created in the past 10 days will be copied.

  Only effective if a sandbox is created during this process.

- **`--copyChatter`**
  
  Only valid if `--licenseType=full`.

  If specified, indicates that chatter data should be copied to the sandbox that is created.
  
  Only effective if a sandbox is created during this process.

- **`--useExistingBranch`**
  
  If specified, indicates that the process is allowed to use a branch that already exists in the remote Git repository. If omitted, and the branch specified by `--branchName` already exists in the remote Git repository, then the environment setup process will not be allowed to continue.

  This is a safety mechanism to prevent accidental data loss on a pre-existing Git branch.

- **`--useExistingSandbox`**
  
  If specified, indicates that the process is allowed to use a sandbox that already exists in Salesforce. If omitted, and the sandbox specified by `--sandbox` already exists, then the environment setup process will not be allowed to continue.

  This is a safety mechanism to prevent accidental data loss in a pre-existing sandbox.

- **`--description=<text>`**
  
  If specified and a sandbox is created during the environment set up process, the description of the sandbox that is created will be set to this value.
  
  Only effective if a sandbox is created during this process.

- **`-su|--signInUrl=<url>`**
  
  If specified, then this URL will be used when authenticating with the sandbox specified by `--sandboxName`.
  
  This is only required if the URL required to authenticate with the sandbox cannot be inferred from the URL stored on the stack (see @concept_credentialinference for more information). Any value specified will be saved in the stack store so that it can be re-used in further operations that involve this environment.
  
- **`-u|--username=<username>`**
  TODO: update once #2135 has been rectified

- **`-p|--password=<password>`**
  TODO: update once #2135 has been rectified

- **`--keepDelta=<directoryPath>`**
  
  If specified, the OrgFlow CLI will retain the delta deployment archives that are uploaded to Salesforce as part of the deployment process. The delta archives will be placed into the directory specified. This can be useful in scenarios where you need to troubleshoot deployment problems.

[!include[HostOptions](partials/host-options.md)]

## Examples

Interactively set up a new environment:

```bash
orgflow env:setup
```

***

Set up a new environment called `developerA` with a sandbox called `devA` and a Git branch called `sandbox/deva`:

```bash
orgflow env:setup --environment=developerA --sandboxName=devA --branchname="sandbox/deva"
```
