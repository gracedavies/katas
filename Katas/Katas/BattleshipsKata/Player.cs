namespace Katas.BattleshipsKata
{
    using System.Collections.Generic;

    public class Player
    {
        public Player(List<BattleShip> playingShip)
        {
            this.BattleShips = playingShip;
        }

        public List<BattleShip> BattleShips { get; private set; }
    }
}