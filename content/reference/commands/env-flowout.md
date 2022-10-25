---
uid: command_env_flowout
title: env:flowout
---

## Description

@concept_flowout metadata. Deploys metadata for a particular @concept_environment from your Git repository to the Salesforce organization.

This command can also be used to validate a deployment without actually making any modifications in the Salesforce organization.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environment=<environmentName>`**

  Required. Prompted for when not specified, and possible to do so.

  The name of the environment to flow out. Environment names are case-insensitive.

[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

- **`-c|--checkOnly`**

  If specified, no change to the metadata in the Salesforce organization are made. Instead, the changes are validated by Salesforce, similar to [validating a changeset](https://help.salesforce.com/articleView?id=sf.changesets_inbound_test_deploy.htm&type=5).

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

  A comma separated list of test class names to execute. Example: `--tests=MyControllerTests,MyTriggerTests`

- **`--jUnitTo=<filePath>`**

  If specified, the OrgFlow CLI will output the results of the test run to a JUnit format file. This file can be read by many CI/CD tools to report on the results of the test run.

- **`--useLocalRepo=<directoryPath>`**

  If specified, OrgFlow will use an existing local repository on disk as the source of the outbound flow as opposed to creating a temporary local clone of your stack's configured remote Git repository.

  This can be useful in automation and CI/CD scenarios, such as automated validation of a pull request (where you want to validate the deployment of the merge result rather than the source environment) or other scenarios when the repository has already been cloned in previous steps.

  The specified path must be a valid Git repository, and must be a recent clone of the stack's configured remote Git repository.

  To avoid potential issues when the specified repository is either ahead or behind the stack's configured remote repository, this argument is currently only valid in combination with `--checkOnly` (i.e. when doing a validation-only outbound flow).

- **`--keepDelta=<directoryPath>`**

  If specified, the OrgFlow CLI will retain the delta deployment archives that are uploaded to Salesforce as part of the deployment process. The delta archives will be placed into the directory specified. This can be useful in scenarios where you need to troubleshoot deployment problems.

[!include[WaitForLockOption](partials/wait-for-lock-option.md)]

[!include[HostOptions](partials/host-options.md)]

## Examples

Interactively flow an environment out:

```bash
orgflow env:flowout
```

***

Flow an environment called `UAT` out, execute all the local tests, and publish the test results to a file on disk so that another application can read the test results:

```bash
orgflow env:flowout --environment=uat --testLevel=RunLocalTests --jUnitTo="C:\TestResults\MyTestResult.xml"
```
