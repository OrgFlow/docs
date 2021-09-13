---
uid: command_env_delete
title: env:delete
---

## Description

Remove any non-production @concept_environment and the associated @concept_environmentstate from the selected @concept_stack. Optionally delete the associated Git branch from the remote Git repository or delete the associated sandbox from Salesforce.

>[!WARNING]
>This operation is destructive and non-reversible.

>[!TIP]
>It is not possible to delete your @concept_productionenvironment.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environment=<environmentName>`**

  Required. Prompted for if not supplied and able to do so.

  The name of the environment to delete. Environment names are case-insensitive.

- **`-b|--deleteBranch`**

  If specified, the Git branch that backs this environment is deleted from the remote Git repository.

- **`-sb|--deleteSandbox`**

  If specified, the sandbox associated with this environment is deleted from Salesforce.

[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

[!include[HostOptions](partials/host-options.md)]

## Examples

Delete an environment called `test` from the stack:

```bash
orgflow env:delete --environment=test
```

***

Delete an environment called `temporaryEnv` from the stack, and delete the associated sandbox from Salesforce and the Git branch that backs it from the remote Git repository:

```bash
orgflow env:delete --environment=test --deleteBranch --deleteSandbox
```
