using System;
using System.Collections.Generic;

namespace ArenaFighter
{
    /// <summary>
    /// The class for the battle in this game
    /// </summary>
    internal class Battle
    {
        // Properties for character informationn for this battle
        internal Character Player { get; set; }
        internal Character Opponent { get; set; }

        // A private list-item for the battle log
        private IList<string> _log;

        /// <summary>
        /// Create a new battle with two part
        /// </summary>
        /// <param name="player">The character for the player</param>
        /// <param name="opponent">The character for the opponent</param>
        internal Battle(Character player, Character opponent)
        {
            // Set referens for this battle character
            Player = player;
            Opponent = opponent;

            // Create a new battle-log
            _log = new List<string>();

            // Start the battle itself
            GoBattle();
        }
        /// <summary>
        /// The battle itself
        /// </summary>
        private void GoBattle()
        {
            while(Player.IsAlived == true && Player.IsRetired == false && Opponent.IsAlived == true)
            {
                Round round = new Round(this);
                if(Player.Health < 1)
                    Player.IsAlived = false;
                if(Opponent.Health < 1)
                    Opponent.IsAlived= false;
            }
            // Write the score to the battle log then show both that battle are ended and the battle log in console window
            WriteToLog($"The score for the player are {Player.Score} and for opponent are{Opponent.Score}");
            Console.WriteLine("********** The battle are ended! ***********");
            ShowBattleLog();
        }
        /// <summary>
        /// Write a message to the battle log
        /// </summary>
        /// <param name="message">The message to battle-log</param>
        internal void WriteToLog(string message) => _log.Add(message);
        /// <summary>
        /// Show the the battle in console window
        /// </summary>
        private void ShowBattleLog()
        {
            Console.WriteLine("********** Battle log **********");
            // Write the message from the battle log
            foreach(var item in _log) 
            {
                Console.WriteLine(item);
            }
        }

    }
}
