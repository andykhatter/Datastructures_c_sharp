using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {

            //implementing a struct

            Name name = new Name("Andy","Singh","Khatter");
            string full_name;
            full_name = name.ToString();
            Console.WriteLine("My Name is {0}",full_name);

            ///////////////////////////

            ////////// Implementing a custom collection class will be enhanced later/////
            CustomCollection names = new CustomCollection();
            names.Add("Andy");
            names.Add("Andy K");
            names.Add("Khatter");
            names.Add("Singh Khatter");
            foreach (Object nameInList in names)
                Console.WriteLine(nameInList);

            Console.WriteLine("Number of elements total: "+names.Count());

            names.Remove("Andy");
            Console.WriteLine("Number of elements after removing: " + names.Count());


            names.Clear();
            Console.WriteLine("Number of elements after clearing: " + names.Count());

            //////////////////////////////////////////////////////////////////////////
            /////////Implementing generics ///////////////////////////////////////////
            int val1 = 100;
            int val2 = 200;

            Console.WriteLine("Value1: " + val1);
            Console.WriteLine("Value2: " + val2);
            swap<int>(ref val1, ref val2);

            Console.WriteLine("Value1: " + val1);
            Console.WriteLine("Value2: " + val2);


            ////////////In C#, arguments can be passed to parameters either by 
            //value or by reference. Passing by reference enables function members,
            //methods, properties, indexers, operators, and constructors to change the value
            //of the parameters and have that change persist in the calling environment///////


            ////////////////////TIMING .NET/////////////////////////////////////

            //int[] nums = new int[100000];
            //BuildArray(nums);
            //Timing timeObj = new Timing();
            //timeObj.startTime();
            //DisplayNums(nums);
            //timeObj.StopTime();
            //Console.WriteLine("Total time spent "+timeObj.result().TotalSeconds);

            ///////METHOD THAT TAKES ANY NUMBER OF ARGUMENTS////////////////////////////
            int total = sumNums(1, 2, 3, 4, 5);
            int total2 = sumNums(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Console.WriteLine(total);
            Console.WriteLine(total2);

            ////////////////Multidimensional arrays//////////////////////////////////
            //not  using -- int[,] daysofsaleineachmonethoverayear = new int[12, 30];

            ////////////////jagged arrays --neither square not rectangular -- each element is an array itself////////////

          //not  using --  int[][] jagged = new int[12][];

            // using .Add for arraylist returns an index
            // .insert method can be used to insert at some particular index 


            ///////////////////////////////SORTING/////////////////////////////////////////////////
            
            ArrayWrapper warray = new ArrayWrapper(10);
            Random rnd = new Random(100);

            for(int i=0;i<10;i++)
            warray.insert((int)(rnd.NextDouble()*100));

            Console.WriteLine("Before  Sorting");
            warray.DisplayElements();

            Console.WriteLine("During  Sorting");
           // warray.BubbleSort();
           // warray.SelectionSort();
            warray.InsertionSort();

            Console.WriteLine("After  Sorting");
            warray.DisplayElements();
            /*
             * For the large datasets:
             * Insert sort is least efficient
             * Selection sort is most efficient 
             * 
             * For small datasets
             * the results are same as above but with very insignificant differences.
             */
            
            /////////////////////////Search Algorithms///////////////////////////////////

            /*
             * Not implementing the sequential search on an array(unordered data).
             * The idea is to match the given item with each of the elements in an array
             *To improve the efficieny of the sequential search.There are two ways that can be taken
             *based upon the probability analysis-- using the 80-20 rule i.e. 80% of the users 
             *always look for the 20% of the data.
             *Probablility distributions as such are called Pareto Distribution.
             *Google Knuth for more on probablity distributions on data sets.
             *So 
             *  If we move the data item being searched up in the array ,the sequential search can be improved significantly:
             *  a) We can check for the data item to be searched if it lies in the top 20% of the data.If it doesnt then move it to the top.
             *  b) Other way is to move the searched data upwards to replace its predecssor and slowly the most searched item will work its way to the top(using bubble sort)
                  
             */
            /////////////////// USING STACK ///////////////////////////////////////////////////
            /*
             *Seperating the use of the various datastructures into methods as the main method is growing big. 
             * Following calls an isPalindrome method which uses the Custom stack class to check if the string is a palindrome.
             * Palindrome is a string that is spelled same from both the starting as well as the last character.
             * for ex: sees,madam,dad etc.
             */

            string stringToBeChecked="seesa";
            if (isPalindrome(stringToBeChecked))
            {
                Console.WriteLine("{0} is a palindrome", stringToBeChecked);
            }
            else
                Console.WriteLine("{0} is not a palindrome", stringToBeChecked);


            // Using stack for an Expression evaluator

            Stack nums = new Stack();
            Stack ops = new Stack();
            string exp = "5+10+15+20+30";
            calculate(nums, ops, exp);
            Console.WriteLine(nums.Pop());




        }
        static void BuildArray(int[] arr)
        {
            for (int i = 0; i < 99999; i++)
                arr[i] = i;
        }
        static void DisplayNums(int[] nums)
        {
            for (int i = 0; i < nums.GetUpperBound(0); i++)
                Console.WriteLine(nums[i] + " ");
        }

        static void swap<T>(ref T val1, ref T val2)
        {
            T temp;
            temp = val1;
            val1 = val2;
            val2 = temp;
        }

        static bool isPalindrome(String stringTocheck)
        {
            if (stringTocheck == null)
                return false;

            bool isPal = true;
            CustomStack cs = new CustomStack();
            string ch;
            for (int x = 0; x < stringTocheck.Length; x++)
            {
                cs.push(stringTocheck.Substring(x, 1));
            }
            int pos = 0;

            while (cs.count > 0)
            {
                ch = cs.pop().ToString();

                if (ch != stringTocheck.Substring(pos, 1))
                {
                    isPal = false;
                    break;
                }

                pos++;
            }

                return isPal;
        }

        static bool isNumeric(string input)
        {
            bool flag = true;
            string pattern = (@"^\d+$");
            Regex validate = new Regex(pattern);
            if (!validate.IsMatch(input))
                flag = false;

            return flag;
 
        }
        static void calculate(Stack N, Stack O, string exp)
        {
            string ch, token = "";
            for (int p = 0; p < exp.Length; p++)
            {
                ch = exp.Substring(p, 1);
                if (isNumeric(ch))
                    token += ch;

                if (ch == " " || p == (exp.Length - 1))
                {
                    if (isNumeric(token))
                    {
                        N.Push(token);
                        token = "";
                    }
                }

                else if (ch == "+" || ch == "-" || ch == "*" || ch == "/")
                {
                    O.Push(ch);
                }
                if (N.Count == 2)
                {
                    Compute(N, O);
                }
            }
        }



        static void Compute(Stack N, Stack O)
        {
            int oper1, oper2;
            string oper;
            oper1 = Convert.ToInt32(N.Pop());
            oper2 = Convert.ToInt32(N.Pop());
            oper = Convert.ToString(O.Pop());

            switch(oper)
            {
                case "+":
                    N.Push(oper1 + oper2);
                        break;

                case "*":
                        N.Push(oper1 * oper2);
                        break;

                case "-":
                        N.Push(oper1 - oper2);
                        break;

                case "/":
                        N.Push(oper1 / oper2);
                        break;
            }
        }

        static int sumNums(params int[] nums)
        {
            int sum = 0;
            for (int i = 0; i <= nums.GetUpperBound(0); i++)
            {
                sum += nums[i];
            }
                return sum;
        }
    }
}
