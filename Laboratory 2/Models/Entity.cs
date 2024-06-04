using System;

namespace Laboratory_2.Models
{
    public class Entity
    {
        Random random = new Random();
        public int Key { get; set; }

        public Entity()
        {
            int key = random.Next(1000, 999999999);
            Key = key;
        }
    }
}
