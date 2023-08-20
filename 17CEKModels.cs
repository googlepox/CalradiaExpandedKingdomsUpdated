// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKSettlementFoodModel
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
    public class CEKSettlementFoodModel : DefaultSettlementFoodModel
    {
        public override ExplainedNumber CalculateTownFoodStocksChange(
          Town town,
          bool includeMarketStocks = true,
          bool includeDescriptions = false)
        {
            ExplainedNumber foodStocksChange = base.CalculateTownFoodStocksChange(town, includeMarketStocks, includeDescriptions);
            if (town.OwnerClan != null && town.OwnerClan.Leader != null)
            {
                if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.VagirPositiveFeatFour))
                {
                    foodStocksChange.Add(1f, GameTexts.FindText("str_culture"));
                }

                if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.RepublicPositiveFeatFour))
                {
                    foodStocksChange.Add(CEKFeats.RepublicPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
                }
            }
            return foodStocksChange;
        }
    }
}
