---
uid: command_env_branch_switch
title: env:branch:switch
---

## Description

Change the @concept_backinggitbranch that an @concept_environment is associated with (known as @concept_branchswitching). Useful for cases where you need to share a sandbox between two or more long-running work items that each have their own Git branch.

The default process is: @concept_flowin changes from the environment's Salesforce org, change the branch on the environment's record in the @concept_statestore, and then @concept_flowout from the new branch to the environment's Salesforce org.

> [!NOTE]
> This command is only available with an Enterprise edition subscription.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environment=<environmentName>`**

  Required. Prompted for if not supplied and possible to do so.

  The name of the environment to switch branch for. Environment names are case-insensitive.

- **`-b|--branchName=<branchName>`**

  Required. Prompted for if not supplied and possible to do so.

  The name of the branch to switch to. Branch names can be case-sensitive depending on your file system and the configuration of your @concept_remotegitrepository provider.

  If you provide a branch name that does not exist, OrgFlow will cut a new branch from the HEAD of the environment's current branch.

- **`--noFlowIn`**

  If specified, the inbound flow of metadata from the Salesforce org to the initial Git branch (before the environment's Git branch is changed) is not performed.

- **`--keepZipFiles=<directoryPath>`**

  If specified, the OrgFlow CLI will retain the zip files containing the metadata items that are retrieved from Salesforce during the inbound flow. The zip files will be placed into the directory specified. This can be useful in scenarios where you need to troubleshoot problems.

  Not valid in conjunction with `--noFlowIn`.

- **`--noFlowOut`**

  If specified, the outbound flow of metadata from the new Git branch to the Salesforce org (after the environment's Git branch is changed) is not performed.

- **`--keepDelta=<directoryPath>`**

  If specified, the OrgFlow CLI will retain the delta deployment archives that are uploaded to Salesforce as part of the deployment process during the outbound flow. The delta archives will be placed into the directory specified. This can be useful in scenarios where you need to troubleshoot deployment problems.

  Not valid in conjunction with `--noFlowOut`.

[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

[!include[WaitForLockOption](partials/wait-for-lock-option.md)]

[!include[HostOptions](partials/host-options.md)]

## Examples

Switch the branch for an environment called `Dev1` to a branch called `feature/profiles`:

```bash
orgflow env:branch:switch -e=Dev1 -b=feature/profiles
```

***

Switch the branch for an environment called `QA` to a branch called `hotfix`, and skip the inbound flow before the branch is switched:

```bash
orgflow env:branch:switch -e=QA -b=hotfix --noFlowIn
```
