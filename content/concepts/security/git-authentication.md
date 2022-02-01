---
uid: guide_git_authentication
title: Handling authentication
---

When OrgFlow calls into Git, Git will need to be able to authenticate with your @concept_remotegitrepository. If you can use Git on the device that you are running OrgFlow to clone and push to your remote Git repository (without Git prompting for credentials), then this is already working as required.

However, this may not always be the case, especially on ephemeral devices that can get torn down between uses (for example, build agents). Luckily, there are several approaches that you can take to rectify this. The approach that you choose will depend a bit on your requirements, as well as the authentication techniques that you have available to you. One of the biggest influences in your approach will be whether or not the device you are running OrgFlow on is ephemeral or not, so for that reason, this guide is split into two sections: [permanent devices](#git-authentication-on-permanent-devices), and [ephemeral devices](#git-authentication-on-ephemeral-devices).

>[!TIP]
> Always remember that OrgFlow needs to be able to **read** and **write** to the remote Git repository. The credentials that you use should allow this.

## Git authentication on permanent devices

These Git authentication techniques are recommended for devices that are long-lived, so you can configure once and have that configuration persist over multiple invocations of OrgFlow.

### Manual authentication configuration

The preferred (and simplest) method for long-lived devices is to manually authenticate once, and then rely on Git to re-use your credentials. The key here is to get Git to a point where it can authenticate *without* having to prompt for credentials (OrgFlow cannot relay these prompts to you).

#### SSH key

If you can, you should add a personal ssh key to allow you to authenticate with the remote Git repository. The basic premise is:

1. You generate a new SSH key on your device
1. You add the newly generated SSH key to your device's SSH agent
1. You add the key to your account in your Git provider

How you do these steps (especially the last step) will depend on the provider of your remote Git repository. You should consult the documentation for your specific provider (for example, here is [GitHub's](https://docs.github.com/en/github/authenticating-to-github/connecting-to-github-with-ssh/generating-a-new-ssh-key-and-adding-it-to-the-ssh-agent)).

#### Credential helper

Another option you have is to use a Git credential helper. A Git credential helper is a small piece of software that can tell Git your credentials for a remote Git repository (if it knows them). Git ships with two credential helpers- `cache` and `store`, however these are not recommended because they are less secure than some other options available.

Other credential helpers (usually from third parties) are favoured because they are more secure, and have better support for native authentication experiences (such as opening up an OAuth dialog to log in to your Git provider, etc.).

[Git Credential Manager Core](https://github.com/microsoft/Git-Credential-Manager-Core) is a cross-platform Git credential helper from Microsoft. Other, platform-specific credential helpers include **Keychain** for macOS, or **Secret Service** or **pass** for Linux.

Installation and configuration of these credential helpers are well documented, and your favorite search engine should be able to help you find a good guide.

### Running OrgFlow in a Docker container on a device that already has SSH authentication configured

If you are running OrgFlow in a Docker container running on a device that already has SSH authentication configured, then you can use your SSH keys from within the container by mounting your SSH folder into the Docker container when you spin it up.

```bash
docker run -it --rm
  --mount type=bind,source=/Path/To/Your/.ssh,target=/root/.ssh
  orgflow/cli
```

### Other authentication options

Some of the authentication options listed below (for ephemeral devices) would also work on permanent devices, but we do not recommend them.

## Git authentication on ephemeral devices

These Git authentication techniques are recommended for devices that are short-lived, where you must reconfigure for every invocation of OrgFlow, or where you are unable to manually intervene to answer prompts or add configuration.

The techniques are listed in order: most recommended to least recommended. The most recommended techniques follow up to date good practices, and keep the authentication secret close to the point that it is being consumed. As the list goes on, the authentication secret is stored further and further away from the point of consumption.

### Platform-native authentication

This technique involves using the authentication mechanism that is natively provided by the platform that is orchestrating your OrgFlow workflows. This should be your first choice when it comes to remote Git repository authentication, but not all platforms provide a way to do this, so be prepared to have to fall back to one of the other techniques if need be.

This authentication method relies on an assumption that you are running OrgFlow via a platform that already has a built-in mechanism for cloning repositories. This is common for CI/CD tools that would first clone a repository and then build or test it etc. Some of these platforms allow you to re-use their remote Git repository authentication mechanism for later re-use. Although you may have to perform a couple of steps to be able to do this.

You should consult the documentation for your particular build platform, but we've provided a couple of examples below to help you understand the requirements:

#### GitHub Actions

GitHub Actions have access to a secret called [`GITHUB_TOKEN`](https://docs.github.com/en/actions/reference/authentication-in-a-workflow). This secret contains a an ephemeral token (it is created when the workflow begins, and then rescinded when the workflow ends) that can be used to authenticate with the current GitHub repository over HTTPS. Because it it ephemeral, you cannot store this token in the state store. Instead, you should use the @command_auth_git_save command to cache the token locally and then add OrgFlow as a Git credential helper.

We provide a GitHub Action [(orgflow-actions/configure-git)](https://github.com/OrgFlow-Actions/configure-git) that can do this for you:

```yaml
- uses: orgflow-actions/configure-git@v2
  with:
    stack-name: ${{ secrets.ORGFLOW_STACKNAME }}
    token: ${{ secrets.GITHUB_TOKEN }}
    license-key: ${{ secrets.ORGFLOW_LICENSEKEY }}
```

Some OrgFlow commands need to be able to push changes back to the remote Git repository. You will need to ensure that GitHub issues a token that allows this if you want to use these commands. There are two ways to do this:

1. From the Web UI for your GitHub repository, go to `SETTINGS` > `ACTIONS` > `WORKFLOW PERMISSIONS`, and make sure that `READ & WRITE PERMISSIONS` is selected.
2. Add the [permissions section](https://docs.github.com/en/actions/reference/workflow-syntax-for-github-actions#permissions) to your workflow's YAML:

  ```yaml
  permissions:
     contents: write
  ```

### Shared SSH key with passphrase

If you'd like to use SSH to communicate with your remote Git repository from an ephemeral device, we'd advise protecting your SSH key with a passphrase that you store in a secret store. Then you'd add the SSH key to the ephemeral device after it has been spun up (you could keep the key in a known location accessible to the device, or within a secret store if you have a store that can support this).

Finally, you should set up your process so that the passphrase for the key can be read from your secret store.

### Use Git config to substitute an access token into the remote Git repository URL

If your remote Git repository supports token-based authentication in the URL and you know the remote Git repository's URL, then you may be able to configure Git to substitute the access token into the URL:

1. Add your access token to a secret store provided by the platform you are using.
1. When you spin up an ephemeral environment, pass the token in as an environment variable (e.g. `TOKEN=xxxxxxxxxxxxxxxx`).
1. Configure Git to substitute the remote Git repository URL for your particular stack for a URL that contains the token. (e.g. `git config --global url."https://api:$TOKEN@github.com/".insteadOf "https://github.com/")`. You'll need to do this once per ephemeral device, and before you run OrgFlow for the first time on that device.

Of course, for this to work, your remote Git repository must support authentication with URL based tokens.

>[!TIP]
> You may need to configure Git with a few URL substitutions in order to cover all possible protocols.
>
> ```bash
> git config --global url."https://api:$TOKEN@github.com/".insteadOf "https://github.com/"
> git config --global url."https://ssh:$TOKEN@github.com/".insteadOf "ssh://git@github.com/"
> git config --global url."https://git:$TOKEN@github.com/".insteadOf "git@github.com:"
> ```

### OrgFlow's native Git credential helper

If all else fails, OrgFlow provides the @command_auth_git_credentialhelper command for you to fall back on. This is a [Git Credential Helper](https://git-scm.com/docs/gitcredentials) that can be added to Git's configuration to allow Git to query OrgFlow for a username and password (or an access token):

1. Run the @command_auth_git_save command to save the credentials required for access to the remote Git repository. Make sure that you keep a copy of the encryption key that you used (you'll need it later).
1. Add @command_auth_git_credentialhelper as a Git Credential Helper every time you spin up an ephemeral device to run OrgFlow, passing in the encryption key used in step 1 so that your credentials can be decrypted (you'll need to do this before you run any other OrgFlow commands) `config --global credential.helper "!orgflow auth:git:credentialhelper -k=<encryptionKey>"`.

>[!WARNING]
> If a Git Credential Helper is able to provide valid credentials for a particular remote Git repository, then Git will try to propagate those credentials to all other registered Credential Helpers.
>
> This can sometimes be useful (e.g. to push valid credentials into the `cache` Credential Helper), but you should be careful to avoid accidentally overwriting credentials in one Credential Helper with those in another. The best way to do this is to make sure that you only configure the Credential Helpers that you actually need.
>
> Some Credential Helpers are read-only (including OrgFlow's), so this propagation will have no effect on them. However, some other Credential Helpers also allow Git to write credentials to their stores. This is one of the reasons that we don't recommend using OrgFlow's Git Credential Helper on personal devices that are likely to have other Credential Helpers already installed.

## Other options

As a general rule, if you can use `git` to read from and write to your remote Git repository on a particular device (without `git` prompting for your credentials), then OrgFlow will be able to do so too. Feel free to achieve this in any way that best suits your use case. Here's a [fairly comprehensive guide](https://coolaj86.com/articles/vanilla-devops-git-credentials-cheatsheet/) covering this topic.
