---
id: guides_git
title: Your Git Repository
sidebar_label: Your Git Repository
---

OrgFlow needs access to a **Git repository** to store your **metadata**. There are many different providers of **Git repositories**, and OrgFlow supports every single one. And because OrgFlow runs on-premises, you could even use an internal Git server if your company requires it.

When you initialize your **stack**, OrgFlow will ask you for the URL to access your **repository**. You will also need to tell OrgFlow the name of the **branch** that will be linked to your **production environment**. OrgFlow remembers this information, so you don't need to re-enter it each time you run a command. It's common to use your default or primary **branch** (sometimes called the master branch) for your **production environment**, but you can use any existing **branch**, or you could even have OrgFlow create a new **branch**.