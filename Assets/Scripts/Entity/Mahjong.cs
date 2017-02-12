using Behaviours;
using UnityEngine;

namespace Entity {
    public class Mahjong {
        private readonly Card _card;
        private readonly GameObject _cube;
        private readonly GameObject _text;

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

        public void MoveTo(Location loc) {
            _cube.transform.position = loc.Pos;
            _cube.transform.rotation = loc.Rot;
            _text.transform.position = loc.Pos;
            _text.transform.rotation = loc.Rot;
        }

        public void HandIn(int i) {
            var dropScript = _cube.GetComponent<DropCard>();
            if (dropScript == null) {
                _cube.AddComponent<DropCard>();
                _cube.GetComponent<DropCard>().Index = i;
            } else {
                dropScript.Index = i;
            }
        }

        public void HandOut() {
            var dropScript = _cube.GetComponent<DropCard>();
            if (dropScript != null) {
                Object.Destroy(_cube.GetComponent<DropCard>());
            }
        }

        public int Serial {
            get { return _card.Serial; }
        }

        public override string ToString() {
            return string.Format("Mahjong {0} {1}", _card.Serial, _card);
        }
    }
}
