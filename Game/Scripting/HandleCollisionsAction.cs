using System;
using System.Collections.Generic;
using System.Data;
using Cycle.Game.Casting;
using Cycle.Game.Services;


namespace Cycle.Game.Scripting
{   

    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool _isGameOver = false;
        private string _message ="Game Over";
        private int countdown = 0;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (_isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGrowth(cast);
                HandleGameOver(cast);
            }
        }


        /// <summary>
        /// Updates the score and size of the snake
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleGrowth(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            SnakeTwo snaketwo = (SnakeTwo)cast.GetFirstActor("snaketwo");
            Score score = (Score)cast.GetFirstActor("score");
            ScoreTwo scoretwo = (ScoreTwo)cast.GetFirstActor("scoretwo");
            countdown = countdown +1;
            if (countdown % 30 == 0){
                snake.GrowTail(1);
                snaketwo.GrowTail(1);
                score.AddPoints(1);
                scoretwo.AddPoints(1);
            }

        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Actor head = snake.GetHead();
            List<Actor> body = snake.GetBody();

            SnakeTwo snaketwo = (SnakeTwo)cast.GetFirstActor("snaketwo");
            Actor headtwo = snaketwo.GetHead();
            List<Actor> bodytwo = snaketwo.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition())) // own collision
                {
                    _isGameOver = true;
                    _message = "Player 1 lose :(";
                }
                foreach (Actor segmenttwo in bodytwo)//snake two collision
                {
                    if (segment.GetPosition().Equals(headtwo.GetPosition()))
                        {
                            _isGameOver = true;
                            _message = "Player 2 lose :(";
                        }

                }
            }
            foreach (Actor segmenttwo in bodytwo)
            {
                if (segmenttwo.GetPosition().Equals(headtwo.GetPosition()))
                {
                    _isGameOver = true;
                    _message = "Player 2 lose :(";
                }
                foreach (Actor segment in body)//snake two collision
                {
                    if (segmenttwo.GetPosition().Equals(head.GetPosition()))
                        {
                            _isGameOver = true;
                            _message = "Player 1 lose :(";
                        }

                }
                
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (_isGameOver == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                List<Actor> segments = snake.GetSegments();
                SnakeTwo snaketwo = (SnakeTwo)cast.GetFirstActor("snaketwo");
                List<Actor> segmentsTwo = snaketwo.GetSegments();

                // create a "game over" message
                int x = (Constants.MAX_X / 2)-50;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText(_message);
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }
                foreach (Actor segment in segmentsTwo)
                {
                    segment.SetColor(Constants.WHITE);
                }

            }
        }

    }
}