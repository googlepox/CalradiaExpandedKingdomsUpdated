// Decompiled with JetBrains decompiler
// Type: CalradiaExpandedKingdoms.RecruitManager
// Assembly: CalradiaExpandedKingdoms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BB1DA1AA-2913-4F7F-8D57-8D6C0FE5AD98
// Assembly location: C:\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CalradiaExpandedKingdoms\bin\Win64_Shipping_Client\CalradiaExpandedKingdoms.dll

using CalradiaExpandedKingdoms.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace CalradiaExpandedKingdoms
{
    public class RecruitManager
    {
        public static RecruitManager instance;
        public List<RecruitData> Recruits;

        public RecruitManager()
        {
            RecruitManager.instance = this;
            this.Recruits = new List<RecruitData>();
        }

        public void LoadRecruitConfig(string xmlPath)
        {
            this.LoadFromXml(this.LoadXmlFile(xmlPath));
        }

        private XmlDocument LoadXmlFile(string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            StreamReader streamReader = new StreamReader(path);
            string end = streamReader.ReadToEnd();
            xmlDocument.LoadXml(end);
            streamReader.Close();
            return xmlDocument;
        }

        private void LoadFromXml(XmlDocument doc)
        {
            if (doc.ChildNodes.Count <= 1)
            {
                throw new TWXmlLoadException("Incorrect XML document format.");
            }

            if (doc.ChildNodes[1].Name != "base")
            {
                throw new TWXmlLoadException("Incorrect XML document format.");
            }

            XmlNode childNode1 = doc.ChildNodes[1].ChildNodes[0];
            if (childNode1.Name != "recruits")
            {
                throw new TWXmlLoadException("Incorrect XML document format.");
            }

            if (!(childNode1.Name == "recruits"))
            {
                return;
            }

            foreach (XmlNode childNode2 in childNode1.ChildNodes)
            {
                if (childNode2.Name == "recruit")
                {
                    bool flag = false;
                    string id1 = "";
                    string id2 = "";
                    string s = "";
                    string ID = "";
                    string str = "";
                    if (childNode2.Attributes["settlement_culture"] != null)
                    {
                        id1 = childNode2.Attributes["settlement_culture"].Value;
                    }

                    if (childNode2.Attributes["recruit_id"] != null)
                    {
                        id2 = childNode2.Attributes["recruit_id"].Value;
                    }

                    if (childNode2.Attributes["chance"] != null)
                    {
                        s = childNode2.Attributes["chance"].Value;
                    }

                    if (childNode2.Attributes["owner_faction"] != null)
                    {
                        ID = childNode2.Attributes["owner_faction"].Value;
                    }

                    if (childNode2.Attributes["is_retinue"] != null)
                    {
                        str = childNode2.Attributes["is_retinue"].Value;
                    }

                    CultureObject cultureObjectById = CEKHelpers.GetCultureObjectByID(id1);
                    if (cultureObjectById == null)
                    {
                        if (CEKCampaignBehavior.IsDebugMode)
                        {
                            InformationManager.DisplayMessage(new InformationMessage("ERROR: Could not find culture \"" + id1 + "\" at " + id2));
                        }

                        flag = true;
                    }
                    CharacterObject npcById = CEKHelpers.GetNPCByID(id2);
                    if (npcById == null)
                    {
                        if (CEKCampaignBehavior.IsDebugMode)
                        {
                            InformationManager.DisplayMessage(new InformationMessage("ERROR: Could not find character \"" + id2 + "\""));
                        }

                        flag = true;
                    }
                    IFaction kingdomById = (IFaction)CEKHelpers.GetKingdomByID(ID);
                    if (kingdomById == null && ID != "")
                    {
                        if (CEKCampaignBehavior.IsDebugMode)
                        {
                            InformationManager.DisplayMessage(new InformationMessage("ERROR: Could not find faction \"" + ID + "\" at " + id2));
                        }

                        flag = true;
                    }
                    int result;
                    if (!int.TryParse(s, out result))
                    {
                        if (CEKCampaignBehavior.IsDebugMode)
                        {
                            InformationManager.DisplayMessage(new InformationMessage("ERROR: wrong input for chance at " + id2));
                        }

                        flag = true;
                    }
                    bool isRetinue = false;
                    if (str == "true")
                    {
                        isRetinue = true;
                    }

                    if (!flag)
                    {
                        this.Recruits.Add(new RecruitData(cultureObjectById, npcById, kingdomById, result, isRetinue));
                    }
                }
            }
        }
    }
}
