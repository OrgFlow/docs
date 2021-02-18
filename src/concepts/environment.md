---
uid: concept_environment
title: Environment
---

Environments form part of your @concept_stack. The simplest way to think of an environment is as a link between a Salesforce organisation and a Git branch.

Some @concept_stackbasedcommands (such as @command_flow_in, @command_flow_out, and [flow:merge](xref:command_flow_merge) ) use the environment records in your stack to know which Salesforce organisations to connect to, and which Git branch in your @concept_remotegitrepository is the @concept_backinggitbranch.

Every stack must contain a single @concept_productionenvironment. This environment is created for you when a stack is initialised with the @command_stack_init command. You can then use the @command_env_setup and @command_env_teardown commands to add or remove environments to or from your stack.

Environments are specific to a stack. Environment names must be unique (case in-sensitive) within a stack. If you have multiple stacks, you can call multiple environments by the same name provided each environment with the same name is in a different stack.

> [!TIP]
> The @command_env_list command can be used to list all of the environments in a given stack.
