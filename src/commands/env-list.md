---
uid: command_env_list
title: env:list
stackBased: true
---

## Description

List every @concept_environment in the selected @concept_stack.

> [!TIP]
> The `--output` option allows you to control the output of this (and every other) command.
>
> - `--output=pretty` is the default and will give you a human readable summary of each environment.
> - `--output=flat` will give you a terser summary of each environment.
> - `--output=json` is the most verbose and, because the output is JSON format, it can be consumed by another process or script (for example to loop over every environment).

## Options

[!include[StackOption](partials/stack-option.md)]
  
[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

[!include[HostOptions](partials/host-options.md)]

## Examples

List every environment in the @concept_defaultstack:

```bash
orgflow env:list
```

***

List every environment in a stack called `backup`, and format the output as JSON:

```bash
orgflow env:list --stack=backup --output=json
```
