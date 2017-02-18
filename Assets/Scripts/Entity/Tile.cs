namespace Entity {
    public class Tile {
        public int Suit {
            get { return _suit; }
        }

        public int Rank {
            get { return _rank; }
        }

        public int Seq {
            get { return _seq; }
        }

        private readonly int _suit;
        private readonly int _rank;
        private readonly int _seq;

        public Tile(int serial) {
            _suit = (serial / 36) + 1;
            _rank = (serial / 4) % 9 + 1;
            _seq = serial % 4 + 1;
        }

        public Tile(int suit, int rank, int seq) {
            _suit = suit;
            _rank = rank;
            _seq = seq;
        }

        public int Serial {
            get { return (_seq - 1) + (_rank - 1) * 4 + (_suit - 1) * 36; }
        }

        public bool IsSequencial() {
            return _suit < 4;
        }

        public override string ToString() {
            if (IsSequencial()) {
                string[] suitNames = {"萬", "条", "筒"};
                string[] rankNames = {"一", "二", "三", "四", "五", "六", "七", "八", "九"};
                return string.Concat(rankNames[_rank - 1], suitNames[_suit - 1]);
            } else {
                string[] rankNames = {"東", "南", "西", "北", "  ", "發", "中"};
                return rankNames[_rank - 1];
            }
        }
    }
}
