---
uid: troubleshooting_logging
title: Logging
---

Logging is the most important tool when troubleshooting issues with OrgFlow. To enable logging, you can use the following two arguments with any OrgFlow command:

- **`--logTo=<filePath>`**

  If specified, a log file is written to the specified path.

- **`--logLevel=[Verbose|Debug|Information|Warning|Error|Fatal]`**

  The minimum log level to be written to the log file; logs below this level will not be written. The default log level if not specified is `Information`.

When logging is enabled, a log file with the detail level you specify in the `--logLevel` argument is written to disk while the command executes. If the file already exists, new log data is appended to the end of the existing file.

## Tokens in log file paths

The `--logTo=<filePath>` argument can be used with any OrgFlow command to have OrgFlow write logs to a file on disk. When specifying this argument, the file path can contain one or more *tokens*. The following tokens are available:

| Token                               | Result
| ------------------------------------|--------------------------------------------------
| `{C}` or `{command}`                | Name of command being executed, e.g. `env:flowin`
| `{T:format}` or `{time:format}`     | UTC date and time of current command invocation (see below)
| `{U}` or `{user}`                   | Current local username
| `{M}` or `{machine}`                | Name of local machine/computer

The same token can be specified more than once if needed.

Tokens can be very useful when you want to vary the log file location and/or name based on things that vary, without having to specify a different value each time. This is most useful when specifying the log file path as a user setting or an environment variable, rather than directly as a command argument.

The `{T}`/`{time}` token needs to be specified with a format string that controls how the date is formatted into the log file path. Any standard or custom .NET DateTime format string is supported. Date and time formatting is performed using the current system locale. For more information, see:

- [Standard date and time format strings](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings)
- [Custom date and time format strings](https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings)

For example, the following `--logTo` argument:

```
--logTo=/orgflow/{user}/logs/{time:yyyy-MM-dd}/{command}-{time:HHmm}.log
```

would make OrgFlow log to a file path similar to:

```
/orgflow/richard/logs/2021-10-06/env-flowin-1648.log
```