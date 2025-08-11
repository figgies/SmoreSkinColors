using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace ColorMod
{
    [BepInAutoPlugin]
    public partial class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log { get; private set; } = null!;
        private void Awake()
        {
            Log = Logger;
            Log.LogInfo($"Plugin {Name} is loaded!");
            this._harmony.PatchAll(typeof(Plugin.Patcher));
        }

        private readonly Harmony _harmony = new Harmony("figgies");

        private class Patcher
        {
            private static bool CreateSkinOption(Customization customization, string name, Color color)
            {
                if (Array.Exists<CustomizationOption>(customization.skins, (CustomizationOption skin) => skin.name == name) || Array.Exists<CustomizationOption>(customization.skins, (CustomizationOption skin) => skin.color == color))
                {
                    return false;
                }
                CustomizationOption skinOption = ScriptableObject.CreateInstance<CustomizationOption>();
                skinOption.color = color;
                skinOption.name = name;
                skinOption.texture = customization.skins[0].texture;
                skinOption.type = Customization.Type.Skin;
                customization.skins = CollectionExtensions.AddToArray<CustomizationOption>(customization.skins, skinOption);
                return true;
            }

            [HarmonyPatch(typeof(PassportManager), "Awake")]
            [HarmonyPostfix]
            private static void PassportManagerAwakePostfix(PassportManager __instance)
            {
                Customization customization = __instance.GetComponent<Customization>();

                Plugin.Patcher.CreateSkinOption(customization, "Skin_FireBrick", new Color32(178, 34, 34, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_SurskitBlue", new Color32(105, 190, 226, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Teal", new Color32(0, 128, 128, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_CoralPink", new Color32(248, 131, 121, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Lavender", new Color32(220, 208, byte.MaxValue, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_MintGreen", new Color32(186, byte.MaxValue, 171, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Vanilla", new Color32(243, 229, 171, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Chocolate", new Color32(132, 86, 60, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Strawberry", new Color32(252, 90, 141, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_PastelOrange", new Color32(byte.MaxValue, 156, 89, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_PastelBlue", new Color32(167, 199, 231, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_PastelPink", new Color32(253, 180, 187, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_WildBerry", new Color32(36, 21, 113, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Sapphire", new Color32(82, 178, 191, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Aquamarine", new Color32(123, 253, 199, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Rose", new Color32(227, 36, 43, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Ruby", new Color32(144, 6, 3, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Blush", new Color32(188, 84, 75, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Pear", new Color32(209, 226, 49, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Pickle", new Color32(89, 125, 53, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Pine", new Color32(35, 79, 30, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Parakeet", new Color32(3, 192, 74, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Orchid", new Color32(218, 112, 214, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Heather", new Color32(158, 123, 181, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Honey", new Color32(249, 201, 1, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_BurntSienna", new Color32(187, 55, 38, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Clay", new Color32(137, 49, 1, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_Black", new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 1));
                Plugin.Patcher.CreateSkinOption(customization, "Skin_White", new Color32(0, 0, 0, 1));
            }
        }
    }
}
