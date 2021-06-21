namespace Kata.Tests
{
    using System.Collections.Generic;
    using Katas.BattleshipsKata;
    using NUnit.Framework;

    public class BattleShipsShould
    {
        [Test]
        public void AllowPlayerOneToAddShipsToBoard()
        {
            var expectedResult = "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\r\n   " +
                                          "0|   |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "1|   |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "2|   |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "3|   |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "4|   |   |   |   |   |   |   |   | c |   |\r\n   " +
                                          "5|   |   |   |   |   |   |   |   | c |   |\r\n   " +
                                          "6|   |   |   |   |   |   |   |   | c |   |\r\n   " +
                                          "7|   |   |   |   |   | d |   |   | c |   |\r\n   " +
                                          "8|   |   |   |   |   | d |   |   |   |   |\r\n   " +
                                          "9|   |   |   |   |   | d |   |   |   | g |";

            var game = new BattleShips();

            var player1BattleShips = new List<BattleShip>
            {
                new Carrier()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 8, YPosition = 4},
                        new Location() {XPositionn = 8, YPosition = 5},
                        new Location() {XPositionn = 8, YPosition = 6},
                        new Location() {XPositionn = 8, YPosition = 7}
                    }
                },
                new Destroyer()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 5, YPosition = 7},
                        new Location() {XPositionn = 5, YPosition = 8},
                        new Location() {XPositionn = 5, YPosition = 9}
                    }
                },
                new Gunship()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 9, YPosition = 9}
                    }
                },
            };

            var player1 = new Player(player1BattleShips);

            game.AddPlayer(player1);

            game.Start();

            Assert.AreEqual(expectedResult, game.Print());
        }

        [Test]
        public void AllowPlayerOneAndPlayerTwoToAddShipsToBoard()
        {
            var expectedPositions = "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\r\n   " +
                                          "0|   |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "1|   |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "2|   |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "3|   |   | d | d | d |   |   |   |   |   |\r\n   " +
                                          "4|   |   |   |   |   |   | g |   | c |   |\r\n   " +
                                          "5|   |   |   |   |   |   |   |   | c |   |\r\n   " +
                                          "6|   |   |   |   |   |   |   |   | c |   |\r\n   " +
                                          "7|   |   |   |   |   | d |   |   | c |   |\r\n   " +
                                          "8|   |   |   |   |   | d |   |   |   |   |\r\n   " +
                                          "9|   |   |   |   |   | d |   |   |   | g |";

            var game = new BattleShips();

            var player1BattleShips = new List<BattleShip>
            {
                new Carrier()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 8, YPosition = 4},
                        new Location() {XPositionn = 8, YPosition = 5},
                        new Location() {XPositionn = 8, YPosition = 6},
                        new Location() {XPositionn = 8, YPosition = 7}
                    }
                },
                new Destroyer()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 5, YPosition = 7},
                        new Location() {XPositionn = 5, YPosition = 8},
                        new Location() {XPositionn = 5, YPosition = 9}
                    }
                },
                new Gunship()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 9, YPosition = 9}
                    }
                },
            };

            var player2BattleShips = new List<BattleShip>
            {
                new Destroyer()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 2, YPosition = 3},
                        new Location() {XPositionn = 3, YPosition = 3},
                        new Location() {XPositionn = 4, YPosition = 3}
                    }
                },
                new Gunship()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 6, YPosition = 4}
                    }
                },
            };

            var player1 = new Player(player1BattleShips);
            var player2 = new Player(player2BattleShips);

            game.AddPlayer(player1);
            game.AddPlayer(player2);

            game.Start();

            Assert.AreEqual(expectedPositions, game.Print());
        }

        [Test]
        public void MarkOIfPlayerMisses()
        {
            var expectedPositions = "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\r\n   " +
                                          "0|   |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "1| o |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "2|   |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "3|   |   | d | d | d |   |   |   |   |   |\r\n   " +
                                          "4|   |   |   |   |   |   | g |   | c |   |\r\n   " +
                                          "5|   |   |   |   |   |   |   |   | c |   |\r\n   " +
                                          "6|   |   |   |   |   |   |   |   | c |   |\r\n   " +
                                          "7|   |   |   |   |   | d |   |   | c |   |\r\n   " +
                                          "8|   |   |   |   |   | d |   |   |   |   |\r\n   " +
                                          "9|   |   |   |   |   | d |   |   |   | g |";

            var game = new BattleShips();

            var player1BattleShips = new List<BattleShip>
            {
                new Carrier()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 8, YPosition = 4},
                        new Location() {XPositionn = 8, YPosition = 5},
                        new Location() {XPositionn = 8, YPosition = 6},
                        new Location() {XPositionn = 8, YPosition = 7}
                    }
                },
                new Destroyer()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 5, YPosition = 7},
                        new Location() {XPositionn = 5, YPosition = 8},
                        new Location() {XPositionn = 5, YPosition = 9}
                    }
                },
                new Gunship()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 9, YPosition = 9}
                    }
                },
            };

            var player2BattleShips = new List<BattleShip>
            {
                new Destroyer()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 2, YPosition = 3},
                        new Location() {XPositionn = 3, YPosition = 3},
                        new Location() {XPositionn = 4, YPosition = 3}
                    }
                },
                new Gunship()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 6, YPosition = 4}
                    }
                },
            };

            var player1 = new Player(player1BattleShips);
            var player2 = new Player(player2BattleShips);

            game.AddPlayer(player1);
            game.AddPlayer(player2);

            game.Start();

            game.Fire(new Location() { XPositionn = 0, YPosition = 1});
            Assert.AreEqual(expectedPositions, game.Print());
        }

        [Test]
        public void MarkXIfPlayerHits()
        {
            var expectedPositions = "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\r\n   " +
                                          "0|   |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "1|   |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "2|   |   |   |   |   |   |   |   |   |   |\r\n   " +
                                          "3|   |   | d | d | x |   |   |   |   |   |\r\n   " +
                                          "4|   |   |   |   |   |   | g |   | c |   |\r\n   " +
                                          "5|   |   |   |   |   |   |   |   | c |   |\r\n   " +
                                          "6|   |   |   |   |   |   |   |   | c |   |\r\n   " +
                                          "7|   |   |   |   |   | d |   |   | c |   |\r\n   " +
                                          "8|   |   |   |   |   | d |   |   |   |   |\r\n   " +
                                          "9|   |   |   |   |   | d |   |   |   | g |";

            var game = new BattleShips();

            var player1BattleShips = new List<BattleShip>
            {
                new Carrier()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 8, YPosition = 4},
                        new Location() {XPositionn = 8, YPosition = 5},
                        new Location() {XPositionn = 8, YPosition = 6},
                        new Location() {XPositionn = 8, YPosition = 7}
                    }
                },
                new Destroyer()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 5, YPosition = 7},
                        new Location() {XPositionn = 5, YPosition = 8},
                        new Location() {XPositionn = 5, YPosition = 9}
                    }
                },
                new Gunship()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 9, YPosition = 9}
                    }
                },
            };

            var player2BattleShips = new List<BattleShip>
            {
                new Destroyer()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 2, YPosition = 3},
                        new Location() {XPositionn = 3, YPosition = 3},
                        new Location() {XPositionn = 4, YPosition = 3}
                    }
                },
                new Gunship()
                {
                    PlacementOnBoard = new List<Location>
                    {
                        new Location() {XPositionn = 6, YPosition = 4}
                    }
                },
            };

            var player1 = new Player(player1BattleShips);
            var player2 = new Player(player2BattleShips);

            game.AddPlayer(player1);
            game.AddPlayer(player2);

            game.Start();

            game.Fire(new Location() { XPositionn = 4, YPosition = 3 });

            Assert.AreEqual(expectedPositions, game.Print());
        }
    }
}
