# OrgFlow Docs

## Running Locally

[docs.orgflow.io](docs.orgflow.io) is powered by [DocFx](https://dotnet.github.io/docfx/).

1. Make sure you have NPM available on your device.
1. Make sure you have a [copy of DocFx](https://github.com/dotnet/docfx/releases) v2 available on your device.
1. Clone this repository.
1. From the root of the repository, run the following commands:
    ```
    npm install leap/
    npm build leap/
    docfx build --serve docfx.json
    ```
    A local copy of the site will be available at http://localhost:8080.
1. Update the content locally running site by running `docfx build docfx.json` after making changes.

### With VS Code

There are a number of tasks available to help make development with VS Code simpler:

1. Make sure you have NPM available on your device.
1. Make sure you have a [copy of DocFx](https://github.com/dotnet/docfx/releases) v2 available on your device.
1. Clone this repository and open in VS Code.
1. Run `npm install`.
1. Run the `build & serve` task. This builds the site and starts it at http://localhost:8080.
1. Use the `build` task to update the content of the site after you have made changes.
