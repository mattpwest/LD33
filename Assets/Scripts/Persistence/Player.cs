
using System.Collections.Generic;

namespace Assets.Scripts.Persistence
{
    public class Player
    {
        public int CurrentLevel;
        public List<Level> Levels;

        public Player()
        {
            this.Levels = new List<Level>();
        }
    }
}
