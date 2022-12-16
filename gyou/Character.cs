namespace gyou
{
    public struct Character
    {
        public readonly string rawSource;
        public readonly CharacterType characterType;

        public Character(string rawSource, CharacterType characterType)
        {
            this.rawSource = rawSource;
            this.characterType = characterType;
        }

        public override string ToString()
        {
            switch (characterType)
            {
                case CharacterType.NORMAL:
                    return rawSource;
                case CharacterType.NEWLINE:
                    return " ";
                case CharacterType.EOF:
                    return " ";
                default:
                    return " ";
            }
        }
    }
}
