---
uid: concept_branchswitching
title: Branch Switching
---

An [Environment's](xref:concept_environment) @concept_backinggitbranch can be switched out to allow for sandboxes to be shared between two or more Git branches. 

An example use case may be a development team where each developer has their own personal sandbox, but may be working on multiple projects at the same time. The developer could create unique Git branches for each piece of work, and can use branch switching to switch between them and have their personal sandbox updated with the metadata in the branch that they switch to.

> [!NOTE]
> Branch switching is only available with an Enterprise edition subscription.

## The process

The default process is: @concept_flowin changes from the environment's Salesforce org, change the branch on the environment's record in the @concept_statestore, and then @concept_flowout from the new branch to the environment's Salesforce org. 

If the branch you are switching to does not yet exist, OrgFlow will create it from the head of the environment's current Git branch. Otherwise, the branch will be left as is on the remote repository.

When switching branches, OrgFlow will check for the most recent @concept_snapshot that is associated to the branch you are switching to. If no snapshot is found, OrgFlow will do a @concept_flowout from the head of the branch you are switching to. 

If a snapshot is found, OrgFlow will apply the snapshot to the environment (similar to a [Rollback](xref:concept_rollback)). This allows for the environment's @concept_environmentstate to be restored to the way it was when the environment's branch was switched away from this branch.

## Impacts

Switching an environment's branch can impact the behaviour of other commands:

@command_env_rollback will warn and prompt for confirmation before rolling back to a snapshot that is associated with a Git branch that differs from the environment's current Git branch. The environment's Git branch will be switched back to the Git branch associated with the target snapshot. After the rollback has been completed, OrgFlow will delete only the snapshots that are associated to the same Git branch as the target snapshot (and are more recent than the target snapshot).

@command_env_snapshot_list will only list snapshots associated to the environment's current Git branch. Use the `--showAllBranches` switch to override this.

@command_env_snapshot_delete will only delete snapshots that are associated to the environment's current Git branch.

<!--
## Managing environment branches

There are commands that allow you to manage environment branches. They all begin with the prefix `env:branch:`:

- @command_env_branch_switch - Switch out the @concept_backinggitbranch for an environment.
- @command_env_branch_list - Lists all the unique branches that have been used for a given environment.
-->
