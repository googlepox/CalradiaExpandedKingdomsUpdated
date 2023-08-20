// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Ruins.Patches.IsVisiblePatch
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using HarmonyLib;
using SandBox.ViewModelCollection.Nameplate;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace CalradiaExpandedKingdoms.Ruins.Patches
{
    [HarmonyPatch(typeof(SettlementNameplateVM), "IsVisible")]
    public class IsVisiblePatch
    {
        private static void Postfix(
          in Vec3 cameraPosition,
          SettlementNameplateVM __instance,
          ref bool __result)
        {
            SettlementComponent settlementComponent = __instance.Settlement.SettlementComponent;
            if (settlementComponent == null || !(settlementComponent is Ruin))
            {
                return;
            }

            Ruin ruin = settlementComponent as Ruin;
            __result = ruin.IsSpotted;
        }
    }
}
