using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Battle
{
    class Player
    {
        private int hp;
        private string name;
        private int attack;
        private int defense;
        private int agility;
        Random random = new Random();

        public void setup(string name, int attack, int defense, int agility)
        {
            this.name = name;
            this.attack = attack;
            this.defense = defense;
            this.agility = agility;
            hp = 100;
        }
        public void display()
        {
            Console.WriteLine(" Name is " + name);
            Console.WriteLine("- current hp: " + hp);
            Console.WriteLine("- attack is: " + attack + " Defense is: " + defense + " and agility is: " + agility );
        }

        public int getAttackDamage()
        {
            int damage = random.Next(attack-3, attack+3);
            return damage;
        }
        public void getHit(int damage)
        {
            int damageTaken;
            damageTaken = damage - random.Next(defense - 3, defense + 3);
            if (damageTaken < 0)
            {
                damageTaken = 0;
            }
            hp = hp - damageTaken;
            Console.WriteLine( name + " has taken " + damageTaken + " damage.");
            Console.WriteLine("\n");

        }

        public int getDefense()
        {
            int defendedDamage = random.Next(defense-3, defense);
            return defendedDamage;
        }
        public void doTheDefend(int defendedDamage)
        {
            int damageReduced = defendedDamage;
            if (damageReduced <0)
            {
                damageReduced = 0;
            }
            Console.WriteLine( name + " defended for " + damageReduced);
            hp = hp + damageReduced;
            if (hp >100)
            {
                hp = 100;
            }
            Console.WriteLine("\n");
        }
        public string getName()
        {
            Console.Write(name);
            return name;
        }
    }
}
