---
uid: command_env_list
title: env:list
---

## Description

List environments in the selected @concept_stack.

> [!TIP]
> The `--json` switch on this (and every other) command causes OrgFlow to print the output of the command in JSON format, so that it can be read and parsed by subsequent steps in a script or pipeline.

## Options

[!include[StackOption](partials/stack-option.md)]

- **`--withTags=name[:value][,name[:value],...]`**

  List only environments matching the specified tags. Multiple tags specifiers are combined using boolean `AND` logic (i.e. only environments matching **all** of the specified tags are included). Tag names and tag values are matched case-insensitively. Omitting a tag value matches only tags with no value. `--withTags` and `--withoutTags` specifiers are combined using boolean `AND` logic; having the same tag spec in both arguments results in no environments being listed.

- **`--withoutTags=name[:value][,name[:value],...]`**

  List only environments **not** matching the specified tags. Multiple tags specifiers are combined using boolean `AND` logic (i.e. only environments matching **none** of the specified tags are included). Tag names and tag values are matched case-insensitively. Omitting a tag value matches only tags with no value. `--withTags` and `--withoutTags` specifiers are combined using boolean `AND` logic; having the same tag spec in both arguments results in no environments being listed.

- **`--useRegex`**

  If specified, regular expression syntax can be used in tag values in `--withTags` and `--withoutTags` arguments for more flexible matching.

> [!TIP]
> If the filtering options provided by the `--withTags`, `--withoutTags` and `--useRegex` arguments are insufficient for your scenario, use the `output=json` argument to list arguments in JSON format and do your own filtering, using your scripting language or a tool such as [jq](https://stedolan.github.io/jq/).

- **`--nameOnly`**

  If specified, only the names of matching environments are printed; all other environment information is omitted. By default, the environment names will be printed as separate lines with no other formatting or delimiters (useful for parsing into a simple array in most common shells to loop over environments). With `--json` the environment names will be printed as a JSON array of strings.

[!include[EncryptionKeyOption](partials/encryption-key-option.md)]

[!include[HostOptions](partials/host-options.md)]

## Examples

List all environments in the @concept_defaultstack in tabular format:

```bash
orgflow env:list
```

***

List all environments in a stack called `backup` in JSON format:

```bash
orgflow env:list --stack=backup --json
```

***

List only the names of all environments in the @concept_defaultstack:

```bash
orgflow env:list --nameOnly
```

***

List the names of all environments with tags `category:development` and `isFullSandbox`:

```bash
orgflow env:list --nameOnly --withTags=category:development,isFullSandbox
```

***

List all environments with an `ownerEmail` tag whose value ends with `@mycompany.com`, using regular expression matching:

```bash
orgflow env:list --withTags="ownerEmail:.*@mycompany.com" --useRegex
```