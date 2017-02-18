using UnityEngine;

namespace Entity {
    public class Location {
        public Vector3 Pos { get; private set; }

        public Quaternion Rot { get; private set; }

        public Location(Vector3 pos) : this(pos, Quaternion.Euler(0, 0, 0)) {
        }

        public Location(Vector3 pos, Quaternion rot) {
            Pos = pos;
            Rot = rot;
        }

        public static Location GetDeckLocation(int index) {
            return new Location(new Vector3(-7.0f + 1.05f * index, -4.0f));
        }

        public static Location GetGroundLocation(int index) {
            var x = -8 + index % 17;
            var z = index / 17;
            var y = -2 + 0.5f * z;
            var pos = new Vector3(x, y, z);
            var rot = Quaternion.Euler(60, 0, 0);
            return new Location(pos, rot);
        }
    }
}
