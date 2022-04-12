using System.Reflection;
using System;
using MelonLoader;
using HarmonyLib;

[assembly: MelonInfo(typeof(meow.MyMod), "Toggel protals", "1.0", "Geri")]
[assembly: MelonColor(ConsoleColor.Yellow)]
[assembly: MelonGame("VRChat", "VRChat")]

namespace meow

{
    public class MyMod : MelonMod
    {
        public static MelonLogger.Instance Logger;
        public override void OnApplicationStart()
        {   
            Logger = new MelonLogger.Instance("PortalToggle", ConsoleColor.Yellow);
            
            settings.Settings();

            try
            {
                HarmonyInstance.Patch(
                        typeof(PortalInternal).GetMethod("Method_Public_Void_0", BindingFlags.Public | BindingFlags.Instance),
                        new HarmonyMethod(GetType().GetMethod("OnPortalEnter", BindingFlags.Static | BindingFlags.NonPublic))
                );
            }
            catch (Exception ex)
            {
                Logger.Msg(ex.ToString());
                Logger.Msg("Something went wrong, the mod may not work properly");
            }

            Logger.Msg("Initialized");
        }

        internal static bool OnPortalEnter()
        {
            if (settings.enabled.Value)
            {
                return true;
            }
            else
            {
                Logger.Msg("Portals disbled");
                return false;
            }
            
        }

    }
}