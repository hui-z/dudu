using System.Collections.Generic;
using System.Linq;
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
                _mahjongs.Add(i, new Mahjong(new Card(i)));
            }
            DisplayHand();
        }

        public void DropCard(int index) {
            _dropCount += 1;
            var serial = _hand.GetCards()[index].Serial;
            var mahjong = _mahjongs[serial];
            mahjong.MoveTo(new Vector3(-7 + _dropCount, -3, 5), Quaternion.Euler(90, 0, 0));
            mahjong.HandOut();
            _hand.Replace(index, _deck.Draw());
            print(string.Format("Dropping card, count {0}, card |{1}|", _dropCount, mahjong));
            DisplayHand();
        }

        private void DisplayHand() {
            var cards = _hand.GetCards();
            print(string.Format("Displaying hand, size {0}, content [{1}]", cards.Count,
                string.Join(", ", cards.Select(x => x.Serial + x.ToString()).ToArray())));
            for (var i = 0; i < cards.Count; i++) {
                var card = cards[i];
                var mahjong = _mahjongs[card.Serial];
                mahjong.MoveTo(new Vector3(-7.0f + 1.05f * i, -4.0f), Quaternion.Euler(0, 0, 0));
                mahjong.HandIn(i);
            }
        }
    }
}
