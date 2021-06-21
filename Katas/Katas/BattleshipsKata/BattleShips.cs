namespace Katas.BattleshipsKata
{
    using System;
    using System.Collections.Generic;

    public class BattleShips
    {
        private string[,] board;
        private List<Player> players;

        public BattleShips()
        {
            this.players = new List<Player>();
            this.board = new string[10,10];
        }

        public void AddPlayer(Player player)
        {
           this.players.Add(player);
        }

        public void Start()
        {
            foreach (var player in this.players)
            {
                foreach (var battleShip in player.BattleShips)
                {
                    this.PlaceBattleShipOnMap(battleShip);
                }
            }
        }

        private void PlaceBattleShipOnMap(BattleShip battleShip)
        {
            foreach (var location in battleShip.PlacementOnBoard)
            {
                this.board[location.YPosition,location.XPositionn] = battleShip.CellName.ToString();
            }
        }

        public Player EndGame()
        {
            return this.players[0];
        }

        public string Print()
        {
            var toprint = "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\r\n   ";
            var ycount = 0;

            for (int x = 0; x < this.board.GetLength(0); x++)
            {
                var line = $"{ycount}| ";
                for (int y = 0; y < this.board.GetLength(1); y++)
                {
                    var value = this.board[x, y] == null ? $" {this.board[x, y]} | " : $"{this.board[x,y]} | ";
                    line += $"{value}";
                }

                toprint = $"{toprint}{line.TrimEnd()}\r\n   ";
                ycount++;
            }

            return toprint.Remove(toprint.Length - 5);
        }

        public void Fire(Location location)
        {
            var cellOccupied = Enum.TryParse<Cell>(this.board[location.YPosition, location.XPositionn], out var currentCell);

            if (cellOccupied)
            {
                switch (currentCell)
                {
                    case Cell.c:
                    case Cell.d:
                    case Cell.g:
                        currentCell = Cell.x;
                        break;
                    default:
                        currentCell = Cell.o;
                        break;

                }
            }
            else
            {
                currentCell = Cell.o;
            }

            this.board[location.YPosition, location.XPositionn] = currentCell.ToString();
        }
    }
}
