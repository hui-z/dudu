using System.Collections.Generic;
using Entity;
using UnityEngine;

namespace Behaviours {
    public class Play : MonoBehaviour {
        private Deck _deck;
        private int _dropCount;
        private Hand _hand;
        private Dictionary<int, Mahjong> _mahjongs;
        private TempButton _zimo;

        private void Start() {
            _deck = new Deck();
            _hand = new Hand(_deck);
            _mahjongs = new Dictionary<int, Mahjong>();
            for (var i = 0; i < Constants.DeckSize; i++) _mahjongs.Add(i, new Mahjong(new Tile(i)));
            _zimo = new TempButton("zimo");
            DisplayHand();
        }

        public void DropCard(int serial) {
            var mahjong = _mahjongs[serial];
            mahjong.MoveTo(Location.GetGroundLocation(_dropCount++));
            mahjong.HandOut();
            _hand.Discard(serial);
            _hand.Add(_deck.Draw());
            print($"Dropping tile, count {_dropCount}, tile |{mahjong}|");
            DisplayHand();
        }

        private void DisplayHand() {
            var tiles = _hand.Tiles;
            print($"RonAble: [{Condition.RonAble(_hand.Tiles)}], Displaying hand, size {tiles.Count}, content [{_hand}]");
            _zimo.MoveTo(Condition.RonAble(_hand.Tiles)
                ? new Location(new Vector3(5.5f, -2, -1))
                : new Location(new Vector3(100, -2, -1)));
            for (var i = 0; i < tiles.Count; i++) {
                var tile = tiles[i];
                var mahjong = _mahjongs[tile.Serial];
                mahjong.MoveTo(Location.GetDeckLocation(i));
                mahjong.HandIn(i);
            }
        }
    }
}
