---
uid: concept_sourcetracking
title: Source Tracking
---

Source tracking is a feature of Salesforce that allows changes in a Salesforce org to be logged and then read by third party application (such as OrgFlow). Source tracking is enabled on an org by org basis, and when enabled, metadata changes are recorded as [SourceMember](https://developer.salesforce.com/docs/atlas.en-us.api_tooling.meta/api_tooling/tooling_api_objects_sourcemember.htm) records.

The Salesforce docs have more information about source tracking and [how to enable it](https://developer.salesforce.com/docs/atlas.en-us.sfdx_dev.meta/sfdx_dev/sfdx_setup_enable_source_tracking_sandboxes.htm). If you've used SFDX before, you may be familiar with source tracking. 

OrgFlow uses source tracking to determine the scope of @concept_clobber during deployments, as well as to determine which metadata items to retrieve during a @concept_partialretrieve.

## Source tracking data that OrgFlow records

OrgFlow needs to record some values from your Salesforce org in order to facilitate source tracking. The values are recorded on the @concept_environment records in OrgFlow's cloud based @concept_statestore. The values that are recorded are:

- 



## When source tracking cannot be used

OrgFlow can fall back to 
