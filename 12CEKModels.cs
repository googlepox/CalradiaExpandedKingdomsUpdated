// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKRaidModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Models
{
    public class CEKRaidModel : DefaultRaidModel
    {
        public override float CalculateHitDamage(MapEventSide attackerSide, float settlementHitPoints)
        {
            ExplainedNumber explainedNumber = new ExplainedNumber(base.CalculateHitDamage(attackerSide, settlementHitPoints));
            if (attackerSide.LeaderParty.LeaderHero != null && attackerSide.LeaderParty.LeaderHero.Culture.HasFeat(CEKFeats.NordlingPositiveFeatOne))
            {
                explainedNumber.AddFactor(CEKFeats.NordlingPositiveFeatOne.EffectBonus, GameTexts.FindText("str_culture"));
            }

            return explainedNumber.ResultNumber;
        }
    }
}
