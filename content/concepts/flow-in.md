---
uid: concept_flowin
title: Flow In
---

One of OrgFlow's core features is the ability to flow metadata between a Salesforce organization (production or sandbox) and a @concept_remotegitrepository. 'Flow in' refers to the process of moving metadata from a Salesforce organization and into a Git repository. Flow in is sometimes referred to as an 'inbound flow', or simply as 'flowing in'.

The flow in process does more than just download the metadata from a Salesforce org and commit it to a Git repository:

## Merge-based commit strategy

OrgFlow is able to determine changes to metadata that have been made directly in the Salesforce organization, as well as changes to the metadata that are only in the @concept_backinggitbranch. Even more impressively, OrgFlow is able to merge changes that have been made the Salesforce organization and the backing Git branch.

For more information, see @concept_mergebasedcommitstrategy.

## Author attribution

When committing metadata changes to the backing Git branch, OrgFlow is able to determine which Salesforce user last modified the file, and that user's name will be added to the commit history.

This allows you to build up a rich commit history, with changes attributed to individual users. You can see who changed which files, and when.
