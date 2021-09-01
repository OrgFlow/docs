---
uid: command_auth_salesforce_save
title: auth:salesforce:save
---

## Description

Encrypt and save credentials that can be used to connect to a Salesforce organization. Credentials can be saved either locally or remotely, and can also optionally be scoped to specific environments.

Alternatively, this command can be used to clear out previously saved credentials.

[!include[EncryptionKeyWarning](partials/encryption-key-warning.md)]

## Precedence and scope

When setting credentials, it is important to understand how they are retrieved and applied in subsequent processes.

There are two locations where credentials can be saved: locally, and remotely in the stack state store. Additionally- there are also two scopes for credentials: environment specific, and stack level (or base). This means that there are four locations that could potentially contain credentials for each environment. When retrieving credentials, OrgFlow needs to be able to deterministically be able to choose which location takes precedence.

It does this by checking for credentials in one location, and if it finds credentials there then it uses those credentials. Otherwise it will check the next location, and so on until either the credentials are discovered, or all possible locations are exhausted (whichever happens first). The precedence is (starting at the top):

1. Environment specific credentials saved locally
1. Environment specific credentials saved on the remote stack state store
1. Stack level (base) credentials saved locally
1. Stack level (base) credentials saved on the remote stack state store

Where credentials are saved is controlled by the `--location` and `--environment` options.

## Options

[!include[StackOption](partials/stack-option.md)]
[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

- **`--environment=<environmentName>`**

  If specified, the credentials to be saved will be specific to the environment specified. Omit to save the credentials at the stack-level. When retrieving saved credentials, the OrgFlow CLI will first to check to see there is are saved credentials that are specific to the environment that it is trying to connect to. If there are no credentials available at the environment level then the CLI will then fall back to using credentials set the stack level.

  >[!NOTE]
  >If credentials are set at the stack level, they should be in a valid format for the production Salesforce organization. This is because the OrgFlow CLI will try to transform stack level credentials into environment specific credentials should it need to.
  >
  >For example- imagine an environment called *EnvironmentA* which is backed by a sandbox called *SandboxA*, and a production Salesforce username *user@orgflow.io*:
  >
  > - If you save credentials at the environment level, then the username needs to be ***user@orgflow.io.sandboxa*** (because no username transformation is applied to environment specific credentials).
  > - If you save credentials at the stack level, then the username needs to be ***user@orgflow.io***. OrgFlow will automatically append ***.sandboxa*** to this username when connecting to *SandboxA* because it expects production credentials to be stored at the stack level, which in turn allows them to be transformed to sandbox credentials.
  > - If you save credentials at the stack level, but use a sandbox specific username (e.g. ***user@orgflow.io.sandboxa***), then OrgFlow will transform this username to ***user@orgflow.io.sandboxa.sandboxa*** when connecting to *SandboxA*. This is probably not what you want, and authentication will probably fail.
  >
  > See @concept_credentialinferrence for more details.

  Environment names are case-insensitive.

- **`-u|--username=<username>`**

  Required. Prompted for when not specified, and possible to do so.

  The username to save.

- **`-p|--password=<password>`**

  Required. Prompted for when not specified, and possible to do so.

  The password to save.

  >[!NOTE]
  > Your Salesforce org may be [configured in a way that requires a Security Token to be supplied with your password](https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_concepts_security.htm). In this case, you must append your security token to the end of the password that you save. For example, if your password is `OrgFlow123`, and your token is `abcdefg`, then you should use `OrgFlow123abcdefg`.

  >[!TIP]
  >Both `--username` and `--password` must be supplied in pairs. It is not possible to specify a value for only one but not the other.
  >
  >An empty value for both (i.e. `--username= --password=`) indicates a wish to clear any saved credentials.

- **`--location=[Local|StateStore]`**

  Default: `Local`.

  The physical location to save the credentials.

  - `Local`: The credentials are saved locally on disk and are specific to the current machine that the `auth:salesforce:save` command is executed on. This is best suited to manual execution where you have multiple team members interacting with the same stack. It allows accountability by allowing each user to authenticate with their own Salesforce account.
  - `StateStore`: The credentials are saved remotely in our stack @concept_statestore. They cannot be read by a third party (including OrgFlow's employees or representatives) without the third party knowing the encryption key that you used to encrypt them. These credentials can be accessed by anyone with access to the stack and the encryption key. This is best suited to scenarios where you might need all deployments to be performed by the same user, or where you have an 'API only' account that is used by automated processes (such as CI/CD).

[!include[HostOptions](partials/host-options.md)]

## Examples

Encrypt and locally save stack level (base) credentials:

```bash
orgflow auth:salesforce:save --username=user@orgflow.io --password=mypassword
```

***

Encrypt and remotely save stack level (base) credentials in the stack state store:

```bash
orgflow auth:salesforce:save --username=user@orgflow.io --password=mypassword --location=StackService
```

***

Encrypt and remotely save environment specific credentials in the stack state store:

```bash
orgflow auth:salesforce:save --environment=qa --username=user@orgflow.io.qa --password=mypassword --location=StackService
```

***

Clear out previously locally saved environment specific credentials:

```bash
orgflow auth:salesforce:save --environment=dev1 --username= --password= --location=Local
```
