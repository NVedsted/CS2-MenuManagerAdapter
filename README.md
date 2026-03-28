# Menu Manager Adapter

CounterStrikeSharp plugins that makes plugins built on top
of [MenuManagerCS2](https://github.com/NickFox007/MenuManagerCS2)
use [CS2MenuManager](https://github.com/schwarper/CS2MenuManager) instead.

## Features

- Render menus built with MenuManagerCS2 through CS2MenuManager
- Default menu configured in CS2MenuManager is respected

## Installation

1. If MenuManagerCS2 is already installed, remove its folder in `plugins` (do not delete its folder in `shared`).
2. Otherwise, download the latest version of MenuManagerCS2 and install the contents of its `shared` folder.
3. Install CS2MenuManager if not already installed
4. Install MenuManagerAdapter & MenuManagerCore plugins

**Expected file structure:**
```
+---plugins
|   +---CS2MenuManager_MenuManager (original from CS2MenuManager)
|   +---MenuManagerAdapter (this plugin)
|   \---MenuManagerCore (fake plugin)
\---shared
    +---CS2MenuManager (original from CS2MenuManager)
    \---MenuManagerApi (original from MenuManagerCS2)
```

## Limitations

- Reset actions are not supported and will throw an exception if provided.
- Modifying the `ChatMenuOption`s returned by `IMenu.AddMenuOption`, `IMenu.MenuOptions`, etc. does nothing
- Manipulating `IMenu.MenuOptions` (e.g., adding, removing, etc.) does nothing
- MetaMod menus are not supported and attempting to use them will silently default to the default menu type of the calling player.

## How it works

Plugins using MenuManagerCS2 rely on a `PluginCapability` that provides an `IMenuApi`. This plugin provides an
alternative implementation of `IMenuApi` that forwards to CS2MenuManager.

To play nicely with plugins that check if `MenuManagerCore` is present in the filesystem, a fake plugin is created that does nothing and can be placed to silence errors.
