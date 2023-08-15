// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Patches.CEKRegisterTypes
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Ruins;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ObjectSystem;

namespace CalradiaExpandedKingdoms.Patches
{
  [HarmonyPatch(typeof (Campaign), "OnRegisterTypes")]
  public class CEKRegisterTypes
  {
    private static void Postfix(MBObjectManager objectManager) => objectManager.RegisterType<Ruin>("Ruin", "Components", 100U);
  }
}
