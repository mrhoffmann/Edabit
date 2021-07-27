using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
// https://edabit.com/user/52MDMbhQDpyDjfCjL

namespace Edabit.Helpers
{
    public static class Challenge
    {
        /// <summary>
        /// Owofied a Sentence
        /// <para>Link: https://edabit.com/challenge/G3hRLmmrcMaGAbf6F</para>
        /// <para>Task: Create a function that takes a sentence and turns every "i" into "wi" and "e" into "we", and add "owo" at the end.</para>
        /// </summary>
        public static string Owofy(string p0) => p0.Replace("i", "wi").Replace("e", "we") + " owo";

        /// <summary>
        /// White Spaces Between Lower and Uppercase Letters
        /// <para>Link: https://edabit.com/challenge/df9LtdceySMvqQJtW</para>
        /// <para>Task: Write a function that inserts a white space between every instance of a lower character followed immediately by an upper character.</para>
        /// </summary>
        public static string WhiteSpace(string p0) => String.Concat(p0.Select(c => Char.IsUpper(c) ? $" {c}" : $"{c}")).Trim();

        /// <summary>
        /// Find the Bomb
        /// <para>Link: https://edabit.com/challenge/FbgicbJyLQan2pbde</para>
        /// <para>Task: Create a function that finds the word "bomb" in the given string (not case sensitive). If found, return "Duck!!!", otherwise return "There is no bomb, relax.".</para>
        /// </summary>
        public static string Bomb(string p0) => p0.ToLower().Contains("bomb") ? "Duck!!!" : "There is no bomb, relax.";

        /// <summary>
        /// IPv4 Validation
        /// <para>Link: https://edabit.com/challenge/BNKRr4N2oFZQfrTY3</para>
        /// <para>Task: Create a function that takes a string (IPv4 address in standard dot-decimal format) and returns true if the IP is valid or false if it's not. For information on IPv4 formatting, please refer to the resources in the Resources tab.</para>
        /// </summary>
        public static bool IsValidIP(string p0)
        {
            string[] split = p0.Split(".");
            if (ValidLength(split)) return false;
            if (!NumbersMayOnlyBeBetween1And255(split)) { return false; }
            foreach (string s in split)
            {
                if (!ValidByte(s)) { return false; }
                if (ValidLeadingDigit(s)) { return false; }
            }
            return split[3] != "0";
        }

        #region Helpers
        private static bool ValidLength(string[] p0) => p0.Length > 4 || p0.Length < 4;
        private static bool ValidByte(string p0) => byte.TryParse(p0, out _);
        private static bool NumbersMayOnlyBeBetween1And255(string[] p0)
        {
            foreach (var _ in from item in p0
                              let temp = byte.Parse(item)
                              where temp < 1 || temp > 255
                              select new { })
            {
                return false;
            }
            return true;
        }
        private static bool ValidLeadingDigit(string p0) => p0.StartsWith("0") && p0.Length > 1;
        #endregion

        /// <summary>
        /// Count Letters in a Word Search
        /// <para>Link: https://edabit.com/challenge/bsPZtsX62zQmRHNjX</para>
        /// <para>Task: Create a function that counts the number of times a particular letter shows up in the word search.</para>
        /// </summary>
        public static int LetterCounter(string[][] p0, string p1)
        {
            int retval = 0;
            foreach (var a in p0) { foreach (var b in a) { if (b.Equals(p1)) retval++; } }
            return retval;
        }

        /// <summary>
        /// Absolute Sum
        /// <para>Link: https://edabit.com/challenge/jBFpjEG3tvsjTZbD4</para>
        /// <para>Task: Take an array of integers (positive or negative or both) and return the sum of the absolute value of each element.</para>
        /// </summary>
        public static int GetAbsValue(int[] array)
        {
            var retval = 0;
            for (var i = 0; i < array.Length; i++) { retval += array[i] < 0 ? array[i] * -1 : array[i] * 1; }
            return retval;
        }

