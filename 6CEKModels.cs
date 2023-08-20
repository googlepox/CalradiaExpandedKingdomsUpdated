// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKPartySpeedCalculatingModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace CalradiaExpandedKingdoms.Models
{
    public class CEKPartySpeedCalculatingModel : DefaultPartySpeedCalculatingModel
    {
        public override ExplainedNumber CalculateFinalSpeed(
          MobileParty mobileParty,
          ExplainedNumber finalSpeed)
        {
            ExplainedNumber finalSpeed1 = base.CalculateFinalSpeed(mobileParty, finalSpeed);
            TerrainType faceTerrainType = Campaign.Current.MapSceneWrapper.GetFaceTerrainType(mobileParty.CurrentNavigationFace);
            if (faceTerrainType == TerrainType.Swamp)
            {
                if (mobileParty.LeaderHero != null)
                {
                    if (!mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.NordlingPositiveFeatThree))
                    {
                        if (mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.LyrionPositiveFeatThree))
                        {
                            finalSpeed1.AddFactor(-0.2f, new TextObject("at Sea"));
                        }
                        else
                        {
                            finalSpeed1.AddFactor(-0.4f, new TextObject("at Sea"));
                        }
                    }
                }
                else
                {
                    finalSpeed1.AddFactor(-0.4f, new TextObject("at Sea"));
                }
            }
            if (mobileParty.LeaderHero != null)
            {
                if (Campaign.Current.Models.MapWeatherModel.GetIsSnowTerrainInPos(mobileParty.Position2D.ToVec3()))
                {
                    if (mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.NordlingPositiveFeatTwo))
                    {
                        finalSpeed1.AddFactor(0.1f, GameTexts.FindText("str_culture"));
                    }

                    if (mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.SturgiaPositiveFeatThree))
                    {
                        finalSpeed1.AddFactor(0.1f, GameTexts.FindText("str_culture"));
                    }

                    if (mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.VagirPositiveFeatTwo))
                    {
                        finalSpeed1.AddFactor(CEKFeats.VagirPositiveFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
                    }
                }
                if (faceTerrainType == TerrainType.Forest && mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.VagirPositiveFeatTwo))
                {
                    float num = 3f;
                    if (mobileParty.Party.NumberOfAllMembers != 0)
                    {
                        num = (double)(mobileParty.Party.NumberOfMenWithHorse / mobileParty.Party.NumberOfAllMembers) < 0.25 ? 3f : 1.5f;
                    }

                    finalSpeed1.AddFactor(CEKFeats.VagirPositiveFeatTwo.EffectBonus * num, GameTexts.FindText("str_culture"));
                }
                if (mobileParty.Party.NumberOfAllMembers != 0)
                {
                    if (mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.BattaniaPositiveFeatFour) && (double)(mobileParty.Party.NumberOfMenWithHorse / mobileParty.Party.NumberOfAllMembers) < 0.25)
                    {
                        finalSpeed1.AddFactor(CEKFeats.BattaniaPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
                    }

                    if (mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.KhuzaitPositiveFeatFour) && (double)(mobileParty.Party.NumberOfMenWithHorse / mobileParty.Party.NumberOfAllMembers) > 0.5)
                    {
                        finalSpeed1.AddFactor(CEKFeats.KhuzaitPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
                    }

                    if (mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.KhergitPositiveFeatOne) && (double)(mobileParty.Party.NumberOfMenWithHorse / mobileParty.Party.NumberOfAllMembers) > 0.5)
                    {
                        finalSpeed1.AddFactor(CEKFeats.KhergitPositiveFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
                    }

                    if (mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.LyrionPositiveFeatOne) && (double)(mobileParty.Party.NumberOfMenWithHorse / mobileParty.Party.NumberOfAllMembers) < 0.5)
                    {
                        finalSpeed1.AddFactor(CEKFeats.LyrionPositiveFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
                    }
                }
            }
            return finalSpeed1;
        }
    }
}
