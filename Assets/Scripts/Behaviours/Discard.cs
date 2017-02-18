using UnityEngine;

namespace Behaviours {
    public class Discard : MonoBehaviour {
        public int Serial { get; set; }

        private void OnMouseDown() {
            Dudu.God.GetComponent<Play>().DropCard(Serial);
        }
    }
}
