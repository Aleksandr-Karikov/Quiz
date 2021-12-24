using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    internal static class FileHelper
    {
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }
        public static async Task<List<QuestionModel>> GetQuestions(string Path)
        {
            List<QuestionModel> output = new();
            try
            {
                // асинхронное чтение
                using (StreamReader sr = new StreamReader(Path))
                {
                    
                    while (true)
                    {
                        string[] lines = new string[6];
                        for (int i=0;i<6;i++)
                        {
                            string line;
                            if ((line= await sr.ReadLineAsync()) == null)
                                return output;
                            lines[i] = line;
                        }
                        output.Add(new QuestionModel()
                        {
                            Question = lines[0],
                            Variant1 = lines[1],
                            Variant2 = lines[2],
                            Variant3 = lines[3],
                            Variant4 = lines[4],
                            Answer = lines[5],
                        });
                    }
                }
            }
            catch (Exception)
            {
                
            }
            return output;
        }
        public static void CreateQustion(QuestionModel model,string path)
        {
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(model.Question);
                    sw.WriteLine(model.Variant1);
                    sw.WriteLine(model.Variant2);
                    sw.WriteLine(model.Variant3);
                    sw.WriteLine(model.Variant4);
                    sw.WriteLine(model.Answer);
                }
            }
        }
    }
}
