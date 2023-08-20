// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKClanFinanceModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements.Workshops;

namespace CalradiaExpandedKingdoms.Models
{
    public class CEKClanFinanceModel : DefaultClanFinanceModel
    {
        public override int CalculateOwnerIncomeFromWorkshop(Workshop workshop)
        {
            int incomeFromWorkshop = base.CalculateOwnerIncomeFromWorkshop(workshop);
            if (workshop.Owner != null)
            {
                if (workshop.Owner.Culture.HasFeat(CEKFeats.RhodokPositiveFeatTwo))
                {
                    incomeFromWorkshop = (int)((double)incomeFromWorkshop * (1.0 + (double)CEKFeats.RhodokPositiveFeatTwo.EffectBonus));
                }

                if (workshop.Owner.Culture.HasFeat(CEKFeats.RepublicNegativeFeatOne))
                {
                    incomeFromWorkshop = (int)((double)incomeFromWorkshop * (1.0 + (double)CEKFeats.RepublicNegativeFeatOne.EffectBonus));
                }

                if (workshop.Owner.Culture.HasFeat(CEKFeats.SturgiaPositiveFeatFour))
                {
                    incomeFromWorkshop = (int)((double)incomeFromWorkshop * (1.0 + (double)CEKFeats.SturgiaPositiveFeatFour.EffectBonus));
                }

                if (workshop.Owner.Culture.HasFeat(CEKFeats.SturgiaPositiveFeatFour))
                {
                    incomeFromWorkshop = (int)((double)incomeFromWorkshop * (1.0 + (double)CEKFeats.VlandianPositiveFeatFour.EffectBonus));
                }
            }
            return incomeFromWorkshop;
        }

        public override int CalculateOwnerIncomeFromCaravan(MobileParty caravan)
        {
            int incomeFromCaravan = base.CalculateOwnerIncomeFromCaravan(caravan);
            if (caravan.Owner != null && caravan.Owner.Culture.HasFeat(CEKFeats.LyrionPositiveFeatFour))
            {
                incomeFromCaravan = (int)((double)incomeFromCaravan * 1.1000000238418579);
            }

            return incomeFromCaravan;
        }
    }
}
