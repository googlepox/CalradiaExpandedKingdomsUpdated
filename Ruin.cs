// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Ruins.Ruin
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using System;
using System.Xml;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;

namespace CalradiaExpandedKingdoms.Ruins
{
  public class Ruin : SettlementComponent
  {
    protected override void OnInventoryUpdated(ItemRosterElement item, int count)
    {
    }

    public override void Deserialize(MBObjectManager objectManager, XmlNode node)
    {
      base.Deserialize(objectManager, node);
      this.BackgroundCropPosition = float.Parse(node.Attributes["background_crop_position"].Value);
      this.BackgroundMeshName = node.Attributes["background_mesh"].Value;
      this.WaitMeshName = node.Attributes["wait_mesh"].Value;
      this.RuinType = (RuinType) Enum.Parse(typeof (RuinType), node.Attributes["type"].Value, true);
    }

    public Ruin()
    {
      this.IsRaided = false;
      this.HasBandits = true;
      this.IsSpotted = false;
    }

    public void ResetRuin()
    {
      this.IsRaided = false;
      this.HasBandits = true;
      this.LastRaided = CampaignTime.Never;
      this.RaidProgress = 0.0f;
      this.LastTick = 0.0f;
    }

    [SaveableProperty(500)]
    public bool IsRaided { get; set; }

    [SaveableProperty(501)]
    public float RaidProgress { get; set; }

    [SaveableProperty(502)]
    public float LastTick { get; set; }

    [SaveableProperty(503)]
    public string RuinSettlementID { get; set; }

    public RuinType RuinType { get; set; }

    [SaveableProperty(505)]
    public bool HasBandits { get; set; }

    [SaveableProperty(506)]
    public CampaignTime LastRaided { get; set; }

    [SaveableProperty(507)]
    public bool IsSpotted { get; set; }
  }
}
