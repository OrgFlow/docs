---
uid: command_auth_git_save
title: auth:git:save
stackBased: true
starterEdition: true
proEdition: true
enterpriseEdition: true
---

## Description

The `auth:git:save` command allows you to save a username and password (or token) that can be used to authenticate with your @concept_remotegitrepository. This then allows you to use the @command_auth_git_credentialhelper command to authenticate with a remote Git repository on machines that may not necessarily have authentication already configured. A good example of this is CI/CD agents that are ephemeral and may be spun up or town down at any time.

The `auth:git:save` command can also be used to change the URL of the remote Git repository for a particular @concept_stack.

>[!NOTE]
> The remote Git repository URL, username, and password are all stored in the @concept_statestore. The password is encrypted with the encryption key that you provide.
>
> This means that anyone with your license key could read the remote Git repository URL and username, and they could also read the password if they are in possession of the encryption key used when running this command. Storing the username and password in the state store is optional (see @guide_git_authentication for more information).

## Options

[!include[StackOption](partials/stack-option.md)]
[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

- **`-r|--repoUrl=<url>`**

  If specified, the remote Git repository URL is updated on the stack in the state store. If omitted, the remote Git repository URL is not changed.

  >[!CAUTION]
  > Your Salesforce metadata will be committed to this repository, so be careful not to accidentally use a public repository if you are not comfortable making your Salesforce metadata visible to the public.

  >[!WARNING]
  > This value will be stored un-encrypted in our state store. Please do not use any URLs that contain authentication secrets (e.g. `https://<secrettoken>@github.com/myrepo.git`).

- **`-u|--gitUsername=<username>`**

  Required. Prompted for when not specified, and possible to do so.

  The username to save. Supply a blank value to indicate that no value should be saved (or to clear out a previously saved value).

- **`-p|--password=<password>|<token>`**

  Required. Prompted for when not specified, and possible to do so.

  The password (or token) to save. Supply a blank value to indicate that no value should be saved (or to clear out a previously saved value).

[!include[HostOptions](partials/host-options.md)]

## Examples

>[!NOTE]
> All of these examples assume that the encryption key for the credentials has been saved using the @command_auth_key_save command. This means that there's no need to specify the key with the `-k|--encryptionKey` option.

Update the username and password but retain the current URL for the remote Git repository:

```bash
orgflow auth:git:save --username=myusername --password=mypassword
```

***

Update the URL of the remote Git repository on the stack:

```bash
orgflow auth:git:save --gitUrl="git@github.com:MyOrg/MyRepo.git --username=myusername --password=mypassword"
```

***

Retain the current URL for the remote Git repository but clear out a previously saved username and password:

```bash
orgflow auth:git:save --username= --password=
```
