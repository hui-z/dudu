using UnityEngine;

namespace Behaviours {
    public class DropCard : MonoBehaviour {
        public int Index;

        private void OnMouseDown() {
            Dudu.God.GetComponent<Play>().DropCard(Index);
        }
    }
}
