using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class Game
    {
        public int[] rolls = new int[21];
        private int rollsIndex = 0;

        public Game() 
        {
        }

		public void Roll(int pins)
        {
            rolls[rollsIndex++] = pins;
		}


        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += strikeBonus(frameIndex);
                    frameIndex += 1;
                }
                else if (IsSpare(frameIndex))
                {
                    score += spareBonus(frameIndex);
                    frameIndex += 2;
                }
                else {
                    score += sumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
        }

        private int sumOfBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int spareBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 2];
        }

        private int strikeBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        public bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        public bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        public static void Main(string[] args)
        {

        }

    }
}
