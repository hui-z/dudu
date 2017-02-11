using UnityEngine;

namespace Behaviours {
    public class DropCard : MonoBehaviour {
        private void OnMouseDown() {
            Constants.God().GetComponent<Play>().DropCard(gameObject.name);
        }
    }
}
