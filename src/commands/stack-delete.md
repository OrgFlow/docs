---
uid: command_stack_delete
title: stack:delete
stackBased: true
---

## Description

Deletes a @concept_stack.

The stack record (as well as every corresponding @concept_environment and @concept_environmentstate record) will be removed from the state store. 

This process does not delete the Git branches, nor the Salesforce organisations that are linked to each environment. If you would like to do this, you should use the @command_env_teardown command for every environment in the stack *before* using this command.

>[!WARNING]
>This process is non-reversible.

## Options

- **`-n|--name=<stackName>`**
  
  Required. Prompted for when not specified, and possible to do so.

  The name of the stack you wish to delete. Stack names are case-insensitive.

[!include[HostOptions](partials/host-options.md)]

## Examples

Delete a stack called 'MyStack':

```bash
orgflow stack:delete -n=MyStack
```
