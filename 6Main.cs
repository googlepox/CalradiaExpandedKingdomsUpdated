// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Patches.GetUpgradeXpCostPatch
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace CalradiaExpandedKingdoms.Patches
{
  [HarmonyPatch(typeof (CharacterObject), "GetUpgradeXpCost")]
  public class GetUpgradeXpCostPatch
  {
    public static bool Prefix(
      PartyBase party,
      int index,
      CharacterObject __instance,
      ref int __result)
    {
      CharacterObject upgradeTarget = (CharacterObject) null;
      if (index >= 0 && index < __instance.UpgradeTargets.Length)
        upgradeTarget = __instance.UpgradeTargets[index];
      __result = Campaign.Current.Models.PartyTroopUpgradeModel.GetXpCostForUpgrade(party, __instance, upgradeTarget);
      if (__result <= 0)
        __result = 100;
      return false;
    }
  }
}
