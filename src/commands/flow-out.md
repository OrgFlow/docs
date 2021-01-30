---
uid: command_flow_out
title: flow:out
---

#flow:out

## Description

@concept_flowout metadata. Deploys metadata for a particular @concept_environment from your Git repository to the Salesforce organisation.

This command can also be used to validate a deployment without actually making any modifications in the Salesforce organisation.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-e|--environment=<environmentName>`**
  
  Required. Prompted for when not specified, and possible to do so.

  The name of the environment to flow out. Environment names are case-insensitive.
  
[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

- **`-c|--checkOnly`**
  
  If specified, no change to the metadata in the Salesforce organisation are made. Instead, the changes are validated by Salesforce, similar to [validating a changeset](https://help.salesforce.com/articleView?id=sf.changesets_inbound_test_deploy.htm&type=5).

  >[!WARNING]
  >Using this option can potentially leave a validated changeset with in the target Salesforce organisation and the Salesforce UI will show a button to 'Quick Deploy' a validated changeset.
  >
  >Using the 'Quick Deploy' option will cause the metadata tracked with OrgFlow to be out of sync, which may cause further OrgFlow operations to incorrectly merge or overwrite metadata changes.

- **`--testLevel=[NoTestRun|RunSpecifiedTests|RunLocalTests|RunAllTestsInOrg]`**
  
  If specified, indicates the tests that should be executed as part of the deployment to Salesforce:
  - `NoTestRun`: No tests are executed.
  - `RunSpecifiedTests`: Only the tests classes specified by `--tests` are executed.
  - `RunLocalTests`: Alls tests in the organisation that do not originate from managed packages are executed.
  - `RunAllTestsInOrg`: Every test in the organisation (including those in managed packages) are executed.

  All deployments are subject to Salesforce's minimum test requirements (e.g. code coverage etc.), regardless of the value that you specify for this option.
  
  If omitted, Salesforce will automatically determine the tests to execute:
  - If deploying to a sandbox, then no tests are run.
  - If deploying to a production organisation and the deployment contains changes to Apex classes or triggers, then `RunLocalTests`.

- **`--tests=<testClassNames>`**
  
  Only valid (and required) if `--testLevel=RunSpecifiedTests`.

  A comma separated list of test class names to execute. Example: `--test=MyControllerTests,MyTriggerTests`

- **`--testResultsTo=<filePath>`**
  
  If specified, the OrgFlow CLI will output the results of the test run to a JUnit format file. This file can be read by many CI/CD tools to report on the results of the test run.

- **`--keepDelta=<directoryPath>`**
  
  If specified, the OrgFlow CLI will retain the delta deployment archives that are uploaded to Salesforce as part of the deployment process. The delta archives will be placed into the directory specified. This can be useful in scenarios where you need to troubleshoot deployment problems.

[!include[HostOptions](partials/host-options.md)]

## Examples

Interactively flow an environment out:

```bash
orgflow flow:out
```

***

Flow an environment called `UAT` out, execute all the local tests, and publish the test results to a file on disk so that another application can publish the test results:

```bash
orgflow flow:out --environment=uat --tests=RunLocalTests --testResultsTo="C:\TestResults\MyTestResult.xml"
```