using System;

namespace RPG_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            Player human = new Player();
            Player npc = new Player();
            Random random = new Random();

            string classChoice;
            string tempName;
            int tempAttack = 0;
            int tempDefense = 0;
            int tempAgility = 0;
            int npcChoice = random.Next(1, 4);
            int npcAction;
            Console.WriteLine("What is your name?");
            tempName = Console.ReadLine();
            Console.WriteLine("Would you rather be a Knight (k), Rogue (r), or Tank (t)?");
            classChoice = Console.ReadLine();
            if (classChoice == "k")
            {
                tempAttack = 10;
                tempDefense = 5;
                tempAgility = 5;
            }
            else if (classChoice == "r")
            {
                tempAttack = 5;
                tempDefense = 5;
                tempAgility = 10;
            }
            else if (classChoice == "t")
            {
                tempAttack = 5;
                tempDefense = 10;
                tempAgility = 5;
            }
            human.setup(tempName, tempAttack, tempDefense, tempAgility);
            if (npcChoice == 1)
            {
                tempAttack = 10;
                tempDefense = 5;
                tempAgility = 5;
            }
            else if (npcChoice == 2)
            {
                tempAttack = 5;
                tempDefense = 5;
                tempAgility = 10;
            }
            else if (npcChoice == 3)
            {
                tempAttack = 5;
                tempDefense = 10;
                tempAgility = 5;
            }
            tempName = "George";
            npc.setup(tempName, tempAttack, tempDefense, tempAgility);

            bool done = false;
            while (!done)
            {
                // Display stats
                human.display();
                npc.display();
                // Get human turn
                Console.WriteLine("\n");
                Console.WriteLine("Do you want to attack (a), or defend (d)?");
                classChoice = Console.ReadLine();
                int npcTurn = random.Next(1, 3);

                if (classChoice == "a")
                {
                    Console.WriteLine("You attack! ");
                    int humanDamage = human.getAttackDamage();
                    npc.getHit(humanDamage);
                   
                }
                else if ((classChoice == "d") && (npcTurn>1))
                {
                    int humanDefended = human.getDefense();
                    human.doTheDefend(humanDefended);
                }
                // get npc turn

                if (npcTurn == 1)
                {
                    npc.getName();
                    Console.Write(" will attack! ");
                    int npcDamage = npc.getAttackDamage();
                    human.getHit(npcDamage);
                }
                else
                {
                    npc.getName();
                    Console.Write(" will defend!");
                    int npcDefended = npc.getDefense();
                    npc.doTheDefend(npcDefended);
                }
                
                
                // Check for deaths
            }
        }

    }
}
