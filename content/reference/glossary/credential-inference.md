---
uid: concept_credentialinference
title: Credential Inference
---

OrgFlow is able to infer sandbox Salesforce credentials and login URLs if it knows the equivalent values for the production organisation.

For example: if OrgFlow knows that there is a production account with the username `allan@mycompany.com`, then it is able to infer that the username to login to a sandbox called `dev` would be `allan@mycompany.com.dev`.

## When will OrgFlow infer credentials?

OrgFlow will infer credentials if all of the following are true:

- The base credentials are known.
- The credentials for the environment to connect to are not known.

## How would OrgFlow know what the base credentials are?

You need to use the @command_auth_salesforce_save command without the `--environment` option. The username and password that you supply to this command will be saved in the @concept_statestore. If you omit the `--environment` option, the username and password will be stored on the stack as opposed to being assigned to any particular @concept_environment. We call these base credentials.

## How are credentials inferred?

OrgFlow will apply the following steps to try to determine the Salesforce username. If OrgFlow is able to determine a Salesforce username at a particular step then it will use that username, otherwise it will move on to the next step:

1. If a username is set on the environment record, then it will be used as is.
1. If a username is set on the stack record (base), then:
   - it will be used as is if connecting to the production environment, otherwise
   - it will be transformed into a sandbox username if connecting to a sandbox environment. This means appending `.<sandboxName>` to the end of the base username (for example `allan@mycompany.com` would become `allan@mycompany.com.test` if connecting to a sandbox called `test`)

Passwords are inferred in the following order:

1. If a password is set on the environment record, then it will be used as is.
2. If a password is set on the stack level (base), then it will be used as is.

The assumption is that password for an individual account will be the same for every environment. If this is not the same, you can use the @command_auth_salesforce_save command to override the username and password for a specific environment.

Salesforce usernames and passwords can be stored either in the @concept_statestore, or locally by using the `@command_auth_salesforce_save` command. When credentials are retrieved, locally stored credentials take precedence over credentials stored in the state store. Credentials must always be set in username and password pairs, so that both values are always retrieved from the same place.

## How are sign in URLs inferred?

OrgFlow will apply the following steps to try to determine the sign-in URL. If OrgFlow is able to determine a sign-in URL at a particular step then it will use that sign-in URL, otherwise, it will move on to the next step:

1. If the sign-in URL is set on the @concept_environment record then that value will be used. The sign-in URL can be set when running @command_env_create by using the `--signInUrl` option.
1. If the base sign-in URL on the @concept_stack record is set, then it will be transformed into the correct format for the environment in question:

- `https://login.salesforce.com` will be transformed into `https://test.salesforce.com` if connecting to a sandbox, or will be left as `https://test.salesforce.com` if connecting to the production environment.
- A 'My Domain' Salesforce sign-in URL (for example `https://myorganisation.my.salesforce.com`) will be transformed into the sandbox equivalent (for example `https://myorganisation--mysandbox.my.salesforce.com`) if connecting to a sandbox, r will be left as is if connecting to the production environment.
- Finally, if no base or environment sign-in URL is available, then `https://login.salesforce.com` will be used for production, and `https://test.salesforce.com` will be used for sandboxes.
