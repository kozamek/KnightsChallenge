using MongoDB.Bson.Serialization.Attributes;

namespace KnightsAPI.Entities
{
    public class Knight
    {
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Birthday { get; set; }
        public List<Weapon> Weapons { get; set; }
        public Attribute Attributes { get; set; }
        public string KeyAttribute { get; set; }
        public bool Hero  { get; set; }
    }
}
