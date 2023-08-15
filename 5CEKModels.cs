// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKSettlementSecurityModel
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
  public class CEKSettlementSecurityModel : DefaultSettlementSecurityModel
  {
    public override ExplainedNumber CalculateSecurityChange(Town town, bool includeDescriptions = false)
    {
      ExplainedNumber securityChange = base.CalculateSecurityChange(town, includeDescriptions);
      if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.EmpirePositiveFeatFour))
        securityChange.Add(CEKFeats.EmpirePositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
      if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.VagirPositiveFeatOne))
        securityChange.Add(CEKFeats.VagirPositiveFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
      if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.KhuzaitNegativeFeatTwo))
        securityChange.Add(CEKFeats.KhuzaitNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
      if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.LyrionNegativeFeatTwo))
        securityChange.Add(CEKFeats.LyrionNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
      if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.PaleicianPositiveFeatFour))
        securityChange.Add(CEKFeats.PaleicianPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
      if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.RepublicPositiveFeatFour))
        securityChange.Add(CEKFeats.RepublicPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
      if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.ApolssalianNegativeFeatOne) && town.Culture != town.OwnerClan.Culture)
        securityChange.Add(CEKFeats.ApolssalianNegativeFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
      return securityChange;
    }
  }
}
