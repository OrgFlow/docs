---
uid: concept_mergebasedcommitstrategy
title: Merge-Based Commit Strategy
---

OrgFlow's merge-based commit strategy allows you to make changes to metadata in a Salesforce org, and merge them with changes made in the @concept_remotegitrepository. This means that different changes to the same metadata item can be made in various places (production Salesforce organization, sandboxes, or directly in Git), and those changes can be effectively merged together. If you're familiar with Git, this is similar to Git's ability to merge changes between different branches.

This merge-based strategy can be applied to almost any metadata type, including Apex classes & triggers, custom objects, custom fields, and almost anything else that you can think of. The exceptions to this are anything that is simply a binary file (i.e. documents etc).

## Sandbox to Git example

Let's say you have an Apex class in an @concept_environment. The class would exist in both the Salesforce sandbox, and the @concept_backinggitbranch:

```apex
public class MyClass
{
  public string SayHello()
  {
    return "Hello";
  }
}
```

Now, you update the class file in the Git branch:

```apex
public class MyClass
{
  private static final string hello = "Hello!";

  public string SayHello()
  {
    return hello;
  }
}
```

At the same time, someone else updates the Apex class in the Sandbox:

```apex
public class MyClass
{
  public string SayHello()
  {
    return "Hello";
  }
  
  public string SayGoodbye()
  {
    return "Goodbye";
  }
}
```

Other deployment tools would simply overwrite one of these Apex classes with the other if you attempted to commit the changes from Salesforce in to the Git branch. OrgFlow, however, will merge the changes; no work will be lost:

```apex
public class MyClass
{
  private static final string hello = "Hello!";

  public string SayHello()
  {
    return hello;
  }
  
  public string SayGoodbye()
  {
    return "Goodbye";
  }
}
```