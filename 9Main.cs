// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Patches.IsItemPreferredPatch
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Helpers;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Patches
{
    [HarmonyPatch(typeof(WorkshopsCampaignBehavior), "IsItemPreferredForTown")]
    internal class IsItemPreferredPatch
    {
        public static void Postfix(ref bool __result, ItemObject item, Town townComponent)
        {
            __result = CEKHelpers.IsInCultureGroup(item.Culture, (BasicCultureObject)townComponent.Culture);
        }
    }
}
