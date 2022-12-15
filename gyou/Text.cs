namespace gyou
{
    public class Text
    {
        private List<List<char>> source;

        public Text(string source)
        {
            this.source = Load(source);
        }

        public char GetChar(int x, int y)
        {
            if (y >= 0
             && source.Count > y
             && x >= 0
             && source[y].Count > x)
            {
                return source[y][x];
            }

            return ' ';
        }
        
        private List<List<char>> Load(string source)
        {
            List<List<char>> ret = new List<List<char>>();
            List<char> line = new List<char>();
            ret.Add(line);

            foreach (char c in source)
            {
                line.Add(c);

                if (IsNewLineChar(c))
                {
                    line = new List<char>();
                    ret.Add(line);
                }
            }

            return ret;
        }

        private bool IsNewLineChar(char c)
        {
            if (c == '\n'
             || c == '\r')
                return true;

            return false;
        }
    }
}
