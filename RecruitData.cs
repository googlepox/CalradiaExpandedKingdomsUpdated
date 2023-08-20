// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.RecruitData
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using TaleWorlds.CampaignSystem;

namespace CalradiaExpandedKingdoms
{
    public struct RecruitData
    {
        public CultureObject culture;
        public CharacterObject character;
        public IFaction faction;
        public int chance;
        public bool isRetinue;

        public RecruitData(
          CultureObject culture,
          CharacterObject character,
          IFaction faction,
          int chance,
          bool isRetinue)
        {
            this.culture = culture;
            this.character = character;
            this.faction = faction;
            this.chance = chance;
            this.isRetinue = isRetinue;
        }
    }
}
