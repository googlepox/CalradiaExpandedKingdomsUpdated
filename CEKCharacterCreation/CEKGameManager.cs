// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.CEKCharacterCreation.CEKGameManager
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using SandBox;
using System;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;
using TaleWorlds.ModuleManager;
using TaleWorlds.MountAndBlade;
using TaleWorlds.SaveSystem.Load;

namespace CalradiaExpandedKingdoms.CEKCharacterCreation
{
    internal class CEKGameManager : SandBoxGameManager
    {
        public CEKGameManager()
        {
        }

        public CEKGameManager(LoadResult loadedGameResult)
          : base(loadedGameResult)
        {
        }

        public override void OnLoadFinished()
        {
            VideoPlaybackState state = Game.Current.GameStateManager.CreateState<VideoPlaybackState>();
            string str = ModuleHelper.GetModuleFullPath("SandBox") + "Videos/CampaignIntro/";
            string subtitleFileBasePath = str + "campaign_intro";
            string videoPath = str + "campaign_intro.ivf";
            string audioPath = str + "campaign_intro.ogg";
            state.SetStartingParameters(videoPath, audioPath, subtitleFileBasePath);
            state.SetOnVideoFinisedDelegate(new Action(this.LaunchSandboxCharacterCreation));
            Game.Current.GameStateManager.CleanAndPushState((GameState)state);
            this.IsLoaded = true;
        }

        private void LaunchSandboxCharacterCreation()
        {
            Game.Current.GameStateManager.CleanAndPushState((GameState)Game.Current.GameStateManager.CreateState<CharacterCreationState>((object)new CEKCharacterCreationContent()));
        }
    }
}
