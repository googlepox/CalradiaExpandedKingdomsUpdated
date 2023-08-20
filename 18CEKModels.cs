// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKPartySizeLimitModel
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
    public class CEKPartySizeLimitModel : DefaultPartySizeLimitModel
    {
        public override ExplainedNumber GetPartyMemberSizeLimit(
          PartyBase party,
          bool includeDescriptions = false)
        {
            ExplainedNumber partyMemberSizeLimit = base.GetPartyMemberSizeLimit(party, includeDescriptions);
            if (party.MobileParty == null || !party.IsMobile || party.MobileParty.IsGarrison || party.MobileParty.LeaderHero == null || !party.MobileParty.LeaderHero.Culture.HasFeat(CEKFeats.ApolssalianPositiveFeatFour))
            {
                return partyMemberSizeLimit;
            }

            partyMemberSizeLimit.Add(CEKFeats.ApolssalianPositiveFeatFour.EffectBonus, GameTexts.FindText("str_culture"));
            return partyMemberSizeLimit;
        }
    }
}
