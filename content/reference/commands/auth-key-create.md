---
uid: command_auth_key_create
title: auth:key:create
---

## Description

Generates a key that can be used to:

- Encrypt and decrypt Salesforce credentials saved with the @command_auth_salesforce_save command.
- Encrypt and decrypt Git credentials saved with the @command_auth_git_save command.

The key can be kept private to yourself, or shared amongst team members if you wish. The key should never be shared with anyone outside of your trusted organization, including with those working for, or on behalf of, OrgFlow.

## Options

[!include[HostOptions](partials/host-options.md)]

## Examples

Generate a key and output it to the terminal:

```bash
orgflow auth:key:create
```

***

Generate a key and copy it to the clipboard (useful to paste a generated key into @command_auth_key_save ):

## [Windows](#tab/win)

```bash
orgflow auth:key:create | clip
```

## [macOS](#tab/macos)

```bash
orgflow auth:key:create | pbcopy
```
