- **`--waitForLock=<minutes>`**

  The maximum amount of time to wait (in minutes) for environments currently locked by other users or OrgFlow instances to be released. Default is `0` (i.e. do not wait but rather fail this command immediately).

  Any command that mutates the state of an environment in any way always acquires an exclusive lock on that environment, to prevent other instances from trying to mutate the same environment simultaneously - something that could have unpredictable results. Particularly in scripted or CI/CD scenarios, it can be useful to have OrgFlow wait a certain amount of time for an already locked environment to become available, rather than failing immediately and requiring the script to be executed again.
