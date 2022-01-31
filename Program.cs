using System;
using System.Collections.Generic;
using System.Linq;

namespace DIS_ISM_6225_Assignment1
{
    class Program
    {
        /* 
        <summary>
        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:
        Input: s = "MumaCollegeofBusiness"
        Output: "MmCllgfBsnss"
        Example 2:
        Input: s = "aeiou"
        Output: ""
        Constraints:
        •	0 <= s.length <= 10000
        s consists of uppercase and lowercase letters
        </summary>
        */

        private static string RemoveVowels(string s)
        {
            String final_string = "";
            // declaring capital vowels to make the code case-insensitive.
            Char[] vowel = new Char[5] { 'A', 'E', 'I', 'O', 'U' };
            int vow_flag;
            char letter;

            try
            {
                if (s.Length >= 0 && s.Length <= 10000)
                {
                    // Traverse through the given string length, to fetch each character
                    for (int i = 0; i < s.Length; i++)
                    {
                        vow_flag = 0;
                        letter = char.ToUpper(s[i]); // Case insensitive

                        // Traverse through the vowel array length
                        for (int j = 0; j < vowel.Length; j++)
                        {
                            // Identify whether the character is a vowel
                            if (letter == vowel[j])
                            {
                                vow_flag = 1;
                            }
                        }

                        //If not a vowel, append it in the string to be returned
                        if (vow_flag == 0)
                        {
                            final_string += letter;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Empty string is not allowed...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return final_string;
        }

        /* 
       <summary>
      Given two string arrays word1 and word2, return true if the two arrays represent the same string, and false otherwise.
      A string is represented by an array if the array elements concatenated in order forms the string.
      Example 1:
      Input: : bulls_string1 = ["Marshall", "Student",”Center”], : bulls_string2 = ["MarshallStudent ", "Center"]
      Output: true
      Explanation:
      word1 represents string "marshall" + "student" + “center” -> "MarshallStudentCenter "
      word2 represents string "MarshallStudent" + "Center" -> "MarshallStudentCenter"
      The strings are the same, so return true.
      Example 2:
      Input: word1 = ["Zimmerman", "School", ”of Advertising”, ”and Mass Communications”], word2 = ["Muma", “College”,"of”, “Business"]
      Output: false
      Example 3:
      Input: word1  = ["University", "of", "SouthFlorida"], word2 = ["UniversityofSouthFlorida"]
      Output: true
      </summary>
      */

        private static bool ArrayStringsAreEqual(string[] bulls_string1, string[] bulls_string2)
        {
            bool similar_flag = false;
            string trans_str1 = "";
            string trans_str2 = "";

            try
            {
                if (bulls_string1.Length != 0 && bulls_string2.Length != 0)
                {
                    // Concatenate entire array elements as a single string, and convert to Uppercase to make the logic robust for Case sensitive testcases, and triming it to remove whitespace characters. 
                    trans_str1 = String.Join("", bulls_string1).ToUpper().Trim();
                    trans_str2 = String.Join("", bulls_string2).ToUpper().Trim();

                    // Comparison
                    if (trans_str1 == trans_str2)
                    {
                        similar_flag = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please do not enter empty strings for comparison.");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }

            return similar_flag;
        }

        /*
      <summary> 
     You are given an integer array bull_bucks. The unique elements of an array are the elements that appear exactly once in the array.
     Return the sum of all the unique elements of nums.
     Example 1:
     Input: bull_bucks = [1,2,3,2]
     Output: 4
     Explanation: The unique elements are [1,3], and the sum is 4.
     Example 2:
     Input: bull_bucks = [1,1,1,1,1]
     Output: 0
     Explanation: There are no unique elements, and the sum is 0.
     Example 3:
     Input: bull_bucks = [1,2,3,4,5]
     Output: 15
     Explanation: The unique elements are [1,2,3,4,5], and the sum is 15.
     </summary>
      */

        private static int SumOfUnique(int[] bull_bucks)
        {
            int sum = 0;
            Dictionary<int, int> d;
            int len = bull_bucks.Length;

            try
            {
                if (len > 0 && len <= 100)
                {
                    // Dictionary perfectly fits this usecase, as the problem is around unique elemetns,
                    d = new Dictionary<int, int>();
                    foreach (int element in bull_bucks)
                    {
                        //Console.WriteLine(element);
                        if (element >= 1 && element <= 100)
                        {
                            //For existing element, increment the count, Else add a new element in the dcitionary with Value 1.
                            if (d.ContainsKey(element))
                                d[element] += 1;
                            else
                                d.Add(element, 1);
                        }
                        else return 0;
                    }

                    //Calcualte the sum of unique elemetns i.e whose count is 1.
                    foreach (var key_value in d)
                    {
                        if (key_value.Value == 1)
                        {
                            sum = sum + key_value.Key;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return sum;
        }

        /*
      <summary>
     Given a square matrix bulls_grid, return the sum of the matrix diagonals.
     Only include the sum of all the elements on the primary diagonal and all the elements on the secondary diagonal that are not part of the primary diagonal.
     Example 1:
     Input: bulls_grid = [[1,2,3],[4,5,6], [7,8,9]]
     Output: 25
     Explanation: Diagonals sum: 1 + 5 + 9 + 3 + 7 = 25
     Notice that element mat[1][1] = 5 is counted only once.
     Example 2:
     Input: bulls_grid = [[1,1,1,1], [1,1,1,1],[1,1,1,1], [1,1,1,1]]
     Output: 8
     Example 3:
     Input: bulls_grid = [[5]]
     Output: 5
     </summary>
      */

        private static int DiagonalSum(int[,] bulls_grid)
        {
            int mat_sum = 0;
            //Fetching the row and column shape of the array
            int row = bulls_grid.GetLength(0);
            int col = bulls_grid.GetLength(1);
            int mid_element_idx;

            try
            {
                // Fetching both the diagonal values in a row at once, and summing it up
                for (int i = 0; i < row; i++)
                {
                    mat_sum += (bulls_grid[i, i] + bulls_grid[i, col - 1]);
                    col--;
                }

                //  For Odd number of row: The above calculation include the middle element twice, so ignoring it once.
                if (row % 2 != 0)
                {
                    mid_element_idx = (int)Decimal.Round(row / 2);
                    mat_sum -= bulls_grid[mid_element_idx, mid_element_idx];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return mat_sum;
        }

        /*
         
        <summary>
        Given a string bulls_string  and an integer array indices of the same length.
        The string bulls_string  will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        Return the shuffled string.
        Example 3:
        Input: bulls_string  = "aiohn", indices = [3,1,4,2,0]
        Output: "nihao"
        */

        private static string RestoreString(string bulls_string, int[] indices)
        {
            int bulls_string_len = bulls_string.Length;
            int indices_len = indices.Length;
            string result = "null";

            string[] temp;
            int temp_ind;

            try
            {
                //Constraint Check
                if (bulls_string_len == indices_len && bulls_string_len >= 1 && bulls_string_len <= 100)
                {

                    // String matchcase
                    if (bulls_string.ToLower() == bulls_string)
                    {
                        temp = new string[bulls_string_len];

                        // Find the indices and replace the characters using the temp variables
                        for (int i = 0; i < bulls_string_len; i++)
                        {
                            temp_ind = indices[i];
                            if (temp_ind >= 0 && temp_ind < indices_len)
                            {
                                temp[temp_ind] = char.ToString(bulls_string[i]);
                            }
                            else
                            {
                                return "null";
                            }
                        }
                        result = string.Join("", temp);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        /*
         <summary>
        Given a 0-indexed string bulls_string   and a character ch, reverse the segment of word that starts at index 0 and ends at the index of the first occurrence of ch (inclusive). If the character ch does not exist in word, do nothing.
        For example, if word = "abcdefd" and ch = "d", then you should reverse the segment that starts at 0 and ends at 3 (inclusive). The resulting string will be "dcbaefd".
        Return the resulting string.
        Example 1:
        Input: bulls_string   = "mumacollegeofbusiness", ch = "c"
        Output: "camumollegeofbusiness"
        Explanation: The first occurrence of "c" is at index 4. 
        Reverse the part of word from 0 to 4 (inclusive), the resulting string is "camumollegeofbusiness".
        Example 2:
        Input: bulls_string   = "xyxzxe", ch = "z"
        Output: "zxyxxe"
        Explanation: The first and only occurrence of "z" is at index 3.
        Reverse the part of word from 0 to 3 (inclusive), the resulting string is "zxyxxe".
        Example 3:
        Input: bulls_string   = "zimmermanschoolofadvertising", ch = "x"
        Output: "zimmermanschoolofadvertising"
        Explanation: "x" does not exist in word.
        You should not do any reverse operation, the resulting string is "zimmermanschoolofadvertising".
        */

        private static string ReversePrefix(string bulls_string6, char ch)
        {
            string res = "";
            try
            {
                //Find the index of ch - in the passed string
                int idx = bulls_string6.IndexOf(ch);

                //Constarint check: case, and the length check
                if (char.ToLower(ch) == ch && bulls_string6.Length >= 1 && bulls_string6.Length <= 250)
                {
                    // Check to confirm the 'ch' mexists in the string
                    if (idx >= 0)
                    {
                        string[] temp = new string[bulls_string6.Length];

                        //Avoided 2 for loops using 2 variables in a single for loop - x and y--  to fetch the characters from the ch character in a reverse manner
                        int x = 0;
                        for (int y = idx; y >= 0; y--)
                        {
                            temp[x] = char.ToString(bulls_string6[y]);
                            x++;
                        }

                        //Fethed the rest part of the string, and appended it in the result
                        temp[x] = bulls_string6.Substring(x, bulls_string6.Length - x);
                        res = string.Join("", temp);
                    }
                    else
                    {
                        res = bulls_string6;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return res;
        }

        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1: Enter the string:");
            string s = Console.ReadLine();
            string final_string = RemoveVowels(s);
            Console.WriteLine("Final string after removing the Vowels: {0}", final_string);
            Console.WriteLine();

            //Question 2:
            string[] bulls_string1 = new string[] { "Marshall", "Student", "Center" };
            string[] bulls_string2 = new string[] { "MarshallStudent", "Center" };

            bool flag = ArrayStringsAreEqual(bulls_string1, bulls_string2);
            Console.WriteLine("Q2");
            if (flag)
            {
                Console.WriteLine("Yes, Both the array’s represent the same string");
            }
            else
            {
                Console.WriteLine("No, Both the array’s don’t represent the same string ");
            }
            Console.WriteLine();

            //Question 3:
            int[] bull_bucks = new int[] { 1, 2, 3, 2 };
            int unique_sum = SumOfUnique(bull_bucks);
            Console.WriteLine("Q3:");
            Console.WriteLine("Sum of Unique Elements in the array are: {0}", unique_sum);
            Console.WriteLine();


            //Question 4:
            int[,] bulls_grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Q4:");
            int diagSum = DiagonalSum(bulls_grid);
            Console.WriteLine("The sum of diagonal elements in the bulls grid is: {0}", diagSum);
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String bulls_string = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(bulls_string, indices);
            Console.WriteLine("The  Final string after rotation is: {0}", rotated_string);
            Console.WriteLine();

            //Quesiton 6:
            string bulls_string6 = "mumacollegeofbusiness";
            char ch = 'c';
            string reversed_string = ReversePrefix(bulls_string6, ch);
            Console.WriteLine("Q6:");
            Console.WriteLine("Resultant string are reversing the prefix: {0}", reversed_string);
            Console.WriteLine();

        }
    }
}