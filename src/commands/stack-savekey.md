---
uid: command_stack_savekey
title: stack:savekey
---

#stack:savekey

## Description

Saves an @concept_encryptionkey locally so that it can automatically be applied to encrypt and un-encrypt credentials saved either locally or on the stack. See the @command_stack_setcredentials or @command_stack_gitauth commands for examples of saving credentials.

[!include[EncryptionKeyWarning](partials/encryption-key-warning.md)]


## Options

[!include[StackOption](partials/stack-option.md)]

- **`-k|--encryptionKey=<key>`**
  
  Required if `--clear` is not specified. Prompted for when not specified, and possible to do so.

  The key to be saved.

- **`--environment=<environmentName>`**
  
  If specified, the key to be saved will be specific to the environment specified. Omit to save the key at the stack-level. When retrieving saved keys, the OrgFlow CLI will first to check to see there is a saved key that is specific to the environment that it is trying to connect to. If there is no key available at the environment level then it will then fall back to the stack level.

  This is useful in cases where you want to restrict access to particular environments. For example- you could create a key that is specific to your production environment, and only disseminate the key to members of your team who should have access to production.

  Environment names are case-insensitive.

- **`--clear`**
  
  Not valid if `-k|--encryptionKey` is specified.

  Clears out the saved key (if any). This action is specific to the stack or environment level, as indicated by `--environment`.

[!include[HostOptions](partials/host-options.md)]

## Examples

Save an encryption key for re-use locally:

```bash
orgflow stack:savekey --encryptionKey=ABCDEFGHIJKLM
```
***

Save an encryption key that is specific to and environment called 'QA' for re-use locally:

```bash
orgflow stack:savekey --encryptionKey=ABCDEFGHIJKLM --environment=QA
```