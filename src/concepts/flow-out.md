---
uid: concept_flowout
title: Flow Out
---

One of OrgFlow's core features is the ability to flow metadata between a @concept_remotegitrepository and a Salesforce organization (production or sandbox). 'Flow out' refers to the process of moving metadata from a Git repository and deploying it into a Salesforce organization. Flow out is sometimes referred to as an 'outbound flow', or simply as 'flowing out'.

## Deployment process

OrgFlow uses Salesforce's standard metadata API to conduct deployments. This API requires that you provide a file archive containing the changes that you wish to deploy. It would be inefficient (and carry more risk) for OrgFlow to simply upload the entire metadata archive from the remote Git repository. Instead, OrgFlow will retrieve the included metadata as it currently is in the Salesforce organization, compare it to the metadata in the remote Git repository, and create a @concept_deltaarchive to be deployed to the Salesforce organization (via the metadata API).

Once OrgFlow has determined the changes that need to be deployed, it will then attempt to deploy them. If the deployment fails, OrgFlow will remove the components that failed from the delta archive, and attempt to deploy it again. This will be repeated until one of the following is met:

- The deployment **fails** for one of the following reasons:
  - There are no components left to be deployed (i.e. all components have failed to be deployed)
  - The maximum number of deployment attempts has been hit (currently 5)
  - The deployment errors are exactly the same as the errors encountered during the previous deployment attempt
  - The deployment as a whole failed, but Salesforce did not report any failed components within it
  - Every component included in the delta archive is successfully deployed, but at least one test fails (if any tests are executed)
  - Every component included in the delta archive is successfully deployed, but code coverage is not high enough for Salesforce to accept the deployment
- The deployment **succeeds**:
  - Every component included in the delta archive is successfully deployed, all tests succeed (if any tests are executed), and code coverage is high enough (if required)

> [!NOTE]
> OrgFlow defines a successful deployment as one where **any** of the components included in the delta archive are deployed (as opposed to **every** component in this archive).
> This allows for more leniency when deploying items that may not flow between Salesforce organizations too well. For example, a particular report that may depend on an object that you do not include in your @concept_includespecs.

## Undeployable Components

If a deployment succeeds, but some of the components failed, then those components become designated as @concept_undeployablecomponents. If an undeployable component can be deployed at a subsequent attempt, then it is no longer designated as an undeployable component.

Undeployable components are recorded in the @concept_statestore, and are significant because they affect the @concept_mergebasedcommitstrategy.
