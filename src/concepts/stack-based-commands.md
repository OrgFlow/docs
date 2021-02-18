---
uid: concept_stackbasedcommands
title: Stack Based Commands
---

OrgFlow commands are split in to two categories: stack-based, and @concept_orgbasedcommands.

Stack based commands are stateful, whereas org-based commands are not. This means that stack-based commands make use of the @concept_statestore to be able to target a particular @concept_stack or @concept_environment. Some stack-based commands also write back to the state store. This means that previous executions of stack-based commands can potentially impact future executions of stack-based commands (i.e. they are stateful).

When you run a stack-based command, you usually need to specify a stack name and environment name to tell OrgFlow which stack or environment to target.

Stack-based commands are the primary use case for OrgFlow. Very few users have a need to venture away from stack-based commands and towards org-based commands.
