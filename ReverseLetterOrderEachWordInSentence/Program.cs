/* ReverseLetterOrderEachWordInSentence.cs           Jason Thatcher
 *                                                   December 2017
 * 
 * Prompts user to input sentence(s) and the program 
 * will reverse the letters in each word while maintaining 
 * the word order and punctuation. 
 * 
 * C#, Array, List<>, Loop, Conditional Expressions, Comments
*/

using System;
using System.Collections.Generic;
using System.Linq;

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

                        if (punctuation.Contains(a[k]))  //Punctuation?: Is the char found in punctuation array?  Save Char and sentence position to reinsert later in proper position.
                        {
                            specials.Add(k);
                        }
                        else if (c != a[k])
                        {
                            b += a[k];  //Reverse order.
                        }
                    }

                    //add space back in following word
                   b += " ";
                                        
                    resume = i;                                   
                    
                }                
            }

            //add punc back in at appropriate location.  
            specials.Sort(); //String with lot of punctuation fails as it tries to fill.  Need to sort to fill back in starting at beginning.

            for(int d = 0;  d<specials.Count; d++)
            {
                b = b.Insert(specials[d], a[specials[d]].ToString());
            }
            
            Console.WriteLine("With letter order reversed: " + b);            
        }      
    }
}
