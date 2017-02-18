using UnityEngine;

namespace Behaviours {
    public class Discard : MonoBehaviour {
        public int Index;

        private void OnMouseDown() {
            Dudu.God.GetComponent<Play>().DropCard(Index);
        }
    }
}
