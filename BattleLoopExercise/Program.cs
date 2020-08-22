using System;
using System.Security.Cryptography.X509Certificates;

namespace BattleLoopExercise
{
    class Program
    {
        
        //TO DO: ensure player and zombie take damage
        static void Main(string[] args)
        {
            // introduction text
            Console.WriteLine("Welcome to the Zombie Arena");
            Console.Write("type in:\n" + "'help': see directory\n" + "'attack': attack a zombie\n" + "'check health': check to see health\n" + "'quit': end game\n");

            int numberOfZombiesKilled = 1;

            // controls whether battle should continue
            bool isBattleOver = false;

            // here, we declare and instantiate a new player that we can use in the loop
            Player player = new Player();
            player.healthPoints = 100;
            player.playerAttack = 50;

            Zombie zombo = new Zombie();
            zombo.health = 50;
            zombo.zombieAttack = 15;

            // battle loop
            while (!isBattleOver)
            {
                // prompt the player for input
                Console.WriteLine("What would you like to do?");
                string playerInput = Console.ReadLine();

                if (playerInput == "help")
                {
                    Console.Write("type in:\n" + "'help': see directory\n" + "'attack': attack a zombie\n" + "'check health': check to see health\n" + "'quit': end game\n");
                }
                else if (playerInput == "check health")
                {
                    Console.Write("" + player.healthPoints + "\n");
                }
                else if (playerInput == "attack")
                {
                    Console.Write("You dealt " + player.playerAttack + " damage.\n");
                    zombo.health = zombo.health - player.playerAttack;
                    Console.Write("The zombie has " + zombo.health + " points of health left.\n");
                }
                else if (playerInput == "quit")
                {
                    isBattleOver = true;
                }

                if (playerInput != "help")
                {
                    Console.Write("The zombie swipes for " + zombo.zombieAttack + " damage.\n");
                    player.healthPoints = player.healthPoints - zombo.zombieAttack;
                    Console.Write("You have " + player.healthPoints + " points of health left.\n");
                }

                if (player.healthPoints <= 0 || zombo.health <= 0)
                {
                    if (player.healthPoints <= 0)
                    {
                        Console.Write("YOU DIED. (Insert Dark Souls Death sound)\n");
                        isBattleOver = true;
                    }
                    else if (zombo.health <= 0)
                    {
                        Console.Write("You won! (Insert Final Fantasy victory music)\n");
                        numberOfZombiesKilled++;
                        Console.Write("A new Zombie approaches and it looks bigger...");
                        zombo.health = 50 + (50 * numberOfZombiesKilled);
                        zombo.zombieAttack = 15 * numberOfZombiesKilled;
                        Console.Write("But you have grown stronger as well.\n");
                        player.healthPoints = 100 + (25 * numberOfZombiesKilled);
                        player.playerAttack = 50 + (15 * numberOfZombiesKilled);
                        Console.Write("Now let's begin again!");
                    }
                }
            }

            // good-bye text
            Console.WriteLine("Thanks for playing! Press ENTER to exit.");
            Console.ReadLine();

            return;
        
        }
    }

    class Player
    {
        public float healthPoints = 100;
        public float playerAttack = 50;

        // Accepts an attack with the given number of damage points
        public void TakeDamage(int damagePoints)
        {
            // TODO: given an amount of damage points, modify the player's health
        }

        // Returns the damage points dealt by this attack
        public float Attack()
        {
            float playerAttack = 50;
            return playerAttack;
        }

        public bool IsDefeated
        {
            get
            {
                // TODO: how do we know if the player has been defeated?
                return false;
            }
        }
    }

    class Zombie
    {
        public float health = 50;
        public float zombieAttack = 15;

        // Accepts an attack with the given number of damage points
        public virtual void TakeDamage(int damagePoints)
        {
            // TODO: given an amount of damage points, modify the zombie's health
        }

        // Returns the damage points dealt by this attack
        public virtual float Attack()
        {
            float zombieAttack = 70;
            return zombieAttack;
        }

        public bool IsDefeated
        {
            get
            {
                // TODO: complete this part!
                return false;
            }
        }
    }
}
