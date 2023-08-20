// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.CEKCharacterCreation.CEKCharacterCreationContent
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Helpers;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace CalradiaExpandedKingdoms.CEKCharacterCreation
{
    internal class CEKCharacterCreationContent : SandboxCharacterCreationContent
    {
        protected override void OnInitialized(CharacterCreation characterCreation)
        {
            Dictionary<string, Vec2> startingPoints = this._startingPoints;
            startingPoints.Remove("aserai");
            startingPoints.Remove("battania");
            startingPoints.Remove("vlandia");
            startingPoints.Add("aserai", new Vec2(490.4023f, 117.1011f));
            startingPoints.Add("battania", new Vec2(265.811f, 488.7303f));
            startingPoints.Add("vlandia", new Vec2(134.7052f, 479.6362f));
            startingPoints.Add("apolssalian", new Vec2(301.5604f, 259.0346f));
            startingPoints.Add("lyrion", new Vec2(613.3167f, 174.055f));
            startingPoints.Add("rebkhu", new Vec2(736.4117f, 303.7353f));
            startingPoints.Add("rhodok", new Vec2(204.9789f, 388.5628f));
            startingPoints.Add("nordling", new Vec2(555.511f, 582.9084f));
            startingPoints.Add("vagir", new Vec2(324.662f, 471.8515f));
            startingPoints.Add("republic", new Vec2(530.8693f, 493.9588f));
            startingPoints.Add("paleician", new Vec2(518.1923f, 414.828f));
            startingPoints.Add("ariorum", new Vec2(435.81f, 240.41f));
            this.AddParentsMenu(characterCreation);
            this.AddChildhoodMenu(characterCreation);
            this.AddEducationMenu(characterCreation);
            this.AddYouthMenu(characterCreation);
            this.AddAdulthoodMenu(characterCreation);
            this.AddAgeSelectionMenu(characterCreation);
        }

        protected new void AddParentsMenu(CharacterCreation characterCreation)
        {
            CharacterCreationMenu menu = new CharacterCreationMenu(new TextObject("{=b4lDDcli}Family"), new TextObject("{=XgFU1pCx}You were born into a family of..."), new CharacterCreationOnInit(this.ParentsOnInit));
            CharacterCreationCategory creationCategory1 = menu.AddMenuCategory(new CharacterCreationOnCondition(this.EmpireParentsOnCondition));
            MBList<SkillObject> skillObjectList1 = new MBList<SkillObject>()
      {
        DefaultSkills.Riding,
        DefaultSkills.Polearm
      };
            CharacterAttribute vigor1 = DefaultCharacterAttributes.Vigor;
            creationCategory1.AddCategoryOption(new TextObject("{=InN5ZZt3}A landlord's retainers"), skillObjectList1, vigor1, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition)null, new CharacterCreationOnSelect(((CEKCharacterCreationContent)this).EmpireLandlordsRetainerOnConsequence), new CharacterCreationApplyFinalEffects(this.EmpireLandlordsRetainerOnApply), new TextObject("{=ivKl4mV2}Your father was a trusted lieutenant of the local landowning aristocrat. He rode with the lord's cavalry, fighting as an armored lancer."), (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            MBList<SkillObject> skillObjectList2 = new MBList<SkillObject>()
      {
        DefaultSkills.Trade,
        DefaultSkills.Charm
      };
            CharacterAttribute social1 = DefaultCharacterAttributes.Social;
            creationCategory1.AddCategoryOption(new TextObject("{=651FhzdR}Urban merchants"), skillObjectList2, social1, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition)null, new CharacterCreationOnSelect(((CEKCharacterCreationContent)this).EmpireMerchantOnConsequence), new CharacterCreationApplyFinalEffects(((CEKCharacterCreationContent)this).EmpireMerchantOnApply), new TextObject("{=FQntPChs}Your family were merchants in one of the main cities of the Empire. They sometimes organized caravans to nearby towns, and discussed issues in the town council."), (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            MBList<SkillObject> skillObjectList3 = new MBList<SkillObject>()
      {
        DefaultSkills.Athletics,
        DefaultSkills.Polearm
      };
            CharacterAttribute endurance1 = DefaultCharacterAttributes.Endurance;
            creationCategory1.AddCategoryOption(new TextObject("{=sb4gg8Ak}Freeholders"), skillObjectList3, endurance1, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition)null, new CharacterCreationOnSelect(this.EmpireFreeholderOnConsequence), new CharacterCreationApplyFinalEffects(this.EmpireFreeholderOnApply), new TextObject("{=09z8Q08f}Your family were small farmers with just enough land to feed themselves and make a small profit. People like them were the pillars of the imperial rural economy, as well as the backbone of the levy."), (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            MBList<SkillObject> skillObjectList4 = new MBList<SkillObject>()
      {
        DefaultSkills.Crafting,
        DefaultSkills.Crossbow
      };
            CharacterAttribute intelligence1 = DefaultCharacterAttributes.Intelligence;
            creationCategory1.AddCategoryOption(new TextObject("{=v48N6h1t}Urban artisans"), skillObjectList4, intelligence1, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition)null, new CharacterCreationOnSelect(this.EmpireArtisanOnConsequence), new CharacterCreationApplyFinalEffects(this.EmpireArtisanOnApply), new TextObject("{=ZKynvffv}Your family owned their own workshop in a city, making goods from raw materials brought in from the countryside. Your father played an active if minor role in the town council, and also served in the militia."), (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            MBList<SkillObject> skillObjectList5 = new MBList<SkillObject>()
      {
        DefaultSkills.Scouting,
        DefaultSkills.Bow
      };
            CharacterAttribute control1 = DefaultCharacterAttributes.Control;
            creationCategory1.AddCategoryOption(new TextObject("{=7eWmU2mF}Foresters"), skillObjectList5, control1, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition)null, new CharacterCreationOnSelect(this.EmpireWoodsmanOnConsequence), new CharacterCreationApplyFinalEffects(this.EmpireWoodsmanOnApply), new TextObject("{=yRFSzSDZ}Your family lived in a village, but did not own their own land. Instead, your father supplemented paid jobs with long trips in the woods, hunting and trapping, always keeping a wary eye for the lord's game wardens."), (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            MBList<SkillObject> skillObjectList6 = new MBList<SkillObject>()
      {
        DefaultSkills.Roguery,
        DefaultSkills.Throwing
      };
            CharacterAttribute cunning1 = DefaultCharacterAttributes.Cunning;
            creationCategory1.AddCategoryOption(new TextObject("{=aEke8dSb}Urban vagabonds"), skillObjectList6, cunning1, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition)null, new CharacterCreationOnSelect(this.EmpireVagabondOnConsequence), new CharacterCreationApplyFinalEffects(this.EmpireVagabondOnApply), new TextObject("{=Jvf6K7TZ}Your family numbered among the many poor migrants living in the slums that grow up outside the walls of imperial cities, making whatever money they could from a variety of odd jobs. Sometimes they did service for one of the Empire's many criminal gangs, and you had an early look at the dark side of life."), (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory2 = menu.AddMenuCategory(new CharacterCreationOnCondition(this.VlandianParentsOnCondition));
            MBList<SkillObject> skillObjectList7 = new MBList<SkillObject>()
      {
        DefaultSkills.Riding,
        DefaultSkills.Polearm
      };
            CharacterAttribute social2 = DefaultCharacterAttributes.Social;
            creationCategory2.AddCategoryOption(new TextObject("{=2TptWc4m}A baron's retainers"), skillObjectList7, social2, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition)null, new CharacterCreationOnSelect(this.VlandiaBaronsRetainerOnConsequence), new CharacterCreationApplyFinalEffects(this.VlandiaBaronsRetainerOnApply), new TextObject("{=0Suu1Q9q}Your father was a bailiff for a local feudal magnate. He looked after his liege's estates, resolved disputes in the village, and helped train the village levy. He rode with the lord's cavalry, fighting as an armored knight."), (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            MBList<SkillObject> skillObjectList8 = new MBList<SkillObject>()
      {
        DefaultSkills.Trade,
        DefaultSkills.Charm
      };
            CharacterAttribute intelligence2 = DefaultCharacterAttributes.Intelligence;
            creationCategory2.AddCategoryOption(new TextObject("{=651FhzdR}Urban merchants"), skillObjectList8, intelligence2, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition)null, new CharacterCreationOnSelect(this.VlandiaMerchantOnConsequence), new CharacterCreationApplyFinalEffects(((CEKCharacterCreationContent)this).VlandiaMerchantOnApply), new TextObject("{=qNZFkxJb}Your family were merchants in one of the main cities of the kingdom. They organized caravans to nearby towns and were active in the local merchant's guild."), (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            MBList<SkillObject> skillObjectList9 = new MBList<SkillObject>()
      {
        DefaultSkills.Polearm,
        DefaultSkills.Crossbow
      };
            CharacterAttribute endurance2 = DefaultCharacterAttributes.Endurance;
            creationCategory2.AddCategoryOption(new TextObject("{=RDfXuVxT}Yeomen"), skillObjectList9, endurance2, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition)null, new CharacterCreationOnSelect(this.VlandiaYeomanOnConsequence), new CharacterCreationApplyFinalEffects(((CEKCharacterCreationContent)this).VlandiaYeomanOnApply), new TextObject("{=BLZ4mdhb}Your family were small farmers with just enough land to feed themselves and make a small profit. People like them were the pillars of the kingdom's economy, as well as the backbone of the levy."), (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            MBList<SkillObject> skillObjectList10 = new MBList<SkillObject>()
      {
        DefaultSkills.Crafting,
        DefaultSkills.TwoHanded
      };
            CharacterAttribute vigor2 = DefaultCharacterAttributes.Vigor;
            creationCategory2.AddCategoryOption(new TextObject("{=p2KIhGbE}Urban blacksmith"), skillObjectList10, vigor2, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition)null, new CharacterCreationOnSelect(((CEKCharacterCreationContent)this).VlandiaBlacksmithOnConsequence), new CharacterCreationApplyFinalEffects(this.VlandiaBlacksmithOnApply), new TextObject("{=btsMpRcA}Your family owned a smithy in a city. Your father played an active if minor role in the town council, and also served in the militia."), (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            MBList<SkillObject> skillObjectList11 = new MBList<SkillObject>()
      {
        DefaultSkills.Scouting,
        DefaultSkills.Crossbow
      };
            CharacterAttribute control2 = DefaultCharacterAttributes.Control;
            creationCategory2.AddCategoryOption(new TextObject("{=YcnK0Thk}Hunters"), skillObjectList11, control2, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition)null, new CharacterCreationOnSelect(this.VlandiaHunterOnConsequence), new CharacterCreationApplyFinalEffects(this.VlandiaHunterOnApply), new TextObject("{=yRFSzSDZ}Your family lived in a village, but did not own their own land. Instead, your father supplemented paid jobs with long trips in the woods, hunting and trapping, always keeping a wary eye for the lord's game wardens."), (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            MBList<SkillObject> skillObjectList12 = new MBList<SkillObject>()
      {
        DefaultSkills.Roguery,
        DefaultSkills.Crossbow
      };
            CharacterAttribute cunning2 = DefaultCharacterAttributes.Cunning;
            creationCategory2.AddCategoryOption(new TextObject("{=ipQP6aVi}Mercenaries"), skillObjectList12, cunning2, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition)null, new CharacterCreationOnSelect(this.VlandiaMercenaryOnConsequence), new CharacterCreationApplyFinalEffects(this.VlandiaMercenaryOnApply), new TextObject("{=yYhX6JQC}Your father joined one of Vlandia's many mercenary companies, composed of men who got such a taste for war in their lord's service that they never took well to peace. Their crossbowmen were much valued across Calradia. Your mother was a camp follower, taking you along in the wake of bloody campaigns."), (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory3 = menu.AddMenuCategory(new CharacterCreationOnCondition(this.SturgianParentsOnCondition));
            CharacterCreationCategory creationCategory4 = creationCategory3;
            TextObject textObject1 = new TextObject("{=mc78FEbA}A boyar's companions");
            MBList<SkillObject> skillObjectList13 = new MBList<SkillObject>();
            skillObjectList13.Add(DefaultSkills.Riding);
            skillObjectList13.Add(DefaultSkills.TwoHanded);
            CharacterAttribute social3 = DefaultCharacterAttributes.Social;
            int focusToAdd1 = this.FocusToAdd;
            int skillLevelToAdd1 = this.SkillLevelToAdd;
            int attributeLevelToAdd1 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect1 = new CharacterCreationOnSelect(this.SturgiaBoyarsCompanionOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects1 = new CharacterCreationApplyFinalEffects(this.SturgiaBoyarsCompanionOnApply);
            TextObject textObject2 = new TextObject("{=hob3WVkU}Your father was a member of a boyar's druzhina, the 'companions' that make up his retinue. He sat at his lord's table in the great hall, oversaw the boyar's estates, and stood by his side in the center of the shield wall in battle.");
            creationCategory4.AddCategoryOption(textObject1, skillObjectList13, social3, focusToAdd1, skillLevelToAdd1, attributeLevelToAdd1, (CharacterCreationOnCondition)null, creationOnSelect1, applyFinalEffects1, textObject2, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory5 = creationCategory3;
            TextObject textObject3 = new TextObject("{=HqzVBfpl}Urban traders");
            MBList<SkillObject> skillObjectList14 = new MBList<SkillObject>();
            skillObjectList14.Add(DefaultSkills.Trade);
            skillObjectList14.Add(DefaultSkills.Tactics);
            CharacterAttribute cunning3 = DefaultCharacterAttributes.Cunning;
            int focusToAdd2 = this.FocusToAdd;
            int skillLevelToAdd2 = this.SkillLevelToAdd;
            int attributeLevelToAdd2 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect2 = new CharacterCreationOnSelect(this.SturgiaTraderOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects2 = new CharacterCreationApplyFinalEffects(this.SturgiaTraderOnApply);
            TextObject textObject4 = new TextObject("{=bjVMtW3W}Your family were merchants who lived in one of Sturgia's great river ports, organizing the shipment of the north's bounty of furs, honey and other goods to faraway lands.");
            creationCategory5.AddCategoryOption(textObject3, skillObjectList14, cunning3, focusToAdd2, skillLevelToAdd2, attributeLevelToAdd2, (CharacterCreationOnCondition)null, creationOnSelect2, applyFinalEffects2, textObject4, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory6 = creationCategory3;
            TextObject textObject5 = new TextObject("{=zrpqSWSh}Free farmers");
            MBList<SkillObject> skillObjectList15 = new MBList<SkillObject>();
            skillObjectList15.Add(DefaultSkills.Athletics);
            skillObjectList15.Add(DefaultSkills.Polearm);
            CharacterAttribute endurance3 = DefaultCharacterAttributes.Endurance;
            int focusToAdd3 = this.FocusToAdd;
            int skillLevelToAdd3 = this.SkillLevelToAdd;
            int attributeLevelToAdd3 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect3 = new CharacterCreationOnSelect(this.SturgiaFreemanOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects3 = new CharacterCreationApplyFinalEffects(this.SturgiaFreemanOnApply);
            TextObject textObject6 = new TextObject("{=Mcd3ZyKq}Your family had just enough land to feed themselves and make a small profit. People like them were the pillars of the kingdom's economy, as well as the backbone of the levy.");
            creationCategory6.AddCategoryOption(textObject5, skillObjectList15, endurance3, focusToAdd3, skillLevelToAdd3, attributeLevelToAdd3, (CharacterCreationOnCondition)null, creationOnSelect3, applyFinalEffects3, textObject6, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory7 = creationCategory3;
            TextObject textObject7 = new TextObject("{=v48N6h1t}Urban artisans");
            MBList<SkillObject> skillObjectList16 = new MBList<SkillObject>();
            skillObjectList16.Add(DefaultSkills.Crafting);
            skillObjectList16.Add(DefaultSkills.OneHanded);
            CharacterAttribute intelligence3 = DefaultCharacterAttributes.Intelligence;
            int focusToAdd4 = this.FocusToAdd;
            int skillLevelToAdd4 = this.SkillLevelToAdd;
            int attributeLevelToAdd4 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect4 = new CharacterCreationOnSelect(this.SturgiaArtisanOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects4 = new CharacterCreationApplyFinalEffects(this.SturgiaArtisanOnApply);
            TextObject textObject8 = new TextObject("{=ueCm5y1C}Your family owned their own workshop in a city, making goods from raw materials brought in from the countryside. Your father played an active if minor role in the town council, and also served in the militia.");
            creationCategory7.AddCategoryOption(textObject7, skillObjectList16, intelligence3, focusToAdd4, skillLevelToAdd4, attributeLevelToAdd4, (CharacterCreationOnCondition)null, creationOnSelect4, applyFinalEffects4, textObject8, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory8 = creationCategory3;
            TextObject textObject9 = new TextObject("{=YcnK0Thk}Hunters");
            MBList<SkillObject> skillObjectList17 = new MBList<SkillObject>();
            skillObjectList17.Add(DefaultSkills.Scouting);
            skillObjectList17.Add(DefaultSkills.Bow);
            CharacterAttribute vigor3 = DefaultCharacterAttributes.Vigor;
            int focusToAdd5 = this.FocusToAdd;
            int skillLevelToAdd5 = this.SkillLevelToAdd;
            int attributeLevelToAdd5 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect5 = new CharacterCreationOnSelect(this.SturgiaHunterOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects5 = new CharacterCreationApplyFinalEffects(this.SturgiaHunterOnApply);
            TextObject textObject10 = new TextObject("{=WyZ2UtFF}Your family had no taste for the authority of the boyars. They made their living deep in the woods, slashing and burning fields which they tended for a year or two before moving on. They hunted and trapped fox, hare, ermine, and other fur-bearing animals.");
            creationCategory8.AddCategoryOption(textObject9, skillObjectList17, vigor3, focusToAdd5, skillLevelToAdd5, attributeLevelToAdd5, (CharacterCreationOnCondition)null, creationOnSelect5, applyFinalEffects5, textObject10, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory9 = creationCategory3;
            TextObject textObject11 = new TextObject("{=TPoK3GSj}Vagabonds");
            MBList<SkillObject> skillObjectList18 = new MBList<SkillObject>();
            skillObjectList18.Add(DefaultSkills.Roguery);
            skillObjectList18.Add(DefaultSkills.Throwing);
            CharacterAttribute control3 = DefaultCharacterAttributes.Control;
            int focusToAdd6 = this.FocusToAdd;
            int skillLevelToAdd6 = this.SkillLevelToAdd;
            int attributeLevelToAdd6 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect6 = new CharacterCreationOnSelect(this.SturgiaVagabondOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects6 = new CharacterCreationApplyFinalEffects(this.SturgiaVagabondOnApply);
            TextObject textObject12 = new TextObject("{=2SDWhGmQ}Your family numbered among the poor migrants living in the slums that grow up outside the walls of the river cities, making whatever money they could from a variety of odd jobs. Sometimes they did services for one of the region's many criminal gangs.");
            creationCategory9.AddCategoryOption(textObject11, skillObjectList18, control3, focusToAdd6, skillLevelToAdd6, attributeLevelToAdd6, (CharacterCreationOnCondition)null, creationOnSelect6, applyFinalEffects6, textObject12, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory10 = menu.AddMenuCategory(new CharacterCreationOnCondition(this.AseraiParentsOnCondition));
            CharacterCreationCategory creationCategory11 = creationCategory10;
            TextObject textObject13 = new TextObject("{=Sw8OxnNr}Kinsfolk of an emir");
            MBList<SkillObject> skillObjectList19 = new MBList<SkillObject>();
            skillObjectList19.Add(DefaultSkills.Riding);
            skillObjectList19.Add(DefaultSkills.Throwing);
            CharacterAttribute endurance4 = DefaultCharacterAttributes.Endurance;
            int focusToAdd7 = this.FocusToAdd;
            int skillLevelToAdd7 = this.SkillLevelToAdd;
            int attributeLevelToAdd7 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect7 = new CharacterCreationOnSelect(this.AseraiTribesmanOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects7 = new CharacterCreationApplyFinalEffects(this.AseraiTribesmanOnApply);
            TextObject textObject14 = new TextObject("{=MFrIHJZM}Your family was from a smaller offshoot of an emir's tribe. Your father's land gave him enough income to afford a horse but he was not quite wealthy enough to buy the armor needed to join the heavier cavalry. He fought as one of the light horsemen for which the desert is famous.");
            creationCategory11.AddCategoryOption(textObject13, skillObjectList19, endurance4, focusToAdd7, skillLevelToAdd7, attributeLevelToAdd7, (CharacterCreationOnCondition)null, creationOnSelect7, applyFinalEffects7, textObject14, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory12 = creationCategory10;
            TextObject textObject15 = new TextObject("{=ngFVgwDD}Warrior-slaves");
            MBList<SkillObject> skillObjectList20 = new MBList<SkillObject>();
            skillObjectList20.Add(DefaultSkills.Riding);
            skillObjectList20.Add(DefaultSkills.Polearm);
            CharacterAttribute vigor4 = DefaultCharacterAttributes.Vigor;
            int focusToAdd8 = this.FocusToAdd;
            int skillLevelToAdd8 = this.SkillLevelToAdd;
            int attributeLevelToAdd8 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect8 = new CharacterCreationOnSelect(this.AseraiWariorSlaveOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects8 = new CharacterCreationApplyFinalEffects(this.AseraiWariorSlaveOnApply);
            TextObject textObject16 = new TextObject("{=GsPC2MgU}Your father was part of one of the slave-bodyguards maintained by the Aserai emirs. He fought by his master's side with tribe's armored cavalry, and was freed - perhaps for an act of valor, or perhaps he paid for his freedom with his share of the spoils of battle. He then married your mother.");
            creationCategory12.AddCategoryOption(textObject15, skillObjectList20, vigor4, focusToAdd8, skillLevelToAdd8, attributeLevelToAdd8, (CharacterCreationOnCondition)null, creationOnSelect8, applyFinalEffects8, textObject16, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory13 = creationCategory10;
            TextObject textObject17 = new TextObject("{=651FhzdR}Urban merchants");
            MBList<SkillObject> skillObjectList21 = new MBList<SkillObject>();
            skillObjectList21.Add(DefaultSkills.Trade);
            skillObjectList21.Add(DefaultSkills.Charm);
            CharacterAttribute social4 = DefaultCharacterAttributes.Social;
            int focusToAdd9 = this.FocusToAdd;
            int skillLevelToAdd9 = this.SkillLevelToAdd;
            int attributeLevelToAdd9 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect9 = new CharacterCreationOnSelect(this.AseraiMerchantOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects9 = new CharacterCreationApplyFinalEffects(this.AseraiMerchantOnApply);
            TextObject textObject18 = new TextObject("{=1zXrlaav}Your family were respected traders in an oasis town. They ran caravans across the desert, and were experts in the finer points of negotiating passage through the desert tribes' territories.");
            creationCategory13.AddCategoryOption(textObject17, skillObjectList21, social4, focusToAdd9, skillLevelToAdd9, attributeLevelToAdd9, (CharacterCreationOnCondition)null, creationOnSelect9, applyFinalEffects9, textObject18, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory14 = creationCategory10;
            TextObject textObject19 = new TextObject("{=g31pXuqi}Oasis farmers");
            MBList<SkillObject> skillObjectList22 = new MBList<SkillObject>();
            skillObjectList22.Add(DefaultSkills.Athletics);
            skillObjectList22.Add(DefaultSkills.OneHanded);
            CharacterAttribute endurance5 = DefaultCharacterAttributes.Endurance;
            int focusToAdd10 = this.FocusToAdd;
            int skillLevelToAdd10 = this.SkillLevelToAdd;
            int attributeLevelToAdd10 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect10 = new CharacterCreationOnSelect(this.AseraiOasisFarmerOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects10 = new CharacterCreationApplyFinalEffects(this.AseraiOasisFarmerOnApply);
            TextObject textObject20 = new TextObject("{=5P0KqBAw}Your family tilled the soil in one of the oases of the Nahasa and tended the palm orchards that produced the desert's famous dates. Your father was a member of the main foot levy of his tribe, fighting with his kinsmen under the emir's banner.");
            creationCategory14.AddCategoryOption(textObject19, skillObjectList22, endurance5, focusToAdd10, skillLevelToAdd10, attributeLevelToAdd10, (CharacterCreationOnCondition)null, creationOnSelect10, applyFinalEffects10, textObject20, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory15 = creationCategory10;
            TextObject textObject21 = new TextObject("{=EEedqolz}Bedouin");
            MBList<SkillObject> skillObjectList23 = new MBList<SkillObject>();
            skillObjectList23.Add(DefaultSkills.Scouting);
            skillObjectList23.Add(DefaultSkills.Bow);
            CharacterAttribute cunning4 = DefaultCharacterAttributes.Cunning;
            int focusToAdd11 = this.FocusToAdd;
            int skillLevelToAdd11 = this.SkillLevelToAdd;
            int attributeLevelToAdd11 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect11 = new CharacterCreationOnSelect(this.AseraiBedouinOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects11 = new CharacterCreationApplyFinalEffects(this.AseraiBedouinOnApply);
            TextObject textObject22 = new TextObject("{=PKhcPbBX}Your family were part of a nomadic clan, crisscrossing the wastes between wadi beds and wells to feed their herds of goats and camels on the scraggly scrubs of the Nahasa.");
            creationCategory15.AddCategoryOption(textObject21, skillObjectList23, cunning4, focusToAdd11, skillLevelToAdd11, attributeLevelToAdd11, (CharacterCreationOnCondition)null, creationOnSelect11, applyFinalEffects11, textObject22, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory16 = creationCategory10;
            TextObject textObject23 = new TextObject("{=tRIrbTvv}Urban back-alley thugs");
            MBList<SkillObject> skillObjectList24 = new MBList<SkillObject>();
            skillObjectList24.Add(DefaultSkills.Roguery);
            skillObjectList24.Add(DefaultSkills.Polearm);
            CharacterAttribute control4 = DefaultCharacterAttributes.Control;
            int focusToAdd12 = this.FocusToAdd;
            int skillLevelToAdd12 = this.SkillLevelToAdd;
            int attributeLevelToAdd12 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect12 = new CharacterCreationOnSelect(this.AseraiBackAlleyThugOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects12 = new CharacterCreationApplyFinalEffects(this.AseraiBackAlleyThugOnApply);
            TextObject textObject24 = new TextObject("{=6bUSbsKC}Your father worked for a fitiwi, one of the strongmen who keep order in the poorer quarters of the oasis towns. He resolved disputes over land, dice and insults, imposing his authority with the fitiwi's traditional staff.");
            creationCategory16.AddCategoryOption(textObject23, skillObjectList24, control4, focusToAdd12, skillLevelToAdd12, attributeLevelToAdd12, (CharacterCreationOnCondition)null, creationOnSelect12, applyFinalEffects12, textObject24, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory17 = menu.AddMenuCategory(new CharacterCreationOnCondition(this.BattanianParentsOnCondition));
            CharacterCreationCategory creationCategory18 = creationCategory17;
            TextObject textObject25 = new TextObject("{=GeNKQlHR}Members of the chieftain's hearthguard");
            MBList<SkillObject> skillObjectList25 = new MBList<SkillObject>();
            skillObjectList25.Add(DefaultSkills.TwoHanded);
            skillObjectList25.Add(DefaultSkills.Bow);
            CharacterAttribute vigor5 = DefaultCharacterAttributes.Vigor;
            int focusToAdd13 = this.FocusToAdd;
            int skillLevelToAdd13 = this.SkillLevelToAdd;
            int attributeLevelToAdd13 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect13 = new CharacterCreationOnSelect(this.BattaniaChieftainsHearthguardOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects13 = new CharacterCreationApplyFinalEffects(this.BattaniaChieftainsHearthguardOnApply);
            TextObject textObject26 = new TextObject("{=LpH8SYFL}Your family were the trusted kinfolk of a Battanian chieftain, and sat at his table in his great hall. Your father assisted his chief in running the affairs of the clan and trained with the traditional weapons of the Battanian elite, the two-handed sword or falx and the bow.");
            creationCategory18.AddCategoryOption(textObject25, skillObjectList25, vigor5, focusToAdd13, skillLevelToAdd13, attributeLevelToAdd13, (CharacterCreationOnCondition)null, creationOnSelect13, applyFinalEffects13, textObject26, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory19 = creationCategory17;
            TextObject textObject27 = new TextObject("{=AeBzTj6w}Healers");
            MBList<SkillObject> skillObjectList26 = new MBList<SkillObject>();
            skillObjectList26.Add(DefaultSkills.Medicine);
            skillObjectList26.Add(DefaultSkills.Charm);
            CharacterAttribute intelligence4 = DefaultCharacterAttributes.Intelligence;
            int focusToAdd14 = this.FocusToAdd;
            int skillLevelToAdd14 = this.SkillLevelToAdd;
            int attributeLevelToAdd14 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect14 = new CharacterCreationOnSelect(this.BattaniaHealerOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects14 = new CharacterCreationApplyFinalEffects(this.BattaniaHealerOnApply);
            TextObject textObject28 = new TextObject("{=j6py5Rv5}Your parents were healers who gathered herbs and treated the sick. As a living reservoir of Battanian tradition, they were also asked to adjudicate many disputes between the clans.");
            creationCategory19.AddCategoryOption(textObject27, skillObjectList26, intelligence4, focusToAdd14, skillLevelToAdd14, attributeLevelToAdd14, (CharacterCreationOnCondition)null, creationOnSelect14, applyFinalEffects14, textObject28, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory20 = creationCategory17;
            TextObject textObject29 = new TextObject("{=tGEStbxb}Tribespeople");
            MBList<SkillObject> skillObjectList27 = new MBList<SkillObject>();
            skillObjectList27.Add(DefaultSkills.Athletics);
            skillObjectList27.Add(DefaultSkills.Throwing);
            CharacterAttribute control5 = DefaultCharacterAttributes.Control;
            int focusToAdd15 = this.FocusToAdd;
            int skillLevelToAdd15 = this.SkillLevelToAdd;
            int attributeLevelToAdd15 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect15 = new CharacterCreationOnSelect(this.BattaniaTribesmanOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects15 = new CharacterCreationApplyFinalEffects(this.BattaniaTribesmanOnApply);
            TextObject textObject30 = new TextObject("{=WchH8bS2}Your family were middle-ranking members of a Battanian clan, who tilled their own land. Your father fought with the kern, the main body of his people's warriors, joining in the screaming charges for which the Battanians were famous.");
            creationCategory20.AddCategoryOption(textObject29, skillObjectList27, control5, focusToAdd15, skillLevelToAdd15, attributeLevelToAdd15, (CharacterCreationOnCondition)null, creationOnSelect15, applyFinalEffects15, textObject30, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory21 = creationCategory17;
            TextObject textObject31 = new TextObject("{=BCU6RezA}Smiths");
            MBList<SkillObject> skillObjectList28 = new MBList<SkillObject>();
            skillObjectList28.Add(DefaultSkills.Crafting);
            skillObjectList28.Add(DefaultSkills.TwoHanded);
            CharacterAttribute endurance6 = DefaultCharacterAttributes.Endurance;
            int focusToAdd16 = this.FocusToAdd;
            int skillLevelToAdd16 = this.SkillLevelToAdd;
            int attributeLevelToAdd16 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect16 = new CharacterCreationOnSelect(this.BattaniaSmithOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects16 = new CharacterCreationApplyFinalEffects(this.BattaniaSmithOnApply);
            TextObject textObject32 = new TextObject("{=kg9YtrOg}Your family were smiths, a revered profession among the Battanians. They crafted everything from fine filigree jewelry in geometric designs to the well-balanced longswords favored by the Battanian aristocracy.");
            creationCategory21.AddCategoryOption(textObject31, skillObjectList28, endurance6, focusToAdd16, skillLevelToAdd16, attributeLevelToAdd16, (CharacterCreationOnCondition)null, creationOnSelect16, applyFinalEffects16, textObject32, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory22 = creationCategory17;
            TextObject textObject33 = new TextObject("{=7eWmU2mF}Foresters");
            MBList<SkillObject> skillObjectList29 = new MBList<SkillObject>();
            skillObjectList29.Add(DefaultSkills.Scouting);
            skillObjectList29.Add(DefaultSkills.Tactics);
            CharacterAttribute cunning5 = DefaultCharacterAttributes.Cunning;
            int focusToAdd17 = this.FocusToAdd;
            int skillLevelToAdd17 = this.SkillLevelToAdd;
            int attributeLevelToAdd17 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect17 = new CharacterCreationOnSelect(this.BattaniaWoodsmanOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects17 = new CharacterCreationApplyFinalEffects(this.BattaniaWoodsmanOnApply);
            TextObject textObject34 = new TextObject("{=7jBroUUQ}Your family had little land of their own, so they earned their living from the woods, hunting and trapping. They taught you from an early age that skills like finding game trails and killing an animal with one shot could make the difference between eating and starvation.");
            creationCategory22.AddCategoryOption(textObject33, skillObjectList29, cunning5, focusToAdd17, skillLevelToAdd17, attributeLevelToAdd17, (CharacterCreationOnCondition)null, creationOnSelect17, applyFinalEffects17, textObject34, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory23 = creationCategory17;
            TextObject textObject35 = new TextObject("{=SpJqhEEh}Bards");
            MBList<SkillObject> skillObjectList30 = new MBList<SkillObject>();
            skillObjectList30.Add(DefaultSkills.Roguery);
            skillObjectList30.Add(DefaultSkills.Charm);
            CharacterAttribute social5 = DefaultCharacterAttributes.Social;
            int focusToAdd18 = this.FocusToAdd;
            int skillLevelToAdd18 = this.SkillLevelToAdd;
            int attributeLevelToAdd18 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect18 = new CharacterCreationOnSelect(this.BattaniaBardOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects18 = new CharacterCreationApplyFinalEffects(this.BattaniaBardOnApply);
            TextObject textObject36 = new TextObject("{=aVzcyhhy}Your father was a bard, drifting from chieftain's hall to chieftain's hall making his living singing the praises of one Battanian aristocrat and mocking his enemies, then going to his enemy's hall and doing the reverse. You learned from him that a clever tongue could spare you  from a life toiling in the fields, if you kept your wits about you.");
            creationCategory23.AddCategoryOption(textObject35, skillObjectList30, social5, focusToAdd18, skillLevelToAdd18, attributeLevelToAdd18, (CharacterCreationOnCondition)null, creationOnSelect18, applyFinalEffects18, textObject36, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory24 = menu.AddMenuCategory(new CharacterCreationOnCondition(this.KhuzaitParentsOnCondition));
            CharacterCreationCategory creationCategory25 = creationCategory24;
            TextObject textObject37 = new TextObject("{=FVaRDe2a}A noyan's kinsfolk");
            MBList<SkillObject> skillObjectList31 = new MBList<SkillObject>();
            skillObjectList31.Add(DefaultSkills.Riding);
            skillObjectList31.Add(DefaultSkills.Polearm);
            CharacterAttribute endurance7 = DefaultCharacterAttributes.Endurance;
            int focusToAdd19 = this.FocusToAdd;
            int skillLevelToAdd19 = this.SkillLevelToAdd;
            int attributeLevelToAdd19 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect19 = new CharacterCreationOnSelect(this.KhuzaitNoyansKinsmanOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects19 = new CharacterCreationApplyFinalEffects(this.KhuzaitNoyansKinsmanOnApply);
            TextObject textObject38 = new TextObject("{=jAs3kDXh}Your family were the trusted kinsfolk of a Khuzait noyan, and shared his meals in the chieftain's yurt. Your father assisted his chief in running the affairs of the clan and fought in the core of armored lancers in the center of the Khuzait battle line.");
            creationCategory25.AddCategoryOption(textObject37, skillObjectList31, endurance7, focusToAdd19, skillLevelToAdd19, attributeLevelToAdd19, (CharacterCreationOnCondition)null, creationOnSelect19, applyFinalEffects19, textObject38, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory26 = creationCategory24;
            TextObject textObject39 = new TextObject("{=TkgLEDRM}Merchants");
            MBList<SkillObject> skillObjectList32 = new MBList<SkillObject>();
            skillObjectList32.Add(DefaultSkills.Trade);
            skillObjectList32.Add(DefaultSkills.Charm);
            CharacterAttribute social6 = DefaultCharacterAttributes.Social;
            int focusToAdd20 = this.FocusToAdd;
            int skillLevelToAdd20 = this.SkillLevelToAdd;
            int attributeLevelToAdd20 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect20 = new CharacterCreationOnSelect(this.KhuzaitMerchantOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects20 = new CharacterCreationApplyFinalEffects(this.KhuzaitMerchantOnApply);
            TextObject textObject40 = new TextObject("{=qPg3IDiq}Your family came from one of the merchant clans that dominated the cities in eastern Calradia before the Khuzait conquest. They adjusted quickly to their new masters, keeping the caravan routes running and ensuring that the tariff revenues that once went into imperial coffers now flowed to the khanate.");
            creationCategory26.AddCategoryOption(textObject39, skillObjectList32, social6, focusToAdd20, skillLevelToAdd20, attributeLevelToAdd20, (CharacterCreationOnCondition)null, creationOnSelect20, applyFinalEffects20, textObject40, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory27 = creationCategory24;
            TextObject textObject41 = new TextObject("{=tGEStbxb}Tribespeople");
            MBList<SkillObject> skillObjectList33 = new MBList<SkillObject>();
            skillObjectList33.Add(DefaultSkills.Bow);
            skillObjectList33.Add(DefaultSkills.Riding);
            CharacterAttribute control6 = DefaultCharacterAttributes.Control;
            int focusToAdd21 = this.FocusToAdd;
            int skillLevelToAdd21 = this.SkillLevelToAdd;
            int attributeLevelToAdd21 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect21 = new CharacterCreationOnSelect(this.KhuzaitTribesmanOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects21 = new CharacterCreationApplyFinalEffects(this.KhuzaitTribesmanOnApply);
            TextObject textObject42 = new TextObject("{=URgZ4ai4}Your family were middle-ranking members of one of the Khuzait clans. He had some  herds of his own, but was not rich. When the Khuzait horde was summoned to battle, he fought with the horse archers, shooting and wheeling and wearing down the enemy before the lancers delivered the final punch.");
            creationCategory27.AddCategoryOption(textObject41, skillObjectList33, control6, focusToAdd21, skillLevelToAdd21, attributeLevelToAdd21, (CharacterCreationOnCondition)null, creationOnSelect21, applyFinalEffects21, textObject42, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory28 = creationCategory24;
            TextObject textObject43 = new TextObject("{=gQ2tAvCz}Farmers");
            MBList<SkillObject> skillObjectList34 = new MBList<SkillObject>();
            skillObjectList34.Add(DefaultSkills.Polearm);
            skillObjectList34.Add(DefaultSkills.Throwing);
            CharacterAttribute vigor6 = DefaultCharacterAttributes.Vigor;
            int focusToAdd22 = this.FocusToAdd;
            int skillLevelToAdd22 = this.SkillLevelToAdd;
            int attributeLevelToAdd22 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect22 = new CharacterCreationOnSelect(this.KhuzaitFarmerOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects22 = new CharacterCreationApplyFinalEffects(this.KhuzaitFarmerOnApply);
            TextObject textObject44 = new TextObject("{=5QSGoRFj}Your family tilled one of the small patches of arable land in the steppes for generations. When the Khuzaits came, they ceased paying taxes to the emperor and providing conscripts for his army, and served the khan instead.");
            creationCategory28.AddCategoryOption(textObject43, skillObjectList34, vigor6, focusToAdd22, skillLevelToAdd22, attributeLevelToAdd22, (CharacterCreationOnCondition)null, creationOnSelect22, applyFinalEffects22, textObject44, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory29 = creationCategory24;
            TextObject textObject45 = new TextObject("{=vfhVveLW}Shamans");
            MBList<SkillObject> skillObjectList35 = new MBList<SkillObject>();
            skillObjectList35.Add(DefaultSkills.Medicine);
            skillObjectList35.Add(DefaultSkills.Charm);
            CharacterAttribute intelligence5 = DefaultCharacterAttributes.Intelligence;
            int focusToAdd23 = this.FocusToAdd;
            int skillLevelToAdd23 = this.SkillLevelToAdd;
            int attributeLevelToAdd23 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect23 = new CharacterCreationOnSelect(this.KhuzaitShamanOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects23 = new CharacterCreationApplyFinalEffects(this.KhuzaitShamanOnApply);
            TextObject textObject46 = new TextObject("{=WOKNhaG2}Your family were guardians of the sacred traditions of the Khuzaits, channelling the spirits of the wilderness and of the ancestors. They tended the sick and dispensed wisdom, resolving disputes and providing practical advice.");
            creationCategory29.AddCategoryOption(textObject45, skillObjectList35, intelligence5, focusToAdd23, skillLevelToAdd23, attributeLevelToAdd23, (CharacterCreationOnCondition)null, creationOnSelect23, applyFinalEffects23, textObject46, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            CharacterCreationCategory creationCategory30 = creationCategory24;
            TextObject textObject47 = new TextObject("{=Xqba1Obq}Nomads");
            MBList<SkillObject> skillObjectList36 = new MBList<SkillObject>();
            skillObjectList36.Add(DefaultSkills.Scouting);
            skillObjectList36.Add(DefaultSkills.Riding);
            CharacterAttribute cunning6 = DefaultCharacterAttributes.Cunning;
            int focusToAdd24 = this.FocusToAdd;
            int skillLevelToAdd24 = this.SkillLevelToAdd;
            int attributeLevelToAdd24 = this.AttributeLevelToAdd;
            CharacterCreationOnSelect creationOnSelect24 = new CharacterCreationOnSelect(this.KhuzaitNomadOnConsequence);
            CharacterCreationApplyFinalEffects applyFinalEffects24 = new CharacterCreationApplyFinalEffects(this.KhuzaitNomadOnApply);
            TextObject textObject48 = new TextObject("{=9aoQYpZs}Your family's clan never pledged its loyalty to the khan and never settled down, preferring to live out in the deep steppe away from his authority. They remain some of the finest trackers and scouts in the grasslands, as the ability to spot an enemy coming and move quickly is often all that protects their herds from their neighbors' predations.");
            creationCategory30.AddCategoryOption(textObject47, skillObjectList36, cunning6, focusToAdd24, skillLevelToAdd24, attributeLevelToAdd24, (CharacterCreationOnCondition)null, creationOnSelect24, applyFinalEffects24, textObject48, (MBList<TraitObject>)null, 0, 0, 0, 0, 0);
            characterCreation.AddNewMenu(menu);
        }

        protected new bool VlandianParentsOnCondition()
        {
            return CEKHelpers.IsInCultureGroup(this.GetSelectedCulture().StringId, "vlandia");
        }

        protected new bool SturgianParentsOnCondition()
        {
            return CEKHelpers.IsInCultureGroup(this.GetSelectedCulture().StringId, "sturgia");
        }

        protected new bool EmpireParentsOnCondition()
        {
            return CEKHelpers.IsInCultureGroup(this.GetSelectedCulture().StringId, "empire");
        }

        protected new bool AseraiParentsOnCondition()
        {
            return CEKHelpers.IsInCultureGroup(this.GetSelectedCulture().StringId, "aserai");
        }

        protected new bool BattanianParentsOnCondition()
        {
            return CEKHelpers.IsInCultureGroup(this.GetSelectedCulture().StringId, "battania");
        }

        protected new bool KhuzaitParentsOnCondition()
        {
            return CEKHelpers.IsInCultureGroup(this.GetSelectedCulture().StringId, "khuzait");
        }
    }
}
