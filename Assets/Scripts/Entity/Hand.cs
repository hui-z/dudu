using System.Collections.Generic;
using System.Linq;

namespace Entity {
    public class Hand {
        private readonly List<Tile> _cards;

        public Hand(Deck deck) {
            _cards = new List<Tile>(Constants.HandSize);
            for (var i = 0; i < Constants.HandSize; i++) {
                Add(deck.Draw());
            }
        }

        public void Replace(int index, Tile tile) {
            _cards.RemoveAt(index);
            Add(tile);
        }

        public List<Tile> GetCards() {
            return _cards;
        }

        private void Add(Tile tile) {
            _cards.Add(tile);
            _cards.Sort((card1, card2) => card1.Serial - card2.Serial);
        }

        public override string ToString() {
            return string.Join(" ", _cards.Select(x => string.Format("[{0} {1}]", x.Serial, x.ToString())).ToArray());
        }
    }
}
