---
uid: concept_includespecs
title: Include Specs
---

During the @concept_flowin and the @concept_flowout processes, OrgFlow needs to know which metadata items you would like to include in the process. The include specs are a declarative syntax that allows you to define rules as to which packages, namespace prefixes, types, and records should be included or excluded. Each individual rule is called an `include spec`, these individual rules can be combined into what is collectively called `include specs`. The order that each `include spec` appears within the `include specs` is important, as explained below.

## The Syntax

### Including Items

By default, all metadata items are excluded. The include spec syntax allows you to selectively include metadata items with the following syntax:

`<packageName>[/<namespacePrefix>[/<metadataTypeApiName>[/folder][/<metadataItemApiName>]]]`

- For unpacked items, use `unpackaged` as the `<packageName>`.
- For items without a namespacePrefix, use `~` as the `<namespacePrefix>`.
- `folder` is only valid (and required) for folderized metadata types (such as `report` and `document`).
- Matching is case-insensitive.
- Glob matching patterns are valid in all parts of the include spec, except for `packageName`. `packageName` must always be specified in its entirety.

Examples:

|Syntax|Includes|
|--|--|
|`unpackaged`|All unpacked types|
|`unpackaged/SBQQ`|All unpackaged types with namespace prefix `SBQQ`|
|`unpackaged/~`|All unpackaged types without a namespace prefix|
|`unpackaged/~/CustomObject`|All unpackaged custom objects without a namespace prefix|
|`unpackaged/*/CustomObject`|All unpackaged custom objects|
|`unpackaged/*/CustomObject/Account`|An unpackaged custom object called `Account` and all of its nested types|
|`unpackaged/*/Report/ReportFolder`|All unpackaged reports in a folder called `ReportFolder` |
|`unpackaged/*/ApexClass/Test_*`|All unpackaged Apex Classes that have a name that begins with `Test_` |

### Excluding Items

An include spec can be inverted by preceding it with the `!` character. An include spec that begins with `!` signifies that metadata items that match the spec should be excluded.

For example: `!unpackaged/~/ApexTrigger` would exclude all Apex Triggers that are unpackaged, and don't have a namespace prefix.

### Combining Include Spec Lines

Individual include spec lines are processed in the order in which they appear in the include specs as a whole. This means that it is possible to create a set of include specs that include a wide range of items, and then individually exclude particular items in a more fine-grained manner.

For example- include everything unpackaged, except for profiles and permissions sets:

```includespecs
unpackaged
!unpackaged/~/Profile
!unpackaged/~/PermissionSet
```

Include every unpackaged Apex Class without a namespace prefix, except for classes that begin with `Test_` (but include a class called `Test_Controller`):

```includespecs
unpackaged/~/ApexClass
!unpackaged/~/ApexClass/Test_*
unpackaged/~/ApexClass/Test_Controller
```
