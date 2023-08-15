// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKVillageProductionModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Feats;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Models
{
  public class CEKVillageProductionModel : DefaultVillageProductionCalculatorModel
  {
    public override float CalculateDailyProductionAmount(Village village, ItemObject item)
    {
      float productionAmount = base.CalculateDailyProductionAmount(village, item);
      if (village.Settlement.Culture.HasFeat(CEKFeats.AriorumPositiveTwo) && village.Settlement.Owner != null && village.Settlement.Owner.Culture.HasFeat(CEKFeats.AriorumPositiveTwo))
        productionAmount *= 1.15f;
      return productionAmount;
    }
  }
}
