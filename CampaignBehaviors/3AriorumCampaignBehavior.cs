// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Patches.AriorumPatch4
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Helpers;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors.BarterBehaviors;

namespace CalradiaExpandedKingdoms.Patches
{
  [HarmonyPatch(typeof (DiplomaticBartersBehavior), "ConsiderClanJoin")]
  public class AriorumPatch4
  {
    private static bool Prefix(Clan clan, Kingdom kingdom) => kingdom != CEKHelpers.GetKingdomByID("ariorum") && clan != CEKHelpers.GetClanByID("manhunters_neutral");
  }
}
