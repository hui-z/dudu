using Entity;
using UnityEngine;

namespace Behaviours {
    public class Play : MonoBehaviour {
        private Deck _deck;
        private Hand _hand;

        private void Start() {
            _deck = new Deck();
            _hand = new Hand(_deck);
            for (var i = 0; i < Hand.Size; i++) {
                var card = _hand.GetCards()[i];
                var position = new Vector3(-7.0f + 1.05f * i, -3.0f);
                var rotation = new Quaternion(0, 0, 0, 0);
                var go = Instantiate(Constants.Adam(), position, rotation);
                go.name = card.GetSerial().ToString();
                go.AddComponent<ClickAndPrint>();
            }
        }
    }
}
