// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Quests.FindItemInRuin.FindItemInRuinQuestBehavior
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Events;
using CalradiaExpandedKingdoms.Ruins;
using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace CalradiaExpandedKingdoms.Quests.FindItemInRuin
{
  public class FindItemInRuinQuestBehavior : CampaignBehaviorBase
  {
    [SaveableField(1)]
    private bool IsCompleted;
    [SaveableField(2)]
    private bool hasTalkedToOldMan;

    public override void RegisterEvents()
    {
      CampaignEvents.SettlementEntered.AddNonSerializedListener((object) this, new Action<MobileParty, Settlement, Hero>(this.OnSettlementEntered));
      CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener((object) this, new Action<CampaignGameStarter>(this.OnGameLoaded));
      CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener((object) this, new Action<CampaignGameStarter>(this.OnNewGameCreated));
      CampaignEvents.OnQuestCompletedEvent.AddNonSerializedListener((object) this, new Action<QuestBase, QuestBase.QuestCompleteDetails>(this.OnQuestCompleted));
    }

    public override void SyncData(IDataStore dataStore)
    {
      dataStore.SyncData<bool>("IsCompleted", ref this.IsCompleted);
      dataStore.SyncData<bool>("hasTalkedToOldMan", ref this.hasTalkedToOldMan);
    }

    private void OnSettlementEntered(MobileParty mobileParty, Settlement settlement, Hero hero)
    {
      if (mobileParty == null || settlement == null || hero == null || !mobileParty.IsMainParty || settlement.SettlementComponent == null || !(settlement.SettlementComponent is Ruin) || Campaign.Current.QuestManager.IsThereActiveQuestWithType(typeof (FindItemInRuinQuestBehavior.FindItemInRuinQuest)) || this.IsCompleted || this.hasTalkedToOldMan || MBRandom.RandomInt(1, 100) > 20)
        return;
      FindItemInRuinQuestBehavior.SpawnOldManAndStartDialog();
    }

    private void OnGameLoaded(CampaignGameStarter obj) => this.SetDialogs();

    private void OnNewGameCreated(CampaignGameStarter obj) => this.SetDialogs();

    private void OnQuestCompleted(QuestBase quest, QuestBase.QuestCompleteDetails detail)
    {
      if (quest == null || !(quest.GetType() == typeof (FindItemInRuinQuestBehavior.FindItemInRuinQuest)))
        return;
      GainRenownAction.Apply(Hero.MainHero, 10f);
      this.IsCompleted = true;
    }

    private static void SpawnOldManAndStartDialog()
    {
      Hero specialHero = HeroCreator.CreateSpecialHero(CharacterObject.Find("cek_quest_old_man"), age: 85);
      specialHero.SetName(new TextObject("{=!}Old Man"), new TextObject("{=!}Old Man"));
      specialHero.StringId = "cek_quest_old_man";
      Campaign.Current.CampaignMissionManager.OpenConversationMission(new ConversationCharacterData(CharacterObject.PlayerCharacter, PartyBase.MainParty, false, false, false, false, false), new ConversationCharacterData(specialHero.CharacterObject, (PartyBase) null, false, false, false, true, false), "", "");
    }

    private void SetDialogs()
    {
      Campaign.Current.ConversationManager.AddDialogFlow(DialogFlow.CreateDialogFlow("cek_find_item_in_ruin_quest_first_choice_neutral").NpcLine(new TextObject("He finally arrives by your side, slightly out of breath.")).NpcLine(new TextObject("“Ah, ahem, one moment... Oh, right. Yes, now. Have you ever heard of the Sword of Crimson Dawn?”[ib:normal]")).GotoDialogState("cek_find_item_in_ruin_quest_first_choice"));
      Campaign.Current.ConversationManager.AddDialogFlow(DialogFlow.CreateDialogFlow("cek_find_item_in_ruin_quest_first_choice_positive").NpcLine(new TextObject("You offer to help the old man. After providing some water and allowing him to catch his breath he smiles and looks up to you before speaking.[rb:positive][rf:happy]")).NpcLine(new TextObject("“Thank you for your help, now, have you heard of the Sword of the Crimson Dawn?”[rb:positive][rf:happy]")).GotoDialogState("cek_find_item_in_ruin_quest_first_choice"));
      Campaign.Current.ConversationManager.AddDialogFlow(DialogFlow.CreateDialogFlow("cek_find_item_in_ruin_quest_end_dialog_negative").NpcLine(new TextObject("The old man is soon left behind as you leave, angry and disappointed.[ib:closed][rf:angry]")).Consequence(new ConversationSentence.OnConsequenceDelegate(this.conversation_talk_to_old_man_deny_quest_on_consequence)).CloseDialog());
      Campaign.Current.ConversationManager.AddDialogFlow(DialogFlow.CreateDialogFlow("cek_find_item_in_ruin_quest_first_choice").BeginPlayerOptions().PlayerOption("“What…? What are you on about?”").GotoDialogState("cek_find_item_in_ruin_quest_second_choice").PlayerOption("“Ah, yes. I have heard of it.”").GotoDialogState("cek_find_item_in_ruin_quest_third_choice").PlayerOption("Turn and walk away, clearly he is a slice short of a full loaf.").GotoDialogState("cek_find_item_in_ruin_quest_end_dialog_negative").EndPlayerOptions());
      Campaign.Current.ConversationManager.AddDialogFlow(DialogFlow.CreateDialogFlow("cek_find_item_in_ruin_quest_second_choice").NpcLine(new TextObject("The old man sighs with mild disappointment.")).NpcLine(new TextObject("“Ahh… yet another that does not know of it. The Sword of the Crimson Dawn is an immensely powerful weapon. Able to cleave mountains, part rivers… even change the weather with a single swing!”")).NpcLine(new TextObject("he smiles again")).NpcLine(new TextObject("“Pure poppycock, that. Sure, It’s strong. I made sure of that when I made the damn thing, but cleaving mountains? Who’d believe that nonsense?”")).BeginPlayerOptions().PlayerOption(new TextObject("“Not a very good sales pitch, old man.”")).GotoDialogState("cek_find_item_in_ruin_quest_fourth_choice").PlayerOption(new TextObject("Turn and walk away, clearly he is a slice short of a full loaf.")).GotoDialogState("cek_find_item_in_ruin_quest_end_dialog_negative").EndPlayerOptions());
      Campaign.Current.ConversationManager.AddDialogFlow(DialogFlow.CreateDialogFlow("cek_find_item_in_ruin_quest_third_choice").NpcLine(new TextObject("The man raises his head and cocks an eyebrow.[rf:unsure_co1, rb:unsure]")).NpcLine(new TextObject("“Oh? And what exactly have you heard about my sword, eh? Something believable, I’d hope.”[rf:unsure_co1, rb:unsure]")).BeginPlayerOptions().PlayerOption(new TextObject("“Heard it was lost, long ago. Nothing more.”")).GotoDialogState("cek_find_item_in_ruin_quest_fifth_choice").PlayerOption(new TextObject("“On second thought, I don’t think I have…”")).GotoDialogState("cek_find_item_in_ruin_quest_second_choice").EndPlayerOptions());
      Campaign.Current.ConversationManager.AddDialogFlow(DialogFlow.CreateDialogFlow("cek_find_item_in_ruin_quest_fourth_choice").NpcLine(new TextObject("The old man bristles")).NpcLine(new TextObject("“I’m not getting through to you am I?” he says before sighing and going on")).NpcLine(new TextObject("“Listen, as you can see I’m old, very old. I’ve not long left in this mortal coil and I want my work to mean something, rather than gather dust in a veritable tomb.”")).NpcLine(new TextObject("he stretches his back before continuing.[ib:hip]")).NpcLine(new TextObject("“Ah… damn these bones of mine… Ngh… Would you help an old man and find my sword? I’d be quite content for it to find its way into such an adventurer's hands.”[ib:hip]")).BeginPlayerOptions().PlayerOption(new TextObject("“Point the way. I’ll be glad to help.”")).Consequence(new ConversationSentence.OnConsequenceDelegate(this.conversation_talk_to_old_man_accept_quest_on_consequence)).CloseDialog().PlayerOption(new TextObject("“Sounds like a lot of effort. What do I get for doing this?”")).GotoDialogState("cek_find_item_in_ruin_quest_sixth_choice").PlayerOption(new TextObject("“Not gonna risk my life for your pride, old man. Go bother someone else.”")).GotoDialogState("cek_find_item_in_ruin_quest_end_dialog_negative").EndPlayerOptions());
      Campaign.Current.ConversationManager.AddDialogFlow(DialogFlow.CreateDialogFlow("cek_find_item_in_ruin_quest_fifth_choice").NpcLine(new TextObject("The old man nods “Indeed it was… along with much more. I’ll say it straight. I saw you from afar, you seem capable, strong. I want you to find my sword and let it taste glory once more”")).NpcLine(new TextObject("He places a hand on his back to steady himself.[ib:hip]")).NpcLine(new TextObject("“What do you think? Up for it?”[ib:hip]")).BeginPlayerOptions().PlayerOption(new TextObject("“Point the way. I’ll be glad to help.”")).Consequence(new ConversationSentence.OnConsequenceDelegate(this.conversation_talk_to_old_man_accept_quest_on_consequence)).CloseDialog().PlayerOption(new TextObject("“Sounds like a lot of effort. What do I get for doing this?”")).GotoDialogState("cek_find_item_in_ruin_quest_sixth_choice").PlayerOption(new TextObject("“Not gonna risk my life for your pride, old man. Go bother someone else.”")).GotoDialogState("cek_find_item_in_ruin_quest_end_dialog_negative").EndPlayerOptions());
      Campaign.Current.ConversationManager.AddDialogFlow(DialogFlow.CreateDialogFlow("cek_find_item_in_ruin_quest_sixth_choice").NpcLine(new TextObject("The old man is taken aback")).NpcLine(new TextObject("“Well… the sword alone would be more than fair payment...but I see you want more…”")).NpcLine(new TextObject("“How about this? I’ll give you 2000 gold to go and search for my sword? 1000 now and 1000 when you come back. I’d say that’s fair… and it’s not like you’d steal from an old man, would you?”")).BeginPlayerOptions().PlayerOption(new TextObject("“Good enough. Hand it over and point the way.”")).Consequence(new ConversationSentence.OnConsequenceDelegate(this.conversation_talk_to_old_man_accept_quest_on_consequence_with_money)).CloseDialog().PlayerOption(new TextObject("“That’s all, huh? So, you’re poor and forgotten. Pathetic.”")).GotoDialogState("cek_find_item_in_ruin_quest_end_dialog_negative").EndPlayerOptions());
      Campaign.Current.ConversationManager.AddDialogFlow(DialogFlow.CreateDialogFlow("start", 125).NpcLine(new TextObject("An old hobbling man struggles to approach you, waving a hand to attempt to catch your attention.")).Condition(new ConversationSentence.OnConditionDelegate(this.conversation_talk_to_old_man_on_condition)).NpcLine(new TextObject("“Ah, oh, wait a moment would you. Ah, damn these knees of mine… Not as spritely as I once was.”")).BeginPlayerOptions().PlayerOption("Wait impatiently.").GotoDialogState("cek_find_item_in_ruin_quest_first_choice_neutral").PlayerOption("Offer help.").GotoDialogState("cek_find_item_in_ruin_quest_first_choice_positive").PlayerOption("Don’t wait.").GotoDialogState("cek_find_item_in_ruin_quest_end_dialog_negative").EndPlayerOptions());
    }

    private void conversation_talk_to_old_man_accept_quest_on_consequence() => new FindItemInRuinQuestBehavior.FindItemInRuinQuest("find_item_in_ruin", (Hero) null, CampaignTime.Never, 0).StartQuest();

    private void conversation_talk_to_old_man_accept_quest_on_consequence_with_money()
    {
      GiveGoldAction.ApplyBetweenCharacters((Hero) null, Hero.MainHero, 1000);
      new FindItemInRuinQuestBehavior.FindItemInRuinQuest("find_item_in_ruin", (Hero) null, CampaignTime.Never, 0).StartQuest();
    }

    private void conversation_talk_to_old_man_deny_quest_on_consequence() => this.hasTalkedToOldMan = true;

    private bool conversation_talk_to_old_man_on_condition() => Hero.OneToOneConversationHero != null && Hero.OneToOneConversationHero.StringId == "cek_quest_old_man";

    [CommandLineFunctionality.CommandLineArgumentFunction("start_conversation_with_old_man", "cek")]
    public static string StartQuestCheat(List<string> strings)
    {
      FindItemInRuinQuestBehavior.SpawnOldManAndStartDialog();
      return "Conversation started";
    }

    public class FindItemInRuinQuest : QuestBase
    {
      [SaveableField(1)]
      private JournalLog journal;
      [SaveableField(2)]
      private int searchedRuins;

      public FindItemInRuinQuest(
        string questId,
        Hero questGiver,
        CampaignTime duration,
        int rewardGold)
        : base(questId, questGiver, duration, rewardGold)
      {
        this.SetDialogs();
      }

      protected override void SetDialogs()
      {
      }

      public override TextObject Title => new TextObject("Find the Sword of the Crimson Dawn");

      public override bool IsRemainingTimeHidden => true;

      public override bool IsSpecialQuest => true;

      protected override void OnStartQuest() => this.journal = this.AddLog(new TextObject("I will have to search some of these ruins to find the sword"));

      protected override void RegisterEvents()
      {
        CEKEvents.RuinRaided.AddNonSerializedListener((object) this, new Action<Ruin>(this.OnRuinRaided));
        CampaignEvents.ConversationEnded.AddNonSerializedListener((object) this, new Action<IEnumerable<CharacterObject>>(this.OnConversationEnded));
      }

      private void OnConversationEnded(IEnumerable<CharacterObject> enumObj)
      {
        foreach (CharacterObject obj in enumObj)
        {
            if (obj == null || obj.EncyclopediaLink == null || !obj.EncyclopediaLink.Contains("cek_quest_old_man"))
                return;
            KillCharacterAction.ApplyByRemove(obj.HeroObject);
            for (int index = 0; index < 25; ++index)
            InformationManager.DisplayMessage(new InformationMessage(" "));
        }
      }

      private void OnRuinRaided(Ruin ruin)
      {
        if (!this.IsOngoing)
          return;
        if (this.searchedRuins <= 2)
          this.journal = this.AddLog(new TextObject("You searched " + ruin.Settlement.Name?.ToString() + " but you couldn't find it"));
        ++this.searchedRuins;
        this.CheckCurrentProgress();
      }

      private void CheckCurrentProgress()
      {
        if (this.searchedRuins < 3)
          return;
        InformationManager.ShowInquiry(new InquiryData("You found it!", "Under a pile of rubble a decorated pommel peeks out, you pull it out of the rubble and see that it is the sword the old man described.", true, false, "Ok", "", (Action) null, (Action) null, "", 0.0f, (Action) null), true);
        ItemObject itemObject = Items.All.FirstOrDefault<ItemObject>((Func<ItemObject, bool>) (x => x.StringId == "cek_find_item_quest_sword"));
        if (itemObject == null)
        {
          InformationManager.DisplayMessage(new InformationMessage("ERROR: Unable to find the quest reward sword (This is likely caused by a mod incompatibility)."));
          itemObject = Items.All.FirstOrDefault<ItemObject>((Func<ItemObject, bool>) (x => x.StringId == "vlandia_2hsword_1_t5"));
        }
        MobileParty.MainParty.ItemRoster.Add(new ItemRosterElement(itemObject, 1));
        this.CompleteQuestWithSuccess();
      }

      protected override void InitializeQuestOnGameLoad()
      {
      }
    }
  }
}
