// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.CustomSaveDefiner
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Quests.FindItemInRuin;
using CalradiaExpandedKingdoms.Ruins;
using System.Collections.Generic;
using TaleWorlds.SaveSystem;

namespace CalradiaExpandedKingdoms
{
  public class CustomSaveDefiner : SaveableTypeDefiner
  {
    public CustomSaveDefiner()
      : base(81818181)
    {
    }

    protected override void DefineClassTypes()
    {
      this.AddClassDefinition(typeof (Ruin), 1);
      this.AddEnumDefinition(typeof (RuinType), 2);
      this.AddClassDefinition(typeof (FindItemInRuinQuestBehavior.FindItemInRuinQuest), 3);
    }

    protected override void DefineContainerDefinitions() => this.ConstructContainerDefinition(typeof (List<Ruin>));
  }
}
