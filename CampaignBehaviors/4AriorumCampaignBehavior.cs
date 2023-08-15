// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Ariorum.AriorumCampaignBehavior
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Helpers;
using CalradiaExpandedKingdoms.Quests.FindItemInRuin;
using HarmonyLib;
using Helpers;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Overlay;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace CalradiaExpandedKingdoms.Ariorum
{
  public class AriorumCampaignBehavior : CampaignBehaviorBase
  {
    public override void RegisterEvents()
    {
      CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener((object) this, new Action<CampaignGameStarter>(this.OnNewGameCreated));
      CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener((object) this, new Action<CampaignGameStarter>(this.OnGameLoaded));
    }

    private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
    {
    }

    private void OnNewGameCreated(CampaignGameStarter campaignGameStarter)
    {
    }

    private void AddGameMenus(CampaignGameStarter campaignGameStarter)
    {
      campaignGameStarter.AddGameMenuOption("town", "town_bol", "{=!}Go to the Bank of Ariorum", new GameMenuOption.OnConditionDelegate(this.game_menu_town_boa_on_condition), new GameMenuOption.OnConsequenceDelegate(this.game_menu_town_boa_on_consequence), false, 3, false);
      campaignGameStarter.AddGameMenu("town_boa", "The Bank of Ariorum", new OnInitDelegate(this.game_menu_town_boa_on_init), GameOverlays.MenuOverlayType.SettlementWithBoth);
      campaignGameStarter.AddGameMenuOption("town_boa", "town_boa_start_quest", "{=!}Start Quest", new GameMenuOption.OnConditionDelegate(this.game_menu_town_boa_start_quest_on_condition), new GameMenuOption.OnConsequenceDelegate(this.game_menu_town_boa_start_quest_on_consequence), true, -1, false);
      campaignGameStarter.AddGameMenuOption("town_boa", "town_boa_back", "{=!}Leave", new GameMenuOption.OnConditionDelegate(this.game_menu_town_boa_back_on_condition), new GameMenuOption.OnConsequenceDelegate(this.game_menu_town_boa_back_on_consequence), true, -1, false);
    }

    private void game_menu_town_boa_start_quest_on_consequence(MenuCallbackArgs args) => new FindItemInRuinQuestBehavior.FindItemInRuinQuest("find_item_in_ruin", (Hero) null, CampaignTime.Never, 2000).StartQuest();

    private bool game_menu_town_boa_start_quest_on_condition(MenuCallbackArgs args) => true;

    private bool game_menu_town_boa_on_condition(MenuCallbackArgs args)
    {
      args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
      return Settlement.CurrentSettlement.StringId == "town_TT1";
    }

    private void game_menu_town_boa_on_consequence(MenuCallbackArgs args) => GameMenu.SwitchToMenu("town_boa");

    private void game_menu_town_boa_on_init(MenuCallbackArgs args)
    {
    }

    private bool game_menu_town_boa_back_on_condition(MenuCallbackArgs args)
    {
      args.optionLeaveType = GameMenuOption.LeaveType.Leave;
      return true;
    }

    private void game_menu_town_boa_back_on_consequence(MenuCallbackArgs args) => GameMenu.SwitchToMenu("town");

    private void ChangeDelegates(CampaignGameStarter campaignGameStarter)
    {
      ConversationManager conversationManager = (ConversationManager) AccessTools.Field(typeof (CampaignGameStarter), "_conversationManager").GetValue((object) campaignGameStarter);
      List<ConversationSentence> conversationSentenceList = (List<ConversationSentence>) AccessTools.Field(typeof (ConversationManager), "_sentences").GetValue((object) conversationManager);
      conversationSentenceList.Find((Predicate<ConversationSentence>) (x => x.Id == "main_option_hostile_1")).OnCondition = new ConversationSentence.OnConditionDelegate(this.conversation_lord_is_threated_neutral_on_condition_new);
      conversationSentenceList.Find((Predicate<ConversationSentence>) (x => x.Id == "caravan_loot")).OnCondition = new ConversationSentence.OnConditionDelegate(this.caravan_loot_on_condition_new);
      conversationSentenceList.Find((Predicate<ConversationSentence>) (x => x.Id == "player_want_to_join_faction_as_mercenary_or_vassal")).OnCondition = new ConversationSentence.OnConditionDelegate(this.conversation_player_want_to_join_faction_as_mercenary_or_vassal_on_condition_new);
    }

    public bool conversation_lord_is_threated_neutral_on_condition_new() => CharacterObject.OneToOneConversationCharacter.Culture != CEKHelpers.GetCultureObjectByID("ariorum") && CharacterObject.OneToOneConversationCharacter.IsHero && Campaign.Current.CurrentConversationContext == ConversationContext.PartyEncounter && Settlement.CurrentSettlement == null && CharacterObject.OneToOneConversationCharacter.IsHero && !CharacterObject.OneToOneConversationCharacter.HeroObject.IsPlayerCompanion && FactionManager.IsNeutralWithFaction(Hero.OneToOneConversationHero.MapFaction, Hero.MainHero.MapFaction);

    private bool caravan_loot_on_condition_new() => MobileParty.ConversationParty.MapFaction != CEKHelpers.GetKingdomByID("ariorum") && MobileParty.ConversationParty != null && MobileParty.ConversationParty.IsCaravan && MobileParty.ConversationParty.Party.MapFaction != Hero.MainHero.MapFaction && MobileParty.ConversationParty.Party.Owner != Hero.MainHero;

    public bool conversation_player_want_to_join_faction_as_mercenary_or_vassal_on_condition_new()
    {
      if (CharacterObject.OneToOneConversationCharacter.Culture == CEKHelpers.GetCultureObjectByID("ariorum") || Hero.MainHero.MapFaction == Hero.OneToOneConversationHero.MapFaction || !Hero.OneToOneConversationHero.MapFaction.IsKingdomFaction || Hero.MainHero.MapFaction.IsKingdomFaction || FactionManager.IsAtWarAgainstFaction(Hero.MainHero.MapFaction, Hero.OneToOneConversationHero.MapFaction))
        return false;
      if (Hero.OneToOneConversationHero.MapFaction.Leader == Hero.OneToOneConversationHero)
      {
        MBTextManager.SetTextVariable("FACTION_SERVICE_TERM", "{=ZOkUKXV2}your service", false);
      }
      else
      {
        StringHelpers.SetCharacterProperties("RULER", Hero.OneToOneConversationHero.MapFaction.Leader.CharacterObject);
        string stringId = Hero.OneToOneConversationHero.MapFaction.Culture.StringId;
        TextObject text = new TextObject("{=tDnfaXKs}the service of {RULER_NAME_AND_TITLE}");
        text.SetTextVariable("RULER_NAME_AND_TITLE", GameTexts.FindText("str_faction_ruler_term_in_speech", stringId));
        MBTextManager.SetTextVariable("FACTION_SERVICE_TERM", text, false);
      }
      return true;
    }

    public override void SyncData(IDataStore dataStore)
    {
    }
  }
}
