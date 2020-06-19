---
id: guides_coreconcepts
title: Core Concepts
sidebar_label: Core Concepts
---

OrgFlow takes advantage of the Git source control system to track the changes that you make in your Salesforce orgs. All of the metadata that you choose to flow with OrgFlow ultimately ends up in your Git repository. If you're familiar with Git, a lot of OrgFlow's core concepts will already be familiar to you. No need to worry though if you're not familiar with Git, as you should be able to get up and running with OrgFlow in no time at all.

If you come across a term that you don't understand, our [terminology](guides_terminology) page should have you covered.

## Your metadata, environments, and stacks.
OrgFlow moves your Salesforce **metadata** between sandboxes and your production org. We call these movements **flows**. In order to facilitate these **flows**, OrgFlow also moves your **metadata** from your Salesforce **orgs** to your **Git repository**. We call these movements **flows**, too. OrgFlow can also move **metadata** from your **Git repository** into your Salesforce **org**. Again, we call this movement a **flow**.

So, that means that there are three ways that OrgFlow can can **flow** your **metadata**:
1. `In` from your **org** to your OrgFlow **Git repository**. 
2. `Out` from your OrgFlow **Git repository** to your **org**.
3. `Merge` from one **org** to another (i.e. move metadata changes between **orgs**). 

Your **Git repository** stores the **metadata** for each org in a **branch**. Each **org** is linked to its own **branch**, this means that changes from one **org** are **flowed** in to the **branch** that is linked to that **org**. That way, you're able to make changes in one **org**, without the changes affecting other **orgs**. We call this an **environment**.

In its simplest form, an **environment** is just an **org** that is linked to a Git **branch**. Under the hood, OrgFlow also stores some other data about your **environment**; this data is required to help OrgFlow operate effectively.

All of your environments together belong to a **stack**. A **stack** will contain exactly one **production environment**, but can contain as many **sandbox environments** as you need. All of the **environments** in a **stack** are linked to the same **Git repository**, but each will be linked to a different **branch** in that **repository**.

OrgFlow does not place restriction on how you change **metadata**. You are free to make changes directly to your production **org** if you'd like to. Changes made directly in Salesforce are still compatible with changes made in other sandboxes, and they're even compatible with changes made directly in Git. OrgFlow will always merge changes, as opposed to overwriting them.

## Commands
Actions in OrgFlow are called commands. When you want to flow changes in, you can use the `flow:in` command. When you want to merge changes from one environment to another, you can use the `flow:merge` command. And when you want to run the tests in your org, you can use the `tool:test` command.

There are many commands in OrgFlow, and some may seem overwhelming at first. It's important to remember that you'll likely only need a small number of these commands in your day to day usage.

## Composable building blocks 
OrgFlow has been designed from the ground up to be composable. But what does that mean?

We see OrgFlow as a flexible tool that can be moulded to suit your current working patterns and tools. Conversely, OrgFlow can be used to open up new possibilities to help streamline your processes.

This flexibility comes from OrgFlow's composable design. At the heart of this design is the Command Line Interface (**CLI**). The **CLI** allows you to run a number of commands. Some of those commands perform simple tasks (things like download your **metadata**, run some tests etc...), and some perform more complicated tasks (things like setting up a new **environment**, merging changes from one **environment** to another etc...). The more complicated tasks are actually just a bunch of the simpler tasks strung together into a cohesive process.

We call the simpler tasks **action commands**, and the more complicated tasks are called **flow commands**. There are only a handful of **flow commands**, and you would be able to get a lot out of OrgFlow by using only the **flow commands**. The **action commands** provide you with the same building blocks that we used to build the **flow commands** (should you want to use them). This composability is one the the strengths of OrgFlow.

The **CLI** that contains all of these commands is itself a composable building block. You can take the **CLI** and build on top of it. We have built the VSCode extension on top of the **CLI**, and we plan to build a number of other integrations on top of it too.

Some of our customers have automated their deployment processes using scripting languages such as Powershell or bash. Some have integrated OrgFlow in to external build or deployment tools such as Jenkins, Teamcity, or Azure DevOps.