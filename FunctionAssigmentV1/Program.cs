namespace FunctionAssigmentV1
{
    internal class Program
    {
        ///<summary>
        ///Ask the user for their name and validate the input.
        ///</summary>
        ///<returns>Returns valid name input</returns>
        static string AskName()
        {
            string name; // Declare variable in correct scope
            while (true)
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine() ?? ""; // Ensure non-null assignment
                if (!string.IsNullOrWhiteSpace(name))
                    break;
                else
                    Console.WriteLine("Name cannot be empty.");
            }
            return name;
        }
        ///<summary>
        ///Ask the user for their age and validate the input
        ///</summary>
        ///<returns>Returns valid age input</returns>
        static int AskAge()
        {
            int age; // Declare variable in correct scope
            while (true)
            {
                Console.Write("Enter your age: ");
                string input = Console.ReadLine() ?? ""; // Ensure non-null assignment
                if (int.TryParse(input, out age) && age > 0)
                    break;
                else
                    Console.WriteLine("Please enter a positive integer.");
            }
            return age;
        }
        ///<summary>
        ///takes the name and age info to print it
        ///</summary>
        ///<returns>A console message with the users name and age</returns>
        static void PrintInfo(string name, int age)
        {
            Console.WriteLine($"Your name is {name} and your age is {age}.");
        }
        ///<summary>
        ///checks the users age
        ///</summary>
        ///<returns>Age of user is they are under 18</returns>
        static bool CheckAdult(int age)
        {
            return age >= 18; 
        }
        ///<summary>
        ///takes the users name and compares it to a set name
        ///</summary>
        ///<returns>Returns the way in which the users name matches the set name</returns>
        static void CompareName(string name, string compareTo)
        {
            // Comparison ignoring case
            if (name.Equals(compareTo, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("Your name matches 'Matti' (case-insensitive).");

            // Exact match comparison (case-sensitive)
            if (name.Equals(compareTo))
                Console.WriteLine("Your name is exactly 'Matti' (case-sensitive).");
        }

        static void Main(string[] args)
        {
            string name = AskName(); // Get valid name
            int age = AskAge();      // Get valid age

            PrintInfo(name, age);
            bool isFullAge = CheckAdult(age);

            if (isFullAge)
                Console.WriteLine("You are an adult.");
            else
                Console.WriteLine("You are not an adult.");

            // Compare the name to another string (e.g., "Matti")
            CompareName(name, "Matti");

            Console.WriteLine();
            Console.Write("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}