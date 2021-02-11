---
uid: concept_productionenvironment
title: Production Environment
---

# Production Environment

A production environment is an @concept_environment that connects to your production Salesforce organisation (as opposed to a sandbox). The other differences are:

- Every @concept_stack must have exactly one production environment.
- Your production environment is created when you run @command_stack_init.
- You cannot use @command_env_teardown to remove a production environment from your stack.
- You cannot use @command_env_setup to add a production environment to your stack.

## Why do I need to have a production environment?

In short, you wouldn't be able to set up new environments without OrgFlow being able to connect to your production Salesforce organisation. To a lesser extent, this is also true of OrgFlow's ability to teardown an environment. 

This is because these operations require OrgFlow to query for, create, and delete sandboxes, and this is only possible via the Tooling API on the production Salesforce organisation.

## Can I restrict access to the production environment?

Yes.

See @concept_accesscontrol for more information. But remember- anyone who wishes to use @command_env_setup, or to delete a sandbox with @command_env_teardown must be able to access the production environment.