using System;

namespace interface4
{
    class Program
    {
        static void Main(string[] args)
        {
            testAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            testAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));

            testSquaresDifference(new MyFrac(2, 3), new MyFrac(1, 3));
            testSquaresDifference(new MyComplex(3, 4), new MyComplex(1, 2));
        }

        static void testAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab
                                   // I’m not sure how to create constant factor "2" in more elegant way,
                                   // without knowing how IMyNumber is implemented
            Console.WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }

        static void testSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing a^2 - b^2 = (a - b)(a + b) with a = " + a + ", b = " + b + " ===");
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            T aSquare = a.Multiply(a);
            T bSquare = b.Multiply(b);
            Console.WriteLine("a^2 = " + aSquare);
            Console.WriteLine("b^2 = " + bSquare);
            T squareDifference = aSquare.Subtract(bSquare);
            Console.WriteLine("a^2 - b^2 = " + squareDifference);
            T aMinusB = a.Subtract(b);
            T aPlusB = a.Add(b);
            Console.WriteLine("(a - b) = " + aMinusB);
            Console.WriteLine("(a + b) = " + aPlusB);
            T product = aMinusB.Multiply(aPlusB);
            Console.WriteLine("(a - b)(a + b) = " + product);
            Console.WriteLine("=== Finishing testing a^2 - b^2 = (a - b)(a + b) with a = " + a + ", b = " + b + " ===");
        }
    }
}