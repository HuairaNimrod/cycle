using System.Collections.Generic;
using Cycle.Game.Casting;
using Cycle.Game.Services;


namespace Cycle.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            List<Actor> segments = snake.GetSegments();
            SnakeTwo snaketwo = (SnakeTwo)cast.GetFirstActor("snaketwo");
            List<Actor> segmentstwo = snaketwo.GetSegments();
            
            Actor score = cast.GetFirstActor("score");
            Actor scoretwo = cast.GetFirstActor("scoretwo");
            scoretwo.SetPosition(new Point(Constants.MAX_X -120, 0));
            List<Actor> messages = cast.GetActors("messages");
            
            _videoService.ClearBuffer();
            _videoService.DrawActors(segments);
            _videoService.DrawActors(segmentstwo);
            _videoService.DrawActor(score);
            _videoService.DrawActor(scoretwo);
            _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}