        /// <summary>
        /// Perfect Square Patch
        /// <para>Link: https://edabit.com/challenge/omTRzwvBibk4etBkx</para>
        /// <para>Task: Create a function that takes an integer and outputs an n x n square solely consisting of the integer n.</para>
        /// </summary>
        public static object SquarePatch(int p0)
        {
            if(p0 == 1) return new int[] { p0 };
            var retval = new int[p0][];
            for (int i = 0; i < p0; i++)
            {
                var arr = new List<int>();
                for(int j = 0; j < p0; j++)
                {
                    arr.Add(p0);
                }
                retval[i] = arr.ToArray();
            }
            return retval;
        }

        /// <summary>
        /// Valid Hex Code
        /// <para>Link: https://edabit.com/challenge/ZhEBoaEfMcK6vT7Kx</para>
        /// <para>Task: Create a function that determines whether a string is a valid hex code. A hex code must begin with a pound key # and is exactly 6 characters in length. Each character must be a digit from 0-9 or an alphabetic character from A-F. All alphabetic characters may be uppercase or lowercase.</para>
        /// </summary>
        public static bool ValidHexCode(string hex) => new Regex("^\\#[0-9a-fA-F]{6}$").IsMatch(hex);

        /// <summary>
        /// Toy Car Workshop
        /// <para>Link: https://edabit.com/challenge/Ccoo3SHJwv4qCLKQb</para>
        /// <para>Task: You work in a toy car workshop, and your job is to build toy cars from a collection of parts. Each toy car needs 4 wheels, 1 car body, and 2 figures of people to be placed inside. Given the total number of wheels, car bodies and figures available, how many complete toy cars can you make?</para>
        /// </summary>
        public static int Cars(int p0, int p1, int p2)
        {
            int retval = 0;
            while(p0 > 4 && p1 > 1 && p2 > 2)
            {
                p0 -= 4;
                p1 --;
                p2 -= 2;
                retval++;
            }

            return retval;
        }

        /// <summary>
        /// Tic Tac Toe
        /// <para>Link: https://edabit.com/challenge/rscwis53jKokoKRYo</para>
        /// <para>Task: Create a function that takes an array of char inputs from a Tic Tac Toe game. Inputs will be taken from player1 as "X", player2 as "O", and empty spaces as "#". The program will return the winner or tie results.</para>
        /// </summary>
        public static string TicTacToe(char[][] p0)
        {
            if (p0.Length < 3 || p0.Length > 3) return "invalid array size";
            foreach (char c in new char[] { 'x', 'o' })
            {
                if (
                    (p0[0][0] == c && p0[1][0] == c && p0[2][0] == c) ||
                    (p0[0][1] == c && p0[1][1] == c && p0[2][1] == c) ||
                    (p0[0][2] == c && p0[1][2] == c && p0[2][2] == c))
                {
                    return "Player " + (c == 'o' ? 1 : 2) + " won";
                } if (
                    (p0[1][0] == c && p0[1][1] == c && p0[2][2] == c) ||
                    (p0[0][2] == c && p0[1][1] == c && p0[2][0] == c))
                {
                    return "Player " + (c == 'o' ? 1 : 2) + " won";
                } if (
                    (p0[1][0] == c && p0[1][1] == c && p0[1][2] == c) ||
                    (p0[0][0] == c && p0[0][1] == c && p0[0][2] == c) ||
                    (p0[2][0] == c && p0[2][1] == c && p0[2][2] == c))
                {
                    return "Player " + (c == 'o' ? 1 : 2) + " won";
                }
            }
            return "No one won";
        }

        /// <summary>
        /// Broken Bridge
        /// <para>Link: https://edabit.com/challenge/udrQ2ckXP9cXNXiSk</para>
        /// <para>Task: Create a function which validates whether a bridge is safe to walk on (i.e. has no gaps in it to fall through).</para>
        /// </summary>
        public static bool BrokenBridge(string p0) => p0.Any(c => c == ' ');

        /// <summary>
        /// Accumulating Array
        /// <para>Link: https://edabit.com/challenge/TmL3qiZE7c25TLmSj</para>
        /// <para>Task: Create a function that takes in an array and returns an array of the accumulating sum. </para>
        /// </summary>
        public static int[] AccumulatingArray(int[] p0)
        {
            for(int i = 1; i < p0.Length; i++) { p0[i] = p0[i - 1] + p0[i]; }
            return p0;
        }

