// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Patches.GenerateClanNameforPlayerPatch
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using HarmonyLib;
using Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

namespace CalradiaExpandedKingdoms.Patches
{
    [HarmonyPatch(typeof(FactionHelper), "GenerateClanNameforPlayer")]
    internal class GenerateClanNameforPlayerPatch
    {
        public static void Postfix(ref TextObject __result)
        {
            CultureObject culture = CharacterObject.PlayerCharacter.Culture;
            if (culture.StringId.ToLower() == "rhodok")
            {
                __result = new TextObject("{=p1dFvTAc}dey {ORIGIN_SETTLEMENT}");
                __result.SetTextVariable("ORIGIN_SETTLEMENT", new TextObject("{=Settlements.Settlement.name.town_V1}Sargot"));
            }
            if (culture.StringId.ToLower() == "apolssalian")
            {
                __result = new TextObject("{=culture.apolssalian.clanname}Oikos {ORIGIN_SETTLEMENT}");
                __result.SetTextVariable("ORIGIN_SETTLEMENT", new TextObject("{=!}Quyaz"));
            }
            if (culture.StringId.ToLower() == "lyrion")
            {
                __result = new TextObject("{=culture.lyrion.clanname}Atrs {ORIGIN_SETTLEMENT}");
                __result.SetTextVariable("ORIGIN_SETTLEMENT", new TextObject("{=!}Razih"));
            }
            if (!(culture.StringId.ToLower() == "paleician"))
            {
                return;
            }

            __result = new TextObject("{=culture.paleician.clanname}House {ORIGIN_SETTLEMENT}");
            __result.SetTextVariable("ORIGIN_SETTLEMENT", new TextObject("{=!}Lageta"));
        }
    }
}
