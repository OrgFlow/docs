---
uid: concept_encryptionkey
title: Encryption Key
---

OrgFlow allows you to store credentials in the @concept_statestore. This allows OrgFlow to support scenarios where you may not be able to complete an OAuth authentication flow (for example automated processes or CI/CD pipelines).

The credentials are encrypted with an encryption key before they are sent to the state store for storage. It is only possible to decrypt the credentials if you are in possession of the encryption key. The encryption key is never sent to OrgFlow's servers or state store, so this prevents third parties (including OrgFlow) from decrypting your saved credentials.

You can use the @command_auth_key_create command to generate a new encryption key. The key is generated on the machine that is running the OrgFlow process, and it is never transmitted over a network or leaves that machine. However, you don't need to use this command to generate a new key if you'd prefer not to. Instead, you can generate your own key so long as it meets the criteria:

- Must be exactly 64 characters long
- Must contain only hexadecimal characters

The same encryption key used when setting credentials (@command_auth_salesforce_save ) must then always be supplied to subsequent commands that require an encryption key to decrypt saved credentials.

Optionally, you can save the encryption key locally with the @command_auth_key_save command. This removes the need to pass the encryption key on every execution.
