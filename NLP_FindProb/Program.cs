using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLP_FindProb
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<KeyValuePair<string, double>> ProbList = new List<KeyValuePair<string, double>>();
            List<KeyValuePair<string, double>> NewProbList = new List<KeyValuePair<string, double>>();
            Console.WriteLine("Enter no condition prob in P(A/B) form:");
            int NoOfProb1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter no condition prob in P(A/B,X) form:");
            int NoOfProb2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter no condition prob in P(A) form:");
            int NoOfProb3 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter probabilities of form P(A/B). Enter A and then Enter B");
            for (int i = 1; i <=NoOfProb1; i++)
            {
                String A = Console.ReadLine();
                String B = Console.ReadLine();
                Console.WriteLine("Entered Prob : P(" + A + "/" + B + ")");
                ProbList.Add(new KeyValuePair<string,double>("P(" + A + "/" + B + ")", 0));
                if(i!=NoOfProb1)
                {
                    Console.WriteLine("Enter next prob in same way");
                }
            }

            Console.WriteLine("Enter probabilities of form P(A/B,X). Enter A then Enter B and then X");
            for (int i = 1; i <= NoOfProb2; i++)
            {
                String A = Console.ReadLine();
                String B = Console.ReadLine();
                String X = Console.ReadLine();
                Console.WriteLine("Entered Prob : P(" + A + "/" + B + ","+X+")");
                ProbList.Add(new KeyValuePair<string,double>("P(" + A + "/" + B +","+X+ ")", 0));
                if (i != NoOfProb3)
                {
                    Console.WriteLine("Enter next prob in same way");
                }
            }

            Console.WriteLine("Enter probabilities of form P(A). Enter A ");
            for (int i = 1; i <= NoOfProb3; i++)
            {
                String A = Console.ReadLine();
              
                Console.WriteLine("Entered Prob : P(" + A + ")");
                ProbList.Add(new KeyValuePair<string,double>("P(" + A +")", 0));
                if (i != NoOfProb3)
                {
                    Console.WriteLine("Enter next prob in same way");
                }
            }

            foreach (var s in ProbList)
                Console.WriteLine(s.Key);

            Console.WriteLine("Enter No of variables to do summation : ");
            int NoOfSumVar = int.Parse(Console.ReadLine());

            List<string> SummationVar = new List<string>();
            Console.WriteLine("Enter the variables to do summation, one by one");

            for (int i = 1; i <= NoOfSumVar; i++)
            {
                SummationVar.Add(Console.ReadLine());
            }

            foreach (string var in SummationVar)
            {
                List<string> temp = new List<string>();
                
                foreach (var prob in ProbList)
                {
                    if (prob.Key.Contains(var))
                    {
                        string NewProbString = prob.Key.Replace(var, "~" + var);
                        temp.Add(NewProbString);
                    }
                    else
                    {
                            temp.Add(prob.Key);
                    }

                }

                ProbList.Add(new KeyValuePair<string, double>("+", 0));
                foreach (string t in temp)
                {
                    ProbList.Add(new KeyValuePair<string,double>(t, 0));
                }    
               
            }

            foreach (var s in ProbList)
                Console.Write(s.Key+ "  ");

            NewProbList = ProbList;

            for (int i = 0; i < NewProbList.Count;i++)
            {
                var s = NewProbList[i];
                int index = 0;
                if (s.Value == 0 && s.Key != "+")
                {
                    Console.WriteLine("enter value for " + s.Key);
                    double value = double.Parse(Console.ReadLine());
                    foreach (var temp in ProbList)
                    {
                        if (temp.Key == s.Key)
                        {
                            index = ProbList.IndexOf(temp);
                            var newKeyValue = new KeyValuePair<string, double>(temp.Key, value);
                            NewProbList.Insert(index, newKeyValue);

                        }
                    }


                }
            }

            foreach (var s in NewProbList)
                Console.Write(s.Key + "  "+s.Value+" ");
            Console.ReadLine();

        }

        
    }
}
