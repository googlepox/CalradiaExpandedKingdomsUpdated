// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKCombatXpModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace CalradiaExpandedKingdoms.Models
{
    public class CEKCombatXpModel : DefaultCombatXpModel
    {
        public override void GetXpFromHit(
          CharacterObject attackerTroop,
          CharacterObject captain,
          CharacterObject attackedTroop,
          PartyBase party,
          int damage,
          bool isFatal,
          CombatXpModel.MissionTypeEnum missionType,
          out int xpAmount)
        {
            base.GetXpFromHit(attackerTroop, captain, attackedTroop, party, damage, isFatal, missionType, out xpAmount);
            ExplainedNumber explainedNumber = new ExplainedNumber((float)xpAmount);
            if (captain != null && captain.IsHero)
            {
                if (captain.Culture.HasFeat(CEKFeats.LyrionPositiveFeatTwo))
                {
                    explainedNumber.AddFactor(CEKFeats.LyrionPositiveFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
                }

                if (captain.Culture.HasFeat(CEKFeats.PaleicianPositiveFeatOne))
                {
                    explainedNumber.AddFactor(CEKFeats.PaleicianPositiveFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
                }

                if (captain.Culture.HasFeat(CEKFeats.RhodokNegativeFeatTwo))
                {
                    explainedNumber.AddFactor(CEKFeats.RhodokNegativeFeatTwo.EffectBonus, GameTexts.FindText("str_culture"));
                }

                if (captain.Culture.HasFeat(CEKFeats.VlandianPositiveFeatThree) && attackedTroop.IsMounted)
                {
                    explainedNumber.AddFactor(CEKFeats.VlandianPositiveFeatThree.EffectBonus, GameTexts.FindText("str_culture"));
                }
            }
            xpAmount = MathF.Round(explainedNumber.ResultNumber);
        }
    }
}
