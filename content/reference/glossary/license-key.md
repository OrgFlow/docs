---
uid: concept_licensekey 
title: License Key
---

Your license key is issued to you when you start a trial, or when you purchase a subscription to OrgFlow. It allows you to use OrgFlow, and also indicates to OrgFlow which features you are licensed to use. It can be shared across your team, and used in automated processes too.

Every command allows you to set the license key with the `--licenseKey` option. Once set, OrgFlow remembers the value for future re-use on the machine that it was set on. You can change the value that was set by simply running a command with the `--licenseKey` option specified again.

> [!WARNING]
> Make sure that you only share your license key with those that you trust. Anyone with your license key can interact with the records in your @concept_statestore, including maliciously removing records with the @command_stack_delete command.
> 