using System.ComponentModel.DataAnnotations;
using System.Numerics;
using static System.Int32;

namespace Numberer;

class Program
{
    static void Main(string[] args)
    {
        string name = "Danica Ellefsen Kvilhaug";
        Console.WriteLine($"Luhn Checker by {name}");
        
        // Try a foreach loop to BigInteger.Parse all numbers needed checking.
        Checker("42424242424242424242");
    }
    
    /// <summary>
    /// A method for checking a number using the Luhn Algorithm.
    /// </summary>
    /// <param name="num">The number to check.</param>
    /// <returns>(bool): True if the number is valid according to the Luhn algorithm, otherwise False.</returns>
    static bool Checker(string num)
    {
        // Parses the string of numbers into a BigInteger so we can divide by 10 to remove the last digit.
        BigInteger parsedNum = BigInteger.Parse(num);
        BigInteger removedLastDigit = parsedNum / 10;

        string luhnCheckedNum = Luhn(removedLastDigit.ToString());

        //Console.WriteLine(parsedNum);
        //Console.WriteLine(luhnCheckedNum);
        
        return parsedNum == BigInteger.Parse(luhnCheckedNum) || true;
    }
    
    /// <param name="num">The number to check.</param>
    /// <returns>(BigInteger): The check digit for the provided number.</returns>
    static string Luhn(string num)
    {
        int iStep = 0;
        int[] storedDigits = [];

        foreach (char i in num)
        {
            // Tries to Parse i into an int intI, throws an exception error if it doesn't work
            if (!TryParse(i.ToString(), out int intI)) throw new Exception($"Error: {i} is not an int... Use numbers only!");
            
            if (iStep % 2 == 0)
            {
                int doubledIntI = intI * 2;
                storedDigits[iStep] = doubledIntI;
                
                iStep++;
                continue;
            }
            storedDigits[iStep] = intI;
            iStep++;
        }
        
        
        // math algorithm = 10 - (num % 10)
        
        throw new Exception("Luhn(): Not yet implemented.");
    }
}

/*
 * 42424242424242424242
   82435252154365464568
   12345678903104823332
   45698773452345435446
   78907345342534253458
   12344435423542354235
   42000035154645645643
   69420843534543534553
   84589023457892345980
   53420582349058903488
*/