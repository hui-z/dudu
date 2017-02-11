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
                var position = new Vector3(-7.0f + 1.05f * i, -4.0f);
                var rotation = new Quaternion(0, 0, 0, 0);
                var cardCube = Instantiate(Constants.Adam(), position, rotation);
                cardCube.name = card.GetSerial().ToString();
                cardCube.AddComponent<DropCard>();
                var cardText = Instantiate(Constants.Eve(), position, rotation);
                cardText.name = string.Format("text {0}", card.GetSerial().ToString());
                cardText.GetComponent<TextMesh>().text = card.ToString();
            }
        }

        public void DropCard(string cardName) {
            var i = 123 - _deck.GetSize();
            var cardCube = GameObject.Find(cardName);
            cardCube.transform.rotation = Quaternion.Euler(90, 0, 0);
            cardCube.transform.position = new Vector3(-7 + i, -3, 5);
            Object.Destroy(cardCube.GetComponent<DropCard>());
            var cardText = GameObject.Find("text " + cardName);
            cardText.transform.rotation = Quaternion.Euler(90, 0, 0);
            cardText.transform.position = new Vector3(-7 + i, -3, 5);
            print("dropping card " + cardName);
            _hand.Replace(1, _deck.Draw());
        }
    }
}
