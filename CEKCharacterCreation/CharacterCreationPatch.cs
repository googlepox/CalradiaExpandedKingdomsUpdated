using HarmonyLib;
using SandBox;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.CEKCharacterCreation
{
    [HarmonyPatch(typeof(SandBoxGameManager), "LaunchSandboxCharacterCreation")]
    internal class CharacterCreationPatch
    {
        public static bool Prefix()
        {
            Game.Current.GameStateManager.CleanAndPushState(Game.Current.GameStateManager.CreateState<CharacterCreationState>(new CEKCharacterCreationContent()));
            return false;
        }
    }
}
