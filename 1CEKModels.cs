// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKBuildingConstructionModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace CalradiaExpandedKingdoms.Models
{
    public class CEKBuildingConstructionModel : DefaultBuildingConstructionModel
    {
        private static readonly TextObject CultureText = GameTexts.FindText("str_culture");

        public override ExplainedNumber CalculateDailyConstructionPower(
          Town town,
          bool includeDescriptions = false)
        {
            ExplainedNumber constructionPower = base.CalculateDailyConstructionPower(town, includeDescriptions);
            if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.EmpirePositiveFeatThree))
            {
                constructionPower.AddFactor(CEKFeats.EmpirePositiveFeatThree.EffectBonus, CEKBuildingConstructionModel.CultureText);
            }

            if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.RepublicPositiveFeatOne))
            {
                constructionPower.AddFactor(CEKFeats.RepublicPositiveFeatOne.EffectBonus, CEKBuildingConstructionModel.CultureText);
            }

            if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.PaleicianPositiveFeatTwo))
            {
                constructionPower.AddFactor(CEKFeats.PaleicianPositiveFeatTwo.EffectBonus, CEKBuildingConstructionModel.CultureText);
            }

            if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.KhergitPositiveFeatTwo))
            {
                constructionPower.AddFactor(CEKFeats.KhergitPositiveFeatTwo.EffectBonus, CEKBuildingConstructionModel.CultureText);
            }

            if (town.OwnerClan.Leader.Culture.HasFeat(CEKFeats.LyrionNegativeFeatOne))
            {
                constructionPower.AddFactor(CEKFeats.LyrionNegativeFeatOne.EffectBonus, CEKBuildingConstructionModel.CultureText);
            }

            return constructionPower;
        }
    }
}
