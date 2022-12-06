using System.Collections.Generic;
using Cycle.Game.Casting;


namespace Cycle.Game.Scripting
{
    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of MoveActorsAction is to move all the actors.
    /// </para>
    /// </summary>

    public class MoveActorsAction : Action
    {

        /// <summary>
        /// Constructs a new instance of MoveActorsAction.
        /// </summary>
        public MoveActorsAction()
        {

        }

         public void Execute(Cast cast, Script script)
        {
            // a) get all the actors from the cast
            List<Actor> actors = new List<Actor>();
            actors = cast.GetAllActors();

            // b) loop through all the actors
            foreach(Actor actor in actors){
            // c) call the MoveNext() method on each actor.
                actor.MoveNext();
            }

        }

    } 

}