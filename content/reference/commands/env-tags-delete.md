---
uid: command_env_tags_delete
title: env:tags:delete
---

## Description

Delete tags from one or more environments.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environments=<environmentName>[,<environmentName>,...]`**

  Required. Prompted for if not supplied and possible to do so.

  The names of one or more environments to delete tags from. Environment names are case-insensitive.

- **`-t|--tags=name[,name,...]`**

  Required. Prompted for if not supplied and possible to do so.

  The names of one or more tags to delete on the given environments. Tag names may only contain alphanumeric characters, hyphens and underscores.

[!include[HostOptions](partials/host-options.md)]

## Remarks

Existing tags with the same names will be overwritten (tag names are matchd case-insensitively).

If any tags will be deleted as a result of the command, the exact changes will be printed to STDERR and user confirmation will be obtained, unless the `--noConfirm` argument is used or prompting is not possible because standard IO streams have been redirected.

## Examples

Delete a tag named `IsTemporary` on the environments named `Alpha` and `Beta`:

```bash
orgflow env:tags:delete --environments=Alpha,Beta --tags=IsTemporary
```

***

Delete several different tags on the environment named `QA`:

```bash
orgflow env:tags:delete --environments=QA --tags=Owner,Category,IsFullSandbox
```
