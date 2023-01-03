using ObjectChess.Models;

namespace ObjectChess.CustomExtensions
{
    public static class StringExtensions
    {
        public static PieceLocation AlgebraicNotationToRankFile(this string input)
        {
            PieceLocation RankFile = new PieceLocation();
            char[] letters = input.ToCharArray();
            RankFile.Rank = (int)Char.GetNumericValue(letters[1]) - 1;

            if (char.ToLower(letters[0]) == 'a')
            {
                RankFile.File = 0;
            }
            else if (char.ToLower(letters[0]) == 'b')
            {
                RankFile.File = 1;
            }
            else if (char.ToLower(letters[0]) == 'c')
            {
                RankFile.File = 2;
            }
            else if (char.ToLower(letters[0]) == 'd')
            {
                RankFile.File = 3;
            }
            else if (char.ToLower(letters[0]) == 'e')
            {
                RankFile.File = 4;
            }
            else if (char.ToLower(letters[0]) == 'f')
            {
                RankFile.File = 5;
            }
            else if (char.ToLower(letters[0]) == 'g')
            {
                RankFile.File = 6;
            }
            else if (char.ToLower(letters[0]) == 'h')
            {
                RankFile.File = 7;
            }
            return RankFile;
        }
    }
}