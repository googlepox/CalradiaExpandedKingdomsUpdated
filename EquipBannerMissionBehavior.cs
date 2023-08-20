// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.EquipBannerMissionBehavior
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace CalradiaExpandedKingdoms
{
    internal class EquipBannerMissionBehavior : MissionLogic
    {
        private List<Agent> spawnedAgents = new List<Agent>();

        public override void OnPreMissionTick(float dt)
        {
            foreach (Agent spawnedAgent in this.spawnedAgents)
            {
                if (spawnedAgent.Equipment != null && !spawnedAgent.Equipment.HasRangedWeapon(WeaponClass.Arrow) && !spawnedAgent.Equipment.HasRangedWeapon(WeaponClass.Bolt) && !spawnedAgent.Equipment.HasRangedWeapon(WeaponClass.TwoHandedSword) && !spawnedAgent.Equipment.HasRangedWeapon(WeaponClass.TwoHandedPolearm) && !spawnedAgent.Equipment.HasRangedWeapon(WeaponClass.TwoHandedMace) && !spawnedAgent.Equipment.HasRangedWeapon(WeaponClass.TwoHandedAxe) && !spawnedAgent.Equipment.HasShield() && !spawnedAgent.HasMount)
                {
                    this.EquipBanner(spawnedAgent, spawnedAgent.Origin.Banner);
                }
            }
            this.spawnedAgents.Clear();
        }

        public override void OnAgentBuild(Agent agent, Banner banner)
        {
            if (!agent.IsHuman || agent.IsHero || agent.Origin.Troop == null || agent.Origin.Troop.Culture == null || agent.Origin.Troop.Culture.IsBandit)
            {
                return;
            }

            this.spawnedAgents.Add(agent);
        }

        public override void OnAgentFleeing(Agent affectedAgent)
        {
            base.OnAgentFleeing(affectedAgent);
            if (affectedAgent.Equipment == null || affectedAgent.Equipment[EquipmentIndex.ExtraWeaponSlot].IsEmpty)
            {
                return;
            }

            affectedAgent.DropItem(EquipmentIndex.ExtraWeaponSlot);
        }

        public void EquipBanner(Agent agent, Banner banner)
        {
            MissionWeapon weapon = new MissionWeapon(MBObjectManager.Instance.GetObject<ItemObject>("campaign_banner_small"), (ItemModifier)null, banner);
            agent.EquipWeaponToExtraSlotAndWield(ref weapon);
        }
    }
}
