---
uid: overview_introduction
title: Introduction
---

OrgFlow is a true DevOps tool for Salesforce.

Instead of re-inventing the wheel with a bespoke or clunky web-based solution, we focus on integration with the tools that you already know and love.

Instead of forcing you to adapt your business processes to fit around our requirements, we focus on giving you the flexibility to design a process that works for you.

Instead of wasting time developing propriety source control, we simply act as the glue between Salesforce and Git.

## How does it work?

At the heart of OrgFlow is what we call a @concept_stack. A stack links your Salesforce org to a [Git repository](xref:concept_remotegitrepository). You can use ***any*** Git repository that you like, whether that's on GitHub, Bitbucket, your corporate network, or anywhere else.

Your stack starts out with a single @concept_environment - your @concept_productionenvironment. This environment links your production Salesforce org to a [single branch](xref:concept_backinggitbranch) in your Git repository. You can then make changes in your production Salesforce org and use OrgFlow to [flow those changes in](xref:command_env_flowin) to your Git branch, or you can make changes to the files in your Git branch and use OrgFlow to [flow those changes out](xref:command_env_flowout) to your production Salesforce org.

You can add more environments to your stack. These additional environments each link a single Salesforce sandbox to a single branch within your Git repository. Again, you can use OrgFlow to flow changes between your sandbox orgs and Git.

Deployments are as simple as [merging one environment into another](xref:command_env_flowmerge). Forget about code-clobber- OrgFlow can merge changes made between multiple orgs into one single file.

## What does OrgFlow **not** do?

There are already a load of great tools to help you do some of the more mundane DevOps tasks. OrgFlow focuses on being the glue between Salesforce and these tools.

Change tracking, pull requests, work item ticketing, automation and scheduling, and inspecting test results are all critical parts of the DevOps process. OrgFlow doesn't come with these features out of the box. This is a good thing, because it means that you are free to use any of the great tools that already do this far better than we ever could.

We don't force you to use our ticketing system. We don't force you to use our automation and scheduling tools. We don't force you to use our diff tools. Want to ticket with Jira, pull request with GitHub, analyze test results with Jenkins, and then deploy with Octopus Deploy? OrgFlow allows you to do this.

## How do I get started?

If you want to jump right in, our @overview_downloadandinstallation documentation can help you do that.

We have some other documentation that we recommend as good starting points:

- Our [getting started guide](xref:guide_gettingstarted) is a good way to learn the basics of running OrgFlow on your own device.
- Our reference section contains a list of all the [OrgFlow commands](xref:command_help), as well as a [glossary of terms](xref:concept_accesscontrol).
- Want to learn about automation and integration? Our [continuous integration guide](xref:guide_ci_overview) covers that for you.
- Need help? Join our [Slack workspace](https://www.orgflow.io/slack) for the quickest response.

## FAQs

### Can I really use any Git repository with OrgFlow?

Yes.

### Can I still make changes in my production Salesforce org when I'm using OrgFlow?

Yes.

### Can I make changes to the metadata in Git and then deploy them?

Yes.

### What if two people make changes to the same metadata item in two different Salesforce orgs?

OrgFlow can merge the changes, so that you don't end up overwriting one person's changes with another's. We do this by utilizing the powerful capabilities of Git- if you're familiar with merging in Git, then you're already familiar with merging in OrgFlow.

### How much does it cost?

We're clear and up-front about our pricing on the [pricing page](https://www.orgflow.io/pricing) of our website.

We have flexible plans that can scale with your usage. We don't charge per user, or based on your Salesforce edition. We think that it's only fair to pay based on how much use you get out of OrgFlow.

### Which tools does OrgFlow integrate with?

OrgFlow is a command-line-interface (CLI), which means that it can integrate with any tool that allows you to script commands. Some common tools that you can integrate OrgFlow into are:

- [GitHub Actions](https://github.com/features/actions)
- [Azure DevOps](https://azure.microsoft.com/en-us/services/devops/)
- [Jenkins](https://www.jenkins.io/)
- [CircleCI](https://circleci.com/)
- [GitLab](https://about.gitlab.com/)
- [Travis CI](https://www.travis-ci.com/)
- [Atlassian](https://www.atlassian.com/software/bamboo)
- [Octopus Deploy](https://octopus.com/)
- Anything else that allows you to script tasks...
