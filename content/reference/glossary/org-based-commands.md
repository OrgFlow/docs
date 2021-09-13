---
uid: concept_orgbasedcommands
title: Org Based Commands
---

OrgFlow commands are split into two categories: org-based, and @concept_stackbasedcommands.

Org based commands are not stateful, whereas stack-based commands are. This means that org-based commands connect directly to your Salesforce organisations, and you need to tell them how to do this (i.e. you cannot use the @concept_stack and @concept_environment records in your @concept_statestore ).

When you run an org-based command, you usually need to specify details about your Salesforce credentials to tell OrgFlow which Salesforce organisation to target.

Org-based commands are the building blocks of OrgFlow. Stack-based commands often orchestrate the execution of several org-based commands (combined with data from the state store) to achieve their functionality. Very few users have a need to venture to org-based commands; stack-based commands are usually more than enough to achieve even your most complex requirements.
