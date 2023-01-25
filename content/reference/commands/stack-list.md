---
uid: command_stack_list
title: stack:list
---

## Description

Lists every available @concept_stack in the state store. Can also be used to determine which stack is currently set to the default.

## Options

[!include[HostOptions](partials/host-options.md)]

## Examples

List all available stacks:

```bash
orgflow stack:list
```

***

List all available stacks and format the output as a JSON object so that it can be consumed by another process or script:

```bash
orgflow stack:list --json
```