        /// <summary>
        /// Letters Only
        /// <para>Link: https://edabit.com/challenge/azvb6mtiQvRGo6XTf</para>
        /// <para>Task: Check if the given string consists of only letters and spaces and if every letter is in lower case.</para>
        /// </summary>
        public static bool LettersOnly(string p0)
        {
            if (p0.Length < 1) return false;
            p0 = p0.Replace(" ", string.Empty);
            return p0.Count(c => Char.IsLower(c)) == p0.Length;
        }

        /// <summary>
        /// Reverse Coding Challenge #1
        /// <para>Link: https://edabit.com/challenge/gtdyy97TTDPWkei9d</para>
        /// <para>Task: This is a reverse coding challenge. Normally you're given explicit directions with how to create a function. Here, you must generate your own function to satisfy the relationship between the inputs and outputs. Your task is to create a function that, when fed the inputs below, produce the sample outputs shown.</para>
        /// </summary>
        public static string ReverseCodingChallengeNumber1(string p0)
        {
            string retval = "";
            for(int i = 1; i < p0.Length; i+=2) { retval += new String(p0[i-1], int.Parse(p0[i].ToString())); }
            return retval;
        }

        /// <summary>
        /// Burrrrrrrp
        /// <para>Link: https://edabit.com/challenge/xFaPak5hmiR3vpH6M</para>
        /// <para>Task: Create a function that returns the string "Burp" with the amount of "r's" determined by the input parameters of the function.</para>
        /// </summary>
        public static string LongBurp(int p0) => "Bu" + new String('r', p0) + "p";

        /// <summary>
        /// Caesar's Cipher
        /// <para>Link: https://edabit.com/challenge/GmPfqu2jmLDBD2NYS</para>
        /// <para>Task: Julius Caesar protected his confidential information by encrypting it using a cipher. Caesar's cipher (check Resources tab for more info) shifts each letter by a number of letters. If the shift takes you past the end of the alphabet, just rotate back to the front of the alphabet. In the case of a rotation by 3, w, x, y and z would map to z, a, b and c. Create a function that takes a string s(text to be encrypted) and an integer k(the rotation factor). It should return an encrypted string.</para>
        /// </summary>
        public static string CaesarCipher(string p0, int p1)
        {
            string retval = "";
            foreach (char ch in p0)
            {
                if (char.IsLetter(ch)) retval += (char)(((ch + p1 - (char.IsUpper(ch) ? 'A' : 'a')) % 26) + (char.IsUpper(ch) ? 'A' : 'a'));
                if (ch == ' ') retval += " ";
                if (ch == '-') retval += "-";
            }
            return retval;
        }

        /// <summary>
        /// Message from Space
        /// <para>Link: https://edabit.com/challenge/58iEEYqxFdnkBjEiA</para>
        /// <para>Task: You have received an encrypted message from space.</para>
        /// </summary>
        public static string SpaceMessage(string p0)
        {
            const string pattern = @"\[(([0-9]+)([a-zA-Z]+))\]";
            if (!Regex.IsMatch(p0, pattern)) return p0;

            do
            {
                var temp = Regex.Match(p0, pattern).Groups;
                for (var i = 0; i < temp.Count; i++)
                {
                    if (int.TryParse(temp[i].ToString(), out _))
                    {
                        p0 = p0.Replace(
                                temp[0].ToString(),
                                string.Concat(
                                    Enumerable.Repeat(
                                        temp[i + 1].ToString(), 
                                        int.Parse(temp[i].ToString())
                                    )
                                )
                            );
                    }
                }
            } while (Regex.IsMatch(p0, pattern));
            return p0;
        }

        /// <summary>
        /// Convert Number to Corresponding Month Name
        /// <para>Link: https://edabit.com/challenge/uevxL5FNM77otyo9Z</para>
        /// <para>Task: Convert Number to Corresponding Month Name</para>
        /// </summary>
        public static string MonthName(int p0) => new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" }[p0];

