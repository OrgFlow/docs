---
id: guides_terminology
title: Terminology
sidebar_label: Terminology
---

You will come across a number of familiar, and a number of unique terms throughout this documentation:

## Org
A Salesforce organisation. This might be your production Salesforce site, a sandbox, or a scratch org.

## Metadata
A Salesforce concept; **metadata** is the term used to describe the structure of your objects, fields, layouts, and more.

## Git Repository
An external source version control store. All of the **metadata** that OrgFlow controls is stored in your **Git repository**; and a **Git repository** is required for OrgFlow to function.

The **Git repository** is external to OrgFlow, which means that you can choose any provider that you like. OrgFlow works with [GitHub](https://github.com/), [BitBucket](https://bitbucket.org/), [GitLab](https://about.gitlab.com/), [Azure DevOps](https://azure.microsoft.com/en-gb/services/devops/), your own internal Git server, or any other Git service.

## Branch
A Git concept; a **branch** encapsulates a set of code changes. A **branch** allows you to change **metadata** without affecting the main (or production) **metadata**. A change in a **branch** can be moved between other **branches** as required. This is one of the core concepts of Git that OrgFlow uses to **flow** your changes between **environments**.

## Environment
OrgFlow combines an **org** with a **branch** to create an **environment**. You can then use OrgFlow to move (or **flow**) the **metadata** between **environments**, or from the **org** to the **branch** and vice versa.

## Production Environment
An **environment** that is linked to your production Salesforce **org**. OrgFlow does not prevent you from making changes directly to your production Salesforce site; in fact, we encourage it. Changes you make directly to production can be **flowed** between **environments**, just like any other **environment**.

## Sandbox Environment
An **environment** that is linked to either a sandbox Salesforce **org**, or a scratch org.

## Flow
The process of moving **metadata** with OrgFlow. There are two types of **flows** within OrgFlow:

### Horizontal
A **flow** of **metadata** between the **org** and the **branch** (i.e. the **metadata** does not leave the target **environment**).

### Vertical
A **flow** of **metadata** between **environments** (i.e. the **metadata** changes from one **environment** are moved to another **environment**).

## Stack
All of your **environments** belong to a **stack**. The **stack** will contain exactly one **production environment**, and can contain as many **sandbox environments** as you need. All of the **environments** in a **stack** will be backed by the same **Git repository**.

OrgFlow also stores a small amount of other data in your **stack**. This extra data allows OrgFlow to automate a few tasks, to make things a bit easier for you.

## Command Line Interface (CLI)
A Command Line Interface (or **CLI**) is a software tool that takes its input from text that the user types. **CLIs** are extremely flexible as they allow you to write scripts to automate a lot of your tasks, freeing up your time from repetition, and reducing the risks of manual errors. 