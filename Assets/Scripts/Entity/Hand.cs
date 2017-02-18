using System.Collections.Generic;
using System.Linq;

namespace Entity {
    public class Hand {
        private readonly List<Tile> _tiles;

        public List<Tile> Tiles {
            get { return _tiles; }
        }

        public Hand(Deck deck) {
            _tiles = new List<Tile>(Constants.HandSize);
            for (var i = 0; i < Constants.HandSize; i++) {
                Add(deck.Draw());
            }
        }

        public void Discard(int serial) {
            Tile tileToRemove = null;
            foreach (var tile in _tiles) {
                if (tile.Serial == serial) {
                    tileToRemove = tile;
                }
            }
            if (tileToRemove != null) {
                _tiles.Remove(tileToRemove);
            }
        }

        public void Add(Tile tile) {
            _tiles.Add(tile);
            _tiles.Sort((tile1, tile2) => tile1.Serial - tile2.Serial);
        }

        public override string ToString() {
            return string.Join(" ", _tiles.Select(x => string.Format("[{0} {1}]", x.Serial, x.ToString())).ToArray());
        }
    }
}
