---
uid: guide_git_overview
title: Overview
---

One of the benefits of OrgFlow is that you can keep your Salesforce metadata in any Git repository that you choose. This could be GitHub, Azure DevOps, Bitbucket, any other hosted Git provider, or even a private self-hosted Git repository on your company's internal network.

The only requirements are that the device that you are running OrgFlow on can:

1. Access the remote repository on a network level (i.e. there are no firewall rules that would prevent this)
1. Authenticate with the repository in order to perform operations such as pushing and pulling

This documentation will explain how OrgFlow uses Git, and the various configuration options that you have (including configuring authentication to the [Remote Git Repository](xref:concept_remotegitrepository)).

## OrgFlow & Git

Most OrgFlow commands will interact with your remote Git repository in one way or another. In order to do this, OrgFlow simply shells out to the Git executable to execute Git commands. This means two things:

1. Git needs to be installed on the device running OrgFlow
2. Git authentication is transparent to OrgFlow, because it is handled entirely by Git

>[!TIP]
> OrgFlow assumes that the Git executable is available at `git`. If this is not the case then you can change this by setting the `ORGFLOW_GIT_EXECUTABLEPATH` environment variable. See @concept_passthrougharguments#git for more information.

If you are already able to clone your remote Git repository through Git (without Git prompting for credentials), then OrgFlow will be able to do so too. If not, or if you're wanting to run OrgFlow elsewhere (such as an ephemeral environment like a Docker container, or a CI/CD agent), then you will need to make sure that you have the correct [git authentication](xref:guide_git_authentication) available.

## Advanced configuration options

There are a number of @concept_passthrougharguments#git available if you wish to finely configure some of the Git related settings for OrgFlow.
