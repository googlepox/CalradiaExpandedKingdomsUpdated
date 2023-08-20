// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Ruins.Patches.CEKGetEncounterMenu
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using HarmonyLib;
using System;
using System.Reflection;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace CalradiaExpandedKingdoms.Ruins.Patches
{
    [HarmonyPatch(typeof(DefaultEncounterGameMenuModel), "GetEncounterMenu")]
    public class CEKGetEncounterMenu
    {
        public static MethodInfo GetEncounteredPartyBaseMethodInfo = AccessTools.Method(typeof(DefaultEncounterGameMenuModel), "GetEncounteredPartyBase", (Type[])null, (Type[])null);

        private static PartyBase GetEncounteredPartyBase(
          PartyBase attackerParty,
          PartyBase defenderParty,
          DefaultEncounterGameMenuModel instance)
        {
            return (PartyBase)CEKGetEncounterMenu.GetEncounteredPartyBaseMethodInfo.Invoke((object)instance, new object[2]
            {
        (object) attackerParty,
        (object) defenderParty
            });
        }

        private static void Postfix(
          PartyBase attackerParty,
          PartyBase defenderParty,
          bool startBattle,
          bool joinBattle,
          DefaultEncounterGameMenuModel __instance,
          ref string __result)
        {
            PartyBase encounteredPartyBase = CEKGetEncounterMenu.GetEncounteredPartyBase(attackerParty, defenderParty, __instance);
            if (!encounteredPartyBase.IsSettlement)
            {
                return;
            }

            Settlement settlement = encounteredPartyBase.Settlement;
            if (settlement.SettlementComponent != null && settlement.SettlementComponent is Ruin)
            {
                __result = "ruin_place";
            }
        }
    }
}
