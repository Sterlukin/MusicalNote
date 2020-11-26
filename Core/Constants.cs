namespace Core
{
    public static class Constants
    {
        public static class Input
        {
            public static readonly string Size = "Размер";
            public static readonly string Notes = "Ноты";
        }

        public static class Delimiters
        {
            public static readonly char BetweenNoteParts = '/';
            public static readonly char BetweenTacts = '|';
            public static readonly char BetweenNotes = ' ';
        }

        public static class Messages
        {
            public static readonly string OutputTitle = "Вывод";
            public static readonly string TactError = " <Ошибка> ";
            public static readonly string OutputError = "Во время обработки данных произошла ошибка: {0}";
        }
    }
}
