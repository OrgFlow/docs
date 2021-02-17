---
uid: concept_statestore
title: State Store
---

# State Store

Every @concept_stackbasedcommand requires knowledge of either a @concept_stack, an @concept_environment, or an @concept_environmentstate (in most cases they require knowledge of a combination of these items). These items are stored as records in the state store.

The state store is a remote, cloud-based service that is owned and managed by OrgFlow; you do not need to set up or maintain this service. OrgFlow implicitly knows how to connect and authenticate with the state store, and so requires no configuration in this regard.

The state store is multi-tenant, and is partitioned by @concept_licensekey. This means that anyone (and only those) with your license key can access the records in your partition. So, no matter where you run OrgFlow from, you will always have access to to your stack, environment, and environment state records. 

For example: a team with three OrgFlow users, each running OrgFlow from their own laptops, and each sharing the same license key would all be sharing the same partition in the state store. This would mean that stack, environments, and environment states would all be shared and accessible by all three users.