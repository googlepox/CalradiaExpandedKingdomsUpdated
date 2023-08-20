// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKArmyManagementCalculationModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Models
{
    public class CEKArmyManagementCalculationModel : DefaultArmyManagementCalculationModel
    {
        public override ExplainedNumber CalculateDailyCohesionChange(
          Army army,
          bool includeDescriptions = false)
        {
            ExplainedNumber dailyCohesionChange = base.CalculateDailyCohesionChange(army, includeDescriptions);
            if (army.LeaderParty.LeaderHero != null)
            {
                if (army.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.NordlingNegativeFeatOne))
                {
                    dailyCohesionChange.AddFactor(CEKFeats.NordlingNegativeFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
                }

                if (army.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.BattaniaNegativeFeatTwo))
                {
                    dailyCohesionChange.AddFactor(CEKFeats.BattaniaNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
                }

                if (army.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.KhuzaitPositiveFeatThree))
                {
                    dailyCohesionChange.AddFactor(CEKFeats.KhuzaitPositiveFeatThree.EffectBonus, GameTexts.FindText("str_culture"));
                }

                if (army.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.RhodokPositiveFeatThree))
                {
                    dailyCohesionChange.AddFactor(CEKFeats.RhodokPositiveFeatThree.EffectBonus * 2f, GameTexts.FindText("str_culture"));
                }

                if (army.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.VagirNegativeFeatTwo))
                {
                    dailyCohesionChange.AddFactor(CEKFeats.VagirNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
                }
            }
            return dailyCohesionChange;
        }

        public override int CalculatePartyInfluenceCost(MobileParty armyLeaderParty, MobileParty party)
        {
            int partyInfluenceCost = base.CalculatePartyInfluenceCost(armyLeaderParty, party);
            if (armyLeaderParty.LeaderHero != null)
            {
                if (armyLeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.NordlingNegativeFeatOne))
                {
                    partyInfluenceCost = (int)((double)partyInfluenceCost * (1.0 + (double)CEKFeats.NordlingNegativeFeatOne.EffectBonus));
                }

                if (armyLeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.BattaniaNegativeFeatTwo))
                {
                    partyInfluenceCost = (int)((double)partyInfluenceCost * (1.0 + (double)CEKFeats.BattaniaNegativeFeatTwo.EffectBonus));
                }

                if (armyLeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.KhuzaitPositiveFeatThree))
                {
                    partyInfluenceCost = (int)((double)partyInfluenceCost * (1.0 + (double)CEKFeats.KhuzaitPositiveFeatThree.EffectBonus));
                }

                if (armyLeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.RhodokPositiveFeatThree))
                {
                    partyInfluenceCost = (int)((double)partyInfluenceCost * (1.0 + (double)CEKFeats.RhodokPositiveFeatThree.EffectBonus));
                }

                if (armyLeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.VagirNegativeFeatTwo))
                {
                    partyInfluenceCost = (int)((double)partyInfluenceCost * (1.0 + (double)CEKFeats.VagirNegativeFeatTwo.EffectBonus));
                }

                if (armyLeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.PaleicianNegativeFeatOne))
                {
                    partyInfluenceCost = (int)((double)partyInfluenceCost * (1.0 + (double)CEKFeats.PaleicianNegativeFeatOne.EffectBonus));
                }
            }
            if (partyInfluenceCost < 5)
            {
                partyInfluenceCost = 5;
            }

            return partyInfluenceCost;
        }
    }
}
