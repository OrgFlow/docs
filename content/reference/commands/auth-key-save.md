---
uid: command_auth_key_save
title: auth:key:save
---

## Description

Saves an @concept_encryptionkey locally so that it can automatically be applied to encrypt and un-encrypt credentials saved either locally or on the stack. See the @command_auth_salesforce_save or @command_auth_git_save commands for examples of saving credentials.

[!include[EncryptionKeyWarning](partials/encryption-key-warning.md)]

## Options

[!include[StackOption](partials/stack-option.md)]

- **`-k|--encryptionKey=<key>`**

  Prompted for when not specified, and possible to do so. Must be a valid encryption key (see @command_auth_key_create to create a new key).

  The key to be saved (if specified), otherwise leave empty to clear out the saved key (if any).

[!include[HostOptions](partials/host-options.md)]

## Examples

Save an encryption key for re-use locally:

```bash
orgflow auth:key:save --encryptionKey=ABCDEFGHIJKLM
```

***

Clear a previously saved encryption key:

```bash
orgflow auth:key:save --encryptionKey=
```
