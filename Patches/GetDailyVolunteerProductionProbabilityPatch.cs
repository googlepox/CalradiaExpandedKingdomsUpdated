using CalradiaExpandedKingdoms.Feats;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;

namespace CalradiaExpandedKingdoms.Patches
{
    [HarmonyPatch(typeof(DefaultVolunteerModel), "GetDailyVolunteerProductionProbability")]
    internal class GetDailyVolunteerProductionProbabilityPatch
    {
        public static void Postfix(Hero hero, int index, Settlement settlement, ref float __result)
        {
            if (hero.Culture.HasFeat(CEKFeats.PaleicianPositiveFeatThree))
            {
                ExplainedNumber explainedNumber = new ExplainedNumber(__result);
                explainedNumber.AddFactor(CEKFeats.PaleicianPositiveFeatThree.EffectBonus);
                __result = explainedNumber.ResultNumber;
            }
        }
    }
}
