---
uid: concept_snapshot
title: Snapshot
---

A snapshot is an immutable copy of an [Environment's](xref:concept_environment) state. Snapshots are stored in our @concept_statestore. Every snapshot is associated to a single environment, and are assigned a number that will be unique within that given environment.

Snapshots don't contain any of your metadata, but they do contain:

- A copy of the @concept_environmentstate at the time that the snapshot was taken.
- The head commit hash of your environment's branch at the time that the snapshot was taken.
- The environment's parity hash at the time that the snapshot was taken.

A snapshot can be used as a target for a @concept_rollback, and they help with @concept_branchswitching.

## Taking snapshots

Snapshots are automatically taken after a @concept_flowin or a @concept_flowout. This includes commands that flow in or flow out as part of their process. The full list of commands that will take snapshots are:

- @command_env_create
- @command_env_flowin
- @command_env_flowout (except if `--checkOnly`)
- @command_env_flowmerge (except if `--gitOnly`)
  - after source environment flow in (except if `--noSourceIn`)
  - after target environment flow in (except if `--noTargetIn`)
  - after target environment flow out (except if `--noTargetOut`)
- @command_stack_create

It is not possible to take a snapshot without an accompanying flow in or flow out.

## Managing snapshots

There are commands that allow you to manage snapshots. They all begin with the prefix `env:snapshot:`:

- @command_env_snapshot_list - Lists all the snapshots for a given environment.
- @command_env_snapshot_delete - Delete snapshots for a given environment.
