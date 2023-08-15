// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Patches.MilitiaSpawnPatch
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Helpers;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Patches
{
  [HarmonyPatch(typeof (Settlement), "AddTroopToMilitiaParty")]
  internal class MilitiaSpawnPatch
  {
    public static bool Prefix(
      MobileParty militaParty,
      CharacterObject militiaTroop,
      CharacterObject eliteMilitiaTroop,
      float troopRatio,
      ref int numberToAddRemaining,
      ref Settlement __instance)
    {
      if (numberToAddRemaining > 0)
      {
        int num = MBRandom.RoundRandomized(troopRatio * (float) numberToAddRemaining);
        float militiaSpawnChance = Campaign.Current.Models.SettlementMilitiaModel.CalculateEliteMilitiaSpawnChance(__instance);
        for (int index = 0; index < num; ++index)
        {
          if ((double) MBRandom.RandomFloat < (double) militiaSpawnChance)
            militaParty.MemberRoster.AddToCounts(eliteMilitiaTroop, 1);
          else if (militaParty.HomeSettlement.StringId == "town_TT1")
          {
            if (MBRandom.RandomInt(1, 100) <= 10)
              militaParty.MemberRoster.AddToCounts(CEKHelpers.GetNPCByID("ariorum_bomber"), 1);
            else
              militaParty.MemberRoster.AddToCounts(militiaTroop, 1);
          }
          else
            militaParty.MemberRoster.AddToCounts(militiaTroop, 1);
        }
        numberToAddRemaining -= num;
      }
      return false;
    }
  }
}
