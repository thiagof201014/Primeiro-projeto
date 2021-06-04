using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulasCSharp
{
    class Program
    {
        // Attacks list
        enum attack { VerticalStrike = 1, HorizontalStrike = 2 }
        enum slimeAttack {Regeneration = 2, SlimeThrow = 3}
        

        static void Main(string[] args)
        {
            //Variables declaration
            int characterHP = 10;
            int slimeHP = 4;
            int attackChoice = 0;
            bool playerDefense = false;
            int[] dammage = { 3, 2 };

            //Game
            while(characterHP > 0 && slimeHP > 0)
            {
                playerDefense = false;

                //Character actions
                Console.Write("What do you want to do? \n1- Attack\n2- Defend\n\nYour choice: ");
                int choice = int.Parse(Console.ReadLine());

                //Actions
                switch (choice)
                {
                    //Attack
                    case 1:
                        Console.Write("\nWhich attack do you want to use? \n1- " + attack.VerticalStrike
                            + "\n2- " + attack.HorizontalStrike + "\n\nYour choice: ");
                        attackChoice = int.Parse(Console.ReadLine());

                        if (attackChoice == 1 || attackChoice == 2)
                        {
                            slimeHP -= dammage[attackChoice - 1];
                            Console.WriteLine("\nYou used " + (attack)attackChoice + " and did " 
                                + dammage[attackChoice - 1]  + " of damage.\nThe slime is now with "
                                + slimeHP + " HP");
                            Console.ReadLine();
                        }

                        break;

                    //Defense
                    case 2:
                        playerDefense = true;
                        Console.WriteLine("\nYou are now defending!");
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("\nInvalid action!");
                        Console.ReadLine();
                        goto case 2;

                        
                }
                //Slime actions
                if (slimeHP > 0)
                {
                    Random slimeAttack = new Random();
                    int slimeAttackChoice = slimeAttack.Next(1, 11);
                    if (slimeAttackChoice <= 5)
                    {
                        slimeHP += 2;
                        Console.WriteLine("The slime used Regeneration and restored 2 of HP. The slime is now with " 
                            + slimeHP + " HP");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("The slime used Slime Throw ");
                        //Player deffending?
                        if (playerDefense == true)
                        {
                            Console.WriteLine("but you are defending!");
                            Console.ReadLine();
                        }
                        else
                        {
                            characterHP -= 3;
                            Console.WriteLine("and did 3 of dammage. Your HP now is " + characterHP);
                            Console.ReadLine();
                        }
                    }
                }
                
            }
            //End of game
            if (slimeHP <= 0)
            {
                Console.WriteLine("You killed the slime!");
                Console.ReadLine();
            }
            else if (characterHP <= 0)
            {
                Console.WriteLine("You died!");
                Console.ReadLine();
            }    
            
        }
    }
}
