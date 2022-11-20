namespace TextParser
{
    public class Program
    {
        static void Main()
        {
            Text text = Parser.Parse("input.txt");
            Console.WriteLine(text);
            Console.WriteLine(text.Sentences[0].Words[3].Content);

        }
    }
}

