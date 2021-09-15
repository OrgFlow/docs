---
uid: guide_ci_overview
title: Automating OrgFlow for Continuous Integration
---

OrgFlow can be deeply integrated into almost any continuous integration or continuous deployment product. The CLI can easily be installed on a worker agent, or you can simply use the [OrgFlow CLI docker image](https://hub.docker.com/r/orgflow/cli) to ensure a well-defined workflow execution host.

Deep integration means that you can be very flexible with your OrgFlow processes. Possible examples include:

- Backing up Salesforce metadata to a Git repository on a regular schedule.
- Running tests in a Salesforce org (production or sandbox) on a nightly basis and reporting the test results back to the CI platform for reporting purposes.
- Automatically deploying metadata changes from a Git branch into a Salesforce org (production or sandbox) whenever changes are committed to a Git branch.
- Supporting popular DevOps patterns and practices (for example, [Gitflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)).
- Linking work items to commits for traceability and velocity tracking.
- Using static code analysis tools to spot anti-patterns and bad code formatting before they make it into your production org.
- Allowing peer code reviews by integrating pull requests into your working patterns.
- And so much more...

These guides contain example workflows for many popular CI/CD platforms, but the list is by no means exhaustive. If you are using a platform that we have not yet covered, then why not try to follow the patterns for another platform and then translate those to the platform of your choice (bonus points if you contribute back by adding guides that are missing).
