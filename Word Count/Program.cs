using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace Word_Count
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string input;

            OpenFileDialog file = new OpenFileDialog();

            file.InitialDirectory = "c:\\";
            file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;

            Console.WriteLine(file.FileName);

            if (file.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(file.FileName))
                {
                    input = sr.ReadToEnd();
                }

                int words = 0;

                for (var i = 0; i < input.Length; i++)
                {
                    if (i < input.Length && !char.IsWhiteSpace(input[i]))
                    {
                        while (i < input.Length && !char.IsWhiteSpace(input[i]))
                        {
                            i++;
                        }

                        words++;
                    }

                    else if (i < input.Length && char.IsWhiteSpace(input[i]))
                    {
                        i++;
                    }
                }

                Console.WriteLine("Total words: " + words);
            }


        }
    }
}
