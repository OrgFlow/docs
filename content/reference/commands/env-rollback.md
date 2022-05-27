---
uid: command_env_rollback
title: env:rollback
---

## Description

@concept_rollback an @concept_environment to a specific @concept_snapshot.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environment=<environmentName>`**

  Required. Prompted for if not supplied and possible to do so.

  The name of the environment to rollback. Environment names are case-insensitive.

- **`-t|-s|--toSnapshot=<number>`**

  Required. Prompted for if not supplied and possible to do so.

  The number of the target snapshot to rollback to.

- **`--noGitRollback`**

  Do not rollback the @concept_remotegitrepository.

- **`--noSalesforceRollback`**

  Do not rollback the metadata in the Salesforce org.

  >[!NOTE]
  >It's possible to use both `--noGitRollback` and `--noSalesforceRollback` at the same time. In this case, the data in the @concept_statestore will be rolled back for the environment, but neither the @concept_backinggitbranch nor the Salesforce org will be rolled back.

[!include[WaitForLockOption](partials/wait-for-lock-option.md)]

[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

[!include[HostOptions](partials/host-options.md)]

## Examples

Rollback an environment called `QA` to snapshot number `6`:

```bash
orgflow env:rollback -e=qa -t=6
```

***

Rollback the state store and the Git branch (but not the Salesforce org) for an environment called `Production` to snapshot number `10`:

```bash
orgflow env:rollback -e=Production -t=10 --noSalesforceRollback
```

***

Rollback the state store and the Salesforce org (but not the Git branch) for an environment called `Production` to snapshot number `10`:

```bash
orgflow env:rollback -e=Production -t=10 --noGitRollback
```

***
