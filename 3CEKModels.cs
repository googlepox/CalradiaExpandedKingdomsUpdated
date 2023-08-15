// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKSettlementProsperityModel
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
  public class CEKSettlementProsperityModel : DefaultSettlementProsperityModel
  {
    public override ExplainedNumber CalculateProsperityChange(
      Town fortification,
      bool includeDescriptions = false)
    {
      ExplainedNumber prosperityChange = base.CalculateProsperityChange(fortification, includeDescriptions);
      if (fortification.OwnerClan != null && fortification.OwnerClan.Leader != null)
      {
        if (fortification.OwnerClan.Leader.Culture.HasFeat(CEKFeats.AseraiPositiveFeatThree))
          prosperityChange.Add(CEKFeats.AseraiPositiveFeatThree.EffectBonus, GameTexts.FindText("str_culture"));
        if (fortification.OwnerClan.Leader.Culture.HasFeat(CEKFeats.RhodokPositiveFeatTwo))
          prosperityChange.Add(0.5f, GameTexts.FindText("str_culture"));
        if (fortification.OwnerClan.Leader.Culture.HasFeat(CEKFeats.VlandianPositiveFeatFour))
          prosperityChange.Add(0.5f, GameTexts.FindText("str_culture"));
        if (fortification.OwnerClan.Leader.Culture.HasFeat(CEKFeats.ApolssalianPositiveFeatThree) && fortification.Culture == fortification.OwnerClan.Leader.Culture)
          prosperityChange.Add(0.5f, GameTexts.FindText("str_culture"));
        if (fortification.OwnerClan.Leader.Culture.HasFeat(CEKFeats.AriorumPositiveOne) && fortification.Culture == fortification.OwnerClan.Leader.Culture)
          prosperityChange.Add(1f, GameTexts.FindText("str_culture"));
      }
      return prosperityChange;
    }

    public override ExplainedNumber CalculateHearthChange(Village village, bool includeDescriptions = false)
    {
      ExplainedNumber hearthChange = base.CalculateHearthChange(village, includeDescriptions);
      if (village.Bound.Owner != null && village.Bound.Owner.Culture.HasFeat(CEKFeats.KhergitPositiveFeatFour))
        hearthChange.AddFactor(CEKFeats.KhergitPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
      return hearthChange;
    }
  }
}
