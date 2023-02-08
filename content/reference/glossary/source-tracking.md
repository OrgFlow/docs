---
uid: concept_sourcetracking
title: Source Tracking
---

Source tracking is a feature of Salesforce that allows changes in a Salesforce org to be logged and then read by third party application (such as OrgFlow). Source tracking is enabled on an org by org basis, and when enabled, metadata changes are recorded as [SourceMember](https://developer.salesforce.com/docs/atlas.en-us.api_tooling.meta/api_tooling/tooling_api_objects_sourcemember.htm) records.

The Salesforce docs have more information about source tracking and [how to enable it](https://developer.salesforce.com/docs/atlas.en-us.sfdx_dev.meta/sfdx_dev/sfdx_setup_enable_source_tracking_sandboxes.htm). If you've used SFDX before, you may be familiar with source tracking. 

OrgFlow uses source tracking to determine the scope of @concept_clobber during deployments, as well as to determine which metadata items to retrieve during a @concept_partialretrieve.

## When source tracking cannot be used

Occasionally source tracking cannot be used by OrgFlow. When this happens, OrgFlow can fall back to functionality that doesn't require source tracking. This impacts:

- **Retrieves** - @concept_partialretrieve is not possible without source tracking, so OrgFlow will fall back to full retrieves.
- **Clobber** - it is not possible to detect clobber without source tracking, so OrgFlow will flag everything to be deployed as *potential clobber* during deployment processes.

OrgFlow is not able to use source tracking if any one of the following is true:

- The target org does not have source tracking enabled (e.g. your production org, a sandbox that does not support source tracking, or a sandbox that was created without source tracking enabled).
- A changeset has been deployed into the org since the most recent full retrieve. Changeset deployments do not create source member records, so OrgFlow is unable to trust the source tracking data in the org if a changeset has been deployed since the most recent full retrieve. OrgFlow calls these deployments 'external deployments'.
- OrgFlow has not retrieved any metadata from the org for the past 30 days. Salesforce deployment records are only available for 30 days, so if 30 days has elapsed since OrgFlow last checked for external deployments then it cannot trust the deployment data contained in Salesforce so it will be unable to trust the source tracking information in the org.
- There has never been a full retrieve of the metadata for the @concept_environment. The very first full retrieve of an environment will pull all the included metadata as well as set the initial source tracking values on the environment's state store record. This is used at a 'starting point' for source tracking, and is usually done during environment set up.
- The @concept_includespecs have changed since the most recent retrieve. If the include specs have changed, then OrgFlow cannot be confident that any previous retrieves or source tracking values would be complete enough to be able to utilize source tracking.

## Source tracking data that OrgFlow records

OrgFlow needs to record some values from your Salesforce org in order to facilitate source tracking. The values are recorded on the @concept_environment records in OrgFlow's cloud based @concept_statestore. The values that are recorded are:

- The most recent known revision number from the Salesforce org (used to determine the point from which changes should be retrieved).
- The ID of the most recent known deployment in the org (used to detrmine if any external deployments have been performed).
- A hash of the include specs at the time of retrieve (used to determine whether or not the include specs have changed since the last retrieve).