- **`--allOrNothing`**

  Either deploy all detected changes to the target org successfully, or nothing at all. If specified, this option instructs OrgFlow to finalize deployment to the target org only if no failures occur on the first attempt.

  An outbound flow is normally performed in a successive exclude-and-retry loop, where any components that failed to deploy in one attempt are excluded in the next attempt, until the deployment succeeds (which may then effectively be a *partial* deployment).

  Specifying this option changes this logic in order to avoid committing a partial deployment to the target org. With this option set, the first attempt is performed as a normal deployment, and if it succeeds without failures, then the changes are committed to the target org and the outbound flow is considered successful. However, **if the first deployment attempt fails**, then subsequent attempts are changed to **validation-only** deployments — still performed in order to collect a complete set of errors — and no changes are committed to the target org and the outbound flow is considered unsuccessful, regardless of the outcome of those validation-only deployment attempts. In the case of a merge flow, the merge result is not pushed to the remote repository.
