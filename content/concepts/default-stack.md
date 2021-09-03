---
uid: concept_defaultstack
title: Default Stack
---

All stack-based commands need to target a particular @concept_stack. When you run a stack-based command, the `--stack` option allows you to pass the name of the stack that you'd like to target into the command. However, if you're repeatedly running multiple commands against the same stack, then this can become cumbersome and repetitive.

The OrgFlow CLI allows you to set a default stack, and that default stack will be used whenever the `--stack` option is omitted from stack-based commands. To do this, you need to use the @command_stack_setdefault command.

The @command_stack_setdefault command sets the default stack only on the machine that executes the command. This means that:

- If you are working in a team, each member of your team will need to run the command on their own computers.
- Different machines can have different default stacks, which is particularly useful if you have different members of the team working on different stacks at the same time.
- If you are running OrgFlow on ephemeral build agents that can get torn down or re-created between build jobs, then the default stack will be unset every time the machine is torn down. In this scenario, it is best to either:
  - Re-run the @command_stack_setdefault command as the first step of every build job, or
  - Explicitly specify the `--stack` option for every stack-based command that you run in your pipeline.
