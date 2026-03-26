# Menu Manager Adapter

CounterStrikeSharp plugins that makes plugins built on top
of [MenuManagerCS2](https://github.com/NickFox007/MenuManagerCS2)
use [CS2MenuManager](https://github.com/schwarper/CS2MenuManager) instead.

## Features

- Render menus built with MenuManagerCS2 through CS2MenuManager
- Default menu configured in CS2MenuManager is respected

## Installation

1. Remove MenuManagerCS2 if installed already
2. Install CS2MenuManager if not already installed
3. Install MenuManagerAdapter

## Limitations

- Reset actions are not supported and will throw an exception if provided.
- Modifying the `ChatMenuOption`s returned by `IMenu.AddMenuOption`, `IMenu.MenuOptions`, etc. does nothing
- Manipulating `IMenu.MenuOptions` (e.g., adding, removing, etc.) does nothing
- MetaMod menus are not supported and attempting to use them will silently default to the default menu type of the calling player.

## How it works

Plugins using MenuManagerCS2 rely on a `PluginCapability` that provides an `IMenuApi`. This plugin provides an
alternative implementation of `IMenuApi` that forwards to CS2MenuManager.
