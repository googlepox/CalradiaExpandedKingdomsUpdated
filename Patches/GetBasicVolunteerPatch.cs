using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Patches
{
    [HarmonyPatch(typeof(DefaultVolunteerModel), "GetBasicVolunteer")]
    internal class GetBasicVolunteerPatch
    {
        public static void Postfix(Hero sellerHero, ref CharacterObject __result)
        {
            CharacterObject basicVolunteer = sellerHero.Culture.BasicTroop;
            if (sellerHero.CurrentSettlement == null || basicVolunteer == sellerHero.Culture.EliteBasicTroop)
            {
                __result = basicVolunteer;
            }

            Settlement currentSettlement = sellerHero.CurrentSettlement;
            float num1 = currentSettlement.IsTown ? sellerHero.Power * 0.03f : sellerHero.Power * 0.05f;
            int num2 = MBRandom.RandomInt(1, 100);
            if (sellerHero.Culture.StringId == "ariorum")
            {
                num1 *= 1.25f;
            }

            if ((double)num2 <= (double)num1)
            {
                __result = sellerHero.Culture.EliteBasicTroop;
            }

            List<RecruitData> recruitDataList = new List<RecruitData>();
            CultureObject settlementCulture = sellerHero.CurrentSettlement.Culture;
            List<RecruitData> list1 = RecruitManager.instance.Recruits.Where<RecruitData>((Func<RecruitData, bool>)(x => x.culture == settlementCulture)).ToList<RecruitData>();
            if (list1.Count > 0)
            {
                if (currentSettlement.Owner == currentSettlement.Owner.MapFaction.Leader)
                {
                    List<RecruitData> list2 = list1.Where<RecruitData>((Func<RecruitData, bool>)(x => x.isRetinue)).ToList<RecruitData>();
                    if (list2.Any<RecruitData>())
                    {
                        RecruitData randomElement = list2.GetRandomElement<RecruitData>();
                        if (num2 <= randomElement.chance)
                        {
                            basicVolunteer = randomElement.character;
                        }
                    }
                }
                if (basicVolunteer == __result)
                {
                    int num3 = 0;
                    foreach (RecruitData recruitData in list1)
                    {
                        num3 += recruitData.chance;
                        if (recruitData.faction != null)
                        {
                            if (recruitData.faction == currentSettlement.OwnerClan.MapFaction && num2 <= num3)
                            {
                                basicVolunteer = recruitData.character;
                                break;
                            }
                        }
                        else if (num2 <= num3)
                        {
                            basicVolunteer = recruitData.character;
                            break;
                        }
                    }
                }
            }
            if (__result != sellerHero.Culture.EliteBasicTroop)
            {
                __result = basicVolunteer;
            }
        }
    }
}
