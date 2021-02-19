---
uid: command_env_test
title: env:test
stackBased: true
starterEdition: false
proEdition: true
enterpriseEdition: true
---

## Description

List every @concept_environment in the selected @concept_stack.

> [!TIP]
> The `--output` option allows you to control the output of this (and every) command.
>
> - `--output=pretty` is the default and will give you a human readable summary of each environment.
> - `--output=flat` will give you a terser summary of each environment.
> - `--output=json` is the most verbose and, because he output is JSON format, it can be consumed by another process or script (for example to loop over every environment).

## Options

[!include[StackOption](partials/stack-option.md)]
  
- **`-e|--environment=<environmentName>`**

  Required. Prompted for if not supplied and able to do so.
  
  The name of the environment to run tests in. Environment names are case-insensitive.
  
[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

- **`-c|--classes=<testClassNames>`**

  A comma separated list of test class names to execute. Example: `--classes=MyControllerTests,MyTriggerTests`

  If specified, only the tests contained within test class names provided will be executed.

- **`-s|--suites=<testSuiteNames>`**

  A comma separated list of test suite names to execute. Example: `--suites=MyControllerTestSuite,MyTriggerTestSuite`

  If specified, only the tests contained within test suite names provided will be executed.

- **`-a|--runAllTests`**

  If specified, every test will be executed (even those in managed packages). Otherwise, only local tests will be executed.

- **`--testResultsTo=<filePath>`**
  
  If specified, the OrgFlow CLI will output the results of the test run to a JUnit format file. This file can be read by many CI/CD tools to report on the results of the test run.

- **`--allowFailures`**

  If specified, the OrgFlow CLI will return a zero exit code even if one or more of the executed tests failed. Otherwise, the OrgFlow CLI will return an exit code of `2` if any of the executed tests fail.

- **`--failureLimit=<number>`**

  If specified, Salesforce will stop execution of the test run once the number of failed tests reach the limit specified. This is useful, for example, if you want to fail fast and halt execution as soon as a single test fails.

- **`--noCodeCoverage`**

  If specified, code coverage will not be calculated by Salesforce for this test run.

[!include[HostOptions](partials/host-options.md)]

## Examples

Run every local test in an environment called `Production`:

```bash
orgflow env:test --environment=production
```

***

Run every test (including those in managed packages) in an environment called `Production`:

```bash
orgflow env:test --environment=production --runAllTests
```

***

Run test from two test classes in an environment called `Production`, export the results to a JUnit format file, and halt the test execution if 5 or more tests fail:

```bash
orgflow env:test --classes=TestClassA,TestClassB --environment=production --jUnitTo="/TestResults/TestExecution1.xml" --failureLimit=5
```
