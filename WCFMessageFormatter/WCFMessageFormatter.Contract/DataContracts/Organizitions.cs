using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Xml;

namespace WCFMessageFormatter.Contracts.DataContracts
{
    [DataContract]
    [Serializable]
    [XmlRoot(Namespace = "WWW.REST")]
    [JsonObject(MemberSerialization.OptIn)]
    public class Organizitions
    {
        [DataMember]
        [XmlAttribute(AttributeName = "res_link")]
        [JsonProperty("@ReponseLink")]
        public string ReponseLink { get; set; }

        //[DataMember]
        [XmlElement]
        [JsonProperty]
        public List<string> Organizition { get; set; }

        [DataMember]
        [XmlElement]
        [JsonProperty]
        public TankCollection<Navigation<string>> NavigationGenericCollection { get; set; }

        [DataMember]
        [XmlElement(ElementName = "TankCollection",Namespace = "WWW.REST")]
        [JsonProperty]
        public TankCollection<Tank> TankCollection { get; set; }

        [DataMember]
        [XmlElement]
        [JsonProperty]
        public byte[] TankBytes { get; set; }

        [DataMember]
        [XmlElement]
        [JsonProperty]
        public Tank OrganizationTank { get; set; }
    }
}
