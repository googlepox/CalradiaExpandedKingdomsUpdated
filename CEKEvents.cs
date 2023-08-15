// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Events.CEKEvents
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Ruins;
using TaleWorlds.CampaignSystem;

namespace CalradiaExpandedKingdoms.Events
{
  public class CEKEvents : CampaignBehaviorBase
  {
    private readonly MbEvent<Ruin> _ruinRaided = new MbEvent<Ruin>();

    public static IMbEvent<Ruin> RuinRaided => (IMbEvent<Ruin>) Campaign.Current.GetCampaignBehavior<CEKEvents>()._ruinRaided;

    public void OnRuinLooted(Ruin ruin) => this._ruinRaided.Invoke(ruin);

    public static CEKEvents Current => Campaign.Current.GetCampaignBehavior<CEKEvents>();

    public override void RegisterEvents()
    {
    }

    public override void SyncData(IDataStore dataStore)
    {
    }
  }
}
