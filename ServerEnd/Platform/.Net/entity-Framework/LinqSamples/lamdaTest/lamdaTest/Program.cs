using System;

namespace lamdaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var translator = new MyQueryTranslator();

            string whereClause = translator.Translate(null);

            // "".Equals();
            Console.WriteLine("Hello World!");
        }
    }
}
