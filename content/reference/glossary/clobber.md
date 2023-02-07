---
uid: concept_clobber
title: Clobber
---

Clobber is what happens when a deployment overwrites changes in a Salesforce org. Sometimes clobber is desirable (such as during a [rollback](xref:concept_rollback)), but in most cases it is safer to avoid clobber. OrgFlow can check for clobber before finalizing a deployment, allowing you to block the deployment entirely or manually intervene in the event of clobber.

OrgFlow uses @concept_sourcetracking to determine the scope of clobber that a deployment may cause.

## Types of clobber

There are two types of clobber:

1. **Confirmed clobber** is anything that would definitely be overwritten if OrgFlow deployed the metadata in to the org.
1. **Potential clobber** can happen if we are unable to definitively determine whether or not metadata items in the org would get overwritten by the deployment. Reasons for not being able to definitively determine clobber include: source tracking being disabled in the target org, source tracking values cannot be relied upon, or the deployment contains non-source tracked types.

> [!TIP]
> Some deployments may have both confirmed and potential clobber. This can happen when OrgFlow is able to determine via source tracking that some changes in the org would get overwritten by the deployment (confirmed clobber), and the deployment also contains some metadata types thst are not source tracked (possible clobber).

## Preventing (or allowing) clobber

The @command_env_flowout and @command_env_flowmerge commands both have `--clobber` arguments that can be used to prevent (or allow) deployments that may cause clobber. 

The @concept_flowin process (applied during both the @command_env_flowin and @command_env_flowmerge commands) can be used to merge any changes in the org with changes that might be deployed from the Git repository. A common scenario would be to flow an environment in immediately before flowing out, in order to reduce the scope of clobber.
