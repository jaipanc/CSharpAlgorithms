
namespace CSharpAlgorithms;

public class Backtracking
{
    /// <summary>
    /// 79. Word Search
    /// </summary>
    /// <param name=""></param>
    /// <param name="word"></param>
    /// <returns></returns>
    public static bool WordSearch(char[][] board, string word)
    {
        int rows = board.Length;
        int cols = board[0].Length;

        bool BfsHelper(int r, int c, int index)
        {
            if (index == word.Length) return true;

            if (r < 0 || c < 0 || r >= rows || c >= cols || board[r][c] != word[index]) return false;

            var temp = board[r][c];
            board[r][c] = '#';

            bool found = BfsHelper(r + 1, c, index + 1) || BfsHelper(r - 1, c, index + 1) || BfsHelper(r, c + 1, index + 1) || BfsHelper(r, c - 1, index + 1);
            board[r][c] = temp;
            return found;
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (board[i][j] == word[0])
                {
                    if (BfsHelper(i, j, 0)) return true;
                }
            }
        }
        return false;
    }
}
