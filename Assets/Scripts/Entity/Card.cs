namespace Entity {
    public class Card {
        private readonly int _suit;
        private readonly int _size;
        private readonly int _seq;

        public Card(int suit, int size, int seq) {
            _suit = suit;
            _size = size;
            _seq = seq;
        }

        public int GetSerial() {
            return (_seq - 1) + (_size - 1) * 4 + (_suit - 1) * 34;
        }

        public override string ToString() {
            if (_suit < 4) {
                string[] suitNames = {"萬", "条", "筒"};
                string[] sizeNames = {"一", "二", "三", "四", "五", "六", "七", "八", "九"};
                return string.Concat(sizeNames[_size - 1], suitNames[_suit - 1]);
            } else {
                string[] sizeNames = {"東", "南", "西", "北", "  ", "發", "中"};
                return sizeNames[_size - 1];
            }
        }
    }
}