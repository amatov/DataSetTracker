# Dependencies

The `.cs` and `.unity` files in this repository are reference source code
for a Unity project -- they are not a complete, buildable Unity project as
committed (there is no `Assets/`, `ProjectSettings/`, or `Packages/`
folder here). To open and build this code in Unity, you will need:

- **A Unity project skeleton** (create a new Unity project and add these
  scripts/scenes into it).
- **OpenCV for Unity** -- referenced via `using OpenCVForUnity;` in
  scripts such as `sku.cs`. Requires a separate paid license from Enox
  Software: https://enoxsoftware.com/
- **PlayFab SDK** -- referenced via `using PlayFab;` /
  `using PlayFab.ClientModels;` in the login/purchase scripts
  (`playFabLogin.cs`, `PlayFabPurchaseScript.cs`, `playFabSKU.cs`,
  `PlayFabIsLoggedIn.cs`). See https://playfab.com/
- **MaterialUI** -- referenced via `using MaterialUI;` in `UXPlayFab.cs`.

None of these are bundled here due to their license terms.

## To just run the application (no Unity/build required)

See [release/README.md](release/README.md) -- download the prebuilt
Windows application instead of building from source.
