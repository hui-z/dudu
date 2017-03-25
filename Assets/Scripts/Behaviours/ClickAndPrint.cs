using UnityEngine;

namespace Behaviours {
    public class ClickAndPrint : MonoBehaviour {
        private void OnMouseDown() {
            print($"click on {gameObject.name}");
        }
    }
}
