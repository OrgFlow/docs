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

- **`--noTargetIn`**

  If specified, the inbound flow of metadata from the `--into` environment is not performed. Instead, the metadata changes from the `--into` environment will be merged with the changes in the `--from` environment's Git branch.

  >[!WARNING]
  >`--noTargetIn` can be potentially destructive unless either `--noTargetOut` or `--checkOnly` is also specified. This is because any metadata changes in the `--into` environment's Salesforce organization that are not already in the `--into` environment's Git branch will be overwritten by the deployment to the `--into` environment.

- **`--noTargetOut`**

  If specified, the merged metadata is not deployed to the `--into` environment's Salesforce organization.

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

- **`--keepZipFiles=<directoryPath>`**

  If specified, the OrgFlow CLI will retain the zip files containing the metadata items that are retrieved from Salesforce. The zip files will be placed into the directory specified. This can be useful in scenarios where you need to troubleshoot problems.

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
