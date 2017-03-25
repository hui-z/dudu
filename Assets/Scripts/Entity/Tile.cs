namespace Entity {
    public class Tile {
        public Tile(int serial) {
            Suit = serial / 36 + 1;
            Rank = serial / 4 % 9 + 1;
            Seq = serial % 4 + 1;
        }

        public Tile(int suit, int rank, int seq) {
            Suit = suit;
            Rank = rank;
            Seq = seq;
        }

        public int Suit { get; }

        public int Rank { get; }

        public int Seq { get; }

        public int Serial {
            get { return Seq - 1 + (Rank - 1) * 4 + (Suit - 1) * 36; }
        }

        public bool IsSequencial() {
            return Suit < 4;
        }

        public override string ToString() {
            if (IsSequencial()) {
                string[] suitNames = {"萬", "条", "筒"};
                string[] rankNames = {"一", "二", "三", "四", "五", "六", "七", "八", "九"};
                return string.Concat(rankNames[Rank - 1], suitNames[Suit - 1]);
            } else {
                string[] rankNames = {"東", "南", "西", "北", "  ", "發", "中"};
                return rankNames[Rank - 1];
            }
        }
    }
}
