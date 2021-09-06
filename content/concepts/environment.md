---
uid: concept_environment
title: Environment
---

Environments form part of your @concept_stack. The simplest way to think of an environment is as a link between a Salesforce organisation and a Git branch.

Some @concept_stackbasedcommands (such as @command_env_flowin, @command_env_flowout, and [env:flowmerge](xref:command_env_flowmerge) ) use the environment records in your stack to know which Salesforce organisations to connect to, and which Git branch in your @concept_remotegitrepository is the @concept_backinggitbranch.

Every stack must contain a single @concept_productionenvironment. This environment is created for you when a stack is initialised with the @command_stack_create command. You can then use the @command_env_create and @command_env_delete commands to add or remove environments to or from your stack.

Environments are specific to a stack. Environment names must be unique (case in-sensitive) within a stack.

> [!TIP]
> The @command_env_list command can be used to list all of the environments in a given stack.
