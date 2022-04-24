---
uid: guide_ci_github
title: GitHub Actions
---

We provide first-class support for GitHub Actions through a set of actions that we develop and maintain:

- Our [`setup`](https://github.com/OrgFlow-Actions/setup) action which allows you to easily install and configure OrgFlow at the start of your job
- Our [`result-to-comment`](https://github.com/OrgFlow-Actions/result-to-comment) action which allows you to post the results of an OrgFlow command as a comment on a GitHub issue or pull request

You are not required to use these actions in order to use OrgFlow in your GitHub Actions workflows, but they do a lot of heavy lifting for you and ensure OrgFlow is configured and invoked in a way that ensures an optimal experience in GitHub Actions.

Please refer to the README files of those actions for more detailed information.

We intend to provide more actions in the future based on customer feedback.

We also maintain a [demo template repository](https://github.com/OrgFlow-Actions/demo) that contains a set of basic sample workflows that show how to use OrgFlow in GitHub Actions. The demo repository can be used in two ways:

- As a set of basic sample workflows that show how to use OrgFlow in GitHub Actions
- As a template repository that you can use as a starting point when creating your own repository