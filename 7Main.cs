// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Patches.StartNewGamePatch
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using HarmonyLib;
using StoryMode;
using System;
using System.Reflection;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace CalradiaExpandedKingdoms.Patches
{
    [HarmonyPatch(typeof(MBGameManager), "StartNewGame", new System.Type[] { typeof(MBGameManager) })]
    internal class StartNewGamePatch
    {
        public static MethodInfo StartNewGameMethodInfo = AccessTools.Method(typeof(MBGameManager), "StartNewGame", new System.Type[1]
        {
      typeof (MBGameManager)
        }, (System.Type[])null);
        private static bool IsContinuing = false;

        private static void StartNewGame(MBGameManager gameLoader)
        {
            StartNewGamePatch.StartNewGameMethodInfo.Invoke((object)null, new object[1]
            {
        (object) gameLoader
            });
            StartNewGamePatch.IsContinuing = false;
        }

        private static bool Prefix(MBGameManager gameLoader)
        {
            if (StartNewGamePatch.IsContinuing || !(gameLoader.GetType() == typeof(StoryModeGameManager)))
            {
                return true;
            }

            InformationManager.ShowInquiry(new InquiryData("Info", "We recommend that you play Calradia Expanded: Kingdoms in Sandbox mode. We cannot guarantee that all quests in Story Mode will work correctly due to the added/changed factions and settlements.", true, true, "Continue anyway", "Cancel", (Action)(() => StartNewGamePatch.Continue(gameLoader)), (Action)null, "", 0.0f, (Action)null));
            return false;
        }

        private static void Continue(MBGameManager gameLoader)
        {
            StartNewGamePatch.IsContinuing = true;
            StartNewGamePatch.StartNewGame(gameLoader);
        }
    }
}
