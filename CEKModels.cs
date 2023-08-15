// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Models.CEKItemValueModel
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using System;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Models
{
  public class CEKItemValueModel : DefaultItemValueModel
  {
    public override int CalculateValue(ItemObject item)
    {
      float num1 = 1f;
      if (item.ItemComponent != null)
        num1 = this.GetEquipmentValueFromTier(item.Tierf);
      float num2 = 1f;
      if (item.ItemComponent is WeaponComponent || item.ItemComponent is TradeItemComponent || item.ItemComponent is HorseComponent || item.ItemComponent is SaddleComponent || item.ItemComponent is ArmorComponent)
        num2 = 100f;
      if (item.ItemComponent is ArmorComponent)
      {
        ArmorComponent itemComponent = item.ItemComponent as ArmorComponent;
        int num3 = itemComponent.ArmArmor + itemComponent.BodyArmor + itemComponent.LegArmor + itemComponent.HeadArmor;
        float num4 = itemComponent.MaterialType != ArmorComponent.ArmorMaterialTypes.Cloth ? (itemComponent.MaterialType != ArmorComponent.ArmorMaterialTypes.Leather ? (itemComponent.MaterialType != ArmorComponent.ArmorMaterialTypes.Chainmail ? (itemComponent.MaterialType != ArmorComponent.ArmorMaterialTypes.Plate ? 1f : 1.2f) : 1f) : 0.7f) : 0.4f;
        if (item.ItemType == ItemObject.ItemTypeEnum.HeadArmor)
          return (int) (15.0 * (double) num1 + (double) (num3 * 300) * (double) num4 - (double) item.Weight * 100.0);
        if (item.ItemType == ItemObject.ItemTypeEnum.ChestArmor)
          return (int) (100.0 * (double) num1 + (double) (itemComponent.BodyArmor * 500 + itemComponent.ArmArmor * 300 + itemComponent.LegArmor * 300) * (double) num4 / ((double) item.Weight / 2.0));
        if (item.ItemType == ItemObject.ItemTypeEnum.HandArmor || item.ItemType == ItemObject.ItemTypeEnum.LegArmor)
          return (int) ((double) num2 * (double) num1 + (double) (num3 * 300) * (double) num4);
        if (item.ItemType == ItemObject.ItemTypeEnum.Cape)
          return (int) ((double) num2 * (double) num1 + ((double) num3 - (double) item.Weight) * 250.0 * (double) num4);
      }
      return (int) ((double) num2 * (double) num1 * (1.0 + 0.20000000298023224 * ((double) item.Appearance - 1.0)) + 100.0 * (double) Math.Max(0.01f, item.Appearance - 1f));
    }
  }
}
