// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKBattleMoraleModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using CalradiaExpandedKingdoms.Helpers;
using SandBox.GameComponents;
using TaleWorlds.MountAndBlade;

namespace CalradiaExpandedKingdoms.Models
{
    public class CEKBattleMoraleModel : SandboxBattleMoraleModel
    {
        public override float GetEffectiveInitialMorale(Agent agent, float baseMorale)
        {
            float effectiveInitialMorale = base.GetEffectiveInitialMorale(agent, baseMorale);
            if (agent != null && agent.Character != null)
            {
                if (agent.Character.Culture == CEKHelpers.GetCultureObjectByID("rebkhu"))
                {
                    effectiveInitialMorale *= 1f + CEKFeats.KhergitNegativeFeatOne.EffectBonus;
                }

                if (agent.Character.Culture == CEKHelpers.GetCultureObjectByID("republic"))
                {
                    effectiveInitialMorale *= 1f + CEKFeats.RepublicPositiveFeatThree.EffectBonus;
                }

                if (agent.Character.Culture == CEKHelpers.GetCultureObjectByID("battania"))
                {
                    effectiveInitialMorale *= 1f + CEKFeats.BattaniaPositiveFeatThree.EffectBonus;
                }

                if (agent.Character.Culture == CEKHelpers.GetCultureObjectByID("rhodok"))
                {
                    effectiveInitialMorale *= 1f + CEKFeats.BattaniaPositiveFeatThree.EffectBonus;
                }
            }
            return effectiveInitialMorale;
        }
    }
}
