---
uid: concept_historydiff
title: History diff
---

During the @concept_flowout process, OrgFlow needs to be able to determine which components have changes so that it can create a @concept_deltaarchive containing just the items that need to be deployed. OrgFlow has two diffing algorithms that it can use to determine these differences - history diff and @concept_fulldiff.

## The process

OrgFlow will compare the metadata at the head of your @concept_backinggitbranch to the metadata at the parity commit hash in the branch. This means that any components that have changes in their Git history between these two Git refs will be included in the diff result.

This is the quickest (because it doesn't involve a retrieve) and safest (in terms of reducing the risk of clobber) diff algorithm. Therefore OrgFlow will always use this diff algorithm as default when it can. It's good to note:

- Metadata items that have changed in Salesforce but have not changed in Git will not be included in the diff result
- History diff is not possible when creating a new environment (because the environment does not yet have a parity hash)
