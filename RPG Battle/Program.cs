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
            int humanDefended = 0;
            int npcDefended = 0;
            int npcDamage = 0;
            int humanDamage = 0;
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
                Console.WriteLine("\n");
                // Display stats
                human.display();
                npc.display();
                // Get human turn
                Console.WriteLine("\n");
                Console.WriteLine("Do you want to attack (a), or defend (d)?");
                classChoice = Console.ReadLine();
                // get npc turn
                int npcTurn = random.Next(1, 3);
                // complete turns dependent on choices players made
                if ((npcTurn == 1) && (classChoice == "a"))
                {
                    Console.WriteLine("You attack! ");
                    humanDamage = human.getAttackDamage();
                    npc.getName();
                    Console.WriteLine(" will attack! ");
                    npcDamage = npc.getAttackDamage();
                    human.getHit(npcDamage);
                    npc.getHit(humanDamage);
                }
                else if ((npcTurn == 2) && (classChoice == "d"))
                {
                    humanDefended = human.getDefense();
                    human.doTheDefend(humanDefended);
                    npc.getName();
                    Console.WriteLine(" will defend!");
                    npcDefended = npc.getDefense();
                    npc.doTheDefend(npcDefended);
                }
                else if ((npcTurn == 1) && (classChoice == "d"))
                {
                    npc.getName();
                    Console.WriteLine(" will attack for " + npcDamage);
                    human.defendAgainstAttack(humanDefended, npcDamage);
                }
                else if ((npcTurn ==2) && (classChoice == "a"))
                {
                    human.getName();
                    Console.WriteLine(" will attack for " + humanDamage);
                    npc.defendAgainstAttack(npcDefended, humanDamage);
                }
                // Check for deaths
                if (human.checkIfDead())
                {
                    done = true;
                    break;
                }
                if (npc.checkIfDead())
                {
                    done = true;
                    break;
                }
                
            }
            Console.ResetColor();
            Console.WriteLine("Please hit any key to end the game");
            Console.ReadKey();
        }

    }
}
