using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public enum SentType
    {
        Exclamation,
        Interrogative,
        Narrative,
        Unknown
    }
    public class Sentence
    {
        public List<Word> Words { get; set; }
        public SentType type { get; set; } 

        public int Count => Words.Count;

        public Sentence()
        {
            this.Words=new List<Word>();
        }
        public override string ToString()
        {
           string content=String.Empty;
            foreach (Word w in Words)
            {
                content = content + " " + w.Content;
            }
            return content;
        }
    }
}
