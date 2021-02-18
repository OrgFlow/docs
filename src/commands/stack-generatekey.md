---
uid: command_stack_generatekey
title: stack:generatekey
stackBased: true
---

## Description

Generates a key that can be used to:

- Encrypt and decrypt Salesforce credentials saved with the @command_stack_setcredentials command.
- Encrypt and decrypt Git credentials saved with the @command_stack_gitauth command.

The key can be kept private to yourself, or shared amongst team members if you wish. The key should never be shared with anyone outside of your trusted organization, including with those working for, or on behalf of, OrgFlow GmbH.

## Options

[!include[HostOptions](partials/host-options.md)]

## Examples

Generate a key and output it to the terminal:

```bash
orgflow stack:generatekey
```

***

Generate a key and copy it to the clipboard (useful to paste a generated key into @command_stack_savekey ):

## [Windows](#tab/win)

```bash
orgflow stack:generatekey --output=flat | clip 
```

## [macOS](#tab/macos)

```bash
orgflow stack:generatekey --output=flat | pbcopy
```
