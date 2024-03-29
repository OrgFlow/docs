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

- **`--environment=<environmentName>`**

  If specified, the key to be saved will be specific to the environment specified. Omit to save the key at the stack-level. When retrieving saved keys, the OrgFlow CLI will first to check to see there is a saved key that is specific to the environment that it is trying to connect to. If there is no key available at the environment level then it will then fall back to the stack level.

  This is useful in cases where you want to restrict access to particular environments. For example- you could create a key that is specific to your production environment, and only disseminate the key to members of your team who should have access to production.

  Environment names are case-insensitive.

[!include[HostOptions](partials/host-options.md)]

## Examples

Save an encryption key for re-use locally:

```bash
orgflow auth:key:save --encryptionKey=ABCDEFGHIJKLM
```

***

Save an encryption key that is specific to and environment called 'QA' for re-use locally:

```bash
orgflow auth:key:save --encryptionKey=ABCDEFGHIJKLM --environment=QA
```

***

Clear a previously saved encryption key:

```bash
orgflow auth:key:save --encryptionKey=
```
