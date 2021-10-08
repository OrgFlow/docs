---
uid: reference_configuration
title: Configuration
---

This topic describes the ways in which you can control OrgFlow's various options and settings.

## Passthrough arguments

Passthrough arguments are a way to provide advanced configuration options to OrgFlow. They can be provided to every command, even if they might not affect every command (for example, Git specific options would not affect the operation of a command that does not interact with Git).

You can provide a passthrough argument either as an environment variable, or as a command line argument (for example `orgflow <command> <passthrough argument>`). The following passthrough arguments are available:

### Git

| Environment Variable | Command Option | Description | Default Value |
|---|---|---|---|
| `ORGFLOW_GIT_EXECUTABLEPATH` | `--c:git.executablePath` | The location of the Git executable on disk. | `git` |
| `ORGFLOW_GIT_UNKNOWNAUTHORNAME` | `--c:git.unknownAuthorName` | The name to use in the commit signature for changes where OrgFlow is unable to determine the author (for example, deletes). | `Unknown Author` |
| `ORGFLOW_GIT_UNKNOWNAUTHOREMAIL` | `--c:git.unknownAuthorEmail` | The email address to use in the commit signature for changes where OrgFlow is unable to determine the author (for example, deletes). | `unknownauthor@orgflow.io` |
| `ORGFLOW_GIT_COMMITTERNAME` | `--c:git.committerName` | The name to use in the committer's commit signature. | `OrgFlow` |
| `ORGFLOW_GIT_COMMITTEREMAIL` | `--c:git.committerEmail` | The email address to use in the committer's commit signature. | `orgflow@orgflow.io` |
