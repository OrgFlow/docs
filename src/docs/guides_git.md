---
id: guides_git
title: Your Git Repository
sidebar_label: Your Git Repository
---

OrgFlow needs access to a **Git repository** to store your **metadata**. There are many different providers of **Git repositories**, and OrgFlow supports every single one. And because OrgFlow runs on-premises, you could even use an internal Git server if your company requires it.

When you initialize your **stack**, OrgFlow will ask you for the URL to access your **repository**. You will also need to tell OrgFlow the name of the **branch** that will be linked to your **production environment**. OrgFlow remembers this information, so you don't need to re-enter it each time you run a command. It's common to use your default or primary **branch** (sometimes called the master branch) for your **production environment**, but you can use any existing **branch**, or you could even have OrgFlow create a new **branch**.

## Merge conflicts
A **merge conflict** occurs when an **environment** is **merged** into another, but OrgFlow and Git are not able to automatically **merge** all the changes. For example: if you change a field's label in one **environment**, and change the same field's label in another **environment**, then OrgFlow does not know which is the correct label to keep when **merging** those **environments**.

If you encounter a **merge conflict**, you will need to manually intervene to resolve it. You will need to choose which changes to keep, and which to discard. In the example above, you would need to choose which label to keep. If you're already familiar with Git, you will already know how to handle this. If you are not familiar with Git, there are lots of resources available online to explain how to resolve the **merge conflicts**.

## Portable metadata
OrgFlow takes several steps to reduce the amount of **merge conflicts** that you'll encounter. However, one of these steps will prevent the **metadata** in your **Git repository** from being deployable with other 3rd party tools. 

OrgFlow allows you to configure your **stack** so that you can disable this option if you need to - see the `--ensurePortable` option on the `stack:init` command. It's worth noting that you might encounter more **merge conflicts** if you use this option.