namespace gyou
{
    public class Text
    {
        private List<List<Character>> characters;

        public Text(string source)
        {
            Lexer lexer = new Lexer(source);
            characters = Load(lexer);
        }

        public Character GetCharacter(int x, int y)
        {
            if (y >= 0
             && characters.Count > y
             && x >= 0
             && characters[y].Count > x)
                return characters[y][x];

            return new Character(" ", CharacterType.NORMAL);
        }
 
        private List<List<Character>> Load(Lexer lexer)
        {
            Character c = lexer.NextCharacter();
            List<List<Character>> ret = new List<List<Character>>();
            List<Character> line = new List<Character>();
            ret.Add(line);

            while (c.characterType != CharacterType.EOF)
            {
                switch (c.characterType)
                {
                    case CharacterType.NEWLINE:
                        line.Add(c);
                        line = new List<Character>();
                        ret.Add(line);
                        break;
                    default:
                        line.Add(c);
                        break;
                }

                c = lexer.NextCharacter();
            }

            return ret;
        }
    }
}
