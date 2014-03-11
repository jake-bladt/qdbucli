## QDBUCLI - Contributing

To contribute to this project, fork it, make your changes, and issue a pull request.

Once you've forked it and cloned it, you will need to do `git submodule init` and `git submodule update` to bring down the libraries it uses.

App.config refers to an external config file for connection strings. This is done to protect the logins and passwords you might use for your datasources. To build successfully, add a new top-level config file to the qdbucli project called Secret.db.config with the following content:

```xml
<connectionStrings></connectionStrings>

This will become useful once database support is added.
