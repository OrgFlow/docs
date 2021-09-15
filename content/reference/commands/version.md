---
uid: command_version
title: --version
---

## Description

Shows version, product, and copyright information for the version of the CLI that you are executing this command on.

> [!TIP]
> The version string is the only output to standard output. All other information (product and copyright information) is printed to standard error. The version string will always be a valid [semantic version](https://semver.org/spec/v2.0.0.html). This allows you to easily extract and parse the version string if you need to.

## Options

There are no options for this command.

The global options available on most other commands are not available for this command.

## Examples

Print version information:

```bash
orgflow --version
```
