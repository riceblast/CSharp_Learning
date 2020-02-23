using System;

namespace ConsoleAppCaculator {
    class Program {
        static void Main(string[] args) {
            int num1 = 0, num2 = 0;
            double? result = null;
            string myOperator,op1,op2;


            while (true) {
                Console.Write("first num:");//第一个操作数
                op1 = Console.ReadLine();
                if (!Int32.TryParse(op1, out num1))
                    continue;

                Console.Write("second num:");//第二个操作数
                op2 = Console.ReadLine();
                if (!Int32.TryParse(op2, out num2))
                    continue;

                Console.Write("operator:"); //操作符
                myOperator = Console.ReadLine();
                switch (myOperator) {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                            Console.WriteLine("不能除0");
                        break;
                    default: {
                            Console.WriteLine("无效运算符");
                            break;
                        }
                    
                }

                if (result != null)
                    Console.WriteLine($"result:{result}");

            }

        }
    }
}
