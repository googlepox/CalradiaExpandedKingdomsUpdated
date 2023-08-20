// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Ruins.RuinCampaignBehavior
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Events;
using CalradiaExpandedKingdoms.Helpers;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace CalradiaExpandedKingdoms.Ruins
{
    public class RuinCampaignBehavior : CampaignBehaviorBase
    {
        private List<Ruin> ruinComponents;
        private Ruin currentRuin;
        private CampaignTime startTime;
        private List<Settlement> ruinSettlements;
        private float searchMultiplier;
        private int ambushPossibility;
        private MobileParty ambushParty;
        private string raidText;
        private string ambushText;
        private bool lastTick;

        public override void RegisterEvents()
        {
            CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener((object)this, new Action<CampaignGameStarter>(this.OnNewGameCreated));
            CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener((object)this, new Action<CampaignGameStarter>(this.OnGameLoaded));
            CampaignEvents.WeeklyTickEvent.AddNonSerializedListener((object)this, new Action(this.WeeklyTick));
            CampaignEvents.HourlyTickEvent.AddNonSerializedListener((object)this, new Action(this.HourlyTick));
        }

        public override void SyncData(IDataStore dataStore)
        {
            if (dataStore.IsSaving)
            {
                this.ruinComponents = new List<Ruin>();
                foreach (Settlement ruinSettlement in this.ruinSettlements)
                {
                    this.ruinComponents.Add(ruinSettlement.SettlementComponent as Ruin);
                }
            }
            dataStore.SyncData<List<Ruin>>("ruinComponents", ref this.ruinComponents);
        }

        public static RuinCampaignBehavior Current => Campaign.Current.GetCampaignBehavior<RuinCampaignBehavior>();

        public void OnNewGameCreated(CampaignGameStarter campaignGameStarter)
        {
            this.Load(campaignGameStarter);
            foreach (Settlement ruinSettlement in this.ruinSettlements)
            {
                (ruinSettlement.SettlementComponent as Ruin).RuinSettlementID = ruinSettlement.StringId;
            }
        }

        public void OnGameLoaded(CampaignGameStarter campaignGameStarter)
        {
            this.Load(campaignGameStarter);
            foreach (Settlement ruinSettlement1 in this.ruinSettlements)
            {
                Settlement ruinSettlement = ruinSettlement1;
                if ((ruinSettlement.SettlementComponent as Ruin).RuinSettlementID != null)
                {
                    Ruin ruin = this.ruinComponents.First<Ruin>((Func<Ruin, bool>)(x => x.RuinSettlementID == ruinSettlement.StringId));
                    AccessTools.Property(typeof(Settlement), "SettlementComponent").SetValue((object)ruinSettlement, (object)ruin);
                }
                else
                {
                    (ruinSettlement.SettlementComponent as Ruin).RuinSettlementID = ruinSettlement.StringId;
                }
            }
        }

        private void Load(CampaignGameStarter campaignGameStarter)
        {
            this.AddGameMenus(campaignGameStarter);
            this.ruinSettlements = Campaign.Current.Settlements.Where<Settlement>((Func<Settlement, bool>)(x => x.SettlementComponent != null && x.SettlementComponent is Ruin)).ToList<Settlement>();
        }

        private void WeeklyTick()
        {
            foreach (Settlement ruinSettlement in this.ruinSettlements)
            {
                if (ruinSettlement.SettlementComponent is Ruin settlementComponent && (double)settlementComponent.LastRaided.ElapsedYearsUntilNow > 1.0)
                {
                    settlementComponent.ResetRuin();
                }
            }
        }

        private void HourlyTick()
        {
            foreach (Settlement settlement in Settlement.FindAll((Func<Settlement, bool>)(x => x.SettlementComponent != null && x.SettlementComponent is Ruin)))
            {
                if (!(settlement.SettlementComponent as Ruin).IsSpotted)
                {
                    float num = MobileParty.MainParty.SeeingRange * 1f;
                    if (1.0 - (double)MobileParty.MainParty.Position2D.DistanceSquared(settlement.Position2D) / ((double)num * (double)num) > 0.0)
                    {
                        settlement.IsVisible = true;
                        (settlement.SettlementComponent as Ruin).IsSpotted = true;
                        Hero.MainHero.AddSkillXp(DefaultSkills.Scouting, 50f);
                    }
                }
            }
        }

        protected void AddGameMenus(CampaignGameStarter campaignGameStarter)
        {
            campaignGameStarter.AddGameMenu("ruin_place", "{RUIN_TEXT}", new OnInitDelegate(this.game_menu_ruin_place_on_init));
            campaignGameStarter.AddGameMenuOption("ruin_place", "explore", "{=!}Explore", new GameMenuOption.OnConditionDelegate(this.game_menu_ruin_explore_on_condition), new GameMenuOption.OnConsequenceDelegate(this.game_menu_ruin_explore_on_consequence), false, -1, false);
            campaignGameStarter.AddGameMenuOption("ruin_place", "loot", "{=!}Loot", new GameMenuOption.OnConditionDelegate(this.game_menu_ruin_loot_on_condition), new GameMenuOption.OnConsequenceDelegate(this.game_menu_ruin_loot_on_consequence), false, -1, false);
            campaignGameStarter.AddGameMenuOption("ruin_place", "hide", "{=!}Hide inside", new GameMenuOption.OnConditionDelegate(this.game_menu_ruin_hide_on_condition), new GameMenuOption.OnConsequenceDelegate(this.game_menu_ruin_hide_on_consequence), false, -1, false);
            campaignGameStarter.AddGameMenuOption("ruin_place", "leave", "{=3sRdGQou}Leave", new GameMenuOption.OnConditionDelegate(this.leave_on_condition), new GameMenuOption.OnConsequenceDelegate(this.game_menu_ruin_leave_on_consequence), true, -1, false);
            campaignGameStarter.AddWaitGameMenu("ruin_wait", "{RAID_TEXT}", new OnInitDelegate(this.game_menu_ruin_wait_on_init), new OnConditionDelegate(this.game_menu_ruin_wait_on_condition), new OnConsequenceDelegate(this.game_menu_ruin_wait_on_consequence), new OnTickDelegate(this.game_menu_ruin_wait_on_tick), GameMenu.MenuAndOptionType.WaitMenuShowOnlyProgressOption);
            campaignGameStarter.AddWaitGameMenu("ruin_hide", "{=!}You and your party are laying low among the ruins.", new OnInitDelegate(this.game_menu_ruin_hide_wait_on_init), new OnConditionDelegate(this.game_menu_ruin_hide_wait_on_condition), new OnConsequenceDelegate(this.game_menu_ruin_hide_wait_on_consequence), new OnTickDelegate(this.game_menu_ruin_hide_wait_on_tick), GameMenu.MenuAndOptionType.WaitMenuHideProgressAndHoursOption);
            campaignGameStarter.AddGameMenu("ruin_ambush", "{AMBUSH_TEXT}", new OnInitDelegate(this.game_menu_ruin_ambush_on_init));
            campaignGameStarter.AddGameMenuOption("ruin_ambush", "continue", "{=!}Continue", new GameMenuOption.OnConditionDelegate(this.game_menu_ambush_continue_on_condition), new GameMenuOption.OnConsequenceDelegate(this.game_menu_ambush_continue_on_consequence), false, -1, false);
            campaignGameStarter.AddGameMenuOption("ruin_wait", "ruin_wait_leave", "Leave", (GameMenuOption.OnConditionDelegate)(args => true), (GameMenuOption.OnConsequenceDelegate)(args =>
            {
                args.optionLeaveType = GameMenuOption.LeaveType.Leave;
                EnterSettlementAction.ApplyForParty(MobileParty.MainParty, Settlement.CurrentSettlement);
                GameMenu.SwitchToMenu("ruin_place");
            }), false, -1, false);
            campaignGameStarter.AddGameMenuOption("ruin_hide", "ruin_hide_leave", "Leave", (GameMenuOption.OnConditionDelegate)(args => true), (GameMenuOption.OnConsequenceDelegate)(args =>
            {
                args.optionLeaveType = GameMenuOption.LeaveType.Leave;
                GameMenu.SwitchToMenu("ruin_place");
            }), false, -1, false);
        }

        private void game_menu_ruin_wait_on_tick(MenuCallbackArgs args, CampaignTime dt)
        {
            this.currentRuin.RaidProgress = this.startTime.ElapsedDaysUntilNow / 1f;
            args.MenuContext.GameMenu.SetProgressOfWaitingInMenu(this.currentRuin.RaidProgress);
            if ((double)this.currentRuin.RaidProgress > 0.99000000953674316 && !this.lastTick)
            {
                this.currentRuin.RaidProgress = 1f;
                this.lastTick = true;
                this.RaidAction();
            }
            if ((double)this.currentRuin.RaidProgress - (double)this.currentRuin.LastTick <= 0.10000000149011612 || (double)this.currentRuin.RaidProgress == 1.0 || (double)this.currentRuin.RaidProgress >= 1.0)
            {
                return;
            }

            this.currentRuin.LastTick += 0.1f;
            this.RaidAction();
        }

        private void RaidAction()
        {
            int num = MBRandom.RandomInt(1, 100);
            if (num <= this.ambushPossibility)
            {
                if (!this.currentRuin.HasBandits)
                {
                    return;
                }

                GameMenu.SwitchToMenu("ruin_ambush");
            }
            else if (num <= 20 && num > 10)
            {
                this.FindLoot();
            }
            else
            {
                if (num > 40)
                {
                    return;
                }

                this.FindGold();
            }
        }

        private void FindGold()
        {
            int num1 = 0;
            switch (this.currentRuin.RuinType)
            {
                case RuinType.Town:
                    num1 = 5000;
                    break;
                case RuinType.Castle:
                    num1 = 4000;
                    break;
                case RuinType.Village:
                    num1 = 3000;
                    break;
                case RuinType.Misc:
                    num1 = 2000;
                    break;
            }
            int num2 = MBRandom.RandomInt(50, (int)Math.Round((double)num1 * (double)this.searchMultiplier));
            TextObject textObject = new TextObject("{=!}You found {CHANGE} {GOLD_ICON}");
            textObject.SetTextVariable("CHANGE", num2);
            textObject.SetTextVariable("GOLD_ICON", "{=!}<img src=\"General\\Icons\\Coin@2x\" extend=\"8\">");
            string soundEventPath = "event:/ui/notification/coins_positive";
            InformationManager.DisplayMessage(new InformationMessage(textObject.ToString(), soundEventPath));
            Hero.MainHero.ChangeHeroGold(num2);
        }

        private void FindLoot()
        {
            int num1 = 0;
            switch (this.currentRuin.RuinType)
            {
                case RuinType.Town:
                    num1 = 10000;
                    break;
                case RuinType.Castle:
                    num1 = 8000;
                    break;
                case RuinType.Village:
                    num1 = 6000;
                    break;
                case RuinType.Misc:
                    num1 = 4000;
                    break;
            }
            int num2 = 0;
            int num3 = (int)Math.Round((double)num1 * (double)this.searchMultiplier);
            List<ItemObject> itemObjectList = new List<ItemObject>();
            List<ItemObject> list = Items.All.Where<ItemObject>((Func<ItemObject, bool>)(x => x.Value > 500 && x.Value < 10000 && !x.IsAnimal)).ToList<ItemObject>();
            for (int index = 0; index < 5; ++index)
            {
                ItemObject itemObject = list[MBRandom.RandomInt(0, list.Count)];
                num2 += itemObject.Value;
                itemObjectList.Add(itemObject);
                if (num2 > num3)
                {
                    break;
                }
            }
            InformationManager.DisplayMessage(new InformationMessage("", "event:/ui/notification/coins_positive"));
            foreach (ItemObject itemObject in itemObjectList)
            {
                MobileParty.MainParty.ItemRoster.AddToCounts(itemObject, 1);
                InformationManager.DisplayMessage(new InformationMessage("You found " + itemObject.Name?.ToString()));
            }
        }

        private void StartAttack()
        {
            this.ambushParty = BanditPartyComponent.CreateBanditParty("ruin_attack_party_" + this.currentRuin.RuinSettlementID, CEKHelpers.GetClanByID("looters"), Campaign.Current.Settlements.First<Settlement>((Func<Settlement, bool>)(x => x.IsHideout)).Hideout, false);
            int level = CharacterObject.PlayerCharacter.Level;
            string str1 = "tier1";
            string str2 = "town";
            int num = level;
            if (num <= 10)
            {
                str1 = "tier1";
            }
            else
            {
                switch (num)
                {
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                        str1 = "tier2";
                        break;
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                    case 26:
                    case 27:
                    case 28:
                    case 29:
                    case 30:
                        str1 = "tier3";
                        break;
                }
            }
            switch (this.currentRuin.RuinType)
            {
                case RuinType.Town:
                    str2 = "town";
                    break;
                case RuinType.Castle:
                    str2 = "castle";
                    break;
                case RuinType.Village:
                    str2 = "village";
                    break;
                case RuinType.Misc:
                    str2 = "misc";
                    break;
            }
            PartyTemplateObject partyTemplateObject = Campaign.Current.ObjectManager.GetObject<PartyTemplateObject>("ruin_" + str1 + "_" + str2 + "_template");
            TroopRoster memberRoster = new TroopRoster(this.ambushParty.Party);
            TroopRoster prisonerRoster = new TroopRoster(this.ambushParty.Party);
            foreach (PartyTemplateStack stack in (List<PartyTemplateStack>)partyTemplateObject.Stacks)
            {
                memberRoster.AddToCounts(stack.Character, MBRandom.RandomInt(stack.MinValue, stack.MaxValue));
            }

            this.ambushParty.InitializeMobilePartyAroundPosition(memberRoster, prisonerRoster, this.currentRuin.Settlement.Position2D, 0.0f);
            this.ambushParty.PartyTradeGold = 15000;
            this.ambushParty.SetCustomName(new TextObject("{=!}Ruin Bandits"));
            this.ambushParty.Party.Visuals.SetMapIconAsDirty();
            this.ambushParty.Position2D = this.currentRuin.Settlement.GatePosition;
            if (PlayerEncounter.Current != null)
            {
                PlayerEncounter.Finish();
            }

            this.currentRuin.HasBandits = false;
            EncounterManager.StartPartyEncounter(this.ambushParty.Party, MobileParty.MainParty.Party);
        }

        private void game_menu_ruin_ambush_on_init(MenuCallbackArgs args)
        {
            GameTexts.SetVariable("AMBUSH_TEXT", this.ambushText);
            InformationManager.DisplayMessage(new InformationMessage("", "event:/ui/notification/death"));
        }

        private bool game_menu_ambush_continue_on_condition(MenuCallbackArgs args)
        {
            args.optionLeaveType = GameMenuOption.LeaveType.Continue;
            return true;
        }

        private void game_menu_ambush_continue_on_consequence(MenuCallbackArgs args)
        {
            this.StartAttack();
        }

        private void game_menu_ruin_wait_on_consequence(MenuCallbackArgs args)
        {
            this.currentRuin.IsRaided = true;
            this.currentRuin.LastRaided = CampaignTime.Now;
            EnterSettlementAction.ApplyForParty(MobileParty.MainParty, this.currentRuin.Settlement);
            CEKEvents.Current.OnRuinLooted(this.currentRuin);
            GameMenu.SwitchToMenu("ruin_place");
        }

        private bool game_menu_ruin_wait_on_condition(MenuCallbackArgs args)
        {
            this.startTime = CampaignTime.Now;
            this.startTime -= CampaignTime.Days(this.currentRuin.RaidProgress);
            args.optionLeaveType = GameMenuOption.LeaveType.Wait;
            return true;
        }

        private void game_menu_ruin_wait_on_init(MenuCallbackArgs args)
        {
            GameTexts.SetVariable("RAID_TEXT", this.raidText);
            args.MenuContext.GameMenu.StartWait();
        }

        private void game_menu_ruin_place_on_init(MenuCallbackArgs args)
        {
            if (Settlement.CurrentSettlement.SettlementComponent == null || !(Settlement.CurrentSettlement.SettlementComponent is Ruin))
            {
                return;
            }

            this.currentRuin = Settlement.CurrentSettlement.SettlementComponent as Ruin;
            GameTexts.SetVariable("RUIN_TEXT", this.currentRuin.Settlement.EncyclopediaText);
            if (MobileParty.MainParty.CurrentSettlement == null)
            {
                return;
            }

            PlayerEncounter.LeaveSettlement();
        }

        private bool game_menu_ruin_explore_on_condition(MenuCallbackArgs args)
        {
            if (!(Settlement.CurrentSettlement.SettlementComponent is Ruin settlementComponent))
            {
                return false;
            }

            if (CharacterObject.PlayerCharacter.HitPoints < 25)
            {
                args.IsEnabled = false;
                args.Tooltip = new TextObject("{=!}You are too wounded to explore the ruin!");
            }
            if (settlementComponent.IsRaided)
            {
                args.IsEnabled = false;
                args.Tooltip = new TextObject("{=!}You were here just a little while ago. There is nothing left to find, you should come back later.");
            }
            if (MobileParty.MainParty.MemberRoster.TotalManCount < 9)
            {
                args.IsEnabled = false;
                args.Tooltip = new TextObject("{=!}It's too dangerous to go in there alone, you should get some men and come back.");
            }
            args.optionLeaveType = GameMenuOption.LeaveType.Bribe;
            return true;
        }

        private bool game_menu_ruin_loot_on_condition(MenuCallbackArgs args)
        {
            if (!(Settlement.CurrentSettlement.SettlementComponent is Ruin settlementComponent))
            {
                return false;
            }

            if (CharacterObject.PlayerCharacter.HitPoints < 25)
            {
                args.IsEnabled = false;
                args.Tooltip = new TextObject("{=!}You are too wounded to loot the ruin!");
            }
            if (settlementComponent.IsRaided)
            {
                args.IsEnabled = false;
                args.Tooltip = new TextObject("{=!}You were here just a little while ago. There is nothing left to find, you should come back later.");
            }
            if (MobileParty.MainParty.MemberRoster.TotalManCount < 9)
            {
                args.IsEnabled = false;
                args.Tooltip = new TextObject("{=!}It's too dangerous to go in there alone, you should get some men and come back!");
            }
            args.optionLeaveType = GameMenuOption.LeaveType.HostileAction;
            return true;
        }

        private bool game_menu_ruin_hide_on_condition(MenuCallbackArgs args)
        {
            if (this.currentRuin.RuinType == RuinType.Misc)
            {
                return false;
            }

            args.optionLeaveType = GameMenuOption.LeaveType.Mission;
            return true;
        }

        private void game_menu_ruin_hide_on_consequence(MenuCallbackArgs args)
        {
            EnterSettlementAction.ApplyForParty(MobileParty.MainParty, Settlement.CurrentSettlement);
            this.ambushText = "While hinding in the ruin you got ambushed by bandits!";
            GameMenu.SwitchToMenu("ruin_hide");
        }

        private void game_menu_ruin_explore_on_consequence(MenuCallbackArgs args)
        {
            this.searchMultiplier = 0.8f;
            this.ambushPossibility = 5;
            this.raidText = "You and your party start exploring the ruins, checking every corner and seeking out forgotten treasures.";
            this.ambushText = "While exploring the ruin you got ambushed by bandits!";
            GameMenu.SwitchToMenu("ruin_wait");
        }

        private void game_menu_ruin_loot_on_consequence(MenuCallbackArgs args)
        {
            this.searchMultiplier = 1f;
            this.ambushPossibility = 10;
            this.raidText = "You and your party start looting the ruins, quickly ransacking the area and searching at a fevered pace.";
            this.ambushText = "While looting the ruin you got ambushed by bandits!";
            GameMenu.SwitchToMenu("ruin_wait");
        }

        private bool leave_on_condition(MenuCallbackArgs args)
        {
            args.optionLeaveType = GameMenuOption.LeaveType.Leave;
            return true;
        }

        private void game_menu_ruin_leave_on_consequence(MenuCallbackArgs args)
        {
            if (MobileParty.MainParty.CurrentSettlement != null)
            {
                PlayerEncounter.LeaveSettlement();
            }

            PlayerEncounter.Finish();
        }

        private void game_menu_ruin_hide_wait_on_tick(MenuCallbackArgs args, CampaignTime dt)
        {
        }

        private void game_menu_ruin_hide_wait_on_init(MenuCallbackArgs args)
        {
            if (Settlement.CurrentSettlement.SettlementComponent is Ruin settlementComponent && settlementComponent.HasBandits && MBRandom.RandomInt(1, 100) <= 15)
            {
                this.StartAttack();
            }

            args.MenuContext.GameMenu.StartWait();
        }

        private void game_menu_ruin_hide_wait_on_consequence(MenuCallbackArgs args)
        {
        }

        private bool game_menu_ruin_hide_wait_on_condition(MenuCallbackArgs args)
        {
            args.optionLeaveType = GameMenuOption.LeaveType.Wait;
            return true;
        }

        [GameMenuInitializationHandler("ruin_place")]
        private static void game_menu_ruin_ui_place_on_init(MenuCallbackArgs args)
        {
            Settlement currentSettlement = Settlement.CurrentSettlement;
            args.MenuContext.SetBackgroundMeshName((currentSettlement.SettlementComponent as Ruin).BackgroundMeshName);
        }

        [GameMenuInitializationHandler("ruin_ambush")]
        private static void game_menu_ruin_ui_ambush_on_init(MenuCallbackArgs args)
        {
            args.MenuContext.SetBackgroundMeshName("wait_ambush");
        }
    }
}
