// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKVolunteerProductionModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Models
{
  public class CEKVolunteerProductionModel : DefaultVolunteerModel
  {
    public override float GetDailyVolunteerProductionProbability(
      Hero hero,
      int index,
      Settlement settlement)
    {
      ExplainedNumber explainedNumber = new ExplainedNumber(base.GetDailyVolunteerProductionProbability(hero, index, settlement));
      if (hero.Culture.HasFeat(CEKFeats.PaleicianPositiveFeatThree))
        explainedNumber.AddFactor(CEKFeats.PaleicianPositiveFeatThree.EffectBonus);
      return explainedNumber.ResultNumber;
    }

    public override CharacterObject GetBasicVolunteer(Hero sellerHero)
    {
      CharacterObject basicVolunteer = sellerHero.Culture.BasicTroop;
      if (sellerHero.CurrentSettlement == null || basicVolunteer == sellerHero.Culture.EliteBasicTroop)
        return basicVolunteer;
      Settlement currentSettlement = sellerHero.CurrentSettlement;
      float num1 = currentSettlement.IsTown ? sellerHero.Power * 0.03f : sellerHero.Power * 0.05f;
      int num2 = MBRandom.RandomInt(1, 100);
      if (sellerHero.Culture.StringId == "ariorum")
        num1 *= 1.25f;
      if ((double) num2 <= (double) num1)
        return sellerHero.Culture.EliteBasicTroop;
      List<RecruitData> recruitDataList = new List<RecruitData>();
      CultureObject settlementCulture = sellerHero.CurrentSettlement.Culture;
      List<RecruitData> list1 = RecruitManager.instance.Recruits.Where<RecruitData>((Func<RecruitData, bool>) (x => x.culture == settlementCulture)).ToList<RecruitData>();
      if (list1.Count > 0)
      {
        if (currentSettlement.Owner == currentSettlement.Owner.MapFaction.Leader)
        {
          List<RecruitData> list2 = list1.Where<RecruitData>((Func<RecruitData, bool>) (x => x.isRetinue)).ToList<RecruitData>();
          if (list2.Any<RecruitData>())
          {
            RecruitData randomElement = list2.GetRandomElement<RecruitData>();
            if (num2 <= randomElement.chance)
              basicVolunteer = randomElement.character;
          }
        }
        if (basicVolunteer == base.GetBasicVolunteer(sellerHero))
        {
          int num3 = 0;
          foreach (RecruitData recruitData in list1)
          {
            num3 += recruitData.chance;
            if (recruitData.faction != null)
            {
              if (recruitData.faction == currentSettlement.OwnerClan.MapFaction && num2 <= num3)
              {
                basicVolunteer = recruitData.character;
                break;
              }
            }
            else if (num2 <= num3)
            {
              basicVolunteer = recruitData.character;
              break;
            }
          }
        }
      }
      return basicVolunteer;
    }
  }
}
