using Entity;
using UnityEngine;

namespace Behaviours {
    public class Play : MonoBehaviour {
        private Deck _deck;
        private Hand _hand;

        private void Start() {
            _deck = new Deck();
            _hand = new Hand(_deck);
            for (var i = 0; i < Constants.DeckSize; i++) {
                var card = new Card(i);
                var rot = Quaternion.Euler(0, 0, 0);
                var cube = Instantiate(Constants.Adam(), new Vector3(101 + i, 0), rot);
                cube.name = card.GetSerial().ToString();
                var text = Instantiate(Constants.Eve(), new Vector3(-101 - i, 0), rot);
                text.name = "text " + card.GetSerial();
                text.GetComponent<TextMesh>().text = card.ToString();
            }
            DisplayHand();
        }

        public void DropCard(string serial) {
            var i = Constants.DeckSize - _deck.GetSize();
            print("dropping card " + serial + " , and this is the " + i);
            var cube = GetCube(int.Parse(serial));
            cube.transform.rotation = Quaternion.Euler(90, 0, 0);
            cube.transform.position = new Vector3(-20 + i, -3, 5);
            Destroy(cube.GetComponent<DropCard>());
            var text = GetText(int.Parse(serial));
            text.transform.rotation = Quaternion.Euler(90, 0, 0);
            text.transform.position = new Vector3(-20 + i, -3, 5);
            _hand.Replace(int.Parse(serial), _deck.Draw());
            print("we have cards count = " + _hand.GetCards().Count);
            DisplayHand();
        }

        private void DisplayHand() {
            for (var i = 0; i < Constants.HandSize; i++) {
                var card = _hand.GetCards()[i];
                var pos = new Vector3(-7.0f + 1.05f * i, -4.0f);
                var rot = Quaternion.Euler(0, 0, 0);
                var cube = GetCube(card.GetSerial());
                cube.transform.position = pos;
                cube.transform.rotation = rot;
                var text = GetText(card.GetSerial());
                text.transform.position = pos;
                text.transform.rotation = rot;
                cube.AddComponent<DropCard>();
            }
        }

        private GameObject GetCube(int serial) {
            return GameObject.Find(serial.ToString());
        }

        private GameObject GetText(int serial) {
            return GameObject.Find("text " + serial);
        }
    }
}
