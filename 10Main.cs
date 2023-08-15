// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Patches.TournamentPatch
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Helpers;
using HarmonyLib;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.Core;

namespace CalradiaExpandedKingdoms.Patches
{
  [HarmonyPatch(typeof (FightTournamentGame), "CachePossibleRegularRewardItems")]
  internal class TournamentPatch
  {
    public static void Postfix(
      FightTournamentGame __instance,
      ref List<ItemObject> ____possibleRegularRewardItemObjectsCache)
    {
      if (____possibleRegularRewardItemObjectsCache == null)
        ____possibleRegularRewardItemObjectsCache = new List<ItemObject>();
      List<ItemObject> collection = new List<ItemObject>();
      foreach (ItemObject itemObject in (List<ItemObject>) Items.All)
      {
        if (itemObject.Value > 1600 && itemObject.Value < 5000 && !itemObject.NotMerchandise && (itemObject.IsCraftedWeapon || itemObject.IsMountable || itemObject.ArmorComponent != null) && !itemObject.IsCraftedByPlayer)
        {
          if (CEKHelpers.IsInCultureGroup(itemObject.Culture, (BasicCultureObject) __instance.Town.Culture))
            ____possibleRegularRewardItemObjectsCache.Add(itemObject);
          else
            collection.Add(itemObject);
        }
      }
      if (____possibleRegularRewardItemObjectsCache.IsEmpty<ItemObject>())
        ____possibleRegularRewardItemObjectsCache.AddRange((IEnumerable<ItemObject>) collection);
      ____possibleRegularRewardItemObjectsCache.Sort((Comparison<ItemObject>) ((x, y) => x.Value.CompareTo(y.Value)));
    }
  }
}
