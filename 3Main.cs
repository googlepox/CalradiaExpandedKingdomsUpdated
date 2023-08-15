// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Patches.GenerateClanNamePatch
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace CalradiaExpandedKingdoms.Patches
{
  [HarmonyPatch(typeof (NameGenerator), "GenerateClanName")]
  internal class GenerateClanNamePatch
  {
    public static void Postfix(
      CultureObject culture,
      Settlement clanOriginSettlement,
      ref TextObject __result)
    {
      if (clanOriginSettlement == null)
        return;
      if (culture.StringId.ToLower() == "rhodok")
        __result.SetTextVariable("ORIGIN_SETTLEMENT", clanOriginSettlement.Name);
      if (culture.StringId.ToLower() == "apolssalian")
        __result.SetTextVariable("ORIGIN_SETTLEMENT", clanOriginSettlement.Name);
      if (culture.StringId.ToLower() == "lyrion")
        __result.SetTextVariable("ORIGIN_SETTLEMENT", clanOriginSettlement.Name);
      if (culture.StringId.ToLower() == "paleician")
        __result.SetTextVariable("ORIGIN_SETTLEMENT", clanOriginSettlement.Name);
    }
  }
}
