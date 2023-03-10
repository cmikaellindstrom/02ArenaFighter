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
        }
    }
}
