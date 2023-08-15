// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Patches.GetMergedXmlForManagedPath
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using HarmonyLib;
using TaleWorlds.ObjectSystem;

namespace CalradiaExpandedKingdoms.Patches
{
  [HarmonyPatch(typeof (MBObjectManager), "GetMergedXmlForManaged")]
  internal class GetMergedXmlForManagedPath
  {
    public static bool Prefix(
      string id,
      ref bool skipValidation,
      bool ignoreGameTypeInclusionCheck = true,
      string gameType = "")
    {
      if (id == "Settlements")
        skipValidation = true;
      return true;
    }
  }
}
