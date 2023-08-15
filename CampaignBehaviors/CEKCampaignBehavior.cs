// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.CEKCampaignBehavior
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Helpers;
using HarmonyLib;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.Library;

namespace CalradiaExpandedKingdoms
{
  public class CEKCampaignBehavior : CampaignBehaviorBase
  {
    public static bool CA;
    public static bool IsDebugMode;
    public static bool IsBannerCarriersOn;

    public override void RegisterEvents()
    {
      CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener((object) this, new Action<CampaignGameStarter>(this.OnGameLoaded));
      CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener((object) this, new Action<CampaignGameStarter>(this.OnGameLoaded));
    }

    public override void SyncData(IDataStore dataStore)
    {
    }

    private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
    {
      this.CAFix();
      this.CheckForCA();
      RecruitManager recruitManager = new RecruitManager();
      RecruitManager.instance.LoadRecruitConfig(BasePath.Name + "Modules/CalradiaExpandedKingdoms/ModuleData/recruit_config.xml");
    }

    private void CheckForCA()
    {
      if (CharacterObject.Find("cla_empire_militia_archer") == null)
        return;
      CEKCampaignBehavior.CA = true;
    }

    private void CAFix()
    {
      Dictionary<CultureObject, Dictionary<int, int>> dictionary = (Dictionary<CultureObject, Dictionary<int, int>>) AccessTools.Field(typeof (RebellionsCampaignBehavior), "_cultureIconIdAndFrequencies").GetValue((object) Campaign.Current.GetCampaignBehavior<RebellionsCampaignBehavior>());
      CultureObject cultureObjectById = CEKHelpers.GetCultureObjectByID("republic");
      if (dictionary.ContainsKey(cultureObjectById))
        return;
      dictionary.Add(cultureObjectById, new Dictionary<int, int>());
      foreach (int clanBannerIconsId in (IEnumerable<int>) cultureObjectById.PossibleClanBannerIconsIDs)
      {
        if (!dictionary[cultureObjectById].ContainsKey(clanBannerIconsId))
          dictionary[cultureObjectById].Add(clanBannerIconsId, 0);
      }
      AccessTools.Field(typeof (RebellionsCampaignBehavior), "_cultureIconIdAndFrequencies").SetValue((object) Campaign.Current.GetCampaignBehavior<RebellionsCampaignBehavior>(), (object) dictionary);
    }

    [CommandLineFunctionality.CommandLineArgumentFunction("toggle_debug_mode", "cek")]
    public static string ToggleDebugMode(List<string> strings)
    {
      CEKCampaignBehavior.IsDebugMode = !CEKCampaignBehavior.IsDebugMode;
      return CEKCampaignBehavior.IsDebugMode ? "Debug Mode is now on" : "Debug Mode is now off";
    }

    [CommandLineFunctionality.CommandLineArgumentFunction("toggle_banner_carriers", "cek")]
    public static string ToggleBannerCarriers(List<string> strings)
    {
      CEKCampaignBehavior.IsBannerCarriersOn = !CEKCampaignBehavior.IsBannerCarriersOn;
      return CEKCampaignBehavior.IsBannerCarriersOn ? "Banner carriers are now enabled" : "Banner carriers are now disabled";
    }
  }
}
