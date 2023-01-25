---
uid: command_env_branch_list
title: env:branch:list
---

## Description

List every @concept_backinggitbranch that an @concept_environment has been associated with. Useful to know which branches have been used when @concept_branchswitching.

> [!NOTE]
> This command is only available with an Enterprise edition subscription.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environment=<environmentName>`**

  Required. Prompted for if not supplied and possible to do so.

  The name of the environment to list branches for. Environment names are case-insensitive.

[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

[!include[HostOptions](partials/host-options.md)]

## Examples

List the branches for an environment called `Dev1`:

```bash
orgflow env:branch:list -e=Dev1
```

***

List the branches for an environment called `QA` and output as JSON:

```bash
orgflow env:branch:list -e=QA --json
```
