// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Feats.CEKFeats
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Feats
{
  public class CEKFeats
  {
    public static FeatObject NordlingPositiveFeatOne { get; private set; }

    public static FeatObject NordlingPositiveFeatTwo { get; private set; }

    public static FeatObject NordlingPositiveFeatThree { get; private set; }

    public static FeatObject NordlingPositiveFeatFour { get; private set; }

    public static FeatObject NordlingNegativeFeatOne { get; private set; }

    public static FeatObject NordlingNegativeFeatTwo { get; private set; }

    public static FeatObject VagirPositiveFeatOne { get; private set; }

    public static FeatObject VagirPositiveFeatTwo { get; private set; }

    public static FeatObject VagirPositiveFeatThree { get; private set; }

    public static FeatObject VagirPositiveFeatFour { get; private set; }

    public static FeatObject VagirNegativeFeatOne { get; private set; }

    public static FeatObject VagirNegativeFeatTwo { get; private set; }

    public static FeatObject RhodokPositiveFeatOne { get; private set; }

    public static FeatObject RhodokPositiveFeatTwo { get; private set; }

    public static FeatObject RhodokPositiveFeatThree { get; private set; }

    public static FeatObject RhodokPositiveFeatFour { get; private set; }

    public static FeatObject RhodokNegativeFeatOne { get; private set; }

    public static FeatObject RhodokNegativeFeatTwo { get; private set; }

    public static FeatObject ApolssalianPositiveFeatOne { get; private set; }

    public static FeatObject ApolssalianPositiveFeatTwo { get; private set; }

    public static FeatObject ApolssalianPositiveFeatThree { get; private set; }

    public static FeatObject ApolssalianPositiveFeatFour { get; private set; }

    public static FeatObject ApolssalianNegativeFeatOne { get; private set; }

    public static FeatObject ApolssalianNegativeFeatTwo { get; private set; }

    public static FeatObject LyrionPositiveFeatOne { get; private set; }

    public static FeatObject LyrionPositiveFeatTwo { get; private set; }

    public static FeatObject LyrionPositiveFeatThree { get; private set; }

    public static FeatObject LyrionPositiveFeatFour { get; private set; }

    public static FeatObject LyrionNegativeFeatOne { get; private set; }

    public static FeatObject LyrionNegativeFeatTwo { get; private set; }

    public static FeatObject KhergitPositiveFeatOne { get; private set; }

    public static FeatObject KhergitPositiveFeatTwo { get; private set; }

    public static FeatObject KhergitPositiveFeatThree { get; private set; }

    public static FeatObject KhergitPositiveFeatFour { get; private set; }

    public static FeatObject KhergitNegativeFeatOne { get; private set; }

    public static FeatObject KhergitNegativeFeatTwo { get; private set; }

    public static FeatObject PaleicianPositiveFeatOne { get; private set; }

    public static FeatObject PaleicianPositiveFeatTwo { get; private set; }

    public static FeatObject PaleicianPositiveFeatThree { get; private set; }

    public static FeatObject PaleicianPositiveFeatFour { get; private set; }

    public static FeatObject PaleicianNegativeFeatOne { get; private set; }

    public static FeatObject PaleicianNegativeFeatTwo { get; private set; }

    public static FeatObject RepublicPositiveFeatOne { get; private set; }

    public static FeatObject RepublicPositiveFeatTwo { get; private set; }

    public static FeatObject RepublicPositiveFeatThree { get; private set; }

    public static FeatObject RepublicPositiveFeatFour { get; private set; }

    public static FeatObject RepublicNegativeFeatOne { get; private set; }

    public static FeatObject RepublicNegativeFeatTwo { get; private set; }

    public static FeatObject EmpirePositiveFeatThree { get; private set; }

    public static FeatObject EmpirePositiveFeatFour { get; private set; }

    public static FeatObject EmpireNegativeFeatTwo { get; private set; }

    public static FeatObject AseraiPositiveFeatThree { get; private set; }

    public static FeatObject AseraiPositiveFeatFour { get; private set; }

    public static FeatObject AseraiNegativeFeatTwo { get; private set; }

    public static FeatObject BattaniaPositiveFeatThree { get; private set; }

    public static FeatObject BattaniaPositiveFeatFour { get; private set; }

    public static FeatObject BattaniaNegativeFeatTwo { get; private set; }

    public static FeatObject KhuzaitPositiveFeatThree { get; private set; }

    public static FeatObject KhuzaitPositiveFeatFour { get; private set; }

    public static FeatObject KhuzaitNegativeFeatTwo { get; private set; }

    public static FeatObject SturgiaPositiveFeatThree { get; private set; }

    public static FeatObject SturgiaPositiveFeatFour { get; private set; }

    public static FeatObject SturgiaNegativeFeatTwo { get; private set; }

    public static FeatObject VlandianPositiveFeatThree { get; private set; }

    public static FeatObject VlandianPositiveFeatFour { get; private set; }

    public static FeatObject VlandianNegativeFeatTwo { get; private set; }

    public static FeatObject AriorumPositiveOne { get; private set; }

    public static FeatObject AriorumPositiveTwo { get; private set; }

    public static FeatObject AriorumPositiveThree { get; private set; }

    public static FeatObject AriorumPositiveFour { get; private set; }

    public static FeatObject AriorumNegativeOne { get; private set; }

    public static FeatObject AriorumNegativeTwo { get; private set; }

    public static void RegisterAll()
    {
      CEKFeats.NordlingPositiveFeatOne = CEKFeats.Create("NordlingPositiveFeatOne");
      CEKFeats.NordlingPositiveFeatTwo = CEKFeats.Create("NordlingPositiveFeatTwo");
      CEKFeats.NordlingPositiveFeatThree = CEKFeats.Create("NordlingPositiveFeatThree");
      CEKFeats.NordlingPositiveFeatFour = CEKFeats.Create("NordlingPositiveFeatFour");
      CEKFeats.NordlingNegativeFeatOne = CEKFeats.Create("NordlingNegativeFeatOne");
      CEKFeats.NordlingNegativeFeatTwo = CEKFeats.Create("NordlingNegativeFeatTwo");
      CEKFeats.VagirPositiveFeatOne = CEKFeats.Create("VagirPositiveFeatOne");
      CEKFeats.VagirPositiveFeatTwo = CEKFeats.Create("VagirPositiveFeatTwo");
      CEKFeats.VagirPositiveFeatThree = CEKFeats.Create("VagirPositiveFeatThree");
      CEKFeats.VagirPositiveFeatFour = CEKFeats.Create("VagirPositiveFeatFour");
      CEKFeats.VagirNegativeFeatOne = CEKFeats.Create("VagirNegativeFeatOne");
      CEKFeats.VagirNegativeFeatTwo = CEKFeats.Create("VagirNegativeFeatTwo");
      CEKFeats.RhodokPositiveFeatOne = CEKFeats.Create("RhodokPositiveFeatOne");
      CEKFeats.RhodokPositiveFeatTwo = CEKFeats.Create("RhodokPositiveFeatTwo");
      CEKFeats.RhodokPositiveFeatThree = CEKFeats.Create("RhodokPositiveFeatThree");
      CEKFeats.RhodokPositiveFeatFour = CEKFeats.Create("RhodokPositiveFeatFour");
      CEKFeats.RhodokNegativeFeatOne = CEKFeats.Create("RhodokNegativeFeatOne");
      CEKFeats.RhodokNegativeFeatTwo = CEKFeats.Create("RhodokNegativeFeatTwo");
      CEKFeats.ApolssalianPositiveFeatOne = CEKFeats.Create("ApolssalianPositiveFeatOne");
      CEKFeats.ApolssalianPositiveFeatTwo = CEKFeats.Create("ApolssalianPositiveFeatTwo");
      CEKFeats.ApolssalianPositiveFeatThree = CEKFeats.Create("ApolssalianPositiveFeatThree");
      CEKFeats.ApolssalianPositiveFeatFour = CEKFeats.Create("ApolssalianPositiveFeatFour");
      CEKFeats.ApolssalianNegativeFeatOne = CEKFeats.Create("ApolssalianNegativeFeatOne");
      CEKFeats.ApolssalianNegativeFeatTwo = CEKFeats.Create("ApolssalianNegativeFeatTwo");
      CEKFeats.LyrionPositiveFeatOne = CEKFeats.Create("LyrionPositiveFeatOne");
      CEKFeats.LyrionPositiveFeatTwo = CEKFeats.Create("LyrionPositiveFeatTwo");
      CEKFeats.LyrionPositiveFeatThree = CEKFeats.Create("LyrionPositiveFeatThree");
      CEKFeats.LyrionPositiveFeatFour = CEKFeats.Create("LyrionPositiveFeatFour");
      CEKFeats.LyrionNegativeFeatOne = CEKFeats.Create("LyrionNegativeFeatOne");
      CEKFeats.LyrionNegativeFeatTwo = CEKFeats.Create("LyrionNegativeFeatTwo");
      CEKFeats.KhergitPositiveFeatOne = CEKFeats.Create("KhergitPositiveFeatOne");
      CEKFeats.KhergitPositiveFeatTwo = CEKFeats.Create("KhergitPositiveFeatTwo");
      CEKFeats.KhergitPositiveFeatThree = CEKFeats.Create("KhergitPositiveFeatThree");
      CEKFeats.KhergitPositiveFeatFour = CEKFeats.Create("KhergitPositiveFeatFour");
      CEKFeats.KhergitNegativeFeatOne = CEKFeats.Create("KhergitNegativeFeatOne");
      CEKFeats.KhergitNegativeFeatTwo = CEKFeats.Create("KhergitNegativeFeatTwo");
      CEKFeats.PaleicianPositiveFeatOne = CEKFeats.Create("PaleicianPositiveFeatOne");
      CEKFeats.PaleicianPositiveFeatTwo = CEKFeats.Create("PaleicianPositiveFeatTwo");
      CEKFeats.PaleicianPositiveFeatThree = CEKFeats.Create("PaleicianPositiveFeatThree");
      CEKFeats.PaleicianPositiveFeatFour = CEKFeats.Create("PaleicianPositiveFeatFour");
      CEKFeats.PaleicianNegativeFeatOne = CEKFeats.Create("PaleicianNegativeFeatOne");
      CEKFeats.PaleicianNegativeFeatTwo = CEKFeats.Create("PaleicianNegativeFeatTwo");
      CEKFeats.RepublicPositiveFeatOne = CEKFeats.Create("RepublicPositiveFeatOne");
      CEKFeats.RepublicPositiveFeatTwo = CEKFeats.Create("RepublicPositiveFeatTwo");
      CEKFeats.RepublicPositiveFeatThree = CEKFeats.Create("RepublicPositiveFeatThree");
      CEKFeats.RepublicPositiveFeatFour = CEKFeats.Create("RepublicPositiveFeatFour");
      CEKFeats.RepublicNegativeFeatOne = CEKFeats.Create("RepublicNegativeFeatOne");
      CEKFeats.RepublicNegativeFeatTwo = CEKFeats.Create("RepublicNegativeFeatTwo");
      CEKFeats.EmpirePositiveFeatThree = CEKFeats.Create("EmpirePositiveFeatThree");
      CEKFeats.EmpirePositiveFeatFour = CEKFeats.Create("EmpirePositiveFeatFour");
      CEKFeats.EmpireNegativeFeatTwo = CEKFeats.Create("EmpireNegativeFeatTwo");
      CEKFeats.AseraiPositiveFeatThree = CEKFeats.Create("AseraiPositiveFeatThree");
      CEKFeats.AseraiPositiveFeatFour = CEKFeats.Create("AseraiPositiveFeatFour");
      CEKFeats.AseraiNegativeFeatTwo = CEKFeats.Create("AseraiNegativeFeatTwo");
      CEKFeats.BattaniaPositiveFeatThree = CEKFeats.Create("BattaniaPositiveFeatThree");
      CEKFeats.BattaniaPositiveFeatFour = CEKFeats.Create("BattaniaPositiveFeatFour");
      CEKFeats.BattaniaNegativeFeatTwo = CEKFeats.Create("BattaniaNegativeFeatTwo");
      CEKFeats.KhuzaitPositiveFeatThree = CEKFeats.Create("KhuzaitPositiveFeatThree");
      CEKFeats.KhuzaitPositiveFeatFour = CEKFeats.Create("KhuzaitPositiveFeatFour");
      CEKFeats.KhuzaitNegativeFeatTwo = CEKFeats.Create("KhuzaitNegativeFeatTwo");
      CEKFeats.SturgiaPositiveFeatThree = CEKFeats.Create("SturgiaPositiveFeatThree");
      CEKFeats.SturgiaPositiveFeatFour = CEKFeats.Create("SturgiaPositiveFeatFour");
      CEKFeats.SturgiaNegativeFeatTwo = CEKFeats.Create("SturgiaNegativeFeatTwo");
      CEKFeats.VlandianPositiveFeatThree = CEKFeats.Create("VlandianPositiveFeatThree");
      CEKFeats.VlandianPositiveFeatFour = CEKFeats.Create("VlandianPositiveFeatFour");
      CEKFeats.VlandianNegativeFeatTwo = CEKFeats.Create("VlandianNegativeFeatTwo");
      CEKFeats.AriorumPositiveOne = CEKFeats.Create("AriorumPositiveOne");
      CEKFeats.AriorumPositiveTwo = CEKFeats.Create("AriorumPositiveTwo");
      CEKFeats.AriorumPositiveThree = CEKFeats.Create("AriorumPositiveThree");
      CEKFeats.AriorumPositiveFour = CEKFeats.Create("AriorumPositiveFour");
      CEKFeats.AriorumNegativeOne = CEKFeats.Create("AriorumNegativeOne");
      CEKFeats.AriorumNegativeTwo = CEKFeats.Create("AriorumNegativeTwo");
      CEKFeats.InitializeFeats();
    }

    private static void InitializeFeats()
    {
      CEKFeats.NordlingPositiveFeatOne.Initialize("NordlingPositiveFeatOne", "Expert Raiders: Faster Village looting", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.NordlingPositiveFeatTwo.Initialize("NordlingPositiveFeatTwo", "Born of the Cold: No speed penalty from snow.", 0.0f, true, FeatObject.AdditionType.Add);
      CEKFeats.NordlingPositiveFeatThree.Initialize("NordlingPositiveFeatThree", "Born of the Sea: No speed penalty from water.", 0.2f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.NordlingPositiveFeatFour.Initialize("NordlingPositiveFeatFour", "War Glory: Increased renown and morale from offensive battles.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.NordlingNegativeFeatOne.Initialize("NordlingNegativeFeatOne", "Independent: Armies lose organization faster. Increased renown cost to invite lords to armies.", 0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.NordlingNegativeFeatTwo.Initialize("NordlingNegativeFeatTwo", "Poor Accounting: Reduced income from settlements.", -0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.VagirPositiveFeatOne.Initialize("VagirPositiveFeatOne", "Cosmopolitan: No foreign governor penalty. Increased settlement security.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.VagirPositiveFeatTwo.Initialize("VagirPositiveFeatTwo", "Northern Highlanders: Reduced speed penalty in both forests and snow.", 0.05f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.VagirPositiveFeatThree.Initialize("VagirPositiveFeatThree", "Homeland: Increased settlement militia production.", 0.1f, true, FeatObject.AdditionType.Add);
      CEKFeats.VagirPositiveFeatFour.Initialize("VagirPositiveFeatFour", "Land Tenure: Increased village tax and settlement food production.", 0.05f, true, FeatObject.AdditionType.Add);
      CEKFeats.VagirNegativeFeatOne.Initialize("VagirNegativeFeatOne", "Non-Expansionist: Reduced troop morale and gained renown from offensive battles.", -0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.VagirNegativeFeatTwo.Initialize("VagirNegativeFeatTwo", "Clan Warlords: Armies lose organization faster. Increased renown cost to invite lords to armies.", 0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.RhodokPositiveFeatOne.Initialize("RhodokPositiveFeatOne", "Organized Militia: Slightly decreased non-noble troop recruitment costs. Increased village militia.", -0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.RhodokPositiveFeatTwo.Initialize("RhodokPositiveFeatTwo", "Industrial Burgs: Increased workshop output and settlement prosperity.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.RhodokPositiveFeatThree.Initialize("RhodokPositiveFeatThree", "Reichsbehörde: Armies last longer and renown costs for recruiting lords are reduced.", -0.05f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.RhodokPositiveFeatFour.Initialize("RhodokPositiveFeatFour", "Königsbanner: Increased troop morale.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.RhodokNegativeFeatOne.Initialize("RhodokNegativeFeatOne", "Trade Sanctions: Reduced settlement profit.", -0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.RhodokNegativeFeatTwo.Initialize("RhodokNegativeFeatTwo", "Exhausted Veterans: Troops require more experience to upgrade.", -0.05f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.ApolssalianPositiveFeatOne.Initialize("ApolssalianPositiveFeatOne", "Self-equipped: Reduced troop recruitment and wage costs.", -0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.ApolssalianPositiveFeatTwo.Initialize("ApolssalianPositiveFeatTwo", "Trade heritage: Increased city income from trade.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.ApolssalianPositiveFeatThree.Initialize("ApolssalianPositiveFeatThree", "Apolssalós: Settlements of same culture have increased prosperity and militia production.", 0.8f, true, FeatObject.AdditionType.Add);
      CEKFeats.ApolssalianPositiveFeatFour.Initialize("ApolssalianPositiveFeatFour", "Heitairoi: Lords have increased party size.", 15f, true, FeatObject.AdditionType.Add);
      CEKFeats.ApolssalianNegativeFeatOne.Initialize("ApolssalianNegativeFeatOne", "Polis autonomy: Reduced security and loyalty to settlements of foreign culture.", -0.8f, false, FeatObject.AdditionType.Add);
      CEKFeats.ApolssalianNegativeFeatTwo.Initialize("ApolssalianNegativeFeatTwo", "Reluctant Leaders: Reduced troop morale from offensive battles.", -0.05f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.LyrionPositiveFeatOne.Initialize("LyrionPositiveFeatOne", "Forced March: Increased speed from infantry on the campaign map.", 0.05f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.LyrionPositiveFeatTwo.Initialize("LyrionPositiveFeatTwo", "Fast Learners: Troops have increased experience from battles.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.LyrionPositiveFeatThree.Initialize("LyrionPositiveFeatThree", "Thalassocracy: Increased city income from trade and less speed penalty from water.", 0.05f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.LyrionPositiveFeatFour.Initialize("LyrionPositiveFeatFour", "Caravaneers: Increased profit from caravans.", 0.05f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.LyrionNegativeFeatOne.Initialize("LyrionNegativeFeatOne", "Poor Engineering: Slower town and siege building speeds.", -0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.LyrionNegativeFeatTwo.Initialize("LyrionNegativeFeatTwo", "Limited Citizenry: Decreased settlement loyalty and security.", -0.8f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.KhergitPositiveFeatOne.Initialize("KhergitPositiveFeatOne", "Born in the Saddle: Increased speed for horsemen on the campaign map.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.KhergitPositiveFeatTwo.Initialize("KhergitPositiveFeatTwo", "Borrowed Learning: Faster town projects, wall repairs and siege engines building.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.KhergitPositiveFeatThree.Initialize("KhergitPositiveFeatThree", "Mounted Tradition: Reduced recruitment and upgrade costs for cavalry.", -0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.KhergitPositiveFeatFour.Initialize("KhergitPositiveFeatFour", "Settling Populace: Faster village growth.", 0.2f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.KhergitNegativeFeatOne.Initialize("KhergitNegativeFeatOne", "Cultural Upheaval: Decreased troop morale.", -0.05f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.KhergitNegativeFeatTwo.Initialize("KhergitNegativeFeatTwo", "Poor Accounting: Reduced income from settlements.", -0.15f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.PaleicianPositiveFeatOne.Initialize("PaleicianPositiveFeatOne", "Fast Learners: Troops have increased experience from battles.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.PaleicianPositiveFeatTwo.Initialize("PaleicianPositiveFeatTwo", "Borrowed Learning: Faster town projects, wall repairs and siege engines building.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.PaleicianPositiveFeatThree.Initialize("PaleicianPositiveFeatThree", "Fyrd: Recruits replenish faster, increased militia production.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.PaleicianPositiveFeatFour.Initialize("PaleicianPositiveFeatFour", "Cosmopolitan: No foreign governor penalty. Increased settlement security.", 0.5f, true, FeatObject.AdditionType.Add);
      CEKFeats.PaleicianNegativeFeatOne.Initialize("PaleicianNegativeFeatOne", "Teething Pains: Disagreements with other lords have more impact.", 0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.PaleicianNegativeFeatTwo.Initialize("PaleicianNegativeFeatTwo", "Reluctant Leaders: Reduced troop morale from offensive battles.", -0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.RepublicPositiveFeatOne.Initialize("RepublicPositiveFeatOne", "Expert Engineering: Faster town projects, wall repairs and siege engines building.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.RepublicPositiveFeatTwo.Initialize("RepublicPositiveFeatTwo", "Civil Duty: Reduced wages for garrisons.", -0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.RepublicPositiveFeatThree.Initialize("RepublicPositiveFeatThree", "Citizens Service: Increased troop morale.", 0.05f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.RepublicPositiveFeatFour.Initialize("RepublicPositiveFeatFour", "Panem et Circenses: Increased settlement security and food production.", 0.8f, true, FeatObject.AdditionType.Add);
      CEKFeats.RepublicNegativeFeatOne.Initialize("RepublicNegativeFeatOne", "Bureaucracy: Decreased workshop output.", -0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.RepublicNegativeFeatTwo.Initialize("RepublicNegativeFeatTwo", "Requisition Forms: Upgrading troops costs slightly more.", 0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.EmpirePositiveFeatThree.Initialize("EmpirePositiveFeatThree", "Expert Engineering: Faster town projects, wall repairs and siege engines building.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.EmpirePositiveFeatFour.Initialize("EmpirePositiveFeatFour", "Cosmopolitan: No foreign governor penalty. Increased settlement security.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.EmpireNegativeFeatTwo.Initialize("EmpireNegativeFeatTwo", "Imperial Decay: Reduced renown from battles.", -0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.AseraiPositiveFeatThree.Initialize("AseraiPositiveFeatThree", "Silk Traders: Increased settlement prosperity.", 0.5f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.AseraiPositiveFeatFour.Initialize("AseraiPositiveFeatFour", "Aggressive Expansion: Increased renown and morale gained from offensive battles.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.AseraiNegativeFeatTwo.Initialize("AseraiNegativeFeatTwo", "Oppressive Rule: Reduced settlement loyalty.", -0.5f, false, FeatObject.AdditionType.Add);
      CEKFeats.BattaniaPositiveFeatThree.Initialize("BattaniaPositiveFeatThree", "Highlanders: Increased morale and autoresolve efficiency during defensive battles.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.BattaniaPositiveFeatFour.Initialize("BattaniaPositiveFeatFour", "Double March: Small speed boost for parties composed by up to a quarter of cavalry.", 0.05f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.BattaniaNegativeFeatTwo.Initialize("BattaniaNegativeFeatTwo", "Clan Warlords: Armies lose organization faster. Increased renown cost to invite lords to armies.", 0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.KhuzaitPositiveFeatThree.Initialize("KhuzaitPositiveFeatThree", "Great Xaan: Reduced renown cost to invite lords to armies, slower army organization decay.", -0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.KhuzaitPositiveFeatFour.Initialize("KhuzaitPositiveFeatFour", "Nomadism: Increased world speed for cavalry.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.KhuzaitNegativeFeatTwo.Initialize("KhuzaitNegativeFeatTwo", "Loose Rule: Reduced settlement security and militia production.", -0.8f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.SturgiaPositiveFeatThree.Initialize("SturgiaPositiveFeatThree", "Born of the Cold: No speed penalty from snow.", 0.1f, true, FeatObject.AdditionType.Add);
      CEKFeats.SturgiaPositiveFeatFour.Initialize("SturgiaPositiveFeatFour", "Booming Trade: Increased income from settlements.", 0.2f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.SturgiaNegativeFeatTwo.Initialize("SturgiaNegativeFeatTwo", "Battle Lust: Reduced troop morale during defensive battles.", -0.1f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.VlandianPositiveFeatThree.Initialize("VlandianPositiveFeatThree", "Chevalerie: Faster training of cavalry units.", 0.15f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.VlandianPositiveFeatFour.Initialize("VlandianPositiveFeatFour", "Industrial Burgs: Increased workshop output and settlement prosperity.", 0.1f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.VlandianNegativeFeatTwo.Initialize("VlandianNegativeFeatTwo", "Costly Lowmen: Increased troop upkeep costs.", 0.05f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.AriorumPositiveOne.Initialize("AriorumPositiveOne", "Trade Hub: Ariorum settlements have increased prosperity.", 1f, true, FeatObject.AdditionType.Add);
      CEKFeats.AriorumPositiveTwo.Initialize("AriorumPositiveTwo", "Expert Manufacturing: Ariorum villages have increased production output.", 0.15f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.AriorumPositiveThree.Initialize("AriorumPositiveThree", "Militarized Nobility: Ariorum notables provide significantly more noble units.", 0.25f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.AriorumPositiveFour.Initialize("AriorumPositiveFour", "Trade Connections: Ariorum caravans have decreased trade penalty.", 0.25f, true, FeatObject.AdditionType.AddFactor);
      CEKFeats.AriorumNegativeOne.Initialize("AriorumNegativeOne", "Expensive Retinues: Significantly increased upkeep costs for all troops.", 0.2f, false, FeatObject.AdditionType.AddFactor);
      CEKFeats.AriorumNegativeTwo.Initialize("AriorumNegativeTwo", "Slave Traders: Reduced settlement loyalty.", -0.5f, false, FeatObject.AdditionType.Add);
    }

    private static FeatObject Create(string stringId) => Game.Current.ObjectManager.RegisterPresumedObject<FeatObject>(new FeatObject(stringId));
  }
}
