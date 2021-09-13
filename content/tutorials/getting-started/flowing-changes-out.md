---
uid: guide_flowingchangesout
title: Flowing changes out
---

In the [previous chapter](xref:guide_flowingchangesin), we added a new object to a sandbox in Salesforce, and then used the @command_env_flowin command to commit that new object to the @concept_backinggitbranch in the @concept_remotegitrepository.

Now, we're going to move metadata in the other direction- from the remote Git repository and into the Salesforce sandbox. We'll use the @command_env_flowout command to do this.

## Making the change in the remote Git repository

We need to make a change to the metadata in the remote Git repository in order to then deploy it. How you do this is up to you. We're using GitHub in this guide, so we'll just go-ahead and make the change directly in there.

1. Find the `Vehicle__c.object` file and click to edit, so that we can update the description of this object.
1. Find the line with the `<description></description>` tags, and update it so that there is some text between those tags (`<description>This is the description of the Vehicle object</description>`).

## Execute the command

Open up a terminal window and run the following command: `orgflow env:flowout`. You'll be prompted for:

- The name of the environment to flow in. You made changes in the `sandbox/1` branch, and that branch backs the environment called `Env1`. Enter `Env1` at this prompt.

```termynal
$ orgflow env:flowout

?Name of environment to flow out:
=Env1

Comparing
%
Deploying
%
```

<!-- ![Flow vehicle out](images/flow-vehicle-out.gif) -->

## Check the results

We've successfully executed our first @command_env_flowout command, but what has actually happened?

- OrgFlow checked for any changes to the metadata in the backing Git branch (only for those object types that we include).
- It noticed that the `Vehicle` object had been updated.
- It then deployed that change to the Salesforce sandbox.

We can confirm that by looking at the object in the sandbox. Log in to the `OrgFlowSB1` sandbox, head to the setup and click to edit the `Vehicle` object. You should see that the description has been updated.

Now that we've flowed in and flowed out changes for a single environments, let's move on to [flowing metadata between environments](xref:guide_flowingchangesbetweenenvironments).
