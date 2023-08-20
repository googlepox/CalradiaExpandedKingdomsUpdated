// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKPartyTroopUpgradeModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Models
{
    public class CEKPartyTroopUpgradeModel : DefaultPartyTroopUpgradeModel
    {
        public override int GetGoldCostForUpgrade(
          PartyBase party,
          CharacterObject characterObject,
          CharacterObject upgradeTarget)
        {
            ExplainedNumber explainedNumber = new ExplainedNumber((float)base.GetGoldCostForUpgrade(party, characterObject, upgradeTarget));
            if (party.IsMobile && party.LeaderHero != null)
            {
                if (party.LeaderHero.Culture.HasFeat(CEKFeats.KhergitPositiveFeatThree) && upgradeTarget.IsMounted)
                {
                    explainedNumber.AddFactor(CEKFeats.KhergitPositiveFeatThree.EffectBonus, GameTexts.FindText("str_culture"));
                }

                if (party.LeaderHero.Culture.HasFeat(CEKFeats.RepublicNegativeFeatTwo))
                {
                    explainedNumber.AddFactor(CEKFeats.RepublicNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
                }
            }
            return (int)explainedNumber.ResultNumber;
        }
    }
}
