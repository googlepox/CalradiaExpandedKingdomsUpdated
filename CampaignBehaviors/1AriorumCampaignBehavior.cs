// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Patches.AriorumPatch2
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Helpers;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors.BarterBehaviors;

namespace CalradiaExpandedKingdoms.Patches
{
  [HarmonyPatch(typeof (DiplomaticBartersBehavior), "ConsiderWar")]
  public class AriorumPatch2
  {
    private static bool Prefix(Clan clan, IFaction otherMapFaction) => otherMapFaction != CEKHelpers.GetKingdomByID("ariorum") && clan.Kingdom != CEKHelpers.GetKingdomByID("ariorum");
  }
}
