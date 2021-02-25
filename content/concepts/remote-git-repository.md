---
uid: concept_remotegitrepository
title: Remote Git Repository
---

For [stack-based processes](xref:concept_stackbasedcommands), OrgFlow uses a [Git](https://git-scm.com/) repository to maintain a record of your Salesforce metadata and its history.

Every @concept_stack needs to be linked to a single remote Git repository. The location of this repository is set when you run the @command_stack_init command.

## Which Git services are supported by OrgFlow?

Answer: any.

There are many Git services available, and OrgFlow supports every single one. The only requirement is that the OrgFlow process is able to connect to the remote repository location (e.g. there are no firewall or network restrictions that would prevent the OrgFlow process from communicating with the remote Git repository).

When we say any, we mean any: GitHub, Azure DevOps, GitLab, Bitbucket, AWS CodeCommit, or even an internal Git server on your corporate network.

> [!TIP]
> OrgFlow processes all of your Salesforce metadata locally on the machine that is running the OrgFlow process. This means that if your remote Git repository is protected by firewall rules then you do not need to alter these rules to allow for an externally hosted process to be able to access the remote Git repository.
