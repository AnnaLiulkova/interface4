using interface4;

namespace interface4.Tests
{
    [TestClass]
    public class interface4Test
    {
        [TestMethod]
        public void TestAddition()
        {
            var a = new MyFrac(1, 2);
            var b = new MyFrac(1, 3);
            var result = a.Add(b);
            Assert.AreEqual(new MyFrac(5, 6), result);
        }

        [TestMethod]
        public void TestSubtraction()
        {
            var a = new MyFrac(3, 4);
            var b = new MyFrac(1, 4);
            var result = a.Subtract(b);
            Assert.AreEqual(new MyFrac(1, 2), result);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            var a = new MyFrac(2, 3);
            var b = new MyFrac(3, 4);
            var result = a.Multiply(b);
            Assert.AreEqual(new MyFrac(1, 2), result);
        }

        [TestMethod]
        public void TestDivision()
        {
            var a = new MyFrac(3, 4);
            var b = new MyFrac(2, 3);
            var result = a.Divide(b);
            Assert.AreEqual(new MyFrac(9, 8), result);
        }

        [TestMethod]
        public void TestDivisionByZero()
        {
            var a = new MyFrac(1, 3);
            Assert.ThrowsException<DivideByZeroException>(() => a.Divide(new MyFrac(0, 1)));
        }

        [TestMethod]
        public void TestEquality()
        {
            var a = new MyFrac(2, 4);
            var b = new MyFrac(1, 2);
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void TestToString()
        {
            var a = new MyFrac(5, 6);
            Assert.AreEqual("5/6", a.ToString());
        }

        [TestMethod]
        public void TestAddition1()
        {
            var a = new MyComplex(1, 3);
            var b = new MyComplex(1, 6);
            var result = a.Add(b);
            Assert.AreEqual(new MyComplex(2, 9), result);
        }

        [TestMethod]
        public void TestSubtraction1()
        {
            var a = new MyComplex(3, 4);
            var b = new MyComplex(1, 2);
            var result = a.Subtract(b);
            Assert.AreEqual(new MyComplex(2, 2), result);
        }

        [TestMethod]
        public void TestMultiplication1()
        {
            var a = new MyComplex(3, 2);
            var b = new MyComplex(1, 4);
            var result = a.Multiply(b);
            Assert.AreEqual(new MyComplex(-5, 14), result);
        }

        [TestMethod]
        public void TestDivision1()
        {
            var a = new MyComplex(2, 3);
            var b = new MyComplex(1, 1);
            var result = a.Divide(b);
            Assert.AreEqual(new MyComplex(2.5, 0.5), result);
        }

        [TestMethod]
        public void TestDivisionByZero1()
        {
            var a = new MyComplex(1, 1);
            Assert.ThrowsException<DivideByZeroException>(() => a.Divide(new MyComplex(0, 0)));
        }

        [TestMethod]
        public void TestEquality1()
        {
            var a = new MyComplex(1.0, 3.0);
            var b = new MyComplex(1.0, 3.0);
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void TestToString1()
        {
            var a = new MyComplex(2, -3);
            Assert.AreEqual("2-3i", a.ToString());
        }

        [TestMethod]
        public void TestSquaresDifference_Fractions()
        {
            var a = new MyFrac(2, 3);
            var b = new MyFrac(1, 3);
            var aSquare = a.Multiply(a);
            var bSquare = b.Multiply(b);
            var diff = aSquare.Subtract(bSquare);
            var aMinusB = a.Subtract(b);
            var aPlusB = a.Add(b);
            var product = aMinusB.Multiply(aPlusB);
            Assert.AreEqual(diff, product);
        }

        [TestMethod]
        public void TestSquaresDifference_Complex()
        {
            var a = new MyComplex(3, 4);
            var b = new MyComplex(1, 2);
            var aSquare = a.Multiply(a);
            var bSquare = b.Multiply(b);
            var diff = aSquare.Subtract(bSquare);
            var aMinusB = a.Subtract(b);
            var aPlusB = a.Add(b);
            var product = aMinusB.Multiply(aPlusB);
            Assert.AreEqual(diff, product);
        }
    }
}