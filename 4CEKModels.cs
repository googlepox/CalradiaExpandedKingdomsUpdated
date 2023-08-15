// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKSettlementLoyaltyModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Models
{
  public class CEKSettlementLoyaltyModel : DefaultSettlementLoyaltyModel
  {
    public override ExplainedNumber CalculateLoyaltyChange(Town town, bool includeDescriptions = false)
    {
      ExplainedNumber loyaltyChange = base.CalculateLoyaltyChange(town, includeDescriptions);
      if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.AseraiNegativeFeatTwo))
        loyaltyChange.Add(CEKFeats.AseraiNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
      if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.LyrionNegativeFeatTwo))
        loyaltyChange.Add(CEKFeats.LyrionNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
      if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.AriorumNegativeTwo))
        loyaltyChange.Add(CEKFeats.AriorumNegativeTwo.EffectBonus, GameTexts.FindText("str_culture"));
      if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.ApolssalianNegativeFeatOne) && town.Culture != town.OwnerClan.Culture)
        loyaltyChange.Add(CEKFeats.ApolssalianNegativeFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
      if (town.Governor != null)
      {
        if (town.Governor.Culture != town.Culture && town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.EmpirePositiveFeatFour))
          loyaltyChange.Add(1f, GameTexts.FindText("str_culture"));
        if (town.Governor.Culture != town.Culture && town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.VagirPositiveFeatOne))
          loyaltyChange.Add(1f, GameTexts.FindText("str_culture"));
        if (town.Governor.Culture != town.Culture && town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.PaleicianPositiveFeatFour))
          loyaltyChange.Add(1f, GameTexts.FindText("str_culture"));
      }
      return loyaltyChange;
    }
  }
}
