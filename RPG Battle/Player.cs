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

        public void setup(string name, int attack, int defense, int agility)
        {
            this.name = name;
            this.attack = attack;
            this.defense = defense;
            this.agility = agility;
        }
    }
}
