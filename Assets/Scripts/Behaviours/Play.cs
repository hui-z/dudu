using System.Collections.Generic;
using Entity;
using UnityEngine;

namespace Behaviours {
    public class Play : MonoBehaviour {
        private Deck _deck;
        private Hand _hand;
        private Dictionary<int, Mahjong> _mahjongs;
        private int _dropCount;

        private void Start() {
            _deck = new Deck();
            _hand = new Hand(_deck);
            _mahjongs = new Dictionary<int, Mahjong>();
            for (var i = 0; i < Constants.DeckSize; i++) {
                _mahjongs.Add(i, new Mahjong(new Tile(i)));
            }
            DisplayHand();
        }

        public void DropCard(int serial) {
            var mahjong = _mahjongs[serial];
            mahjong.MoveTo(Location.GetGroundLocation(_dropCount++));
            mahjong.HandOut();
            _hand.Discard(serial);
            _hand.Add(_deck.Draw());
            print(string.Format("Dropping card, count {0}, card |{1}|", _dropCount, mahjong));
            DisplayHand();
        }

        private void DisplayHand() {
            var cards = _hand.GetCards();
            print(string.Format("Displaying hand, size {0}, content [{1}]", cards.Count, _hand));
            for (var i = 0; i < cards.Count; i++) {
                var card = cards[i];
                var mahjong = _mahjongs[card.Serial];
                mahjong.MoveTo(Location.GetDeckLocation(i));
                mahjong.HandIn(i);
            }
        }
    }
}
