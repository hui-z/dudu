using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity {
    public class Deck {
        private int _head;
        private List<Tile> _tiles;

        private void Initialize() {
            _tiles = new List<Tile>(Constants.DeckSize);
            for (var serial = 0; serial < Constants.DeckSize; serial++) {
                _tiles.Add(new Tile(serial));
            }
            var random = new Random();
            for (var i = 0; i < Constants.DeckSize; i++) {
                var j = random.Next(Constants.DeckSize);
                var tmp = _tiles[i];
                _tiles[i] = _tiles[j];
                _tiles[j] = tmp;
            }
        }

        public Deck() {
            _head = 0;
            Initialize();
        }

        public int GetSize() {
            return _tiles.Count() - _head;
        }

        public Tile Draw() {
            return _tiles[_head++];
        }

        public override string ToString() {
            return string.Join(" ", _tiles.Select(x => string.Format("[{0} {1}]", x.Serial, x.ToString())).ToArray());
        }
    }
}
