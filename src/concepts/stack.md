---
uid: concept_stack
title: Stack
---

# Stack

A stack is a collection of [Environments](xref:concept_environment), and metadata changes can be moved between each of these environments.

Stacks also contain @concept_environmentstate records, as well as some other information that is required to allow OrgFlow to effectively process your metadata:
- A name for your stack (so that you can identify and switch between stacks if you need to).
- Information about the @concept_remotegitrepository (so that OrgFlow can clone and push to it).
- Optional information related to authenticating with Salesforce (so that automated processes that can't open an OAuth dialog can authenticate with your Salesforce organisations).
- An optional API version (so that you can target a specific version of the Salesforce APIs).

## Managing stacks

There are a number of commands that allow you to manage stacks. They all begin with the prefix `stack:`. Here are some examples:
- @command_stack_init - Initializes a new stack. This will probably be the very first command you run with OrgFlow.
- @command_stack_setcredentials - Save (encrypted) Salesforce credentials in your stack to bypass the OAuth authentication prompts.
- @command_stack_delete - Delete a stack and all of its associated records.

## Stack record storage

Stack records are stored remotely, in the @concept_statestore.

## Deep dive

A stack is required in order to use any of the @concept_stackbasedcommands (this is why they are called stack-based commands). If you prefer to use just the @concept_orgbasedcommands, then you do not need a stack. For most OrgFlow users however, stack-based commands will be the only commands that they use.

Stacks are stored remotely, and can be accessed by anyone with your license key. This allows you to share a single license key across a team, and have all team members interact with the same stack. This is particularly useful if you have multiple users each developing in their own sandbox. Each development sandbox would be mapped to an environment in the stack, and then each developer would be free to @concept_flowin changes from their sandbox to the remote Git repository as required. Because each of these environments are in the same stack, the changes from the different sandboxes can be merged and the deployed (@concept_flowout) between environments.

When you initialise a new stack with the @command_stack_init command, you need to specify the location of the remote Git repository that will be used to store your Salesforce metadata. Your stack should be one-to-one with your remote Git repository- you can't have more than one remote Git repository in a single stack, and you shouldn't have more than one stack configured to share a single remote Git repository (unless you really know what you're doing).

As you add environments to your stack, each environment will be assigned a branch in your remote Git repository. The Git branch that is assigned to an environment is sometimes called the 'connected' branch, or referred to as the 'branch that backs' the environment.  Again, you should think of branches and environments as a one-to-one mapping- you can't have more than one Git branch assigned to a single environment, and you shouldn't have more than one environment configured to share a single Git branch (unless you really know what you're doing). This concept is covered in more detail by the [environment documentation](xref:concept_environment).