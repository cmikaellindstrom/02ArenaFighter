using System;

namespace ArenaFighter
{
    /// <summary>
    /// The round function class
    /// </summary>
    internal class Round
    {
        
        // Score for the result of this round
        enum Score
        {
            Lost = 3,
            Tied = 5,
            Win = 20
        }

        // A factor for the damage on charcter health at lost of round
        const int DAMAGE = 2;
        
        /// <summary>
        /// Create a new round in the battle
        /// </summary>
        /// <param name="battle">The battle the new round are in</param>
        internal Round(Battle battle)
        {
            // Variables for the round
            int t1, t2, realdamage;
            string message = "", text = "";

            // Tell the user that new round are started
            Console.WriteLine("A new round are started.");

            // Calculate round value for each character
            t1 = battle.Player.Strength + Program.random.Next(1, 6);
            t2 = battle.Opponent.Strength + Program.random.Next(1, 6);

            // Add text to message
            message = $"{battle.Player.Name} hit {battle.Opponent.Name} and " +
                $"{battle.Opponent.Name} hit {battle.Player.Name}. ";

            // Check which character win this round
            if(t1 == t2)
            {
                // The result of this round were that nobody win the round
                text = "The result of this round were that nobody win the round.";
                message += text;
                Console.WriteLine(text);

                // Add value to character score
                battle.Player.Score += (int)Score.Tied;
                battle.Opponent.Score += (int)Score.Tied;
            }
            else if(t1 > t2)
            {
                // The result of this round were that the player win
                char answer; // The answer the user give 
                realdamage = t1 * DAMAGE;

                // Add text to message and change opponents health
                text = $"The result of this round were that {battle.Player.Name} win and give {realdamage} damage on {battle.Opponent.Name} health.";
                message += text;
                battle.Opponent.Health -= realdamage;

                // Show the result of this round for the user and ask if the user want give up
                Console.WriteLine(text + " Want you give up? Y/N");
                answer = Console.ReadKey().KeyChar;

                // Check the user answer
                if(answer.Equals('y'))
                    battle.Player.IsRetired = true;

                // Add value to character score
                battle.Player.Score += (int)Score.Win;
                battle.Opponent.Score += (int)Score.Lost;
                
            }
            else
            {
                // The result of this round were that the opponent win
                realdamage = t2 * DAMAGE; // Calculate the damage opponent gave the player character health

                // Show a message to the user and change the player health
                text = $"{battle.Opponent.Name} win this round and give {realdamage} damage on {battle.Player.Name} health";
                Console.WriteLine(text);
                message += text;
                battle.Player.Health -= realdamage;

                // Add value to the character score
                battle.Player.Score += (int)Score.Lost;
                battle.Opponent.Score += (int)Score.Win;
            }
            battle.WriteToLog(message);
        }
    }
}
