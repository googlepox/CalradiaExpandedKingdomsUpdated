// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Ruins.Patches.bandit_start_barter_conditionPatch
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Encounters;

namespace CalradiaExpandedKingdoms.Ruins.Patches
{
  [HarmonyPatch(typeof (BanditsCampaignBehavior), "bandit_start_barter_condition")]
  public class bandit_start_barter_conditionPatch
  {
    private static void Postfix(ref bool __result)
    {
      if (PlayerEncounter.Current == null || PlayerEncounter.EncounteredParty == null || !PlayerEncounter.EncounteredParty.Id.Contains("ruin_attack_party_"))
        return;
      __result = false;
    }
  }
}
