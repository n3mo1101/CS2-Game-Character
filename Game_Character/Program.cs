using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_GCH
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }

    abstract class GameCharacter
    {
        public string Name { get; protected set; }

        private int _Level { get; set; }
        public int Level
        {
            get => _Level;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Error: Character Level cannot be negative");
                _Level = value;
            }
        }
        
        private int _Health { get; set; }
        public int Health
        {
            get => _Health;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Error: Character Health cannot be negative");
                _Health = value;
            }
        }

        private int _Mana { get; set; }
        public int Mana
        {
            get => _Mana;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Error: Character Mana cannot be negative");
                _Mana = value;
            }
        }

        private int _Strength { get; set; }
        public int Strength
        {
            get => _Strength;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Error: Character Strength cannot be negative");
                _Strength = value;
            }
        }

        private int _Intelligence { get; set; }
        public int Intelligence
        {
            get => _Intelligence;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Error: Character Intelligence cannot be negative");
                _Intelligence = value;
            }
        }

        public GameCharacter(string name, int level, int health, int mana, int strength, int intelligence)
        {
            Name = name;
            Level = level;
            Health = health;
            Mana = mana;
            Strength = strength;
            Intelligence = intelligence;
        }

        public abstract void Attack();
        public abstract void Defend();
        public abstract void LevelUp();
    }
}