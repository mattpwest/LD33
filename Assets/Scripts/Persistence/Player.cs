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
                if (Levels.ToArray().Length == 0) {
                    return 0;
                }

                for (int i = Levels.ToArray().Length - 1; i >= 0; i--) {
                    if (Levels[i].TerrorRating > 0) {
                        return i + 1;
                    }
                }

                return 0;
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
