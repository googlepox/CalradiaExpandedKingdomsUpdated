// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKBattleRewardModel
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
    public class CEKBattleRewardModel : DefaultBattleRewardModel
    {
        public override ExplainedNumber CalculateRenownGain(
          PartyBase party,
          float renownValueOfBattle,
          float contributionShare)
        {
            ExplainedNumber renownGain = base.CalculateRenownGain(party, renownValueOfBattle, contributionShare);
            if (party.IsMobile)
            {
                if (party.MobileParty.PartyComponent.Leader != null && party.MobileParty.PartyComponent.Leader.Culture.HasFeat(CEKFeats.EmpireNegativeFeatTwo))
                {
                    renownGain.AddFactor(CEKFeats.EmpireNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
                }

                if (party.MapEvent.AttackerSide.LeaderParty.LeaderHero != null)
                {
                    if (party.MapEvent.AttackerSide.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.AseraiPositiveFeatFour))
                    {
                        renownGain.AddFactor(CEKFeats.AseraiPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
                    }

                    if (party.MapEvent.AttackerSide.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.NordlingPositiveFeatFour))
                    {
                        renownGain.AddFactor(CEKFeats.NordlingPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
                    }

                    if (party.MapEvent.AttackerSide.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.VagirNegativeFeatOne))
                    {
                        renownGain.AddFactor(CEKFeats.VagirNegativeFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
                    }
                }
            }
            return renownGain;
        }

        public override ExplainedNumber CalculateMoraleGainVictory(
          PartyBase party,
          float renownValueOfBattle,
          float contributionShare)
        {
            ExplainedNumber moraleGainVictory = base.CalculateMoraleGainVictory(party, renownValueOfBattle, contributionShare);
            if (party.IsMobile)
            {
                if (party.MapEvent.AttackerSide.LeaderParty.LeaderHero != null)
                {
                    if (party.MapEvent.AttackerSide.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.AseraiPositiveFeatFour))
                    {
                        moraleGainVictory.AddFactor(CEKFeats.AseraiPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
                    }

                    if (party.MapEvent.AttackerSide.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.NordlingPositiveFeatFour))
                    {
                        moraleGainVictory.AddFactor(CEKFeats.NordlingPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
                    }

                    if (party.MapEvent.AttackerSide.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.VagirNegativeFeatOne))
                    {
                        moraleGainVictory.AddFactor(CEKFeats.VagirNegativeFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
                    }

                    if (party.MapEvent.AttackerSide.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.PaleicianNegativeFeatTwo))
                    {
                        moraleGainVictory.AddFactor(CEKFeats.PaleicianNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
                    }

                    if (party.MapEvent.AttackerSide.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.ApolssalianNegativeFeatTwo))
                    {
                        moraleGainVictory.AddFactor(CEKFeats.ApolssalianNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
                    }
                }
                if (party.MapEvent.DefenderSide.LeaderParty.LeaderHero != null && party.MapEvent.DefenderSide.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.PaleicianNegativeFeatTwo))
                {
                    moraleGainVictory.AddFactor(CEKFeats.PaleicianNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
                }
            }
            return moraleGainVictory;
        }
    }
}
