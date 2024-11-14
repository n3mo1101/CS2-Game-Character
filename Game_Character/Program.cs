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
            Warrior warrior = new Warrior("Thor", 1, 100, 0, 15, 0);
            Console.WriteLine(warrior.ToString());
            
            Console.WriteLine();
            warrior.Attack();
            warrior.Defend();

            Console.WriteLine();
            warrior.LevelUp();

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

    class Warrior : GameCharacter
    {
        private int Armor = 10;

        public Warrior(string name, int level, int health, int mana, int strength, int intelligence) 
            : base(name, level, health, mana, strength, intelligence)
        {
            Mana = 0;
            Intelligence = 0;
        }

        Random random = new Random();

        public override void Attack()
        {
            int baseDamage = Strength * 2;
            int criticalChance = random.Next(0,99);
            bool criticalHit = criticalChance < 20 ? true : false;
            int finalDamage = criticalHit ? baseDamage * 2 : baseDamage;
            
            if (criticalHit)
                Console.WriteLine($"Attack: {Name} attacks and deals {finalDamage} damage. It was a critical hit!");   
            else
                Console.WriteLine($"Attack: {Name} attacks and deals {finalDamage} damage.");
        }

        public override void Defend()
        {
            int damageReduction = Armor / 2;
            int blockChance = random.Next(0,99);
            bool blockedAttack = blockChance < 15 ? true : false;

            if (blockedAttack)
                Console.WriteLine($"Defend: {Name} defended from an incoming attack. All damage was blocked successfully!");
            else
                Console.WriteLine($"Defend: {Name} defended from an incoming attack. Damage received is reduced by {damageReduction}.");
        }

        public override void LevelUp()
        {
            Level += 1;
            Strength += 5;
            Health += 20;
            Armor += 2;

            Console.WriteLine($"{Name} has reached Level {Level}.");  
            Console.WriteLine($"Stats Increased: Strength +5, Health +20, Armor +2");
        }

        public override string ToString()
        {
            return $"[Character Info]\n" +
            $"Name: {Name}\n" +
            $"Class: Warrior\n" +
            $"Level: {Level}\n" +
            $"Health: {Health}\n" +
            $"Strength: {Strength}\n" +
            $"Armor: {Armor}";
        }
    }
}