***

The following options are global across all commands:

- **`-h|--help`**

  If specified, prints help for this command instead of executing it.

- **`-l|--licenseKey=<key>`**

  The @concept_licensekey you were issued to allow you to use the OrgFlow CLI. If a valid key is supplied, it is stored locally on the machine so that it does not need to be specified again on the next execution.

- **`--acceptEula`**

  If specified, you are signifying that you accept our End User License Agreement (EULA). You only need to specify this once per device, because your acceptance will be cached on the device (you can pass `--acceptEula=false` if you wish to clear this). You must accept our EULA to be able to run most OrgFlow commands.

- **`--logTo=<filePath>`**

  If specified, a log file is written to the location given.

- **`--logLevel=[Verbose|Debug|Information|Warning|Error|Fatal]`**

  Default: `Information`

  The minimum log level to be written to the log file; logs below this level will not be written. Only effective if a valid value for `--logTo` has been specified.

- **`--diagnostic=[Auto|Always|Never]`**

  Default: `Auto`

  If the CLI encounters an exception then it will ask (where possible) the user whether or not to create a @concept_diagnosticbundle and write it to disk. If it is not able to prompt then no action is taken. This is the default behaviour (`Auto`).

  You can change this default behaviour (and suppress the prompt) by specifying either `Always` or `Never` (which will always write the bundle or never write the bundle, respectively). This is particularly useful in a CI/CD context, where the CLI may not be able to prompt, but you still want to create diagnostic bundles for all failures.

- **`--diagnosticDirPath=<directoryPath>`**

  If specified, sets the location to write the @concept_diagnosticbundle (if any). If not specified, a default location will automatically be chosen. This default location depends on a number of factors, including the operating system and some file-system based restrictions that might be in place. The location that the diagnostic bundle is ultimately written to is always included in the standard error output of the CLI.

- **`--noConfirm`**

  If specified, suppresses confirmation prompts that the CLI might raise before performing destructive or dangerous procedures. If suppressed, the CLI assumes that the prompts would have been answered positively and continues with execution.

- **`--progress=[Interactive|Never|Always]`**

  Default: `Interactive`

  Controls how progress is printed to the standard error stream:
  - `Interactive`: Progress is sent to the standard error stream only if the standard error stream is connected to an interactive terminal.
  - `Never`: Progress is not sent to the standard error stream.
  - `Always`: Progress is sent to the standard error stream, even if that stream has been redirected.

- **`--tempDir=<directoryPath>`**

  If specified, sets the location to use as storage for files that may need to be stored on disk temporarily during command execution. For example, the location on disk where zip files containing metadata from Salesforce are downloaded to before they are unzipped.

  If not specified, the CLI will automatically choose an appropriate location on disk (usually in the current user's temporary storage location). This automatically chosen location may be deeply nested within a drive, which may be problematic if the operating system imposes limits on file path lengths and the files placed into temporary storage have particularly long paths or names.

- **`--output=[Pretty|Flat|Json]`**

  Default: `Pretty`

  Controls the format of the output sent to the standard output stream:
  - `Pretty`: The output is designed to be read by humans. It may contain visual indicators to help you understand the data, such as colored text, indentation, symbols.
  - `Flat`: The output is designed to be easy to copy and paste into another application or format.
  - `Json`: The output is serialized into a structured JSON object that is designed to be consumed by another process or application. This is the most verbose output available, and is useful for scripting or automation.

- **`--forceSignIn`**.

  If specified, the CLI will ignore any cached Salesforce access tokens, and will require the Salesforce authentication process to be re-completed for each organisation that the command connects to.

- **`--maxTransientErrorRetries=<count>`**.

  If no value is specified, the CLI will indefinitely retry any process that fails due to a transient error. This is the default behaviour, and allows for resilience against temporary issues that might otherwise cause a process to fail.

  Specify a positive integer value to prevent indefinite retries. Each process that fails due to a transient error will be retried up to a maximum amount of times specified. For example, `--maxTransientErrorRetries=5`: Each process that fails will be re-tried up to a maximum of five times. If an earlier process fails four times but then succeeds on the fifth attempt, the counter is reset for the next process.

  Specify `--maxTransientErrorRetries=0` to disable transient failure retries.

- **`--maxTransientErrorDelay=<seconds>`**.

  Default: `60`

  Processes retried due to a transient error are delayed by a back-off policy that gradually increases the time to wait between retries. Specify a non-negative integer value as the maximum amount of seconds to wait between attempts.

  Specify `--maxTransientErrorDelay=0` to disable the back-off policy and always instantly retry failed processes.
