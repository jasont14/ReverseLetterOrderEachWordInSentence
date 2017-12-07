using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLetterOrderEachWordInSentence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write Sentence: \n");
            string a = Console.ReadLine();            
                        
            ReverseLetters(a);
            Console.ReadLine();
        }

        private static void ReverseLetters(string a)
        {
            string b = "";        
            char c = '\u0020';
            char[] punctuation =  {'.', '?', '!', ',', ';', ':'};
            List<int> specials = new List<int>();
            
            int resume = 0;

            for (int i = 0; i<a.Length; i++)
            {               
                //Assume space follows each word.
                
                if (c == a[i] | i == a.Length-1) //look for a space in the sentence or end of sentence.

                {
                    int stop = i;

                    for (int k=i; k>resume-1; k--)  //Loop through current word to reverse letters and maintain punctuation
                    {

                        if (punctuation.Contains(a[k]))  //Punctuation?: Is the char found in punctuation array?  Save Char and sentence position so we can reinsert in proper position.
                        {
                            specials.Add(k);
                        }
                        else if (c != a[k])
                        {
                            b += a[k];  //If not add characters to string in reverse order.
                        }
                    }

                    //add space back in
                   b += " ";
                                        
                    resume = i;                                   
                                      
                    //find next character that is not a space.  Set resume location.
                    
                }                
            }

            //add punc back in at appropriate location

            for(int d = 0;  d<specials.Count; d++)
            {
                b = b.Insert(specials[d], a[specials[d]].ToString());
            }
           
            Console.WriteLine("With letter order reversed: " + b);            
        }      
    }
}
