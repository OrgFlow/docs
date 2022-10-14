---
uid: command_env_snapshot_list
title: env:snapshot:list
---

## Description

List every @concept_snapshot for a given @concept_environment and @concept_backinggitbranch. By default, only snapshots that are associated with the environment's current Git branch are displayed, but this can be overridden with the `--showAllBranches` switch. Listed snapshots are ordered by their number, descending (i.e. most recent first).

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environment=<environmentName>`**

  Required. Prompted for if not supplied and possible to do so.

  The name of the environment to list snapshots for. Environment names are case-insensitive.

- **`--showAllBranches`**

  Show all snapshots regardless of the Git branch that they are associated with.

[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

[!include[HostOptions](partials/host-options.md)]

## Examples

List every snapshot for an environment called `Production` in the @concept_defaultstack:

```bash
orgflow env:snapshot:list -e=Production
```

***

List every snapshot in an environment called `QA`, and format the output as JSON:

```bash
orgflow env:snapshot:list -e=QA --output=json
```
