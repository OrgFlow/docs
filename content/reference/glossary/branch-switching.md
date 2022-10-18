---
uid: concept_branchswitching
title: Branch Switching
---

An [Environment's](xref:concept_environment) @concept_backinggitbranch can be switched out to allow for sandboxes to be shared between two or more Git branches. 

An example use case may be a development team where each developer has their own personal sandbox, but may be working on multiple projects at the same time. The developer could create unique Git branches for each piece of work, and can use branch switching to switch between them and have their personal sandbox updated with the metadata in the branch that they switch to.

> [!NOTE]
> Branch switching is only available with an Enterprise edition subscription.

## The process

The default process is: @concept_flowin changes from the environment's Salesforce org, change the branch on the environment's record in the @concept_statestore, and then @conceptflowout from the new branch to the environment's Salesforce org. 

If the branch you are switching to does not yet exist, OrgFlow will create it from the head of the environment's current Git branch.

OrgFlow uses [Snapshots](xref:concept_snapshot) to restore environment state during the ...xxx

## Impacts

## Managing environment branches

There are commands that allow you to manage environment branches. They all begin with the prefix `env:branch:`:

- @command_env_branch_switch - Switch out the @concept_backinggitbranch for an environment.
- @command_env_branch_list - Lists all the unique branches that have been used for a given environment.
