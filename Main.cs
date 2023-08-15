// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Main
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Ariorum;
using CalradiaExpandedKingdoms.CEKCharacterCreation;
using CalradiaExpandedKingdoms.Docks;
using CalradiaExpandedKingdoms.Events;
using CalradiaExpandedKingdoms.Feats;
using CalradiaExpandedKingdoms.Models;
using CalradiaExpandedKingdoms.Quests.FindItemInRuin;
using CalradiaExpandedKingdoms.Ruins;
using HarmonyLib;
using SandBox;
using SandBox.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.SaveSystem;
using TaleWorlds.SaveSystem.Load;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace CalradiaExpandedKingdoms
{
  public class Main : MBSubModuleBase
  {
    public static Harmony patcher = new Harmony("Patcher");
    public static MobileParty upgradingParty;
    protected static string ModulePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase.Remove(0, 8)) + System.IO.Path.DirectorySeparatorChar.ToString() + ".." + System.IO.Path.DirectorySeparatorChar.ToString() + ".." + System.IO.Path.DirectorySeparatorChar.ToString();

    protected override void OnGameStart(Game game, IGameStarter gameStarter)
    {
      if (!(game.GameType is Campaign))
        return;
      CampaignGameStarter campaignGameStarter = (CampaignGameStarter) gameStarter;
      campaignGameStarter.AddBehavior((CampaignBehaviorBase) new DocksCampaignBehavior());
      campaignGameStarter.AddBehavior((CampaignBehaviorBase) new AriorumCampaignBehavior());
      campaignGameStarter.AddBehavior((CampaignBehaviorBase) new CEKCampaignBehavior());
      campaignGameStarter.AddBehavior((CampaignBehaviorBase) new RuinCampaignBehavior());
      campaignGameStarter.AddBehavior((CampaignBehaviorBase) new CEKEvents());
      campaignGameStarter.AddBehavior((CampaignBehaviorBase) new FindItemInRuinQuestBehavior());
      campaignGameStarter.AddModel((GameModel) new CEKItemValueModel());
      campaignGameStarter.AddModel((GameModel) new CEKBuildingConstructionModel());
      campaignGameStarter.AddModel((GameModel) new CEKBattleRewardModel());
      campaignGameStarter.AddModel((GameModel) new CEKSettlementProsperityModel());
      campaignGameStarter.AddModel((GameModel) new CEKSettlementLoyaltyModel());
      campaignGameStarter.AddModel((GameModel) new CEKSettlementSecurityModel());
      campaignGameStarter.AddModel((GameModel) new CEKPartySpeedCalculatingModel());
      campaignGameStarter.AddModel((GameModel) new CEKCombatXpModel());
      campaignGameStarter.AddModel((GameModel) new CEKPartyTroopUpgradeModel());
      campaignGameStarter.AddModel((GameModel) new CEKPartyWageModel());
      campaignGameStarter.AddModel((GameModel) new CEKSettlementTaxModel());
      campaignGameStarter.AddModel((GameModel) new CEKRaidModel());
      campaignGameStarter.AddModel((GameModel) new CEKArmyManagementCalculationModel());
      campaignGameStarter.AddModel((GameModel) new CEKSettlementMilitiaModel());
      campaignGameStarter.AddModel((GameModel) new CEKClanFinanceModel());
      campaignGameStarter.AddModel((GameModel) new CEKBattleMoraleModel());
      campaignGameStarter.AddModel((GameModel) new CEKSettlementFoodModel());
      campaignGameStarter.AddModel((GameModel) new CEKPartySizeLimitModel());
      campaignGameStarter.AddModel((GameModel) new CEKVolunteerProductionModel());
      campaignGameStarter.AddModel((GameModel) new CEKVillageProductionModel());
      campaignGameStarter.AddModel((GameModel) new CEKPriceFactorModel());
      CEKFeats.RegisterAll();
    }

    private void LoadPNG(string Name)
    {
      new SpriteData("CalradiaExpandedKingdomsSpriteData").Load(UIResourceManager.UIResourceDepot);
      SpriteData spriteData = UIResourceManager.SpriteData;
      TaleWorlds.Engine.Texture engineTexture = TaleWorlds.Engine.Texture.LoadTextureFromPath(Name + ".png", BasePath.Name + "Modules/CalradiaExpandedKingdoms/AssetSources/GauntletUI");
      engineTexture.PreloadTexture(true);
      TaleWorlds.TwoDimension.Texture texture = new TaleWorlds.TwoDimension.Texture((TaleWorlds.TwoDimension.ITexture) new EngineTexture(engineTexture));
      SpriteCategory spriteCategory = spriteData.SpriteCategories[Name];
      spriteCategory.SpriteSheets.Add(texture);
      spriteCategory.Load((ITwoDimensionResourceContext) UIResourceManager.ResourceContext, UIResourceManager.UIResourceDepot);
      UIResourceManager.BrushFactory.Initialize();
    }

    protected override void OnSubModuleLoad()
    {
      new Harmony("CEK").PatchAll();
      base.OnSubModuleLoad();
      TaleWorlds.MountAndBlade.Module.CurrentModule.ClearStateOptions();
      TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(new InitialStateOption("CampaignResumeGame", new TextObject("{=6mN03uTP}Saved Games"), 0, (Action) (() => ScreenManager.PushScreen(SandBoxViewCreator.CreateSaveLoadScreen(false))), (Func<(bool, TextObject)>) (() => (TaleWorlds.MountAndBlade.Module.CurrentModule.IsOnlyCoreContentEnabled, new TextObject("{=V8BXjyYq}Disabled during installation.")))));
      TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(new InitialStateOption("ContinueCampaign", new TextObject("{=0tJ1oarX}Continue Campaign"), 1, new Action(this.ContinueCampaign), (Func<(bool, TextObject)>) (() => this.IsContinueCampaignDisabled())));
      TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(new InitialStateOption("CEK", new TextObject("{=str_cek}Calradia Expanded: Kingdoms"), 3, (Action) (() => MBGameManager.StartNewGame((MBGameManager) new CEKGameManager())), (Func<(bool, TextObject)>) (() => (TaleWorlds.MountAndBlade.Module.CurrentModule.IsOnlyCoreContentEnabled, new TextObject("{=V8BXjyYq}Disabled during installation.")))));
      TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(new InitialStateOption("Options", new TextObject("{=NqarFr4P}Options"), 9998, (Action) (() => ScreenManager.PushScreen(ViewCreator.CreateOptionsScreen(true))), (Func<(bool, TextObject)>) (() => (false, TextObject.Empty))));
      TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(new InitialStateOption("Credits", new TextObject("{=ODQmOrIw}Credits"), 9999, (Action) (() => ScreenManager.PushScreen(ViewCreator.CreateCreditsScreen())), (Func<(bool, TextObject)>) (() => (false, TextObject.Empty))));
      TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(new InitialStateOption("Exit", new TextObject("{=YbpzLHzk}Exit Game"), 10000, (Action) (() => MBInitialScreenBase.DoExitButtonAction()), (Func<(bool, TextObject)>) (() => (TaleWorlds.MountAndBlade.Module.CurrentModule.IsOnlyCoreContentEnabled, new TextObject("{=V8BXjyYq}Disabled during installation.")))));
      foreach (string Name in new List<string>()
      {
        "ui_charactercreation_vanilla",
        "ui_charactercreation_3",
        "ui_charactercreation_4"
      })
        this.LoadPNG(Name);
    }

    private (bool, TextObject) IsContinueCampaignDisabled()
    {
      if (TaleWorlds.MountAndBlade.Module.CurrentModule.IsOnlyCoreContentEnabled)
        return (true, new TextObject("{=V8BXjyYq}Disabled during installation."));
      return string.IsNullOrEmpty(BannerlordConfig.LatestSaveGameName) ? (true, new TextObject("{=aWMZQKXZ}Save the game at least once to continue")) : (!MBSaveLoad.IsSaveGameFileExists(BannerlordConfig.LatestSaveGameName), new TextObject("{=60LTq0tQ}Can't find the save file for the latest save game."));
    }

    private void ContinueCampaign()
    {
      SaveGameFileInfo saveFileWithName = MBSaveLoad.GetSaveFileWithName(BannerlordConfig.LatestSaveGameName);
      if (saveFileWithName != null && !saveFileWithName.IsCorrupted)
        SandBoxSaveHelper.TryLoadSave(saveFileWithName, new Action<LoadResult>(this.StartGame));
      else
        InformationManager.ShowInquiry(new InquiryData(new TextObject("{=oZrVNUOk}Error").ToString(), new TextObject("{=t6W3UjG0}Save game file appear to be corrupted. Try starting a new campaign or load another one from Saved Games menu.").ToString(), true, false, new TextObject("{=yS7PvrTD}OK").ToString(), (string) null, (Action) null, (Action) null, "", 0.0f, (Action) null));
    }

    private void StartGame(LoadResult loadResult) => MBGameManager.StartNewGame((MBGameManager) new CEKGameManager(loadResult));

    public override void OnMissionBehaviorInitialize(Mission mission)
    {
      if (!CEKCampaignBehavior.IsBannerCarriersOn)
        return;
      base.OnMissionBehaviorInitialize(mission);
      if (Mission.Current.CombatType == Mission.MissionCombatType.Combat && (mission.IsFieldBattle || mission.MissionLogics.OfType<SiegeDeploymentMissionController>().Any<SiegeDeploymentMissionController>()))
        mission.AddMissionBehavior(new EquipBannerMissionBehavior());
    }
  }
}
