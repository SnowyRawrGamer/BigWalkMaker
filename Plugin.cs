using BepInEx;
using BepInEx.Unity.IL2CPP;
using Il2CppInterop.Runtime.Injection;
using BigWalkMaker.Builder;
using BigWalkMaker.Logic;
using BigWalkMaker.UI;

namespace BigWalkMaker;

[BepInPlugin(Guid, Name, Version)]
public sealed class Plugin : BasePlugin
{
    public const string Guid = "com.snowy.bigwalkmaker";
    public const string Name = "BigWalkMaker";
    public const string Version = "0.1.0";

    public override void Load()
    {
        ClassInjector.RegisterTypeInIl2Cpp<MainMenuPatch>();
        ClassInjector.RegisterTypeInIl2Cpp<PlacementController>();
        ClassInjector.RegisterTypeInIl2Cpp<TriggerSystem>();

        AddComponent<MainMenuPatch>();
        AddComponent<PlacementController>();
        AddComponent<TriggerSystem>();
        Log.LogInfo($"{Name} {Version} loaded");
    }
}
