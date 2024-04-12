using KnightsAPI.Entities;
using MongoDB.Driver;

namespace KnightsAPI.Data
{
    public class KnightsSeed
    {
        public static void SeedData(IMongoCollection<Knight> knightsCollection)
        {
            try
            {
                bool existKnight = knightsCollection.Find(k => true).Any();

                if (!existKnight)
                    knightsCollection.InsertManyAsync(GetMyKnights());
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            
        }

        private static IEnumerable<Knight> GetMyKnights()
        {
            return new List<Knight>()
            {
                new Knight()
                {
                    Id = "1",
                    Name = "Caique",
                    Nickname = "CaiqueBurssed",
                    Birthday = "17/09/1997",
                    Weapons = new List<Weapon>()
                    {
                        new Weapon()
                        {
                            Name = "sword",
                            Mod = 3,
                            Attr = "strength",
                            Equipped = true
                        },
                    },
                    Attributes = new Attributes()
                    {
                        Strength = 10,
                        Dexterity = 8,
                        Constitution = 12,
                        Intelligence = 15,
                        Wisdom = 14,
                        Charisma = 11
                    },
                    KeyAttribute = "intelligence",
                    Hero = false
                },
            };
        }
    }
}
