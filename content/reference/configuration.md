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
| `ORGFLOW_GIT__EXECUTABLEPATH` | `--c:git.executablePath` | The location of the Git executable on disk. | `git` |
| `ORGFLOW_GIT__UNKNOWNAUTHORNAME` | `--c:git.unknownAuthorName` | The name to use in the commit signature for changes where OrgFlow is unable to determine the author (for example, deletes). | `Unknown Author` |
| `ORGFLOW_GIT__UNKNOWNAUTHOREMAIL` | `--c:git.unknownAuthorEmail` | The email address to use in the commit signature for changes where OrgFlow is unable to determine the author (for example, deletes). | `unknownauthor@orgflow.io` |
| `ORGFLOW_GIT_COMMITTERNAME` | `--c:git.committerName` | The name to use in the committer's commit signature. | `OrgFlow` |
| `ORGFLOW_GIT__COMMITTEREMAIL` | `--c:git.committerEmail` | The email address to use in the committer's commit signature. | `orgflow@orgflow.io` |

### Metadata Archives

| Environment Variable | Command Option | Description | Default Value |
|---|---|---|---|
| `ORGFLOW_METADATARCHIVE__DISALLOWCASEONLYRENAMES` | `--c:metadataarchive.disallowcaseonlyrenames` | Whether or not OrgFlow will allow case-ony renames of metadata files<sup>1</sup>. | `true` |

#### Notes

<sup>1</sup> OrgFlow disallows this by default because case-only renames can confuse Git on a case-insensitive file system. If you encounter this situation (and OrgFlow is configured to disallow it) then OrgFlow will error with a message like `Cannot apply archive changes: The file '[...]' has changed in case only (to '[...]]')`.
