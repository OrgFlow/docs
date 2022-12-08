---
uid: command_env_flowin
title: env:flowin
---

## Description

@concept_flowin metadata. Retrieve metadata for a particular @concept_environment from your Salesforce organization and commit it to your Git repository.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environment=<environmentName>`**

  Required. Prompted for when not specified, and possible to do so.

  The name of the environment to flow in. Environment names are **not** case-sensitive.

[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

- **`-m|--message`**

  Required. Prompted for when not specified, and possible to do so. If a blank value is specified, then the OrgFlow CLI will construct a default message to use.

  The message to be used when committing changes to the Git repository. The flow in process may create more than one commit, and the same message will be used for all commits.

- **`-c|--checkOnly`**

  If specified, a *validation-only* inbound flow is performed, which means no changes will be pushed to your configured remote Git repository, and no changes will be persisted in the @concept_environmentstate. This is useful to proactively detect potential merge conflicts, collect information about which changes *would* be applied to your environment were it to be flowed in, or to check if any changes have been made to an org that you wouldn't expect changes to be made (such as your production org).

- **`-c|--conflicts=prompt|allAsLocal|allAsRemote|askForEach|gitMergetool|abort`**

  Specifies how unresolved merge conflicts encountered during inbound flow should be handled.

  - `prompt`: Prompt user interactively for each encountered set of unresolved merge conflicts if possible, otherwise abort the inbound flow
  - `allAsLocal`: Resolve all merge conflicts by letting the version in the Git branch win
  - `allAsRemote`: Resolve all merge conflicts by letting the incoming version from the Salesforce org win
  - `askForEach`: Let user choose between local and remote for each conflicted file
  - `gitMergetool`: Run configured `git-mergetool` command for each encountered set of unresolved merge conflicts
  - `abort`: Abort the inbound flow if any unresolved merge conflicts are encountered

  The specified conflict resolution strategy applies only to files which could not automatically resolved by Git. If not specified, the default behavior is equal to `prompt`.

- **`--excludeUndeployable`**

  If specified, the metadata that is currently marked as undeployable in the state store is not included in the process.

- **`--interactiveExclude`**

  If specified, the OrgFlow CLI will launch a browser window to give you an opportunity to hand-pick the metadata items that you would like exclude from the flow in process.

- **`--exclude=<includeSpecs>`**

  If specified, the OrgFlow CLI will exclude metadata types and items that match the @concept_includespecs from this flow in execution.

  Each include spec should be comma separated.

- **`--force`**

  If specified, the metadata that is retrieved from the Salesforce organization is committed to the Git repository as-is. The OrgFlow CLI will make no attempt to merge the changes in the Salesforce organization with the changes in Git (if any).

  The end result is that the metadata in the Git repository will match the metadata in the Salesforce organization, but any change to the metadata that is in Git but not in the Salesforce organization will be lost.

  This has the side effect of removing all @concept_undeployablecomponents from the state store for this specific environment.

- **`--keepZipFiles=<directoryPath>`**

  If specified, the OrgFlow CLI will retain the zip files containing the metadata items that are retrieved from Salesforce. The zip files will be placed into the directory specified. This can be useful in scenarios where you need to troubleshoot problems.

[!include[WaitForLockOption](partials/wait-for-lock-option.md)]

[!include[HostOptions](partials/host-options.md)]

## Examples

Interactively flow an environment in:

```bash
orgflow env:flowin
```

***

Flow an environment called `UAT` in, with a custom commit message:

```bash
orgflow env:flowin --environment=uat --message="Adds new Account layout"
```
