// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Docks.DocksCampaignBehavior
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Overlay;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace CalradiaExpandedKingdoms.Docks
{
  public class DocksCampaignBehavior : CampaignBehaviorBase
  {
    public static MethodInfo visit_the_tavern_on_conditionMethodInfo = AccessTools.Method(typeof (PlayerTownVisitCampaignBehavior), "visit_the_tavern_on_condition", (Type[]) null, (Type[]) null);
    public static MethodInfo town_backstreet_on_initMethodInfo = AccessTools.Method(typeof (PlayerTownVisitCampaignBehavior), "town_backstreet_on_init", (Type[]) null, (Type[]) null);
    public static MethodInfo back_on_conditionMethodInfo = AccessTools.Method(typeof (PlayerTownVisitCampaignBehavior), "back_on_condition", (Type[]) null, (Type[]) null);
    public static MethodInfo game_menu_town_town_leave_on_conditionMethodInfo = AccessTools.Method(typeof (PlayerTownVisitCampaignBehavior), "game_menu_town_town_leave_on_condition", (Type[]) null, (Type[]) null);
    private static List<Settlement> Towns;
    private static CampaignTime travelStartTime;
    private static Settlement travelToSettlement;
    private static float travelTimeDays;

    public override void RegisterEvents() => CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener((object) this, new Action<CampaignGameStarter>(this.AddPortMenu));

    public override void SyncData(IDataStore dataStore)
    {
    }

    public static bool visit_the_tavern_on_condition(MenuCallbackArgs args) => (bool) DocksCampaignBehavior.visit_the_tavern_on_conditionMethodInfo.Invoke((object) null, new object[1]
    {
      (object) args
    });

    private static void town_backstreet_on_init(MenuCallbackArgs args) => DocksCampaignBehavior.town_backstreet_on_initMethodInfo.Invoke((object) null, new object[1]
    {
      (object) args
    });

    public static bool back_on_condition(MenuCallbackArgs args) => (bool) DocksCampaignBehavior.back_on_conditionMethodInfo.Invoke((object) null, new object[1]
    {
      (object) args
    });

    public static bool game_menu_town_town_leave_on_condition(MenuCallbackArgs args) => (bool) DocksCampaignBehavior.game_menu_town_town_leave_on_conditionMethodInfo.Invoke((object) null, new object[1]
    {
      (object) args
    });

    private bool IsAtSea() => DocksCampaignBehavior.Towns.Contains(Settlement.CurrentSettlement);

    private int CalculatePrice(Settlement settlement)
    {
      float num1 = Settlement.CurrentSettlement.GatePosition.Distance(settlement.GatePosition);
      int skillValue = Hero.MainHero.GetSkillValue(DefaultSkills.Medicine);
      float num2 = num1 * 5f + (float) (MobileParty.MainParty.Party.NumberOfAllMembers * 25);
      return (int) (num2 - num2 * (float) (0.05000000074505806 * (double) skillValue / 100.0));
    }

    private float CalculateTime(Settlement targetSettlement) => Settlement.CurrentSettlement.GatePosition.Distance(targetSettlement.GatePosition) / 75f;

    private void OpenWaitMenu(Settlement settlement, int cost)
    {
      if (Hero.MainHero.Gold < cost)
      {
        InformationManager.DisplayMessage(new InformationMessage("You don't have enough denars."));
      }
      else
      {
        Hero.MainHero.Gold -= cost;
        DocksCampaignBehavior.travelStartTime = CampaignTime.Now;
        DocksCampaignBehavior.travelToSettlement = settlement;
        PlayerEncounter.Current.IsPlayerWaiting = true;
        GameMenu.SwitchToMenu("docks_wait");
      }
    }

    private void MovePlayerToSettlement()
    {
      Campaign.Current.SpeedUpMultiplier = 4f;
      PlayerEncounter.Finish();
      if (!DocksCampaignBehavior.travelToSettlement.IsUnderSiege)
        EncounterManager.StartSettlementEncounter(MobileParty.MainParty, DocksCampaignBehavior.travelToSettlement);
      MobileParty.MainParty.Position2D = DocksCampaignBehavior.travelToSettlement.GatePosition;
    }

    private void AddPortMenu(CampaignGameStarter campaignGameSystemStarter)
    {
      DocksCampaignBehavior.Towns = new List<Settlement>()
      {
        Settlement.Find("town_ES2"),
        Settlement.Find("town_A4"),
        Settlement.Find("town_A8"),
        Settlement.Find("town_A6"),
        Settlement.Find("town_A1"),
        Settlement.Find("town_EW2"),
        Settlement.Find("town_EW4"),
        Settlement.Find("town_V7"),
        Settlement.Find("town_V11"),
        Settlement.Find("town_V4"),
        Settlement.Find("town_B6"),
        Settlement.Find("town_EN2"),
        Settlement.Find("town_S4"),
        Settlement.Find("town_S9"),
        Settlement.Find("town_A10"),
        Settlement.Find("town_TT1")
      };
      campaignGameSystemStarter.AddGameMenuOption("town", "town_docks", "{=!}Go to the docks", (GameMenuOption.OnConditionDelegate) (args =>
      {
        args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
        return this.IsAtSea();
      }), (GameMenuOption.OnConsequenceDelegate) (args => GameMenu.SwitchToMenu("town_docks")), false, 4, false);
      campaignGameSystemStarter.AddGameMenu("town_docks", "{=!}You are at the Docks.", new OnInitDelegate(DocksCampaignBehavior.town_backstreet_on_init), GameOverlays.MenuOverlayType.SettlementWithParties);
      campaignGameSystemStarter.AddGameMenuOption("town_docks", "town_docks_sail", "{=!}Sail to another town", (GameMenuOption.OnConditionDelegate) (args =>
      {
        args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
        return this.IsAtSea();
      }), (GameMenuOption.OnConsequenceDelegate) (args => GameMenu.SwitchToMenu("docks_sail")), false, -1, false);
      campaignGameSystemStarter.AddGameMenuOption("town_docks", "town_docks_back", "{=!}Back to town center", new GameMenuOption.OnConditionDelegate(DocksCampaignBehavior.back_on_condition), (GameMenuOption.OnConsequenceDelegate) (x => GameMenu.SwitchToMenu("town")), true, -1, false);
      campaignGameSystemStarter.AddGameMenu("docks_sail", "{=!}Select a town.", new OnInitDelegate(DocksCampaignBehavior.town_backstreet_on_init), GameOverlays.MenuOverlayType.SettlementWithParties);
      foreach (Settlement town in DocksCampaignBehavior.Towns)
      {
        Settlement settlement = town;
        campaignGameSystemStarter.AddGameMenuOption("docks_sail", "docks_sail_to_" + settlement.StringId, "{=!}Sail to " + settlement.Name.ToString(), (GameMenuOption.OnConditionDelegate) (args =>
        {
          args.optionLeaveType = GameMenuOption.LeaveType.Trade;
          return settlement != MobileParty.MainParty.CurrentSettlement && !settlement.IsUnderSiege && !settlement.OwnerClan.IsAtWarWith((IFaction) Hero.MainHero.Clan) && !Hero.MainHero.CurrentSettlement.IsUnderSiege;
        }), (GameMenuOption.OnConsequenceDelegate) (x =>
        {
          int Cost = this.CalculatePrice(settlement);
          float time = this.CalculateTime(settlement);
          DocksCampaignBehavior.travelTimeDays = time;
          InformationManager.ShowInquiry(new InquiryData("Do you really want to sail to " + settlement.Name.ToString() + "?", "The Journey will cost " + Cost.ToString() + " denars and take " + Math.Round((double) time, 1, MidpointRounding.ToEven).ToString() + " days", true, true, "Yes", "Cancel", (Action) (() => this.OpenWaitMenu(settlement, Cost)), (Action) null, "", 0.0f, (Action) null));
        }), true, -1, false);
      }
      campaignGameSystemStarter.AddWaitGameMenu("docks_wait", "{=!}You are traveling to {TOWN_NAME}.", (OnInitDelegate) (args =>
      {
        args.MenuContext.GameMenu.StartWait();
        MBTextManager.SetTextVariable("TOWN_NAME", DocksCampaignBehavior.travelToSettlement.Name.ToString(), false);
      }), (OnConditionDelegate) (args =>
      {
        args.MenuContext.GameMenu.StartWait();
        args.optionLeaveType = GameMenuOption.LeaveType.Wait;
        Campaign.Current.SpeedUpMultiplier = 10f;
        return true;
      }), (OnConsequenceDelegate) (args => this.MovePlayerToSettlement()), (OnTickDelegate) ((args, dt) => args.MenuContext.GameMenu.SetProgressOfWaitingInMenu(DocksCampaignBehavior.travelStartTime.ElapsedDaysUntilNow / DocksCampaignBehavior.travelTimeDays)), GameMenu.MenuAndOptionType.WaitMenuShowOnlyProgressOption);
      campaignGameSystemStarter.AddGameMenuOption("docks_wait", "docks_wait_leave", "", (GameMenuOption.OnConditionDelegate) (args => true), (GameMenuOption.OnConsequenceDelegate) (args => { }), false, -1, false);
      campaignGameSystemStarter.AddGameMenuOption("docks_sail", "docks_sail_back", "{=!}Back to the docks", new GameMenuOption.OnConditionDelegate(DocksCampaignBehavior.back_on_condition), (GameMenuOption.OnConsequenceDelegate) (x => GameMenu.SwitchToMenu("town_docks")), true, -1, false);
    }
  }
}
