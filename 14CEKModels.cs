// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKSettlementMilitiaModel
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
    public class CEKSettlementMilitiaModel : DefaultSettlementMilitiaModel
    {
        public override ExplainedNumber CalculateMilitiaChange(
          Settlement settlement,
          bool includeDescriptions = false)
        {
            ExplainedNumber militiaChange = base.CalculateMilitiaChange(settlement, includeDescriptions);
            if (settlement.OwnerClan != null && settlement.OwnerClan.Leader != null)
            {
                if (settlement.OwnerClan.Leader.Culture.HasFeat(CEKFeats.RhodokPositiveFeatTwo))
                {
                    militiaChange.Add(1f, GameTexts.FindText("str_culture"));
                }

                if (settlement.OwnerClan.Leader.Culture.HasFeat(CEKFeats.KhuzaitNegativeFeatTwo))
                {
                    militiaChange.Add(CEKFeats.KhuzaitNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
                }

                if (settlement.OwnerClan.Leader.Culture.HasFeat(CEKFeats.VagirPositiveFeatThree))
                {
                    militiaChange.Add(1f, GameTexts.FindText("str_culture"));
                }

                if (settlement.OwnerClan.Leader.Culture.HasFeat(CEKFeats.PaleicianPositiveFeatThree))
                {
                    militiaChange.Add(0.5f, GameTexts.FindText("str_culture"));
                }

                if (settlement.OwnerClan.Leader.Culture.HasFeat(CEKFeats.ApolssalianPositiveFeatThree) && settlement.OwnerClan.Culture == settlement.Culture)
                {
                    militiaChange.Add(CEKFeats.ApolssalianPositiveFeatThree.EffectBonus, GameTexts.FindText("str_culture"));
                }
            }
            return militiaChange;
        }
    }
}
