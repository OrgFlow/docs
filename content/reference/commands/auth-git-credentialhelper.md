---
uid: command_auth_git_credentialhelper
title: auth:git:credentialhelper
stackBased: true
starterEdition: true
proEdition: true
enterpriseEdition: true
---

## Description

The `auth:git:credentialhelper` command is only intended to be executed by Git. It's a [Git Credential Helper](https://git-scm.com/docs/gitcredentials) that allows Git to use the username and password saved by @command_auth_git_save to authenticate with your @concept_remotegitrepository. This is useful on machines that may not necessarily have authentication already configured. A good example of this is CI/CD agents that are ephemeral and may be spun up or town down at any time.

OrgFlow does not require the use of this credential helper, so long as you have another mechanism in place to allow Git to authorize with the remote Git repository. However, if you do decide to use this credential helper, you must configure Git in order to do so (see below for examples of this).

## Options

[!include[StackOption](partials/stack-option.md)]
[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

## As a Git credential helper

This command can be used as a Git credential helper to provide the stored credential as required by Git. This is particularly useful in a CI/CD context where hosted agents may be spun up or torn down between usage.

To do this, you need to add the `orgflow auth:git:credentialhelper` command as a credential helper in Git config:

```bash
git config --global credential.helper "!orgflow auth:git:credentialhelper"
```

The string that you provide to Git is simply a command that will be executed by Git whenever it needs to query for credentials. The `!` before the command indicates to Git that the text that follows is a command to be executed. This means that you can specify other arguments as required. In this example, we are specifying the name of the stack as well as the license key. This is common in a CI/CD scenario where you may not be able to guarantee that the license key or default stack has already been set, or simply where you wish to keep these values in a secret store.

```bash
git config --global credential.helper "!orgflow auth:git:credentialhelper --stack=NightlyBackup --licenseKey=123-456-789"
```
