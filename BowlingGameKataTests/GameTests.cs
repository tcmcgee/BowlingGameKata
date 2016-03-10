using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGameKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void SampleTest()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void CreateGameTest()
        {
            Game game = new Game();

            Assert.AreEqual(0, game.Score());
        }

        [TestMethod()]
        public void noPinsGameTest()
        {
            Game game = new Game();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(0);
            }
            Assert.AreEqual(0, game.Score());
        }

        [TestMethod()]
        public void SinglePinGameTest()
        {
            Game game = new Game();
            game.Roll(1);
            for (int i = 0; i < 19; i++)
            {
                game.Roll(0);
            }
            Assert.AreEqual(1, game.Score());

        }

        [TestMethod()]
        public void SingleStrikeGameTest()
        {
            Game game = new Game();

            game.Roll(10);
            for (int i = 0; i < 18; i++)
            {
                game.Roll(0);
            }

            Assert.AreEqual(10, game.Score());
        }

        [TestMethod()]
        public void MiddleGamePinTest()
        {
            Game game = new Game();

            for (int i = 0; i < 10; i++)
            {
                game.Roll(0);
            }
            game.Roll(7);
            for (int i = 0; i < 9; i++)
            {
                game.Roll(0);
            }

            Assert.AreEqual(7, game.Score());
        }

        [TestMethod()]
        public void IsStrikeTest()
        {
            Game game = new Game();
            game.Roll(10);

            Assert.AreEqual(true, game.IsStrike(0));
        }

        [TestMethod()]
        public void IsNotStrikeTest()
        {
            Game game = new Game();

            Assert.AreEqual(false, game.IsStrike(6));
        }

        [TestMethod()]
        public void IsSpareTest()
        {
            Game game = new Game();
            game.Roll(7);
            game.Roll(3);

            Assert.AreEqual(true, game.IsSpare(0));
        }

        [TestMethod()]
        public void IsNotSpareTest()
        {
            Game game = new Game();
            game.Roll(1);
            game.Roll(3);

            Assert.AreEqual(false, game.IsSpare(0));
        }

        [TestMethod()]
        public void SpareRolledTests()
        {
            Game game = new Game();

            game.Roll(7);
            game.Roll(3);
            game.Roll(2);
            game.Roll(1);
            Assert.AreEqual(15, game.Score());
        }
        [TestMethod()]
        public void StrikeRolledTest()
        {
            Game game = new Game();
            game.Roll(10);
            game.Roll(1);
            game.Roll(5);
            Assert.AreEqual(22, game.Score());
        }
        [TestMethod()]
        public void TwelveStrikeGameTest()
        {
            Game game = new Game();
            for (int i = 0; i < 12; i++)
            {
                game.Roll(10);
            }
            Assert.AreEqual(300, game.Score());
        }

        public void TenSpareGameTest()
        {
            Game game = new Game();
            for (int i = 0; i < 21; i++)
            {
                game.Roll(5);
            }
            Assert.AreEqual(150, game.Score());
        }


        [TestMethod()]
        public void AlmostSpareGameTest()
        {
            Game game = new Game();
            for (int i = 0; i < 10; i++)
            {
                game.Roll(9);
                game.Roll(0);
            }
            Assert.AreEqual(90, game.Score());
        }

    }
}