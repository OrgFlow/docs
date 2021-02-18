---
uid: concept_orgflowincludefile
title: .orgflowinclude File
---

The .orgflowinclude file contains the @concept_includespecs for @concept_stackbasedcommands. It can be found at the root of your @concept_remotegitrepository (i.e. `/.orgflowinclude'), which means that a full change history for this file will be available in Git should you ever need it.

- Each include spec is placed on its own line.
- The `#` character can be used to indicate the start of a comment.
- Empty (or whitespace) lines are valid, and will be removed from the parsed include specs.

Example:

```includespecs
# This is a full line comment.
# Include all unpackaged items:
unpackaged

# Exclude profiles:
!unpackaged/~/Profile

# Exclude some other things:
!DelegateGroup
!Queue
!Role # Comments can begin any where in a line
!ListView
!Skill
```
