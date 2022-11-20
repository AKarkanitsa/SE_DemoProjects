using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public class Parser
    {
        public static char[] punctuations = { '!', '?', '.', ',', ' '};
        public static Text Parse(string filename)
        {
            string someText = "What are you doing? Hello! What is it? Tell me, what is it? I am happy to see you. See you.";
            Word word = new Word();
            Sentence sentence = new Sentence();
            Text text = new Text();
            int i = 0;
            while (i<someText.Length)
            {
                if (punctuations.Contains(someText[i]))
                {
                    sentence.Words.Add(word);
                    word = new Word();
                    if (someText[i] == '!' || someText[i] == '?' || someText[i] == '.')
                    {
                        switch (someText[i])
                        {
                            case '!' :  sentence.type=SentType.Exclamation; break;
                            case '?' :   sentence.type = SentType.Interrogative; break;
                            case '.' :   sentence.type = SentType.Narrative; break;
                        }
                        text.Sentences.Add(sentence);
                        sentence = new Sentence();
                    }
                }
                else word.Content += someText[i];
                i = i + 1;
            }                
            return text;
        }
    }
}
