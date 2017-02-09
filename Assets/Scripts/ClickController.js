#pragma strict

var outX = -4.5;
var outY = 3;

function SetPosition(x, y) {
    transform.position = new Vector3(x, y, 0);
}

function OnMouseDown () {
  print("clicked");
  var newCard = Instantiate(gameObject, new Vector3(outX, outY, 0), new Quaternion(0, 3.14, 0, 0));
  newCard.name = "Card" + outX + outY;
  // SetPosition(outX, outY);
  outX = outX + 0.9;
  if (outX > 4.6) {
    outX = -4.5;
    outY = outY - 1;
  }
}

