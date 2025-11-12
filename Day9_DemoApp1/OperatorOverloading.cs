using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day9_DemoApp1

{
    internal class OperatorOverloading
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(1, 2);
            Complex c2 = new Complex(1, 2);
            Complex sum = c1 + c2;
            Complex sub = c1 - c2;
            Complex mul = c1 * c2;
            Console.WriteLine(sum);
            Console.WriteLine(sub);
            Console.WriteLine(mul);
            Console.WriteLine($"equals method {c1.Equals(c2)}");
            Console.WriteLine(c1 == c2);
            Console.WriteLine(c1 != c2);
            Console.ReadLine();
        }
    }
    public class Complex
    {

        public int Real { get; set; }
        public int Imaginary { get; set; }
        private string lastOperator = " ";
        public Complex(int real, int imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex result = new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
            result.lastOperator = "+ (Addition)";
            return result;

        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex result = new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
            result.lastOperator = "- (subtraction)";
            return result;

        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            Complex result = new Complex(c1.Real * c2.Real, c1.Imaginary * c2.Imaginary);
            result.lastOperator = "* (Multiplication)";
            return result;

        }
        public static bool operator ==(Complex c1,Complex c2)
        {
            return (c1.Real==c2.Real && c1.Imaginary == c2.Imaginary);
        }
        public static bool operator !=(Complex c1, Complex c2)
        {
            return !(c1== c2);
        }
        public override bool Equals(object obj)
        {
            if (obj is Complex other)
            {
                return this.Real == other.Real && this.Imaginary == other.Imaginary;
            }return false;
        }
        public override string ToString()
        {
            return $"Operation: {lastOperator} -> Result={Real} +{Imaginary}i";
        }
    }
    }
   
    

