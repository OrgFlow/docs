---
uid: command_env_flowmerge
title: env:flowmerge
---

## Description

Merges metadata from one @concept_environment into another.

## Process

1. @concept_flowin the source and target environments (optional- see `--noSourceIn` and `--noTargetIn` options).
1. Merge the metadata from the source environment into the target environment.
1. @concept_flowout the target environment to deploy the result of the merge in to the target environment's Salesforce organization (optional- see the `--noTargetOut` option).

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-f|--from=<environmentName>`**

  Required. Prompted for when not specified, and possible to do so.

  The name of the environment to merge from. Environment names are case-insensitive.

- **`-i|--into=<environmentName>`**

  Required. Prompted for when not specified, and possible to do so.

  The name of the environment to merge into. Environment names are case-insensitive.

  The metadata changes from the environment specified to the `--from` option will be merged into the metadata in the `--into` environment.

[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

- **`--noSourceIn`**

  If specified, the inbound flow of metadata from the `--from` environment is not performed. Instead, only the metadata changes that are already in that environment's Git branch will be merged into the `--into` environment.

- **`--sourceInRetrieveMode=auto|partial|full`**

  Specifies how metadata is retrieved from the source Salesforce org. The default value is `auto`.

  - `auto`: Favor a @concept_partialretrieve if it is safe and possible to do so, fall back to a full retrieve if not
  - `partial`: Never fall back to a full retrieve, always do a partial retrieve (even if it is not safe to do so); fail if it is not possible to do a partial retrieve (e.g. if source tracking is not enabled in the org)
  - `full`: Always do a full retrieve, even if a partial retrieve would be possible

- **`--sourceInConflicts=prompt|allAsLocal|allAsRemote|askForEach|gitMergetool|abort`**

  Specifies how unresolved merge conflicts encountered during the inbound flow of the source environment should be handled. The default value is `prompt`.

  - `prompt`: Prompt user interactively for each encountered set of unresolved merge conflicts if possible, otherwise abort the inbound flow
  - `allAsLocal`: Resolve all merge conflicts by letting the version in the Git branch win
  - `allAsRemote`: Resolve all merge conflicts by letting the incoming version from the Salesforce org win
  - `askForEach`: Let user choose between local and remote for each conflicted file
  - `gitMergetool`: Run configured `git-mergetool` command for each encountered set of unresolved merge conflicts
  - `abort`: Abort the inbound flow if any unresolved merge conflicts are encountered

- **`--noTargetIn`**

  If specified, the inbound flow of metadata from the `--into` environment is not performed. Instead, the metadata changes from the `--into` environment will be merged with the changes in the `--from` environment's Git branch.

  >[!WARNING]
  >`--noTargetIn` can increase the risk of clobber to the  org. This is because any metadata changes in the `--into` environment's Salesforce organization that are not already in the `--into` environment's Git branch will be overwritten by the deployment to the `--into` environment. The `--clobber` arg allows control of how to handle clobber if it is encountered.

- **`--targetInRetrieveMode=auto|partial|full`**

  Specifies how metadata is retrieved from the taget Salesforce org. The default value is `auto`.

  - `auto`: Favor a @concept_partialretrieve if it is safe and possible to do so, fall back to a full retrieve if not
  - `partial`: Never fall back to a full retrieve, always do a partial retrieve (even if it is not safe to do so); fail if it is not possible to do a partial retrieve (e.g. if source tracking is not enabled in the org)
  - `full`: Always do a full retrieve, even if a partial retrieve would be possible

- **`--targetInConflicts=prompt|allAsLocal|allAsRemote|askForEach|gitMergetool|abort`**

  Specifies how unresolved merge conflicts encountered during the inbound flow of the target environment should be handled. The default value is `prompt`.

  - `prompt`: Prompt user interactively for each encountered set of unresolved merge conflicts if possible, otherwise abort the inbound flow
  - `allAsLocal`: Resolve all merge conflicts by letting the version in the Git branch win
  - `allAsRemote`: Resolve all merge conflicts by letting the incoming version from the Salesforce org win
  - `askForEach`: Let user choose between local and remote for each conflicted file
  - `gitMergetool`: Run configured `git-mergetool` command for each encountered set of unresolved merge conflicts
  - `abort`: Abort the inbound flow if any unresolved merge conflicts are encountered

- **`--conflicts=prompt|allAsLocal|allAsRemote|askForEach|gitMergetool|abort`**

  Specifies how unresolved merge conflicts should be handled during the merge from the source branch into the target branch. The default value is `prompt`.

  - `prompt`: Prompt user interactively for each encountered set of unresolved merge conflicts if possible, otherwise abort the inbound flow
  - `allAsLocal`: Resolve all merge conflicts by letting the version in the Git branch win
  - `allAsRemote`: Resolve all merge conflicts by letting the incoming version from the Salesforce org win
  - `askForEach`: Let user choose between local and remote for each conflicted file
  - `gitMergetool`: Run configured `git-mergetool` command for each encountered set of unresolved merge conflicts
  - `abort`: Abort the inbound flow if any unresolved merge conflicts are encountered

- **`--diffMode=auto|history|org`**

  Specifies the diffing algorithm to use when comparing metadata in the Git branch to the metadata in the Salesforce org during the outound flow of the target environment. The default value is `auto`.

  - `auto`: Use history diff if supported, otherwise fall back to full diff
  - `history`: Use @concept_historydiff if supported, otherwise abort
  - `org`: Use @concept_orgdiff

- **`--noTargetOut`**

  If specified, the merged metadata is not deployed to the `--into` environment's Salesforce organization.

  The specified conflict resolution strategy applies only to files which could not automatically resolved by Git. If not specified, the default behavior is equal to `prompt`.

- **`--clobber=auto|accept|abort`**

  Specifies how @concept_clobber should be handled, if encountered during the outbound flow of the target environment. Default is `auto`.

  - `auto`: Allow potential clobber, but abort on certain clobber
  - `accept`: Allow all clobber (both potential and certain)
  - `abort`: Do not allow any clobber (either potential or certain), and abort before any changes are deployed to the target Salesforce org.

- **`-g|--gitOnly`**

  Shorthand for `--noSourceIn --noTargetIn --noTargetOut` (i.e. only the Git based operations will be performed, and there will be no interaction with Salesforce).

- **`-c|--checkOnly`**

  If specified, the merge result will be validated, but it won't be persisted.

  This means that:
  - The result of the merge will not be pushed to your remote Git repository
  - The deployment to the `--into` environment's Salesforce organization (if any) will be validated by Salesforce, but the changes will not be deployed.

[!include[CheckOnlyDeployWarning](partials/check-only-deploy-warning.md)]

[!include[AllOrNothingOption](partials/all-or-nothing-option.md)]

- **`--testLevel=[NoTestRun|RunSpecifiedTests|RunLocalTests|RunAllTestsInOrg]`**

  If specified, indicates the tests that should be executed as part of the deployment to Salesforce:
  - `NoTestRun`: No tests are executed.
  - `RunSpecifiedTests`: Only the test classes specified by `--tests` are executed.
  - `RunLocalTests`: All tests in the organization that do not originate from managed packages are executed.
  - `RunAllTestsInOrg`: Every test in the organization (including those in managed packages) are executed.

  All deployments are subject to Salesforce's minimum test requirements (e.g. code coverage etc.), regardless of the value that you specify for this option.

  If omitted, Salesforce will automatically determine the tests to execute:
  - If deploying to a sandbox, then no tests are run.
  - If deploying to a production organization and the deployment contains changes to Apex classes or triggers, then `RunLocalTests`.

- **`--tests=<testClassNames>`**

  Only valid (and required) if `--testLevel=RunSpecifiedTests`.

  A comma separated list of test class names to execute. Example: `--test=MyControllerTests,MyTriggerTests`

- **`--jUnitTo=<filePath>`**

  If specified, the OrgFlow CLI will output the results of the test run to a JUnit format file. This file can be read by many CI/CD tools to report on the results of the test run.

- **`--keepDelta=<directoryPath>`**

  If specified, the OrgFlow CLI will retain the delta deployment archives that are uploaded to Salesforce as part of the deployment process. The delta archives will be placed into the directory specified. This can be useful in scenarios where you need to troubleshoot deployment problems.

[!include[WaitForLockOption](partials/wait-for-lock-option.md)]

[!include[HostOptions](partials/host-options.md)]

## Examples

Interactively merge an environment into another:

```bash
orgflow env:flowmerge
```

***

Commit (flow in) the changes from the `test` and `production` environments, merge the changes from `test` into the `production` environment, and deploy the result of the merge into the `production` Salesforce organization:

```bash
orgflow env:flowmerge --from=test --into=production
```

***

Commit (flow in) the changes from the `test` and `production` Salesforce organizations, merge the changes from `test` into the `production` environment, and deploy the result of the merge into the `production` Salesforce organization:

```bash
orgflow env:flowmerge --from=test --into=production
```

***

Merge the changes from environments `dev1`, `dev2`, and `dev3` into production. The changes from the `production` Salesforce environment are retrieved only once (at the start), and the result of all three merges are deployed together (at the end):

```bash
orgflow env:flowmerge --from=dev1 --into=production --noTargetOut

orgflow env:flowmerge --from=dev2 --into=production --noTargetIn --noTargetOut

orgflow env:flowmerge --from=dev3 --into=production --noTargetIn
```
