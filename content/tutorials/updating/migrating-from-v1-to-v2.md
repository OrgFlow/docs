---
uid: guide_v1tov2update
title: v1 to v2 migration guide
---

Version 2 of OrgFlow brings a handful of new features and breaking changes. This guide will take you through the process of updating from version 1 to version 2.

## Output formats

The most impactful breaking change is to the way that you specify the output format of commands. Version 1 had an `--output` argument on every command which allowed you to specify on output format of `Pretty`, `Flat`, or `JSON`. The `Flat` output format was not frequently used, and it added maintentance overhead (especially as we continued to add new features and commands).

Version 2 of OrgFlow removes the `Flat` output format and the `--output` argument, and continues to default to `Pretty` output format unless the new `--json` switch is specified (which changes the output to JSON). We feel that this new switch simplifies the control of output format as well as reducing our maintenance overhead. The migration steps required are as follows:

- Anywhere where you ommitted the `--output` argument will continue to work as before.
- Anywhere where you specified `--output=pretty` will need to be updated so that this argument is removed.
- Anywhere where you specified `--output=flat` will need to be updated. There is no equivalent to the flat output in version 2, so you will need to decide whether to switch to pretty or JSON output in these cases.
- Anywhere where you specified `--output=json` will need to be updated to `--json`.

## Source tracking

OrgFlow builds on the @concept_sourcetracking features in Salesforce to add two powerful new features in version2: @concept_clobber detection and @concept_partialretrieve. OrgFlow automatically detects whether or not source tracking is available for your Salesforce orgs and @concept_environment, and it can fall back to maintain functionality should source tracking not be available.

You do not need to do anything in OrgFlow to enable source tracking support, but you may want to ensure that source tracking is enabled in your Salesforce orgs so that you get the best OrgFlow experience. OrgFlow will automatically enable source tracking support after the first @concept_flowin with version 2 from an org with source tracking enabled.

## Clobber detection

@concept_clobber detection can warn you before you deploy changes that would overwrite changes in the Salesforce org. Version 1 of OrgFlow would simply continue with this deployment wihtout producing any warnings.

## Partial retrieves

## Selective inbound flows

The `--interactiveExclude` and `--exclude` arguments have been removed from the @command_env_flowin command. These arguments allowed you to do 'selective inbound flows', but excluding components during inbound flows prevented us from being able to rely on source tracking data from Salesforce. This feature required a large amount of maintenance and testing which slowed down delivery of other features, and it contributed a relatively large percentage of the overall download size.

Usage data showed that this feature was not in use by anybody. Removing it allowed us to deliver source tracking, clobber detection, partial retrieves, all while reducing the overall binary size and maintenance/testing requirements going forward.
