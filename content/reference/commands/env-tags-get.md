---
uid: command_env_tags_get
title: env:tags:get
---

## Description

Get tags from one or more environments.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environments=<environmentName>[,<environmentName>,...]`**

  Required. Prompted for if not supplied and possible to do so.

  The names of one or more environments to get tags from. Environment names are case-insensitive.

- **`-t|--tags=name`**

  The names of one or more tags to get from the given environments, or omit to get all tags. Tag names are case-insensitive.

- **`--valueOnly`**

  Changes the output so that only the value of a single tag from a single environment is outputted. Only valid when a single value is specified for both `--environments` and `--tags`.

  This is particularly useful for scripted workflows where you want to get and assign the value of a tag to a variable, for example.

[!include[HostOptions](partials/host-options.md)]

## Examples

Get the tags `Owner` and `IsPreviewSandbox` from the environments named `Alpha`, `Beta`, and `Gamma`:

```bash
orgflow env:tags:get --environments=Alpha,Beta,Gamma --tags=Owner,IsPreviewSandbox
```

***

Get just the value of a tag called `Owner` from the environment named `QA`:

```bash
orgflow env:tags:set --environments=QA --tags=Owner --valueOnly
```
