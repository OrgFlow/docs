---
uid: concept_partialretrieve
title: Partial Retrieve
---

In orgs with @concept_sourcetracking enabled, OrgFlow is able to significantly reduce the time taken to retrieve metadata by enabling partial retrieves.

Partial retrieves are quicker than full retrieves because OrgFlow can use source tracking to determine the subset of meatdata that has changed in the org and only retrieve that (as opposed to retrieveing all the metadata in order to determine which items have changed). Partial retrieves are not always possible (see @concept_sourcetracking for more information).
