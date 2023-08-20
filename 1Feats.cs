// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Feats.Patches.InitializeAllPatch
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using HarmonyLib;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace CalradiaExpandedKingdoms.Feats.Patches
{
    [HarmonyPatch(typeof(DefaultCulturalFeats), "InitializeAll")]
    internal class InitializeAllPatch
    {
        private static void Postfix()
        {
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("empire_decreased_garrison_wage"), (object)new TextObject("Pax Civite: Reduced wages for garrisons."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("empire_army_influence"), (object)new TextObject("Glory to the Empire: Increased influence from participating in armies."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("empire_slower_hearth_production"), (object)new TextObject("Depopulation: Slower village growth."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("aserai_cheaper_caravans"), (object)new TextObject("Caravaneers: Cheaper caravans and increased trade profit."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("aserai_desert_speed"), (object)new TextObject("Desert Striders: No speed penalty in deserts."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("aserai_increased_wages"), (object)new TextObject("Soldier-slaves: Increased troop upkeep costs."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("battanian_forest_speed"), (object)new TextObject("Forest Dwellers: Faster movement and increased sight range in forests."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("battanian_militia_production"), (object)new TextObject("Homeland: Increased settlement militia production."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("battanian_slower_construction"), (object)new TextObject("Poor Engineering: Slower town and siege building speeds."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("khuzait_cheaper_recruits_mounted"), (object)new TextObject("Mounted Tradition: Reduced recruitment and upgrade costs for cavalry."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("khuzait_increased_animal_production"), (object)new TextObject("Livestock Breeding: Increased village production to livestock."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("khuzait_decreased_town_tax"), (object)new TextObject("Poor Accounting: Reduced income from settlements."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("sturgian_cheaper_recruits_infantry"), (object)new TextObject("Eager Warriors: Infantrymen are cheaper to recruit and upgrade."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("sturgian_decreased_cohesion_rate"), (object)new TextObject("Boyar Army: Armies lose cohesion at a slower pace."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("sturgian_increased_decision_penalty"), (object)new TextObject("Divergent Interests: Disagreements with other lords have more impact."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("vlandian_renown_mercenary_income"), (object)new TextObject("Battle Glory: Increased renown from battles and income from mercenary contracts."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("vlandian_villages_production_bonus"), (object)new TextObject("Château Lié: Increased production output to castle bound villages."));
            AccessTools.Field(typeof(FeatObject), "_description").SetValue((object)MBObjectManager.Instance.GetObject<FeatObject>("vlandian_increased_army_influence_cost"), (object)new TextObject("Questionable Authority: Recruiting lords to armies costs more influence."));
        }
    }
}
