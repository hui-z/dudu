/*
 * What a stupid name :(
 */

using UnityEngine;
using UnityEngine.Rendering;

namespace Entity {
    public class TempButton {
        private readonly GameObject _cube;
        private readonly GameObject _text;

        public TempButton(string name) {
            _cube = Object.Instantiate(Dudu.Adam, new Vector3(0, 0), Quaternion.Euler(0, 0, 270));
            _cube.name = name;
            _cube.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
            _text = Object.Instantiate(Dudu.Eve, new Vector3(0, 0), Quaternion.Euler(0, 0, 0));
            _text.name = string.Format("text {0}", name);
            _text.GetComponent<TextMesh>().text = "自摸";
        }

        public void MoveTo(Location loc) {
            _cube.transform.position = loc.Pos;
            _cube.transform.rotation = loc.Rot;
            _text.transform.position = loc.Pos;
            _text.transform.rotation = loc.Rot;
        }
    }
}