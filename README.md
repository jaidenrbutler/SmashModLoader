# Smash Mod Loader

Smash Mod Loader is a tool for managing and launching mods for **Super Smash Bros. Ultimate** using the **Yuzu Emulator**. It allows users to easily install, enable/disable, and manage mods for the game, as well as set up their Yuzu emulator paths and mod folders.

---

## 🎮 Features

- **Mod Management**: Add, enable, disable, and remove mods with ease.
- **Plugin Management**: Automatically detect and manage Skyline plugins.
- **Yuzu Emulator Integration**: Select the path to your Yuzu executable and the game ISO for seamless launching.
- **Mod Folder Customization**: Overwrite the mod folder path to suit your needs.
- **Easy-to-Use Interface**: Simple and intuitive interface for quick setup and modding.

---

## 📥 Installation

### Pre-built Executable

1. Download the latest release from the [Releases Page](https://github.com/jaidenrbutler/SmashModLoader/releases).
2. Extract the `.zip` file to your preferred location.
3. Run `SmashModLoader.exe`.

 ## 🛠️ How to Use

Once you've set up `Smash Mod Loader`, follow these steps to start managing your mods and launch your game:

### 1. **Set Up Yuzu**

Before using the mod loader, you need to set the path for your Yuzu Emulator and the game ISO:

- **Open Settings**: Click the "Settings" button in the top menu.
- **Select Yuzu Executable**: In the settings page, click the "Set Yuzu Path" button to browse for your Yuzu executable (`yuzu.exe`).
- **Select Game ISO**: Set the path for your `Super Smash Bros. Ultimate` ISO file by clicking the "Set Smash ISO Path" button. This will allow the loader to know where to find your game.

### 2. **Install Mods**

To install mods, you can import `.zip` files that contain mods or plugins:

- **Import Mods**: Click on the "Import Mod" button. This will open a file dialog where you can select a `.zip` file. The tool will automatically extract the mod to the correct folders (mods or plugins).
- **Organize Files**: Mods will be placed in the mod folder, while `.nro` plugin files will be placed in the plugin folder.

### 3. **Manage Mods**

You can enable or disable mods easily through the interface:

- **Enable/Disable Mods**: In the mod list, right-click on the mod and choose "Enable" or "Disable" from the context menu. Disabled mods will be moved to the `disabled` folder, while enabled ones will remain in the main mod folder.
- **Enable/Disable Plugins**: Similarly, for Skyline plugins, you can enable or disable them by right-clicking and selecting the option from the context menu.

### 4. **Launch the Game**

Once you've set up everything:

- **Launch Yuzu**: Click the "Launch" button to open Yuzu with your selected game ISO and the active mods. The tool will use the paths you configured earlier to launch the game with the mods applied.

### 5. **Troubleshooting**

- **Yuzu Not Found**: If the "Launch" button doesn't work, make sure that you have correctly set the Yuzu executable path in the settings.
- **Mods Not Appearing**: Ensure that the mod files are correctly placed in the `mods` folder and that the mod format is compatible with the tool.
