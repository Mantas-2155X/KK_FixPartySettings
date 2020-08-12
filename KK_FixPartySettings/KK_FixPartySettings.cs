using BepInEx;
using HarmonyLib;

using UnityEngine;

namespace KK_FixPartySettings
{
    [BepInProcess("Koikatsu Party")]
    [BepInPlugin(nameof(KK_FixPartySettings), nameof(KK_FixPartySettings), VERSION)]
    public class KK_FixPartySettings : BaseUnityPlugin
    {
        public const string VERSION = "1.0.0";

        private void Awake() => Harmony.CreateAndPatchAll(typeof(KK_FixPartySettings), nameof(KK_FixPartySettings));

        [HarmonyPrefix, HarmonyPatch(typeof(ConfigScene), "Start")]
        public static void ConfigScene_Start_ChangeDisplay(ConfigScene __instance, ConfigScene.ShortCutGroup[] ___shortCuts)
        {
            var arr = Traverse.Create(___shortCuts[6]).Field("_trans").GetValue<RectTransform[]>();
            arr[0] = __instance.transform.Find("Canvas/imgWindow/ScrollView/Content/Node Addtional_20").GetComponent<RectTransform>();
        }
    }
}