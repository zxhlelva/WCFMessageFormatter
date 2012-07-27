using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WCFMessageFormatter.Contracts.DataContracts
{
    [DataContract]
    [Serializable]
    [XmlRoot(IsNullable = false)]
    [JsonObject(MemberSerialization.OptIn)]
    public class Tank
    {
        [DataMember]
        [XmlElement(Order = 1)]
        [JsonProperty]
        public int Speed { get; set; }

        [XmlElement(Order = 2)]
        [DataMember]
        [JsonProperty]
        public int Weight { get; set; }

        [XmlAttribute("CanDive")]
        [DataMember]
        [JsonProperty("@CanDive")]
        public bool CanDive { get; set; }

        [XmlElement(ElementName = "TankCollection", Order = 3)]
        [DataMember(Name = "TankCollection")]
        [JsonProperty]
        public TankCollection<string> TankCollection { get; set; }

        [XmlIgnore]
        public List<string> History { get; set; }

        [XmlElement(ElementName = "Name", Order = 4)]
        [DataMember(IsRequired = false)]
        [JsonProperty]
        public string Name { get; set; }
    }

    //[DataContract]
    [Serializable]
    [XmlRoot(Namespace = "WWW.REST", IsNullable = false)]
    [JsonObject(MemberSerialization.OptIn)]
    public class TankCollection<T> : IList<T>, IXmlSerializable
    {
        //[XmlAttribute("CollectionName")]
        [XmlElement(IsNullable = true)]
        [DataMember]
        [JsonProperty("@CollectionName")]
        public string CollectionName { get; set; }

        private List<T> _items;

        [JsonProperty]
        [XmlArray("ItemArray")]
        [XmlArrayItem("Item", NestingLevel = 1)]
        public List<T> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public TankCollection()
        {
            this._items = new List<T>();
        }

        public int IndexOf(T item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        public T this[int index]
        {
            get { return this._items[index]; }
            set { this._items[index] = value; }
        }

        public void Add(T item)
        {
            this._items.Add(item);
        }

        public void Clear()
        {
            this._items.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this._items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return this._items.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this._items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._items.GetEnumerator();
        }

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof (T));
            reader.Read();
            while (reader.NodeType != XmlNodeType.EndElement)
            {

                // YES it uses the XmlSerializer to serialize each item!
                // It is so simple.
                T item = (T) serializer.Deserialize(reader);
                if (item != null) // May be I have to throw here ?
                    this.Add(item);
            }
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            Type type = this.GetType();
            object[] objArray = type.GetCustomAttributes(typeof (XmlRootAttribute), false);
            XmlRootAttribute obj = objArray[0] as XmlRootAttribute;
            writer.WriteElementString("CollectionName", "WWW.REST", this.CollectionName);
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(obj.ElementName);
            xmlRootAttribute.Namespace = "WWW.REST";
            XmlSerializer serializer = new XmlSerializer(typeof (T), xmlRootAttribute);
            foreach (var item in this._items)
            {
                serializer.Serialize(writer, item);
            }
        }

        #endregion
    }

    [DataContract(Name = "{0}")]
    [Serializable]
    [XmlRoot("GenericNavigation", Namespace = "WWW.TEST", IsNullable = false)]
    [JsonObject]
    public class Navigation<T>
    {
        public T Obj { get; set; }
    }
}