        /// <summary>
        /// Less Than 100?
        /// <para>Link: https://edabit.com/challenge/3ZwEJFANGaSpqnzrs</para>
        /// <para>Task: Given two numbers, return true if the sum of both numbers is less than 100. Otherwise return false.</para>
        /// </summary>
        public static bool LessThan100(int p0, int p1) => p0 + p1 < 100;

        /// <summary>
        /// Return the Remainder from Two Numbers
        /// <para>Link: https://edabit.com/challenge/4p5WBxogs2ENAb4Wu</para>
        /// <para>Task: There is a single operator in C#, capable of providing the remainder of a division operation. Two numbers are passed as parameters. The first parameter divided by the second parameter will have a remainder, possibly zero. Return that value.</para>
        /// </summary>
        public static int Remainder(int p0, int p1) => p0 % p1;

        /// <summary>
        /// Array of Multiples
        /// <para>Link: https://edabit.com/challenge/4p5WBxogs2ENAb4Wu</para>
        /// <para>Task: Create a function that takes two numbers as arguments (num, length) and returns an array of multiples of num until the array length reaches length.</para>
        /// </summary>
        public static int[] ArrayOfMultiples(int p0, int p1)
        {
            int[] retval = new int[p1];
            for(var i = 0; i < p1; i++) { retval[i] = p0 * (i+1); }
            return retval;
        }

        /// <summary>
        /// Positive Count / Negative Sum
        /// <para>Link: https://edabit.com/challenge/SXeEZPxDM9Y5HzLvw</para>
        /// <para>Task: Create a function that takes an array of positive and negative numbers. Return an array where the first element is the count of positive numbers and the second element is the sum of negative numbers.</para>
        /// </summary>
        public static int[] CountPosSumNeg(double[] p0)
        {
            if (p0.Length < 1) return new int[] { };
            return new int[] { p0.Where(x => x > 0).Count(), int.Parse(p0.Sum(x => (x < 0 ? x : 0)).ToString()) };
        }

        /// <summary>
        /// Find the Largest Numbers in a Group of Arrays
        /// <para>Link: https://edabit.com/challenge/nermqxzovZbfFBC9X</para>
        /// <para>Task: Create a function that takes an array of arrays with numbers. Return a new (single) array with the largest numbers of each.</para>
        /// </summary>
        public static double[] FindLargest(double[][] p0)
        {
            double[] retval = new double[p0.Length];
            for(var i = 0; i < p0.Length; i++)
            {
                retval[i] = p0[i][p0[i].ToList().IndexOf(p0[i].Max())];
            }
            return retval;
        }

        /// <summary>
        /// Return the Next Number from the Integer Passed
        /// <para>Link: https://edabit.com/challenge/NAQhEoxbofPidLxm9</para>
        /// <para>Task: Create a function that takes a number as an argument, increments the number by +1 and returns the result.</para>
        /// </summary>
        public static int Addition(int p0) => ++p0;

        /// <summary>
        /// The Collatz Conjecture
        /// <para>Link: https://edabit.com/challenge/F6m5ZRyzK5fmqTrBG</para>
        /// <para>Task: Create a function to repeatedly evaluate these operations, until reaching 1. Return the number of steps it took.</para>
        /// </summary>
        public static int Collatz(int p0)
        {
            int retval = 0;
            do
            {
                p0 = p0 % 2 == 0 ? p0 / 2 : (p0 * 3) + 1;
                retval++;
            } while (p0 != 1);
            return retval;
        }

        /// <summary>
        /// Return the Sum of Two Numbers
        /// <para>Link: https://edabit.com/challenge/3LpBLgNRyaHMvNb4j</para>
        /// <para>Task: Create a function that takes two numbers as arguments and return their sum.</para>
        /// </summary>
        public static int Addition(int p0, int p1) => p0 + p1;

        /// <summary>
        /// Fraction Greater Than One
        /// <para>Link: https://edabit.com/challenge/uCtG3Gtfx7fgNWM58</para>
        /// <para>Task: Given a fraction as a string, return whether or not it is greater than 1 when evaluated.</para>
        /// </summary>
        public static bool GreaterThanOne(string p0) => double.Parse(p0.Split("/")[0]) / double.Parse(p0.Split("/")[1]) > 1;

