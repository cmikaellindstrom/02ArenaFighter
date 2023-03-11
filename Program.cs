using System;

namespace ArenaFighter
{
    /// <summary>
    /// The start class for this program/game
    /// </summary>
    internal class Program
    {
        // Name of this program/game
        const string ProgramName = "The Arena Fighter 2000";

        // A array of names for opponent character
        static string[] names = new string[6] {"David" , "Valter", "Erik", "Paul", "Gustav", "Karl"};

        // Instans that handle creating of randomly values
        internal static Random random = new Random();
        
        /// <summary>
        /// The start point of this program/game
        /// </summary>
        /// <param name="args">Anything</param>
        static void Main(string[] args)
        {
            // Welcome the user to this program/game
            Console.WriteLine($"Welcome to {ProgramName}!");

            // Make a pause in this program/game
            Console.ReadKey();

            // Ask the user about a name of their character then create a character
            Console.Write("Write a name of your character: ");
            string playerName = Console.ReadLine();

            Character player = new Character(playerName);

            while(player.IsAlived == true && player.IsRetired == false)
            {
                // Character a randomly opponent to the player
                Character opponent = new Character(names[random.Next(1, names.Length)]);

                // Create a new Battle
                Battle battle = new Battle(player, opponent);

                // Make a pause in this program/game
                Console.ReadKey();
            }
        }
    }
}
