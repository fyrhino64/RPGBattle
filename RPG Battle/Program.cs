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
                System.Threading.Thread.Sleep(400);
                Console.WriteLine("\n");
                // Display stats
                human.display();
                System.Threading.Thread.Sleep(200);
                Console.WriteLine("\n");
                npc.display();
                System.Threading.Thread.Sleep(500);
                // Get human turn
                Console.WriteLine("\n");
                Console.WriteLine("Do you want to attack (a), or defend (d)?");
                classChoice = Console.ReadLine();
                // get npc turn, if turn = 1, NPC attacks, if 2 NPC Defends
                int npcTurn = random.Next(1, 3);
                // complete turns dependent on choices players made
                if (getTurnOrder(npc.agility, human.agility, human.name, npc.name))
                {
                    System.Threading.Thread.Sleep(500);
                    if ((npcTurn == 1) && (classChoice == "a"))
                    {
                        Console.WriteLine("You attack! ");
                        humanDamage = human.getAttackDamage();
                        System.Threading.Thread.Sleep(400);
                        if (npc.didPlayerDodge(npc.agility))
                        {
                            npc.getName();
                            Console.WriteLine(" dodged!");
                        }
                        else
                        {
                            npc.getHit(humanDamage);
                            if (npc.checkIfDead())
                            {
                                done = true;
                                break;
                            }
                        }
                        System.Threading.Thread.Sleep(400);
                        npc.getName();
                        Console.WriteLine(" will attack! ");
                        npcDamage = npc.getAttackDamage();
                        if (human.didPlayerDodge(human.agility))
                        {
                            human.getName();
                            Console.Write(" dodged!");
                        }
                        else
                        {
                            human.getHit(npcDamage);
                            human.checkIfDead();
                            if (human.checkIfDead())
                            {
                                done = true;
                                break;
                            }
                        }

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
                        human.defendAgainstAttack(humanDefended, npcDamage);
                        npc.getName();
                        Console.WriteLine(" will attack for " + npcDamage);
                        if (human.checkIfDead())
                        {
                            done = true;
                            break;
                        }
                    }
                    else if ((npcTurn == 2) && (classChoice == "a"))
                    {
                        human.getName();
                        Console.WriteLine(" will attack for " + humanDamage);
                        npc.defendAgainstAttack(npcDefended, humanDamage);
                        if (npc.checkIfDead())
                        {
                            done = true;
                            break;
                        }
                    }
                }

                else
                {
                    if ((npcTurn == 1) && (classChoice == "a"))
                    {
                        npc.getName();
                        Console.WriteLine(" will attack! ");
                        humanDamage = human.getAttackDamage();
                        npcDamage = npc.getAttackDamage();
                        human.getHit(npcDamage);
                        if (human.checkIfDead())
                        {
                            done = true;
                            break;
                        }
                        Console.WriteLine("You attack! ");
                        npc.getHit(humanDamage);
                        if (npc.checkIfDead())
                        {
                            done = true;
                            break;
                        }
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
                        Console.WriteLine(" will attack!");
                        if (human.didPlayerDodge(human.agility))
                        {
                            human.getName();
                            Console.WriteLine(" dodged!");
                        }
                        else
                        {
                            npc.getName();
                            Console.WriteLine(" attacks for " + npcDamage);
                            human.defendAgainstAttack(humanDefended, npcDamage);
                            if (human.checkIfDead())
                            {
                                done = true;
                                break;
                            }
                        }
                    }
                    else if ((npcTurn == 2) && (classChoice == "a"))
                    {
                        human.getName();
                        Console.WriteLine(" will attack!");
                        if (npc.didPlayerDodge(npc.agility))
                        {
                            npc.getName();
                            Console.WriteLine(" dodged!");
                        }
                        else
                        {
                            human.getName();
                            Console.WriteLine(" attacks for " + humanDamage);
                            npc.defendAgainstAttack(npcDefended, humanDamage);
                            if (npc.checkIfDead())
                            {
                                done = true;
                                break;
                            }
                        }
                    }
                }
            }
            Console.ResetColor();
            Console.WriteLine("Please hit any key to end the game");
            Console.ReadKey();
        }
        //if human player's agility is greater than or equal to the npc player, the player will go first
        static bool getTurnOrder(int npcAgility, int humanAgility, string humanName, string npcName)
        {
            if (npcAgility <= humanAgility)
            {
                Console.WriteLine("The player will go first");
                return true;

            }
            else
            {
                Console.WriteLine(npcName + " will go first");
                return false;
            }
        }
    }
}
