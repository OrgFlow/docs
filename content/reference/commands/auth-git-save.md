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

>[!NOTE]
> The password that you save will be encrypted with the encryption key that you provide. You will need to use the same key to decrypt the password with the @command_auth_git_credentialhelper command.

## Options

[!include[StackOption](partials/stack-option.md)]
[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

- **`-u|--gitUsername=<username>`**

  Required. Prompted for when not specified, and possible to do so.

  The username to save. Supply a blank value to indicate that no value should be saved (or to clear out a previously saved value).

- **`-p|--password=<password>|<token>`**

  Required. Prompted for when not specified, and possible to do so.

  The password (or token) to save. Supply a blank value to indicate that no value should be saved (or to clear out a previously saved value).

- **`--location=[Local|StateStore]`**

  Default: `Local`.

  The physical location to save the credentials.

  - `Local`: The credentials are saved locally on disk and are specific to the current machine that the `auth:git:save` command is executed on. This is best suited to instances where you may have an ephemeral device and Git token. For example, a CI/CD platform may provision an agent and a Git token that last only for the duration of the current job.
  - `StateStore`: The credentials are saved remotely in our stack @concept_statestore. They cannot be read by a third party (including OrgFlow's employees or representatives) without the third party knowing the encryption key that you used to encrypt them. These credentials can be accessed by anyone with access to the stack and the encryption key. This is best suited to scenarios where you might need a central place to store the Git credentials required to authenticate to the remote Git repository.

[!include[HostOptions](partials/host-options.md)]

## Examples

>[!NOTE]
> Some of these examples assume that the encryption key for the credentials has been saved using the @command_auth_key_save command. This means that there's no need to specify the key with the `-k|--encryptionKey` option.

Save a username and password locally on the current device:

```bash
orgflow auth:git:save --username=myusername --password=mypassword
```

***

Save a username and password in the state store so that others with the license key and encryption key can use it:

```bash
orgflow auth:git:save --username=myusername --password=mypassword --location=statestore
```

***

Clear out a previously saved username and password:

```bash
orgflow auth:git:save --username= --password=
```

***

Generate an encryption key, use it to encrypt git credentials that are saved locally to the current device, and then add OrgFlow as a Git credentials helper. This is a common requirement on CI/CD agents where the agent is ephemeral and you need to configure Git with the credentials to clone or push to a repository.

```bash
# Cache the Git credentials locally:
encryptionKey=`orgflow auth:key:create --output=flat`
orgflow auth:git:save -u="myusername" -p="mypassword" -k=$encryptionKey

# Add OrgFlow as a Git credential helper:
git config --global credential.helper "!orgflow auth:git:credentialhelper -k=$encryptionKey"
```
