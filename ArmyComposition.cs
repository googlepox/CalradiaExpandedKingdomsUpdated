// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.ArmyComposition
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Helpers;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms
{
    public static class ArmyComposition
    {
        public static Dictionary<CharacterObject, float> GetDesireForTroops(
          CharacterObject[] volunteers,
          MobileParty mobileParty)
        {
            Dictionary<CharacterObject, float> dic = new Dictionary<CharacterObject, float>();
            Dictionary<ArmyComposition.TroopType, float> culturalComposition = (Dictionary<ArmyComposition.TroopType, float>)null;
            if (mobileParty.LeaderHero != null)
            {
                culturalComposition = ArmyComposition.GetCulturalComposition(mobileParty.LeaderHero.Culture);
            }

            if (culturalComposition != null)
            {
                Dictionary<ArmyComposition.TroopType, float> compositionNumbers = ArmyComposition.GetPartyCompositionNumbers(mobileParty);
                foreach (CharacterObject volunteer in volunteers)
                {
                    if (volunteer != null)
                    {
                        ArmyComposition.TroopType troopType = ArmyComposition.GetTroopType(volunteer);
                        float comparingCompositions = ArmyComposition.GetTroopDesireByComparingCompositions(culturalComposition, compositionNumbers, troopType, volunteer, mobileParty.LeaderHero.Culture);
                        ArmyComposition.AddOrReplace(dic, volunteer, comparingCompositions);
                    }
                }
            }
            return dic;
        }

        public static float CalculateUpgradeDesire(
          CharacterObject upgradeTarget,
          MobileParty mobileParty)
        {
            float upgradeDesire = 1f;
            if (mobileParty != null && upgradeTarget != null)
            {
                Dictionary<ArmyComposition.TroopType, float> culturalComposition = (Dictionary<ArmyComposition.TroopType, float>)null;
                if (mobileParty.LeaderHero != null)
                {
                    culturalComposition = ArmyComposition.GetCulturalComposition(mobileParty.LeaderHero.Culture);
                }

                if (culturalComposition != null)
                {
                    ArmyComposition.TroopType troopType = ArmyComposition.GetTroopType(upgradeTarget);
                    Dictionary<ArmyComposition.TroopType, float> compositionNumbers = ArmyComposition.GetPartyCompositionNumbers(mobileParty);
                    upgradeDesire *= ArmyComposition.GetTroopDesireByComparingCompositions(culturalComposition, compositionNumbers, troopType, upgradeTarget, mobileParty.LeaderHero.Culture);
                }
            }
            return upgradeDesire;
        }

        private static float GetTroopDesireByComparingCompositions(
          Dictionary<ArmyComposition.TroopType, float> culturalComposition,
          Dictionary<ArmyComposition.TroopType, float> finalComposition,
          ArmyComposition.TroopType currentType,
          CharacterObject target,
          CultureObject reference)
        {
            float comparingCompositions = 0.1f;
            if (CEKHelpers.IsInCultureGroup((BasicCultureObject)target.Culture, (BasicCultureObject)reference) || target.Occupation == Occupation.Mercenary)
            {
                if (finalComposition.ContainsKey(currentType))
                {
                    float num1 = finalComposition[currentType];
                    if (culturalComposition.ContainsKey(currentType))
                    {
                        float num2 = culturalComposition[currentType];
                        comparingCompositions = (double)num1 >= (double)num2 ? 0.5f : 1f;
                    }
                    else if (ArmyComposition.ADesiredTypeExistsInUpgrades(culturalComposition, target))
                    {
                        comparingCompositions = 0.65f;
                    }
                }
                else if (culturalComposition.ContainsKey(currentType))
                {
                    comparingCompositions = 1f;
                }
                else if (ArmyComposition.ADesiredTypeExistsInUpgrades(culturalComposition, target))
                {
                    comparingCompositions = 0.65f;
                }
            }
            return comparingCompositions;
        }

        private static Dictionary<ArmyComposition.TroopType, float> GetPartyCompositionNumbers(
          MobileParty mobileParty)
        {
            Dictionary<ArmyComposition.TroopType, int> dictionary = new Dictionary<ArmyComposition.TroopType, int>();
            foreach (TroopRosterElement troopRosterElement in mobileParty.Party.MemberRoster.GetTroopRoster())
            {
                if (troopRosterElement.Character != null)
                {
                    ArmyComposition.TroopType troopType = ArmyComposition.GetTroopType(troopRosterElement.Character);
                    if (dictionary.ContainsKey(troopType))
                    {
                        dictionary[troopType] += troopRosterElement.Number;
                    }
                    else
                    {
                        dictionary.Add(troopType, troopRosterElement.Number);
                    }
                }
            }
            int numberOfAllMembers = mobileParty.Party.NumberOfAllMembers;
            Dictionary<ArmyComposition.TroopType, float> compositionNumbers = new Dictionary<ArmyComposition.TroopType, float>();
            foreach (KeyValuePair<ArmyComposition.TroopType, int> keyValuePair in dictionary)
            {
                float num = (float)keyValuePair.Value / (float)numberOfAllMembers;
                compositionNumbers.Add(keyValuePair.Key, num);
            }
            return compositionNumbers;
        }

        private static void AddOrReplace(
          Dictionary<CharacterObject, float> dic,
          CharacterObject key,
          float value)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }

        private static bool ADesiredTypeExistsInUpgrades(
          Dictionary<ArmyComposition.TroopType, float> culturalComposition,
          CharacterObject candidate)
        {
            if (candidate.UpgradeTargets != null)
            {
                foreach (CharacterObject upgradeTarget1 in candidate.UpgradeTargets)
                {
                    if (culturalComposition.ContainsKey(ArmyComposition.GetTroopType(upgradeTarget1)))
                    {
                        return true;
                    }

                    if (upgradeTarget1.UpgradeTargets != null)
                    {
                        foreach (CharacterObject upgradeTarget2 in upgradeTarget1.UpgradeTargets)
                        {
                            if (culturalComposition.ContainsKey(ArmyComposition.GetTroopType(upgradeTarget2)))
                            {
                                return true;
                            }

                            if (upgradeTarget2.UpgradeTargets != null)
                            {
                                foreach (CharacterObject upgradeTarget3 in upgradeTarget2.UpgradeTargets)
                                {
                                    if (culturalComposition.ContainsKey(ArmyComposition.GetTroopType(upgradeTarget3)))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private static Dictionary<ArmyComposition.TroopType, float> GetCulturalComposition(
          CultureObject culture)
        {
            if (culture != null)
            {
                if (culture == CEKHelpers.GetCultureObjectByID("khuzait"))
                {
                    return new Dictionary<ArmyComposition.TroopType, float>()
          {
            {
              ArmyComposition.TroopType.HorseArcher,
              0.35f
            },
            {
              ArmyComposition.TroopType.LightCavalry,
              0.35f
            },
            {
              ArmyComposition.TroopType.TwoHanded,
              0.15f
            },
            {
              ArmyComposition.TroopType.Ranged,
              0.15f
            }
          };
                }

                if (culture == CEKHelpers.GetCultureObjectByID("rebkhu"))
                {
                    return new Dictionary<ArmyComposition.TroopType, float>()
          {
            {
              ArmyComposition.TroopType.MountedSkirmisher,
              0.25f
            },
            {
              ArmyComposition.TroopType.LightCavalry,
              0.2f
            },
            {
              ArmyComposition.TroopType.HeavyCavalry,
              0.2f
            },
            {
              ArmyComposition.TroopType.LightInfantry,
              0.1f
            },
            {
              ArmyComposition.TroopType.HeavyInfantry,
              0.1f
            },
            {
              ArmyComposition.TroopType.Ranged,
              0.15f
            }
          };
                }

                if (culture == CEKHelpers.GetCultureObjectByID("rhodok"))
                {
                    return new Dictionary<ArmyComposition.TroopType, float>()
          {
            {
              ArmyComposition.TroopType.LightCavalry,
              0.05f
            },
            {
              ArmyComposition.TroopType.LightInfantry,
              0.2f
            },
            {
              ArmyComposition.TroopType.HeavyInfantry,
              0.25f
            },
            {
              ArmyComposition.TroopType.TwoHanded,
              0.2f
            },
            {
              ArmyComposition.TroopType.Ranged,
              0.3f
            }
          };
                }

                if (culture == CEKHelpers.GetCultureObjectByID("vlandia"))
                {
                    return new Dictionary<ArmyComposition.TroopType, float>()
          {
            {
              ArmyComposition.TroopType.LightCavalry,
              0.1f
            },
            {
              ArmyComposition.TroopType.HeavyCavalry,
              0.35f
            },
            {
              ArmyComposition.TroopType.LightInfantry,
              0.2f
            },
            {
              ArmyComposition.TroopType.HeavyInfantry,
              0.15f
            },
            {
              ArmyComposition.TroopType.Ranged,
              0.2f
            }
          };
                }

                if (culture == CEKHelpers.GetCultureObjectByID("paleician"))
                {
                    return new Dictionary<ArmyComposition.TroopType, float>()
          {
            {
              ArmyComposition.TroopType.LightCavalry,
              0.1f
            },
            {
              ArmyComposition.TroopType.LightInfantry,
              0.15f
            },
            {
              ArmyComposition.TroopType.HeavyInfantry,
              0.3f
            },
            {
              ArmyComposition.TroopType.TwoHanded,
              0.2f
            },
            {
              ArmyComposition.TroopType.Ranged,
              0.25f
            }
          };
                }

                if (culture == CEKHelpers.GetCultureObjectByID("nordling"))
                {
                    return new Dictionary<ArmyComposition.TroopType, float>()
          {
            {
              ArmyComposition.TroopType.LightCavalry,
              0.05f
            },
            {
              ArmyComposition.TroopType.LightInfantry,
              0.1f
            },
            {
              ArmyComposition.TroopType.HeavyInfantry,
              0.2f
            },
            {
              ArmyComposition.TroopType.TwoHanded,
              0.35f
            },
            {
              ArmyComposition.TroopType.Skirmisher,
              0.1f
            },
            {
              ArmyComposition.TroopType.Ranged,
              0.2f
            }
          };
                }

                if (culture == CEKHelpers.GetCultureObjectByID("sturgia"))
                {
                    return new Dictionary<ArmyComposition.TroopType, float>()
          {
            {
              ArmyComposition.TroopType.HeavyCavalry,
              0.15f
            },
            {
              ArmyComposition.TroopType.MountedSkirmisher,
              0.15f
            },
            {
              ArmyComposition.TroopType.HorseArcher,
              0.05f
            },
            {
              ArmyComposition.TroopType.LightInfantry,
              0.25f
            },
            {
              ArmyComposition.TroopType.HeavyInfantry,
              0.2f
            },
            {
              ArmyComposition.TroopType.Ranged,
              0.2f
            }
          };
                }

                if (culture == CEKHelpers.GetCultureObjectByID("vagir"))
                {
                    return new Dictionary<ArmyComposition.TroopType, float>()
          {
            {
              ArmyComposition.TroopType.HeavyCavalry,
              0.2f
            },
            {
              ArmyComposition.TroopType.HorseArcher,
              0.1f
            },
            {
              ArmyComposition.TroopType.LightCavalry,
              0.1f
            },
            {
              ArmyComposition.TroopType.LightInfantry,
              0.15f
            },
            {
              ArmyComposition.TroopType.HeavyInfantry,
              0.15f
            },
            {
              ArmyComposition.TroopType.TwoHanded,
              0.15f
            },
            {
              ArmyComposition.TroopType.Ranged,
              0.15f
            }
          };
                }

                if (culture == CEKHelpers.GetCultureObjectByID("battania"))
                {
                    return new Dictionary<ArmyComposition.TroopType, float>()
          {
            {
              ArmyComposition.TroopType.LightCavalry,
              0.05f
            },
            {
              ArmyComposition.TroopType.LightInfantry,
              0.15f
            },
            {
              ArmyComposition.TroopType.HeavyInfantry,
              0.2f
            },
            {
              ArmyComposition.TroopType.TwoHanded,
              0.15f
            },
            {
              ArmyComposition.TroopType.Skirmisher,
              0.15f
            },
            {
              ArmyComposition.TroopType.Ranged,
              0.3f
            }
          };
                }

                if (culture == CEKHelpers.GetCultureObjectByID("aserai"))
                {
                    return new Dictionary<ArmyComposition.TroopType, float>()
          {
            {
              ArmyComposition.TroopType.HorseArcher,
              0.25f
            },
            {
              ArmyComposition.TroopType.MountedSkirmisher,
              0.25f
            },
            {
              ArmyComposition.TroopType.LightCavalry,
              0.1f
            },
            {
              ArmyComposition.TroopType.LightInfantry,
              0.1f
            },
            {
              ArmyComposition.TroopType.HeavyInfantry,
              0.05f
            },
            {
              ArmyComposition.TroopType.TwoHanded,
              0.1f
            },
            {
              ArmyComposition.TroopType.Ranged,
              0.15f
            }
          };
                }

                if (culture == CEKHelpers.GetCultureObjectByID("lyrion"))
                {
                    return new Dictionary<ArmyComposition.TroopType, float>()
          {
            {
              ArmyComposition.TroopType.LightCavalry,
              0.15f
            },
            {
              ArmyComposition.TroopType.MountedSkirmisher,
              0.25f
            },
            {
              ArmyComposition.TroopType.LightInfantry,
              0.15f
            },
            {
              ArmyComposition.TroopType.HeavyInfantry,
              0.25f
            },
            {
              ArmyComposition.TroopType.Ranged,
              0.2f
            }
          };
                }

                if (culture == CEKHelpers.GetCultureObjectByID("empire") || culture == CEKHelpers.GetCultureObjectByID("republic") || culture == CEKHelpers.GetCultureObjectByID("apolssalian"))
                {
                    return new Dictionary<ArmyComposition.TroopType, float>()
          {
            {
              ArmyComposition.TroopType.HeavyCavalry,
              0.25f
            },
            {
              ArmyComposition.TroopType.LightInfantry,
              0.1f
            },
            {
              ArmyComposition.TroopType.HeavyInfantry,
              0.35f
            },
            {
              ArmyComposition.TroopType.Skirmisher,
              0.1f
            },
            {
              ArmyComposition.TroopType.Ranged,
              0.2f
            }
          };
                }
            }
            return (Dictionary<ArmyComposition.TroopType, float>)null;
        }

        private static ArmyComposition.TroopType GetTroopType(CharacterObject troop)
        {
            if (troop.FirstBattleEquipment == null)
            {
                return ArmyComposition.TroopType.Unknown;
            }

            Equipment firstBattleEquipment = troop.FirstBattleEquipment;
            if (troop.IsInfantry)
            {
                if (firstBattleEquipment.HasWeaponOfClass(WeaponClass.Javelin))
                {
                    return ArmyComposition.TroopType.Skirmisher;
                }

                if (firstBattleEquipment.HasWeaponOfClass(WeaponClass.TwoHandedAxe) || firstBattleEquipment.HasWeaponOfClass(WeaponClass.TwoHandedMace) || firstBattleEquipment.HasWeaponOfClass(WeaponClass.TwoHandedSword))
                {
                    return ArmyComposition.TroopType.TwoHanded;
                }

                return troop.Tier <= 3 ? ArmyComposition.TroopType.LightInfantry : ArmyComposition.TroopType.HeavyInfantry;
            }
            if (troop.IsRanged)
            {
                return firstBattleEquipment.HasWeaponOfClass(WeaponClass.Javelin) ? ArmyComposition.TroopType.Skirmisher : ArmyComposition.TroopType.Ranged;
            }

            if (!troop.IsMounted)
            {
                return ArmyComposition.TroopType.Unknown;
            }

            if (firstBattleEquipment.HasWeaponOfClass(WeaponClass.Javelin))
            {
                return ArmyComposition.TroopType.MountedSkirmisher;
            }

            if (firstBattleEquipment.HasWeaponOfClass(WeaponClass.Bow) || firstBattleEquipment.HasWeaponOfClass(WeaponClass.Crossbow))
            {
                return ArmyComposition.TroopType.HorseArcher;
            }

            return !CEKHelpers.IsEliteTroop(troop) ? ArmyComposition.TroopType.LightCavalry : ArmyComposition.TroopType.HeavyCavalry;
        }

        private enum TroopType
        {
            LightInfantry,
            HeavyInfantry,
            Ranged,
            Skirmisher,
            LightCavalry,
            HeavyCavalry,
            HorseArcher,
            MountedSkirmisher,
            TwoHanded,
            Unknown,
        }
    }
}
