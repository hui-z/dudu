using System.Collections.Generic;
using System.Linq;
using Entity;

public class Condition {
    public static bool IsTriple(Tile t1, Tile t2, Tile t3) {
        var sameSuit = Same(t1.Suit, t2.Suit, t3.Suit);
        var sameTile = sameSuit && Same(t1.Rank, t2.Rank, t3.Rank);
        var sequential = sameSuit && t1.IsSequencial() && Same(t1.Rank + 1, t2.Rank, t3.Rank - 1);
        return sameTile || sequential;
    }

    public static bool RonAble(List<Tile> tiles) {
        if (tiles.Count % 3 != 2 || tiles.Count != Constants.HandSize) return false;
        for (var i = 0; i < Constants.HandSize; i += 3) {
            var ronAble = Same(tiles[i].Suit, tiles[i].Suit) && Same(tiles[i].Rank, tiles[i + 1].Rank);
            for (var j = 0; j < Constants.HandSize; j += 3) {
                if (i == j) j += 2;
                ronAble = ronAble && IsTriple(tiles[j], tiles[j + 1], tiles[j + 2]);
            }
            if (ronAble) return true;
        }
        return false;
    }

    private static bool Same(params int[] numbers) {
        return numbers.All((x) => (x == numbers[0]));
    }
}
