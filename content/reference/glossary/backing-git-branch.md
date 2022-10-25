---
uid: concept_backinggitbranch
title: Backing Git Branch
---

A @concept_stack is linked to a @concept_remotegitrepository. A backing [Git branch](https://git-scm.com/book/en/v2/Git-Branching-Branches-in-a-Nutshell) is simply a branch in this repository this is used to track the metadata of a particular @concept_environment. The environment record serves as a link between the backing Git branch and the Salesforce organisation which it backs.

The metadata in a Salesforce organisation can be committed to the backing Git branch with the @command_env_flowin command (@concept_flowin ). And the metadata in the backing Git branch can be deployed to a Salesforce organisation with the @command_env_flowout command (@concept_flowout ).

> [!TIP]
> The @command_env_flowin command is no the only way that you can change the metadata in a backing Git branch.
>
> You can change any of the metadata files either directly in this branch by cloning it, making the required changes, and then pushing the changes back up to the remote Git Repository. You can also merge changes from other branches (either with the Git merge command or via a Pull Request).
>
> OrgFlow is able to track changes made in both your Salesforce organisation and your backing Git branch independently, and it is able to merge those changes using the @command_env_flowin command.

## Creating a backing Git branch

By default, the backing Git branch is created by the @command_env_create command. The branch will be created from the `HEAD` of the branch that backs the source environment used by that command (by default this will be the @concept_productionenvironment, but this can be changed by the options available on that command).

You can avoid this default functionality by manually creating the backing Git branch in the remote Git repository *before* running the @command_env_create command. See the [env:create command documentation](xref:command_env_create) for details on how to do this.

## Switching a backing Git branch

OrgFlow allows you to change an environment's backing Git branch. See @concept_branchswitching or @command_env_branch_switch for more details.
