---
uid: command_stack_gitauth
title: stack:gitauth
stackBased: true
starterEdition: true
proEdition: true
enterpriseEdition: true
---

## Description

The `stack:gitauth` command can be used to allow authentication with a remote Git repository on machines that may not necessarily have authentication already configured. A good example of this are CI/CD agents that are ephemeral and may be spun up or town down at any time.

The basic premise is:

1. The username and password (or token) for the remote Git repository are saved on the @concept_stack record in the state store. These credentials are encrypted and can only be un-encrypted by users in possession of the encryption key (see @command_stack_generatekey ).
1. The `stack:gitauth` command is added to Git as a [Credentials Helper](https://git-scm.com/book/en/v2/Git-Tools-Credential-Storage). This allows Git to query the OrgFlow CLI to retrieve credentials stored on the stack.

This command can also be used to change the URL of the remote repository that is stored on the stack. For example, if you re-name or migrate your remote repository from one location to another.

## Options

[!include[StackOption](partials/stack-option.md)]
[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

- **`--action=<key>`**

  Default: `get`
  
  - `get`: retrieve and un-encrypt the Git credentials stored on the stack.
  - `Set`: encrypt and update the Git credentials that are stored on the stack.
  - `Purge`: remove any Git credentials that are currently stored on the stack.

- **`--gitUrl=<url>`**

  Only valid if `--action=Set`.

  If specified, the Git URL is updated on the stack in the state store. If omitted, the Git URL is not changed.

- **`--gitUsername=<username>`**

  Only valid if `--action=Set`.

  If specified, the Git username is updated on the stack in the state store. If omitted, the Git username is not changed.

- **`--gitPassword=<password>|<token>`**

  Only valid if `--action=Set`.

  If specified, the Git password is updated on the stack in the state store. If omitted, the Git password is not changed.

[!include[HostOptions](partials/host-options.md)]

## As a Git credentials helper

This command can be used as a Git credentials helper to provide the stored credentials as required by Git. This is particularly useful in a CI/CD context where hosted agents may be spun up or torn down between usage.

To do this, you need to add the `orgflow stack:auth` command as a credential helper in Git config:

```bash
git config --global credential.helper "orgflow stack:gitauth"
```

The string that you provide to Git is simply a command that will be executed by Git whenever it needs to query for credentials. This means that you can specify other arguments as required. In this example, we are specifying the name of the stack as well as the license key. This common in a CI/CD scenario where you may not be able to guarantee that the license key or default stack has already been set, or simply where you wish to keep these values in a secret store.

```bash
git config --global credential.helper "orgflow stack:gitauth --stack=NightlyBackup --licenseKey=123-456-789"
```

## Examples

>[!NOTE]
> All of these example assume that the encryption key for the credentials has been saved using the @command_stack_savekey command. This means that there's no need to specify the key with the `-k|--encryptionKey` option.

Display the Git credentials currently stored on the stack:

```bash
orgflow stack:gitauth
```

***

Update the URL of the remote repository on the stack:

```bash
orgflow stack:gitauth --gitUrl="git@github.com:MyOrg/MyRepo.git"
```

***

Save the username and password for remote Git repository authentication:

```bash
orgflow stack:gitauth --gitUsername=MyUsername --gitPassword=MyPassword
```
