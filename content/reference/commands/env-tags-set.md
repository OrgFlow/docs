---
uid: command_env_tags_set
title: env:tags:set
---

## Description

Set tags on one or more environments.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environments=<environmentName>[,<environmentName>,...]`**

  Required. Prompted for if not supplied and possible to do so.

  The names of one or more environments to set tags on. Environment names are case-insensitive.

- **`-t|--tags=name[:value][,name[:value],...]`**

  Required. Prompted for if not supplied and possible to do so.

  One or more tags to set on the given environments. Omitting a value sets a tag with no value. Tag names may only contain alphanumeric characters, hyphens and underscores. Tag values may contain anything except newline characters. Spaces in tag values can be set using shell-specific quoting. Commas in tag values can be set by escaping them with backslash as `\,` e.g. `--tags=FullName:Payne\,Chris`.

[!include[HostOptions](partials/host-options.md)]

## Remarks

Existing tags with the same names will be overwritten (tag names are matchd case-insensitively).

If any existing tags will be overwritten with values other than their existing values, the exact changes will be printed to STDERR and user confirmation will be obtained, unless the `--noConfirm` argument is used or prompting is not possible because standard IO streams have been redirected.

## Examples

Set a value-less tag named `IsTemporary` on the environments named `Alpha` and `Beta`:

```bash
orgflow env:tags:set --environments=Alpha,Beta --tags=IsTemporary
```

***

Set several different tags on the environment named `QA`:

```bash
orgflow env:tags:set --environments=QA --tags=Owner:Tobias,Category:Testing,IsFullSandbox
```

***

Use spaces in a tag value:

```bash
orgflow env:tags:set --environments=Dev1 --tags="OwnerFullName:Dimitrius Woodward,Category:Development"
```
