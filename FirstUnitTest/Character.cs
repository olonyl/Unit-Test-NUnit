using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public enum Type { Elf, Ork}
    public class Character
    {
        public Type Type { get => _type; set => _type = value; }
        public string Name { get => _expected;}
        public int Health { get => _health; }
        public double Speed { get => Type == Type.Elf ? 1.7 : 1.4; }
        public bool IsDead { get => _isDead; }
        public List<string> Weaponry { get; set; } = new List<string>();
        public int Armor { get=> _armor; set=> _armor = value; }

        private string _expected;
        private int _health = 100;
        private Type _type;
        private bool _isDead = false;
        private int _armor = 50;

        public Character(Type type)
        {
            _type = type;
        }

        public Character(Type type, string expected)
        {
            _type = type;
            _expected = expected;
        }

        public void Damage(double damage)
        {
            if (damage > 1000) throw new ArgumentOutOfRangeException("The value can not be grater thatn 1000");
            _isDead = true;
        }
    }
}
