namespace ArenaFighter
{
    /// <summary>
    /// The class for information about Character
    /// </summary>
    internal class Character
    {
        // Some properites for the character
        internal string Name { get; set; }
        internal int Strength { get; set; }
        internal int Health { get; set; }

        internal int Score { get; set; }
        internal bool IsAlived { get; set; }
        internal bool IsRetired { get; set; }

        /// <summary>
        /// Create a new character with some start values
        /// </summary>
        /// <param name="name">The name of the new character</param>
        public Character(string name) 
        {
            // Set the character name and set their strength, health randomly
            Name = name;
            Strength = Program.random.Next(1,6);
            Health = Program.random.Next(1,100);

            // Set the character for the character to zero
            Score = 0;

            // Set the character IsAlived to true and IsRetired to false
            IsAlived = true;
            IsRetired = false;
        }
    }
}
