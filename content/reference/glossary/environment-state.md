---
uid: concept_environmentstate
title: Environment State
---

In order to support @concept_bidirectionalmetadata, OrgFlow needs to record some information about the state of each @concept_environment in your @concept_stack. This information is referred to as 'environment state', and is stored in the @concept_statestore.

OrgFlow never records the contents of your metadata. In fact, the contents of your metadata are processed entirely on the machine that is running OrgFlow, and it never leaves that machine except for when pushing to Salesforce or to your @concept_remotegitrepository.

Instead, environment state contains identifiers (including package name, object type, and object name) for the components that OrgFlow needs to record state for.
