using UnityEngine;

namespace Behaviours {
    public class DropCard : MonoBehaviour {
        public int Serial;

        private void OnMouseDown() {
            Dudu.God.GetComponent<Play>().DropCard(Serial);
        }
    }
}
