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
            Warrior warrior = new Warrior("Thor", 1, 100, 15);
            Mage mage = new Mage("Merlin", 1, 80, 50, 20);

            Console.WriteLine("\t[ Character Menu ]");
            Console.WriteLine($"\n{warrior.ToString()}\n{new String('-', 30)}");   
            Console.WriteLine($"\n{mage.ToString()}\n{new String('-', 30)}");   
            
            Console.WriteLine($"\nTurn Phase - [ {warrior.Name} ]\n");
            warrior.Attack();
            warrior.Defend();
            warrior.LevelUp();

            Console.WriteLine($"\nTurn Phase - [ {mage.Name} ]\n");
            mage.Attack();
            mage.Defend();
            mage.LevelUp();

            Console.WriteLine($"\n{new String('-', 30)}");
            Console.WriteLine($"\t[ Character Menu ]");

            Console.WriteLine($"\n{warrior.ToString()}\n{new String('-', 30)}");   
            Console.WriteLine($"\n{mage.ToString()}\n{new String('-', 30)}");   

            Console.ReadKey();
        }
    }

    abstract class GameCharacter
    {
        public string Name { get; protected set; }
        private int _Level { get; set; }
        private int _Health { get; set; }
        private int _Mana { get; set; }
        private int _Strength { get; set; }
        private int _Intelligence { get; set; }

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

        public Warrior(string name, int level, int health, int strength) 
            : base(name, level, health, 0, strength, 0) { 

        }

        public override void Attack()
        {
            int baseDamage = Strength * 2;
            int criticalRate = new Random().Next(0,99);
            bool criticalHit = criticalRate < 20 ? true : false;
            int finalDamage = criticalHit ? baseDamage * 2 : baseDamage;
            
            if (criticalHit)
                Console.WriteLine($"Attack: {Name} attacks and deals {finalDamage} damage. It was a critical hit!");   
            else
                Console.WriteLine($"Attack: {Name} attacks and deals {finalDamage} damage.");
        }

        public override void Defend()
        {
            int damageReduction = Armor / 2;
            int blockRate = new Random().Next(0,99);
            bool blockedDamage = blockRate < 15 ? true : false;

            if (blockedDamage)
                Console.WriteLine($"Defend: {Name} blocked the incoming attack! All damage is negated.");
            else
                Console.WriteLine($"Defend: {Name} guards for the incoming attack. Damage received is reduced by {damageReduction}.");
        }

        public override void LevelUp()
        {
            const int STR = 5, HP = 20, DF = 2;

            Level++;
            Strength += STR;
            Health += HP;
            Armor += DF;

            Console.WriteLine($"{Name} has reached Level {Level}!");  
            Console.WriteLine($"Stats Increased: Strength +{STR}, Health +{HP}, Armor +{DF}");
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
            $"Class: Warrior\n" +
            $"\nLevel: {Level}\n" +
            $"Health: {Health}\n" +
            $"Strength: {Strength}\n" +
            $"Armor: {Armor}";
        }
    }

    class Mage : GameCharacter
    {
        private int SpellPower = 10;
        
        public Mage(string name, int level, int health, int mana, int intelligence) 
            : base(name, level, health, mana, 0, intelligence) {
            
        }

        public override void Attack()
        {
            int magicDamage = (Intelligence * 3) + SpellPower;
            int burnChance = new Random().Next(0,99);
            bool burnEffect = burnChance < 25 ? true : false;

            if (burnEffect)
                Console.WriteLine($"Attack: {Name} casts a spell and deals {magicDamage} magic damage. Additional burn effect is applied.");
            else
                Console.WriteLine($"Attack: {Name} casts a spell and deals {magicDamage} magic damage.");
        }

        public override void Defend()
        {
            int damageReduction = Mana / 4;
            int evadeChance = new Random().Next(0,99);
            bool evadeAttack = evadeChance < 20 ? true : false;

            if (evadeAttack)
                Console.WriteLine($"Defend: {Name} evades the attack and negates all incoming damage.");
            else
                Console.WriteLine($"Defend: {Name} guards for the incoming attack. Damage received is reduced by {damageReduction}.");
        }

        public override void LevelUp()
        {
            const int INT = 5, MP = 15, SP = 3;

            Level++;
            Intelligence += INT;
            Mana += MP;
            SpellPower += SP;

            Console.WriteLine($"{Name} has reached Level {Level}!");  
            Console.WriteLine($"Stats Increased: Intelligence +{INT}, Mana +{MP}, Spell Power +{SP}");
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
            $"Class: Mage\n" +
            $"\nLevel: {Level}\n" +
            $"Health: {Health}\n" +
            $"Mana: {Mana}\n" +
            $"Intelligence: {Intelligence}\n" +
            $"Spell Power: {SpellPower}";
        }
    }
}