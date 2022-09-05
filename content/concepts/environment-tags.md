---
uid: concept_tags
title: Environment Tags
---

Tags are arbitrary name/value pairs that you can set on the environments in your OrgFlow stack.

A tag can either have a value (for example `OwnerEmail:dimitrius@acme.com`) or no value (for example `IsDisabled`). Tags with values are most useful when you need to filter or carry out actions based on values that may differ between environments, such as send an email to the owner of an environment. Tags without values are useful for modeling and acting on boolean conditions, such as excluding environments that have been temporarily disabled.

Environment tags are stored in OrgFlow's cloud-based state store, and can therefore be managed and used from any device. Tags are pass-through and completely opaque to OrgFlow; OrgFlow ascribes no meaning to, and bases no processing on, the existence or values of any enviroment tags. Their meaning and use are completely up to you and the processes and pipelines you build around them.

categorization
values
flags


Tags are a simple but powerful automation feature of OrgFlow. They allow you to develop scripts, CI/CD pipelines and other forms of automation that treat environments differently without having to hard-code environment names into your scripts. Instead, you can set different tags on different environments and base your script logic on those tags.

This flexibility allows you to:

- Add/remove environments of different categories in your stack without having to modify your scripts
- Change the handling of existing environments without modifying your scripts
- Avoid hard-coding environment names in your scripts
- Avoid unneccesary commits and churn on your scripts

To manage tags on your environments, use the @command_env_tags_set and @command_env_tags_delete commands. Both commands allow you to set/delete multiple tags on multiple environments in a single command.

To use tags in your scripts and automation pipelines, use the @command_env_list command. For simple filtering needs, you can use the `--withTags` argument of the @command_env_list command itself to list environments matching a given set of tags and then use a loop in your script to perform some set of actions on those environments. For more advanced filtering needs, you can use the `--output=json` argument to include all environment tags in JSON output, allowing you to base custom filtering and processing logic on those tags. You can also use a combination of both.

To see a list of environments matching a given set of tags, use the @command_env_list command.

EXAMPLE USE CASES



To see all current tags on a given environment, use the @command_env_list command with JSON output.

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
> OrgFlow assumes that the Git executable is available at `git`. If this is not the case then you can change this by setting the `ORGFLOW_GIT_EXECUTABLEPATH` environment variable. See @reference_configuration#git for more information.

If you are already able to clone your remote Git repository through Git (without Git prompting for credentials), then OrgFlow will be able to do so, too. If not, or if you want to run OrgFlow elsewhere (such as an ephemeral environment like a Docker container, or a CI/CD agent), then you will need to make sure that you have the correct [git authentication](xref:guide_git_authentication) available.

## Advanced configuration options

There are a number of configuration options available if you wish to finely configure some of the Git related settings for OrgFlow. See @reference_configuration#git for more information.
