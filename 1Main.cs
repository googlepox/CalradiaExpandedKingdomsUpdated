// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Fixes.OnHeroComesOfAgePatch
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using HarmonyLib;
using Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace CalradiaExpandedKingdoms.Fixes
{
  [HarmonyPatch(typeof (AgingCampaignBehavior), "OnHeroComesOfAge")]
  internal class OnHeroComesOfAgePatch
  {
    public static bool Prefix(Hero hero)
    {
      if (!(hero.StringId == "lord_manhunters_1"))
        return true;
      EquipmentHelper.AssignHeroEquipmentFromEquipment(hero, hero.BattleEquipment);
      EquipmentHelper.AssignHeroEquipmentFromEquipment(hero, hero.CivilianEquipment);
      return false;
    }
  }
}
