---
uid: command_env_unlock
title: env:unlock
stackBased: true
starterEdition: true
proEdition: true
enterpriseEdition: true
---

## Description

Unlocks an @concept_environment.

Environments are locked by OrgFlow while processes run on them. This prevents concurrent (potentially conflicting) processes from being performed on the same environment. The environment should be automatically unlocked by OrgFlow when the process that acquires the lock is completed, but occasionally this may fail to happen (for example if there is an abrupt and unexpected termination of the OrgFlow process). This command can be used to unlock environments that have fallen victim to this deadlocking.

> [!TIP]
> The @command_env_list command can show you a list of all your environments, as well as which ones are currently locked.

## Options

[!include[StackOption](partials/stack-option.md)]
  
- **`-e|--environment=<environmentName>`**

Required. Prompted for if not supplied and able to do so.
  
The name of the environment to unlock. Environment names are case-insensitive.

[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

[!include[HostOptions](partials/host-options.md)]

## Examples

Unlock an environment called `QA`:

```bash
orgflow env:unlock --environment=qa
```
