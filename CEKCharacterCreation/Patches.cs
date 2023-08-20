// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.CEKCharacterCreation.Patches
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterCreation;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Multiplayer;

namespace CalradiaExpandedKingdoms.CEKCharacterCreation
{
    internal class Patches
    {
        [HarmonyPatch(typeof(CharacterCreationCultureStageVM), "InitializePlayersFaceKeyAccordingToCultureSelection")]
        public class CEKSandboxInitializePlayersFaceKeyAccordingToCultureSelectionPatch
        {
            private static void Postfix(CharacterCreationCultureVM selectedCulture)
            {
                string str1 = "<BodyProperties version='4' age='25.84' weight='0.5000' build='0.5000'  key='000BAC088000100DB976648E6774B835537D86629511323BDCB177278A84F667017776140748B49500000000000000000000000000000000000000003EFC5002'/>";
                string str2 = "<BodyProperties version='4' age='25.84' weight='0.5000' build='0.5000'  key='000500000000000D797664884754DCBAA35E866295A0967774414A498C8336860F7776F20BA7B7A500000000000000000000000000000000000000003CFC2002'/>";
                string str3 = "<BodyProperties version='4' age='25.84' weight='0.5000' build='0.5000'  key='001CB80CC000300D7C7664876753888A7577866254C69643C4B647398C95A0370077760307A7497300000000000000000000000000000000000000003AF47002'/>";
                string str4 = "<BodyProperties version='4' age='25.84' weight='0.5000' build='0.5000'  key='0028C80FC000100DBA756445533377873CD1833B3101B44A21C3C5347CA32C260F7776F20BBC35E8000000000000000000000000000000000000000042F41002'/>";
                string str5 = "<BodyProperties version='4' age='25.84' weight='0.5000' build='0.5000'   key='0016F80E4000200EB8708BD6CDC85229D3698B3ABDFE344CD22D3DD5388988680F7776F20B96723B00000000000000000000000000000000000000003EF41002'/>";
                string keyValue = "";
                if (selectedCulture.Culture.StringId == "apolssalian")
                {
                    keyValue = str4;
                }
                else if (selectedCulture.Culture.StringId == "lyrion")
                {
                    keyValue = str4;
                }
                else if (selectedCulture.Culture.StringId == "rebkhu")
                {
                    keyValue = str5;
                }
                else if (selectedCulture.Culture.StringId == "rhodok")
                {
                    keyValue = str1;
                }
                else if (selectedCulture.Culture.StringId == "nordling")
                {
                    keyValue = str2;
                }
                else if (selectedCulture.Culture.StringId == "vagir")
                {
                    keyValue = str2;
                }
                else if (selectedCulture.Culture.StringId == "republic")
                {
                    keyValue = str3;
                }
                else if (selectedCulture.Culture.StringId == "paleician")
                {
                    keyValue = str3;
                }

                BodyProperties bodyProperties;
                if (!(keyValue != "") || !BodyProperties.FromString(keyValue, out bodyProperties))
                {
                    return;
                }

                CharacterObject.PlayerCharacter.UpdatePlayerCharacterBodyProperties(bodyProperties, CharacterObject.PlayerCharacter.Race, CharacterObject.PlayerCharacter.IsFemale);
            }
        }

        [HarmonyPatch(typeof(WidgetsMultiplayerHelper), "GetFactionColorCode")]
        public class CEKSandboxSetColorGradientPatch
        {
            private static void Postfix(
              ref string lowercaseFactionCode,
              bool useSecondary,
              ref string __result)
            {
                if (useSecondary)
                {
                    if (!(__result == "#000000FF"))
                    {
                        return;
                    }

                    if (lowercaseFactionCode == "nordling")
                    {
                        __result = "#3654b5FF";
                    }

                    if (lowercaseFactionCode == "vagir")
                    {
                        __result = "#2a8e99FF";
                    }

                    if (lowercaseFactionCode == "rhodok")
                    {
                        __result = "#db7530FF";
                    }

                    if (lowercaseFactionCode == "apolssalian")
                    {
                        __result = "#e0be26FF";
                    }

                    if (lowercaseFactionCode == "lyrion")
                    {
                        __result = "#bf742eFF";
                    }

                    if (lowercaseFactionCode == "rebkhu")
                    {
                        __result = "#2f5c30FF";
                    }

                    if (lowercaseFactionCode == "paleician")
                    {
                        __result = "#2b273dFF";
                    }

                    if (lowercaseFactionCode == "republic")
                    {
                        __result = "#d43737FF";
                    }
                }
                else if (__result == "#FFFFFFFF")
                {
                    if (lowercaseFactionCode == "nordling")
                    {
                        __result = "#3654b5FF";
                    }

                    if (lowercaseFactionCode == "vagir")
                    {
                        __result = "#2a8e99FF";
                    }

                    if (lowercaseFactionCode == "rhodok")
                    {
                        __result = "#db7530FF";
                    }

                    if (lowercaseFactionCode == "apolssalian")
                    {
                        __result = "#e0be26FF";
                    }

                    if (lowercaseFactionCode == "lyrion")
                    {
                        __result = "#bf742eFF";
                    }

                    if (lowercaseFactionCode == "rebkhu")
                    {
                        __result = "#2f5c30FF";
                    }

                    if (lowercaseFactionCode == "paleician")
                    {
                        __result = "#2b273dFF";
                    }

                    if (lowercaseFactionCode == "republic")
                    {
                        __result = "#d43737FF";
                    }
                }
            }
        }
    }
}
