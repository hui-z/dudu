using System.Collections.Generic;
using System.Linq;

namespace Entity {
    public class Hand {
        public Hand(Deck deck) {
            Tiles = new List<Tile>(Constants.HandSize);
            for (var i = 0; i < Constants.HandSize; i++) Add(deck.Draw());
        }

        public List<Tile> Tiles { get; }

        public void Discard(int serial) {
            foreach (var tile in Tiles)
                if (tile.Serial == serial) {
                    Tiles.Remove(tile);
                    break;
                }
        }

        public void Add(Tile tile) {
            Tiles.Add(tile);
            Tiles.Sort((tile1, tile2) => tile1.Serial - tile2.Serial);
        }

        public override string ToString() {
            return string.Join(" ", Tiles.Select(x => $"[{x.Serial} {x.ToString()}]").ToArray());
        }
    }
}
