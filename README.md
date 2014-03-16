## QDBUCLI
### (The quick-and-dirty backup command-line interface)

This is a command-line interface for using the [QDBackup](https://github.com/jake-bladt/QDBackup) library. It's a no-frills application for creating and running backup jobs. It's an example of how to use QDBackup and not deliberately meant as a viable stand-alone product. It currently runs as a REPL application although the intention is to make it fully scriptable.

Also, unless you see a master branch, it's not done yet. Don't rely on it for backing up valuable files yet.

### Contributing
This project relies on two other repos, both under active development. To bring down the full codebase, execute the following:
`git clone https://github.com/jake-bladt/qdbucli.git`
`cd qdbucli`
`git clone https://github.com/jake-bladt/QDBackup.git`
`git clone https://github.com/jake-bladt/ReplMvc.git`

In the main project, create a file called Secret.db.config with the following content:
```xml
<connectionStrings/>
```

To see a list of commands, start the application and type "list" (no quotes.)
