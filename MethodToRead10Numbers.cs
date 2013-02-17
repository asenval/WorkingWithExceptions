using System;

class MethodToRead10Numbers
{
    static void Main()
    {
        int start = 1;
        int end = 100;
        int[] intArray = new int[10];
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Insert Number in interval ({0} - {1}):", start, end);
            try
            {
                intArray[i] = ReadNumber(start, end);
                start = intArray[i];
            }
            catch (FormatException fex)
            {
                Console.Error.WriteLine("Error: " + fex.Message);
                i--;
            }
            catch (ArgumentOutOfRangeException aex)
            {
                Console.Error.WriteLine("Error: " + aex.Message);
                i--;
            }
            
        }
        Console.Write(intArray[0]);
        for (int i = 1; i < 10; i++)
        {
            Console.Write(", {0}", intArray[i]);
        }
        Console.WriteLine();
    }

    static int ReadNumber(int start, int end)
    {
        int n=0;
        if (int.TryParse(Console.ReadLine(), out n) == false)
        {
            throw new FormatException("You don't entered an integer number");
        }
        if (n < start || n > end)
        {
            throw new ArgumentOutOfRangeException(String.Format("Number is out of ({0} - {1}):", start, end));
        }
        return n;
    }
}
