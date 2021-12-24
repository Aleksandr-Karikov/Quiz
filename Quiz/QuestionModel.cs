using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class QuestionModel
    {

        public string Question { get; set; }
        public string Answer { get; set; }
        public string Variant1 { get; set; }
        public string Variant2 { get; set; }
        public string Variant3 { get; set; }
        public string Variant4 { get; set; }
        public bool CheckAnswer(string answer)
        {
            if (answer == Answer)
            {
                return true;
            }
            return false;
        }
        public void SaveAnswer(int position)
        {

        }
    }
}
