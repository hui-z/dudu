using Behaviours;
using UnityEngine;

namespace Entity {
    public class Mahjong {
        private readonly Card _card;
        private readonly GameObject _cube;
        private readonly GameObject _text;
        private bool _inHand;

        public Mahjong(Card card) {
            _card = card;
            var n = card.Serial;
            var rot = Quaternion.Euler(0, 0, 0);
            _cube = Object.Instantiate(Dudu.Adam, new Vector3(101 + n, 0), rot);
            _cube.name = n.ToString();
            _text = Object.Instantiate(Dudu.Eve, new Vector3(-101 - n, 0), rot);
            _text.name = "text " + n;
            _text.GetComponent<TextMesh>().text = card.ToString();
        }

        public void MoveTo(Vector3 position, Quaternion rotation) {
            _cube.transform.position = position;
            _cube.transform.rotation = rotation;
            _text.transform.position = position;
            _text.transform.rotation = rotation;
        }

        public void HandIn() {
            if (_inHand) return;
            _inHand = true;
            _cube.AddComponent<DropCard>();
            _cube.GetComponent<DropCard>().Serial = _card.Serial;
        }

        public void HandOut() {
            if (!_inHand) return;
            _inHand = false;
            Object.Destroy(_cube.GetComponent<DropCard>());
        }

        public int Serial {
            get { return _card.Serial; }
        }

        public override string ToString() {
            return string.Format("Mahjong {0} {1}", _card.Serial, _card);
        }
    }
}
