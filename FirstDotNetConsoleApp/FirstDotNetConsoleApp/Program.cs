using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDotNetConsoleApp
{
    class Program
    {
        /// <summary>
        /// This sample shows how to create instance of Java class, call methods and get/set fields.
        /// 
        /// The Java class we use for the sample is:
        /// 
        /// 
        /// <code>
        /// public class SampleJavaClass {
        ///     public Integer numberA;
        ///     public Integer numberB;
        ///     
        ///     public Integer SumAandB()
        ///     {
        ///         return numberA + numberB;
        ///     }
        ///     
        ///     public Integer Multiply(Integer a, Integer b)
        ///     {
        ///         return a * b;
        ///     }
        ///     
        ///     public String SayHello(String name)
        ///     {
        ///         return "Hello " + name;
        ///     }
        /// }
        /// </code>
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Activating Javonet...");
            //You can obtain your free trial key at: https://my.javonet.com/signup/ 
            //Check more at http://www.javonet.com
            JavonetBridge.Javonet.Activate("your@mail.com", "your-license-key",
                @"C:\Program Files (x86)\Java\jdk1.8.0_144");

            JavonetBridge.Javonet.AddReference(@"SampleJavaJar.jar");

            //Creating instance of Java class
            var sampleClass = JavonetBridge.Javonet.New("SampleJavaClass");

            //Calling instance methods
            String res = sampleClass.Invoke<String>("SayHello", "Student");
            Console.WriteLine("Java method 'SayHello' returned: " + res);

            //Setting fields
            sampleClass.Set("numberA", 4);
            sampleClass.Set("numberB", 8);

            //Getting fields
            var a = sampleClass.Get<int>("numberA");
            Console.WriteLine("Field 'numberA' has value: " + a);
            var b = sampleClass.Get<int>("numberB");
            Console.WriteLine("Field 'numberB' has value: " + b);

            //Calling instance methods with int result
            int result = sampleClass.Invoke<int>("SumAandB");
            Console.WriteLine("Sum of A and B is: " + result);

            //Calling method passing int arguments
            int multiplyResult = sampleClass.Invoke<int>("Multiply", 10, 4);
            Console.WriteLine("Result of multiplying 10 and 4 is: " + multiplyResult);

            Console.WriteLine("\n\nCongratulations! You just called Java from .NET. Easy, isn't it?");
            Console.ReadLine();
        }
    }
}
