using BepInEx;
using HarmonyLib;
using UnityEngine;
using InControl;
using PlayerActionsHelper;
using UnboundLib.Networking;
using UnboundLib;

[BepInDependency("com.willis.rounds.unbound")]
[BepInDependency("pykess.rounds.plugins.moddingutils")]
[BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch")]
[BepInDependency("com.CrazyCoders.Rounds.RarityBundle")]
[BepInDependency("root.rarity.lib")]
[BepInDependency("root.cardtheme.lib")]
[BepInDependency("com.rounds.willuwontu.ActionHelper")]
[BepInPlugin(ModId, ModName, Version)]
[BepInProcess("Rounds.exe")]

public class CatsCards : BaseUnityPlugin
{
    private const string ModId = "com.CatsCards.Cats";
    private const string ModName = "Cats Cards";
    public const string Version = "0.0.0";
    internal static string modInitials = "Cats";
    internal static AssetBundle assets;
    internal static CatsCards instance;
    
    void Awake()
    {
        var harmony = new Harmony(ModId);
        harmony.PatchAll();
        instance = this;
        assets = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("assetbundle", typeof(CatsCards).Assembly);
        assets.LoadAsset<GameObject>("ModCards").GetComponent<CardHolder>().RegisterCards();

        PlayerActionManager.RegisterPlayerAction(new ActionInfo("SwitchHoldable", new KeyBindingSource(Key.LeftShift),
            new DeviceBindingSource(InputControlType.DPadDown)));
    }    

}