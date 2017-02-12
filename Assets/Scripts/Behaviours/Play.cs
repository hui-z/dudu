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
                _mahjongs.Add(i, new Mahjong(new Card(i)));
            }
            DisplayHand();
        }

        public void DropCard(int serial) {
            _dropCount += 1;
            _mahjongs[serial].MoveTo(new Vector3(-7 + _dropCount, -3, 5), Quaternion.Euler(90, 0, 0));
            _mahjongs[serial].HandOut();
            _hand.Replace(serial, _deck.Draw());
            print("dropping card " + serial + " , and this is the " + _dropCount + " " + _mahjongs[serial]);
            DisplayHand();
        }

        private void DisplayHand() {
            var cards = _hand.GetCards();
            for (var i = 0; i < cards.Count; i++) {
                var card = cards[i];
                var mahjong = _mahjongs[card.Serial];
                mahjong.MoveTo(new Vector3(-7.0f + 1.05f * i, -4.0f), Quaternion.Euler(0, 0, 0));
                mahjong.HandIn();
            }
        }
    }
}
