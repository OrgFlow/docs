---
uid: concept_rollback
title: Rollback
---

Rollback (or rolling back) is the process of reverting changes in either Salesforce, your @concept_remotegitrepository, or both. Rollbacks are useful if you need to revert a bad deployment or change. You can rollback to any @concept_snapshot for a given environment that has not been deleted.

## Performing a rollback

Rollbacks are performed with the @command_env_rollback command. You will need to know the target snapshot's number in order to rollback; you can use the @command_env_snapshot_list command to list all the available snapshots for a given environment.

By default, a rollback will:

- Revert the @concept_environmentstate to match the state as recorded in the snapshot.
- Revert the environment's @concept_backinggitbranch to how it looked at the time that the snapshot was taken.
- Revert any changes in your Salesforce org since the snapshot was taken by performing a @concept_flowout with the metadata in your Git branch as it looked at the time that the snapshot was taken.
- Delete any snapshots that have been rolled back. For example, if the most recent snapshot number for an environment is `10`, and you rollback to snapshot number `4`, then snapshots `5` to `10` (inclusive) will be deleted.
