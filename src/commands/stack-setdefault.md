---
uid: command_stack_setdefault
title: stack:setdefault
stackBased: true
---

## Description

Set a @concept_defaultstack so that you do not need to specify `--stack` options on commands that require them. The stack chosen as the default is specific to the machine that you run this command on.

You can view a list of all the available stacks with the @command_stack_list command. This command will also indicate the current default stack (if any).

## Options

- **`-n|--name=<stackName>`**
  
  Required. Prompted for when not specified, and possible to do so.

  The name of the stack to be set as the default. Stack names are case-insensitive.

[!include[HostOptions](partials/host-options.md)]

## Examples

Set the default stack to one called *NightlyBackup*:

```bash
orgflow stack:setdefault --name=NightlyBackup
```
