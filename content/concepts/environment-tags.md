---
uid: concept_tags
title: Environment Tags
---

Tags are arbitrary name/value pairs that you can set on the environments in your OrgFlow stack.

A tag can either have a value (for example `ownerEmail:dimitrius@acme.com`) or no value (for example `isDisabled`). Tags with values are most useful when you need to filter or carry out actions based on values that may differ between environments, such as send an email to the owner of an environment. Tags without values are useful for modeling and acting on boolean conditions, such as excluding environments that have been temporarily disabled.

Both tag names and tag values are **case-insensitive**. Tag names may only contain alphanumeric characters, hyphens and underscores. Tag values may contain anything except newline characters.

Environment tags are stored in OrgFlow's cloud-based state store, and can therefore be managed and used from any device. Tags are pass-through and completely opaque to OrgFlow; OrgFlow ascribes no meaning to, and bases no processing on, the existence or values of any enviroment tags. Their meaning and use are completely up to you and the processes and pipelines you build around them.

Tags are a simple but powerful automation feature of OrgFlow. They allow you to develop scripts, CI/CD pipelines and other forms of automation that treat environments differently without having to hard-code environment names into your scripts. Instead, you can set different tags on different environments and base your script logic on those tags.

This flexibility allows you to:

- Add/remove environments of different categories in your stack without having to modify your scripts
- Change the handling of existing environments without modifying your scripts
- Avoid hard-coding environment names in your scripts
- Avoid unneccesary commits and churn on your scripts

## Use cases

The potential use cases for tags are virtually unlimited and depend on your requirements, but here are some examples of what environment tags could be used for:

- **Categorize and group** your environments and develop scripts or pipelines that apply particular logic or processing only for environments in a certain category or group. As an example, you might categorize all your environments as either `dev`, `test`, `staging`. In your CI/CD pipelines, you might only flow in changes in environments with the tag `category:dev`, because no changes made in `test` and `staging` environments should be preserved.

- Save **arbitrary values** on your environments and use those values as per-environment inputs to the logic or processing in your scripts or pipelines. As an example, you might designate a code owner for each development environment, and store the owner's email address on each environment with the tags similar to `ownerEmail:name@domain.com`. In your CI/CD pipelines, you might then send an email to the owner of any environment where merge conflicts are detected.

- **Flag** your environments based on boolean semantics and use conditional logic or processing in your scripts or pipelines based on those flags. As an example, you might add a `noMergeFromDownstream` tag to some environments to allow environments to temporarily stop receiving automatic merges from downstream environments. In your scheduled upstream merge CI/CD pipeline, you would then exclude those environments from processing.

## Managing tags

To manage tags on your environments, use the @command_env_tags_set and @command_env_tags_delete commands. Both commands allow you to set/delete multiple tags on multiple environments in a single command.

To see all tags on a given environment or to see a list of environments matching a given set of tags, use the @command_env_list command.

## Using tags

To use tags in your scripts and automation pipelines, use the @command_env_list command. For simple filtering needs, you can use the `--withTags` argument of the @command_env_list command itself to list environments matching a given set of tags and then use a loop in your script to perform some set of actions on those environments. For more advanced filtering needs, you can use the `--output=json` argument to include all environment tags in JSON output, allowing you to base custom filtering and processing logic on those tags. You can also use a combination of both.
