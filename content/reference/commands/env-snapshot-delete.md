---
uid: command_env_snapshot_delete
title: env:snapshot:delete
---

## Description

Delete a @concept_snapshot or a range of snapshots from a given environment. Useful if you know that some snapshots were taken at a point that was bad and you want to prevent a @concept_rollback to those snapshots.

If you've used @concept_branchswitching on an environment, only snapshots that are linked to the environment's current @concept_backinggitbranch are deleted.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environment=<environmentName>`**

  Required. Prompted for if not supplied and possible to do so.

  The name of the environment whose snapshots are to be deleted. Environment names are case-insensitive.

- **`-s|--snapshots=<start[-end]>`**

  Required. Prompted for if not supplied and possible to do so.

  The number or numbers of the snapshot(s) to delete. Specify either a single number or a range of numbers with the syntax `start-end`, e.g. `6-10`. Specify multiple numbers or ranges by separating them with either a comma (`,`) or a semi-colon (`;`), e.g. `3-6,8,10-15`.

[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

[!include[HostOptions](partials/host-options.md)]

## Examples

Delete snapshot number `3` from an environment called `Production`:

```bash
orgflow env:snapshot:delete -e=Production -s=3
```

***

Delete snapshot numbers `3` and `5` from an environment called `QA`:

```bash
orgflow env:snapshot:delete -e=QA -s=3,5
```

***

Delete snapshot numbers `5` through to `10`, as well as numbers `12` and `14` from an environment called `Dev`:

```bash
orgflow env:snapshot:delete -e=Dev -s=5-10,12,14
```
