using System;
using System.Xml.Serialization;

namespace T10_Serialization
{
    public enum Genre
    {
        [XmlEnum(Name = "Computer")]
        Computer,
        [XmlEnum(Name = "Fantasy")]
        Fantasy,
        [XmlEnum(Name = "Romance")]
        Romance,
        [XmlEnum(Name = "Horror")]
        Horror,
        [XmlEnum(Name = "Science Fiction")]
        ScienceFiction
    }

    [XmlType("catalog", Namespace = "http://library.by/catalog")]
    [XmlRoot(Namespace = "http://library.by/catalog", IsNullable = false)]
    public class Catalog
    {
        [XmlElement("book")]
        public CatalogBook[] Book { get; set; }

        [XmlAttribute("date", DataType = "date")]
        public DateTime Date { get; set; }
    }

    [XmlType("book", Namespace = "http://library.by/catalog")]
    public class CatalogBook
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("isbn")]
        public string Isbn { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("genre")]
        public Genre Genre { get; set; }

        [XmlElement("publisher")]
        public string Publisher { get; set; }

        [XmlElement("publish_date", DataType = "date")]
        public DateTime PublishDate { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("registration_date", DataType = "date")]
        public DateTime RegistrationDate { get; set; }
    }
}