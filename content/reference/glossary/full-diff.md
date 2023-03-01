---
uid: concept_fulldiff
title: Full diff
---

During the @concept_flowout process, OrgFlow needs to be able to determine which components have changes so that it can create a @concept_deltaarchive containing just the items that need to be deployed. OrgFlow has two diffing algorithms that it can use to determine these differences - full diff and @concept_historydiff.

## The process

OrgFlow will retrieve metadata from your Salesforce org, and compare it with the metadata that you plan to deploy (this is usually the metadata in your @concept_backinggitbranch ). Any component that differs in this comparison is included in the diff result.

This is the most thorough diffing algorithm because it can detect every difference between the Salesforce org and the local metadata, but it does come with some drawbacks:

- The retrieve can be very slow, especially if a @concept_partialretrieve is not possible
- The diff result can contain items that have not changed locally but that are ahead in Salesforce, which will cause @concept_clobber when it comes to deploying the diff result

A good use case for a full diff is if you would like the meatdata in the Salesforce org to match exactly the state of the metadata locally (i.e. you require parity between them, even if it means overwriting changes in Salesforce).

> [!TIP]
> If you refresh a sandbox that is associated to an OrgFlow environment, it's best to do a @concept_flowout with a full diff immediately afterwards (to help maintain full parity between your org and the Git branch)
