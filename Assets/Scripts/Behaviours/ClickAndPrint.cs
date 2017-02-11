using UnityEngine;

namespace Behaviours {
    public class ClickAndPrint : MonoBehaviour {
        private void OnMouseDown() {
            print(string.Format("click on {0}", gameObject.name));
        }
    }
}
