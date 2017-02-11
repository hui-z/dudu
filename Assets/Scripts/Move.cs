using System;
using System.Collections.Specialized;
using System.Text;
using Entity;
using UnityEngine;

public class Move : MonoBehaviour {
    public float OutX = -5.0f;
    public float OutY = 3.0f;
    public int Count = 0;
    private Deck _deck;
    private Hand _hand;

    private void Start() {
        _deck = new Deck();
        _hand = new Hand();
        for (var i = 0; i < 13; i++) {
            _hand.Add(_deck.Draw());
        }
    }

    private void OnMouseDown() {
        if (_deck.GetSize() > 0) {
            var card = _deck.Draw();
            print(card.ToString());
            _hand.Replace(5, card);
        }
        var sb = new StringBuilder();
        foreach (var card in _hand.GetCards()) {
            sb.Append(card.ToString()).Append("|");
        }
        print(string.Format("clicked, now you get {0}", sb));
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
