---
uid: concept_accesscontrol
title: Access Control
---

The @concept_statestore is partitioned by license key, which means that everyone who uses your license key will have full access to all of the @concept_stack and @concept_environment records associated with your license key.

This can be problematic if you also use the @command_auth_salesforce_save command to save Salesforce credentials in either a stack or environment record, but you do not wish for everyone who uses your license key to be able to authenticate with every Salesforce organization linked to an environment. For example:

- You're working for a client who has created a development environment for you but they do not wish to give you access to their @concept_productionenvironment.
- You have a change control manager who should be the only one capable of promoting changes to production, but you still wish for other people to be able to track other environments with OrgFlow.

## Restricting access to Salesforce organizations

If you'd like (or need) to save Salesforce credentials on the stack or an environment, but wish to only have a subset of your OrgFlow users be able to use those credentials, then you should use a different @concept_envryptionkey for each group of environment credentials that you'd like to have restricted.

For example: Use encryption key `A` when setting base credentials with the @command_auth_salesforce_save command. Then, use a different encryption key (`B`) to set the credentials for the production environment (again with the @command_auth_salesforce_save command). Anyone wishing to authenticate with your production environment via OrgFlow will need to hold encryption key `B`, whereas anyone with encryption key `A` can authenticate with any other environment.

> [!TIP]
> This example takes advantage of @concept_credentialinferrence, which is a core concept when dealing to Salesforce authentication and OrgFlow.

## Restricting access to backing Git branches

You may also wish to consider restricting access to the @concept_backinggitbranch for sensitive environments. This would prevent someone from bypassing OrgFlow entirely and pushing changes directly to the branch.

Git doesn't natively support this kind of functionality, but a lot of Git services add this feature in one way or another (usually by allowing policies to be configured that restrict who can make changes to particular branches):

- GitHub calls it a [branch protection rule](https://docs.github.com/en/github/administering-a-repository/managing-a-branch-protection-rule)
- Azure DevOps calls it a [branch policy](https://docs.microsoft.com/en-us/azure/devops/repos/git/branch-policies?view=azure-devops)
- GitLab calls it a [protected branch](https://docs.gitlab.com/ee/user/project/protected_branches.html)
- Bitbucket calls it [branch permissions](https://confluence.atlassian.com/bitbucketserver/using-branch-permissions-776639807.html)

You should check with your Git service to see how best to implement this.

> [!WARNING]
> If you choose to restrict access to Git branches, you should also take care if using @command_auth_git_save command or @command_auth_git_credentialhelper Git credential helper.
>
> The Git authentication details set or retrieved by this command are globally available to everyone with your license key. So if you have used this command to save credentials for a user that has access to every Git branch, then anyone with your key could just use those credentials in place of their own.
