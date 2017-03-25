using Behaviours;
using UnityEngine;

namespace Entity {
    public class Mahjong {
        private readonly GameObject _cube;
        private readonly GameObject _text;
        private readonly Tile _tile;

        public Mahjong(Tile tile) {
            _tile = tile;
            var n = tile.Serial;
            var rot = Quaternion.Euler(0, 0, 0);
            _cube = Object.Instantiate(Dudu.Adam, new Vector3(101 + n, 0), rot);
            _cube.name = n.ToString();
            _text = Object.Instantiate(Dudu.Eve, new Vector3(-101 - n, 0), rot);
            _text.name = "text " + n;
            _text.GetComponent<TextMesh>().text = tile.ToString();
        }

        public int Serial {
            get { return _tile.Serial; }
        }

        public void MoveTo(Location loc) {
            _cube.transform.position = loc.Pos;
            _cube.transform.rotation = loc.Rot;
            _text.transform.position = loc.Pos;
            _text.transform.rotation = loc.Rot;
        }

        public void HandIn(int i) {
            var dropScript = _cube.GetComponent<Discard>();
            if (dropScript == null) {
                _cube.AddComponent<Discard>();
                _cube.GetComponent<Discard>().Serial = _tile.Serial;
            }
        }

        public void HandOut() {
            var dropScript = _cube.GetComponent<Discard>();
            if (dropScript != null) Object.Destroy(_cube.GetComponent<Discard>());
        }

        public override string ToString() {
            return $"Mahjong {_tile.Serial} {_tile} {_text.GetComponent<TextMesh>().text}";
        }
    }
}
