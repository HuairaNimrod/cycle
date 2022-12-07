using System;


namespace Cycle.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class ScoreTwo : Actor
    {
        private int _points = 0;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public ScoreTwo()
        {
            AddPoints(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this._points += points;
            SetText($"Player 2 : {this._points}");
        }
    }
}