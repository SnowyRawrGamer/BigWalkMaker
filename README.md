# BigWalkMaker

BigWalkMaker is a BepInEx 6 IL2CPP mod for Big Walk that adds a custom puzzle editor and playable custom levels.

## Features

- Adds a Custom button to the main menu.
- Level manager lists saved `.json` levels with Play and Edit actions.
- Create New Level names a level and enters the builder sandbox.
- Import via Code / JSON accepts pasted share codes or JSON level definitions.
- Builder supports flight, raycast placement, basic blocks, and interactive objects.
- Trigger links connect buttons and plates to doors, bridges, and other targets by stable GUID.

## Architecture

- `Plugin.cs`: BepInEx entry point and lifecycle wiring.
- `UI/MainMenuPatch.cs`: main-menu button and level-manager dialog (IMGUI scaffold).
- `Builder/PlacementController.cs`: editor camera movement and raycast placement.
- `Logic/TriggerSystem.cs`: trigger-to-target wiring and runtime activation.
- `Data/LevelData.cs`: JSON-serializable level schema and file persistence.

## Build

1. Install the .NET 6 SDK.
2. Set `BIGWALK_MANAGED_DIR` to Big Walk's `*_Data/Managed` directory.
3. Set `BEPINEX_ROOT` to the BepInEx installation directory.
4. Run `dotnet restore` and `dotnet build -c Release`.
5. Copy `bin/Release/net6.0/BigWalkMaker.dll` to `BepInEx/plugins/BigWalkMaker/`.

The project references Unity and BepInEx assemblies from those local installation paths; no game binaries are redistributed.
