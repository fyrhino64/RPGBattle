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
            Console.WriteLine("Name is" + name);
            Console.WriteLine("- current hp is " + hp);
            Console.WriteLine("- attack is: " + attack + " Your Defense is: " + defense + " and your agility is: " + agility );
        }

        public int getAttackDamage()
        {
            int damage = random.Next(attack-3, attack+3);
            return damage;
        }
        public void receiveAttackDamage(int damage)
        {
            int damageTaken;
            damageTaken = damage - random.Next(defense - 3, defense + 3);
            if (damageTaken < 0)
            {
                damageTaken = 0;
            }
            hp = hp - damageTaken;
            Console.WriteLine( name + " has taken " + damageTaken + " damage.");

        }
    }
}
