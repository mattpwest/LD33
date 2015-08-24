using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Persistence
{
    public class Player
    {
        public int CurrentLevel
        {
            get
            {
                return this.Levels.Max(l => l.LevelNumber);
            }
        }
        public List<Level> Levels;

        public Player()
        {
            this.Levels = new List<Level>();
        }

        public void UpdateLevelStats(int levelNumber, int terrorRating)
        {
            var levelToUpdate = this.Levels.SingleOrDefault(x => x.LevelNumber == levelNumber);

            if(levelToUpdate == null)
            {
                this.Levels.Add(new Level
                                {
                                    LevelNumber = levelNumber,
                                    TerrorRating = terrorRating
                                });
                return;
            }

            if (levelToUpdate.TerrorRating > levelNumber)
            {
                return;
            }

            levelToUpdate.TerrorRating = levelNumber;
        }
    }
}
