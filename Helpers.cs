// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.Helpers.CEKHelpers
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.ObjectSystem;

namespace CalradiaExpandedKingdoms.Helpers
{
    public static class CEKHelpers
    {
        public static bool IsInCultureGroup(
          BasicCultureObject culture,
          BasicCultureObject referenceCulture)
        {
            return CEKHelpers.IsInCultureGroup(culture != null ? culture.StringId : "", referenceCulture != null ? referenceCulture.StringId : "");
        }

        public static bool IsInCultureGroup(string id, string referenceId)
        {
            if (id == referenceId)
            {
                return true;
            }

            if (referenceId == "vlandia" || referenceId == "rhodok" || referenceId == "paleician")
            {
                return id == "vlandia" || id == "rhodok" || id == "paleician";
            }

            if (referenceId == "khuzait" || referenceId == "rebkhu")
            {
                return id == "khuzait" || id == "rebkhu";
            }

            if (referenceId == "nordling" || referenceId == "sturgia")
            {
                return id == "nordling" || id == "sturgia";
            }

            if (referenceId == "empire" || referenceId == "apolssalian" || referenceId == "republic" || referenceId == "ariorum")
            {
                return id == "empire" || id == "apolssalian" || id == "republic" || id == "ariorum";
            }

            if (referenceId == "vagir" || referenceId == "battania")
            {
                return id == "vagir" || id == "battania";
            }

            return (referenceId == "lyrion" || referenceId == "aserai") && (id == "lyrion" || id == "aserai");
        }

        public static Kingdom GetKingdomByID(string ID)
        {
            return Kingdom.All.FirstOrDefault<Kingdom>((Func<Kingdom, bool>)(x => x.StringId == ID));
        }

        public static Hero GetClanLeaderByID(string id)
        {
            return Clan.All.FirstOrDefault<Clan>((Func<Clan, bool>)(x => x.StringId == id)).Leader;
        }

        public static Clan GetClanByID(string id)
        {
            return Clan.All.FirstOrDefault<Clan>((Func<Clan, bool>)(x => x.StringId == id));
        }

        public static CharacterObject GetNPCByID(string id)
        {
            return id == null ? (CharacterObject)null : CharacterObject.All.FirstOrDefault<CharacterObject>((Func<CharacterObject, bool>)(x => x.StringId == id));
        }

        public static CultureObject GetCultureObjectByID(string id)
        {
            return MBObjectManager.Instance.GetObjectTypeList<CultureObject>().FirstOrDefault<CultureObject>((Func<CultureObject, bool>)(x => x.StringId == id));
        }

        public static bool IsEliteTroop(CharacterObject character)
        {
            CharacterObject eliteBasicTroop = character.Culture.EliteBasicTroop;
            return eliteBasicTroop.UpgradeTargets != null && (character == eliteBasicTroop || ((IEnumerable<CharacterObject>)eliteBasicTroop.UpgradeTargets).Contains<CharacterObject>(character));
        }
    }
}
