using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    class CompareBySentLength : IComparer<Sentence>
    {
        public int Compare(Sentence? x, Sentence? y)
        {
            return x.Count.CompareTo(y.Count);
        }
    }
    public class Text
    {        
        public List<Sentence> Sentences { get; set; }

        public Text()
        {
            this.Sentences=new List<Sentence>();
        }

        public void Sort()
        {
            Sentences.Sort(new CompareBySentLength());
        }

        public override string ToString()
        {
            string content = String.Empty;
            foreach (Sentence s in Sentences)
            {
                content = content + s.ToString() + '\n';
            }
            return content;
        }
    }
}
