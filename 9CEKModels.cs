// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKPriceFactorModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Models
{
    public class CEKPriceFactorModel : DefaultTradeItemPriceFactorModel
    {
        public override float GetTradePenalty(
          ItemObject item,
          MobileParty clientParty,
          PartyBase merchant,
          bool isSelling,
          float inStore,
          float supply,
          float demand)
        {
            float tradePenalty = base.GetTradePenalty(item, clientParty, merchant, isSelling, inStore, supply, demand);
            if (clientParty != null && clientParty.IsCaravan && clientParty.Owner.Culture.HasFeat(CEKFeats.AriorumPositiveFour))
            {
                tradePenalty *= 0.8f;
            }

            return tradePenalty;
        }
    }
}