        /// <summary>
        /// Reverse the Case
        /// <para>Link: https://edabit.com/challenge/99oN5igrbXddAjHEL</para>
        /// <para>Task: Given a string, create a function to reverse the case. All lower-cased letters should be upper-cased, and vice versa.</para>
        /// </summary>
        public static string ReverseCase(string p0)
        {
            char[] arr = new char[p0.Length]; int i = 0;
            foreach (char v in p0) { if (char.IsUpper(v)) arr[i] = char.ToLower(v); else arr[i] = char.ToUpper(v); i++; }
            return new string(arr);
        }

        /// <summary>
        /// Return the Highest and Lowest Numbers
        /// <para>Link: https://edabit.com/challenge/zcuASzWmpFHpPtrbH</para>
        /// <para>Task: Create a function that accepts a string of space separated numbers and returns the highest and lowest number (as a string).</para>
        /// </summary>
        public static string HighLow(string p0) => $"{p0.Split(" ").Max(element => int.Parse(element))} {p0.Split(" ").Min(element => int.Parse(element))}";

        /// <summary>
        /// Is the Number Symmetrical?
        /// <para>Link: https://edabit.com/challenge/H77JNgLtEnQcX5hcu</para>
        /// <para>Task: Create a function that takes a number as an argument and returns true or false depending on whether the number is symmetrical or not. A number is symmetrical when it is the same as its reverse.</para>
        /// </summary>
        public static bool IsSymmetrical(int p0) => new string(p0.ToString().ToCharArray().Reverse().ToArray()) == p0.ToString();

        /// <summary>
        /// Convert All Array Items to String
        /// <para>Link: https://edabit.com/challenge/hqTYj7NbLnCcjxryi</para>
        /// <para>Task: Create a function that takes an array of integers and strings, converts integers to strings, and returns the array as a string array.</para>
        /// </summary>
        public static string[] ParseArray(object[] p0) => Array.ConvertAll(p0, element => element.ToString());

        /// <summary>
        /// ATM PIN Code Validation
        /// <para>Link: https://edabit.com/challenge/gBYEFXeD9G2JMZ9dD</para>
        /// <para>Task: ATM machines allow 4 or 6 digit PIN codes and PIN codes cannot contain anything but exactly 4 digits or exactly 6 digits. Your task is to create a function that takes a string and returns true if the PIN is valid and false if it's not.</para>
        /// </summary>
        public static bool ValidatePIN(string p0) => p0.All(Char.IsDigit) && (p0.Length == 4 || p0.Length == 6);

        /// <summary>
        /// Check if a Number is a Palindrome
        /// <para>Link: https://edabit.com/challenge/qrJyh8ouvr2iseZy4</para>
        /// <para>Task: Create a function that returns true if a number is a palindrome.</para>
        /// </summary>
        public static bool IsPalindrome(int p0) => new string(p0.ToString().ToCharArray().Reverse().ToArray()) == p0.ToString();

        /// <summary>
        /// Maskify the String
        /// <para>Link: https://edabit.com/challenge/RFeBL2TzSf7mRMNJi</para>
        /// <para>Task: Your task is to create a function that takes a string, transforms all but the last four characters into "#" and returns the new masked string.</para>
        /// </summary>
        public static string Maskify(string p0) => p0.Length > 0 ? p0.Length > 4 ? new string('#', p0.Length - 4) + p0.Substring(p0.Length - 4, 4) : p0 : "";

        /// <summary>
        /// Seven Boom!
        /// <para>Link: https://edabit.com/challenge/z2pzd2AJ3zr32uedG</para>
        /// <para>Task: Create a function that takes an array of numbers and return "Boom!" if the digit 7 appears in the array. Otherwise, return "there is no 7 in the array".</para>
        /// </summary>
        public static string SevenBoom(int[] p0) => p0.Any(x => x.ToString().Contains("7")) ? "Boom!" : "there is no 7 in the array";
    }
}
