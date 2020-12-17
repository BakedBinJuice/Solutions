using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Password_Philosophy
{
    class ScanPass {

        // Function to find the first password policy integer of each line.
        public static int convertToInt(string str, int x, int y) {
            // First and second index of the line.
            var firstCharInt = str[x];
            var secondCharInt = str[y];

            // Convert the found integers to strings.
            string firstCharStr = firstCharInt.ToString();
            string secondCharStr = secondCharInt.ToString();
            // Add both characters together to create the whole number.
            string both = firstCharStr + secondCharStr;

            // Replace all non integers with nothing.
            string result = Regex.Replace(both, @"[^\d]", "");
            int finalChar;
            
            // convert the final string to an integer so we can perfrom mathematical operations.
            finalChar = int.Parse(result);
            return(finalChar);
        }

        // Function to find the second password policy integer of each line.
        public static int convertToThreeInt(string str, int x, int y, int n) {
            // Find the three given index's of the line to find the second integer.
            var firstCharInt = str[x];
            var secondCharInt = str[y];
            var thirdCharInt = str[n];

            // Convert all found integers to strings.
            string firstCharStr = firstCharInt.ToString();
            string secondCharStr = secondCharInt.ToString();
            string thirdCharStr = thirdCharInt.ToString();
            // Add all the strings together to get the whole numeber.
            string both = firstCharStr + secondCharStr + thirdCharStr;

            // Replace all non integers with nothing.
            string result = Regex.Replace(both, @"[^\d]", "");
            int finalChar;
            
            // Convert the final string to an integer.
            finalChar = int.Parse(result);
            return(finalChar);
        }

        // Function to find the letter to match against the password in the current line.
        public static string findLetterType(string str, int x, int y, int n) {
            // Find the three given index's of the line to find the letter.
            var firstCharInt = str[x];
            var secondCharInt = str[y];
            var thirdCharInt = str[n];

            // Convert the found Characters to strings so they can be added together.
            string firstCharStr = firstCharInt.ToString();
            string secondCharStr = secondCharInt.ToString();
            string thirdCharStr = thirdCharInt.ToString();
            // Add all the strings together.
            string both = firstCharStr + secondCharStr + thirdCharStr;

            // Replace all non letters with nothing.
            string result = Regex.Replace(both, @"[^a-zA-Z]", "");
            return(result);
        }

        public int part2() {
            // Read the data from the file.
            var readData = System.IO.File.ReadAllLines(@"data.txt");

            int invalid = 0;
            int valid = 0;

            // Loop over each line of the file.
            foreach(var lineRead in readData) {
                // Find the given index positions of each line.
                int firstInt = convertToInt(lineRead, 0, 1);
                int secondInt = convertToThreeInt(lineRead, 2, 3, 4);

                // Find the given character of each line and convert to a character.
                var letterType = findLetterType(lineRead, 4, 5, 6);
                char letterTypeChar = letterType[0];

                // Strip line of all non alphanumerical characters.
                string result = Regex.Replace(lineRead, @"[^a-zA-Z]", "");

                // Contain the indexed characters in variables.
                char firstChar = result[firstInt];
                char secondChar = result[secondInt];

                // If the first indexed character is equal to the character type but the second index position is not equal, password is valid.
                if (firstChar == letterTypeChar && secondChar != letterTypeChar) {
                    valid++;
                }

                // If the first indexed character is not equal to the character type but the second indexed character is equal, password is valid.
                else if (firstChar != letterTypeChar && secondChar == letterTypeChar) {
                    valid++;
                }

                // If the password does not follow the policy, it is invalid.
                else {
                    invalid++;
                }
            }

            return valid;
        }

        private int convertToInt(int v1, int v2)
        {
            throw new NotImplementedException();
        }

        // This is the function that checks the policy and counts how many passwords are valid.
        public void checkPass() {
            // Read all the lines of the data file.
            var readData = System.IO.File.ReadAllLines(@"data.txt");
            // Initiate a new Random object.
            Random random = new Random();

            // This variable keeps track of how many passwords are valid.
            int mainCount = 0;

            // For each line in the data file.
            foreach (var lineRead in readData) {
                // Find the first policy integer.
                int firstInt = convertToInt(lineRead, 0, 1);
                // Find the second Policy integer.
                int secondInt = convertToThreeInt(lineRead, 2, 3, 4);

                // Find the policy letter.
                string letterType = findLetterType(lineRead, 4, 5, 6);

                // This variable keeps track of how many times the policy letter occurs in the current line.
                int count = 0;

                // For loop that iterates through each character of the line.
                for(int n = 0; n!=lineRead.Length; n++) {
                    // Converts the index of 'n' in the line to a string to it can be compared to the policy integer.
                    string currString = lineRead[n].ToString();

                    // If the policy letter is equal to the current index of the line then increment count by one.
                    if (letterType == currString) {
                        count++;
                    }

                    // If the policy letter is not equal to the current index of the line, continue.
                    else {
                        continue;
                    }
                }

                // Subtract 1 from count, to account for the policy letter in the line.
                count = count - 1;

                // If count is >=  first policy integer and count <= second policy integer then increment the maincount by 1.
                if (count>=firstInt && count<=secondInt) {
                    mainCount++;
                }

                // If count does not meet the password policy, continue.
                else {
                    continue;
                }
            }

            Console.WriteLine("Part 1 answer: ");
            Console.WriteLine(mainCount);
            Console.WriteLine("Part 2 answer: " );
            var answer = part2();
            Console.WriteLine(answer);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Create a new ScanPass object.
            var ScanPass = new ScanPass();
            // Call the checkPass function.
            ScanPass.checkPass();
        }
    }

}

