// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKPartyWageModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using CalradiaExpandedKingdoms.Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace CalradiaExpandedKingdoms.Models
{
  public class CEKPartyWageModel : DefaultPartyWageModel
  {
    public override int GetTroopRecruitmentCost(
      CharacterObject troop,
      Hero buyerHero,
      bool withoutItemCost = false)
    {
      ExplainedNumber explainedNumber = new ExplainedNumber((float) base.GetTroopRecruitmentCost(troop, buyerHero, withoutItemCost));
      if (buyerHero != null)
      {
        if (buyerHero.Culture.HasFeat(CEKFeats.KhergitPositiveFeatThree))
          explainedNumber.AddFactor(CEKFeats.KhergitPositiveFeatThree.EffectBonus, GameTexts.FindText("str_culture"));
        if (buyerHero.Culture.HasFeat(CEKFeats.RhodokPositiveFeatOne) && !CEKHelpers.IsEliteTroop(troop))
          explainedNumber.AddFactor(CEKFeats.RhodokPositiveFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
        if (buyerHero.Culture.HasFeat(CEKFeats.ApolssalianPositiveFeatOne))
          explainedNumber.AddFactor(CEKFeats.ApolssalianPositiveFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
        if (CEKHelpers.IsEliteTroop(troop))
          explainedNumber.AddFactor(0.2f);
        if (CEKHelpers.IsInCultureGroup((BasicCultureObject) troop.Culture, (BasicCultureObject) buyerHero.Culture))
          explainedNumber.AddFactor(-0.05f, GameTexts.FindText("str_culture"));
        if (buyerHero.Clan != null)
        {
          Kingdom kingdom = buyerHero.Clan.Kingdom;
          if (kingdom != null && !CEKHelpers.IsInCultureGroup((BasicCultureObject) kingdom.Culture, (BasicCultureObject) troop.Culture))
            explainedNumber.AddFactor(0.25f, GameTexts.FindText("str_kingdom"));
          if (buyerHero.Clan.Tier >= 4)
            explainedNumber.AddFactor((float) (buyerHero.Clan.Tier - 3) * 0.05f);
          else if (buyerHero.Clan.Tier <= 1)
            explainedNumber.AddFactor((float) (buyerHero.Clan.Tier - 2) * 0.05f);
        }
      }
      return MathF.Round(explainedNumber.ResultNumber);
    }

    public override ExplainedNumber GetTotalWage(MobileParty mobileParty, bool includeDescriptions = false)
    {
      ExplainedNumber totalWage = base.GetTotalWage(mobileParty, includeDescriptions);
      if (mobileParty.LeaderHero != null)
      {
        if (mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.ApolssalianPositiveFeatOne))
          totalWage.AddFactor(CEKFeats.ApolssalianPositiveFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
        if (mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.SturgiaNegativeFeatTwo))
          totalWage.AddFactor(CEKFeats.SturgiaNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
        if (mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.VlandianNegativeFeatTwo))
          totalWage.AddFactor(CEKFeats.VlandianNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
        if (mobileParty.LeaderHero.Culture.HasFeat(CEKFeats.AriorumNegativeOne))
          totalWage.AddFactor(CEKFeats.AriorumNegativeOne.EffectBonus, GameTexts.FindText("str_culture"));
      }
      if (mobileParty.IsGarrison && mobileParty.CurrentSettlement != null)
      {
        Settlement currentSettlement = mobileParty.CurrentSettlement;
        if ((currentSettlement.IsTown || currentSettlement.IsCastle) && currentSettlement.OwnerClan.Leader != null && currentSettlement.OwnerClan.Leader.Culture.HasFeat(CEKFeats.RepublicPositiveFeatTwo))
          totalWage.AddFactor(CEKFeats.RepublicPositiveFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
      }
      return totalWage;
    }
  }
}
