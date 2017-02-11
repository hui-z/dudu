using Entity;
using UnityEngine;

public class Move : MonoBehaviour {
    public float OutX = -5.0f;
    public float OutY = 3.0f;
    public int Count = 0;
    private Deck _deck;

    private void Start() {
        _deck = new Deck();
    }

    private void OnMouseDown() {
        print("clicked in C Sharp");
        if (_deck.GetSize() > 0) {
            print(_deck.GetSize());
            print(_deck.Draw().ToString());
        }
        var position = new Vector3(OutX, OutY);
        var rotation = new Quaternion(0, 0, 0, 0);
        var otherCube = Instantiate(gameObject, position, rotation);
        otherCube.name = string.Format("Card {0}", ++Count);
        OutX += 1;
        if (OutX > 5.1) {
            OutX = -5;
            OutY -= 1.1f;
        }
    }
}
