// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKSettlementTaxModel
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
    public class CEKSettlementTaxModel : DefaultSettlementTaxModel
    {
        public override ExplainedNumber CalculateTownTax(Town town, bool includeDescriptions = false)
        {
            ExplainedNumber townTax = base.CalculateTownTax(town, includeDescriptions);
            if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.NordlingNegativeFeatTwo))
            {
                townTax.AddFactor(CEKFeats.NordlingNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
            }

            if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.KhergitNegativeFeatTwo))
            {
                townTax.AddFactor(CEKFeats.KhergitNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
            }

            if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.SturgiaPositiveFeatFour))
            {
                townTax.AddFactor(CEKFeats.SturgiaPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
            }

            if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.VagirPositiveFeatFour))
            {
                townTax.AddFactor(CEKFeats.VagirPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
            }

            if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.ApolssalianPositiveFeatTwo))
            {
                townTax.AddFactor(CEKFeats.ApolssalianPositiveFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
            }

            if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.LyrionPositiveFeatThree))
            {
                townTax.AddFactor(CEKFeats.LyrionPositiveFeatThree.EffectBonus, GameTexts.FindText("str_culture"));
            }

            if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.RhodokNegativeFeatOne))
            {
                townTax.AddFactor(CEKFeats.RhodokNegativeFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
            }

            return townTax;
        }
    }
}
