using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool inputValidity = false;

            int indexOfSpace;
            int rowNumber = 0;
            int locationNumber = 0;

            // 获取用户输入并检测合法性
            Console.WriteLine("该程序用于计算杨辉三角中第 n 行的第 m 个数字");
            Console.WriteLine("请输入 n 和 m（取值范围：1 <= m <= n <= 10000），以空格间隔：");
            string input = Console.ReadLine();
            while (!inputValidity)
            {
                if (!input.Contains(' '))
                {
                    Console.WriteLine("输入中必须包含空格，请重新输入：");
                    input = Console.ReadLine();
                }
                else
                {
                    indexOfSpace = input.IndexOf(' ');
                    try
                    {
                        rowNumber = Convert.ToInt32(input.Substring(0, indexOfSpace));
                        locationNumber = Convert.ToInt32(input.Substring(indexOfSpace + 1,
                            input.Length - indexOfSpace - 1));

                        if (rowNumber < 1 || rowNumber > 10000 || locationNumber < 1 || 
                            locationNumber > 10000 || locationNumber > rowNumber)
                        {
                            throw new OverflowException();
                        }
                        inputValidity = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("输入中包含非数字字符，请重新输入：");
                        input = Console.ReadLine();
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("输入数字不符合范围，请重新输入：");
                        input = Console.ReadLine();
                    }
                }
            }

            int result = PascalTriangle(rowNumber, locationNumber);
            Console.WriteLine();
            Console.WriteLine("杨辉三角中，第 " + rowNumber + 
                " 行的第 " + locationNumber + " 个数字是：");
            if (result < 1)
            {
                Console.WriteLine("该数字超出计算范围");
            }
            else
            {
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }

        static int PascalTriangle(int n, int m)
        {
            int temp = 0;            
            try
            {
                if (m == n || m == 1)
                {
                    return 1;
                }

                // 
                temp = GetNumber(n, m, 2);
                if (temp > 252)
                {
                    throw new OverflowException();
                }
                return temp;
            }
            catch (OverflowException)
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="method">1. 递归；2. 循环；3. 尾递归求组合数；
        /// 4. 递归求阶乘再求组合数；5. 循环求阶乘再求组合数</param>
        /// <returns></returns>
        static int GetNumber(int n, int m, int method)
        {
            switch (method)
            {
                case 1:
                    // 调用递归实现的杨辉三角计算方法
                    return PascalRecursion(n, m);
                case 2:
                    // 调用循环实现的杨辉三角计算方法
                    return PascalLoop(n, m);
                case 3:
                    // 调用尾递归实现的组合数计算方法
                    return Combination(n - 1, 1, m - 1, 1, n - m, 1);
                case 4:
                    // 通过调用递归实现的阶乘计算，计算组合数
                    return Factorial(n - 1, 1) / Factorial(m - 1, 1) / Factorial(n - m, 1);
                case 5:
                    // 通过调用循环实现的阶乘计算，计算组合数
                    return Factorial1(n - 1) / Factorial1(m - 1) / Factorial1(n - m);
                default:
                    return -1;
            }
        }

        /// <summary>
        /// 使用递归计算杨辉三角中第 n 行的第 m 个数
        /// </summary>
        /// <param name="m">数字在其所在行的位置</param>
        /// <param name="n">数字所在的行</param>
        /// <returns></returns>
        static int PascalRecursion(int n, int m)
        {
            if (m == n || m == 1)
            {
                return 1;
            }

            return PascalRecursion(n - 1, m - 1) + PascalRecursion(n - 1, m);
        }

        /// <summary>
        /// 使用二维数组和循环计算杨辉三角中第 n 行的第 m 个数
        /// </summary>
        /// <param name="n">数字所在的行</param>
        /// <param name="m">数字在其所在行的位置</param>
        /// <returns></returns>
        static int PascalLoop(int n, int m)
        {
            int[,] table = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < Math.Min(m, i + 1); j++)
                {
                    if (i == j || j == 0)
                    {
                        table[i, j] = 1;
                    }
                    else
                    {
                        table[i, j] = table[i - 1, j] + table[i - 1, j - 1];
                    }
                }
            }
            return table[n - 1, m - 1];
        }

        /// <summary>
        /// 使用组合数公式计算杨辉三角中第 n 行的第 m 个数
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static int PascalCombination(int n, int m)
        {
            // 调用尾递归实现的组合数计算方法
            return Combination(n - 1, 1, m - 1, 1, n - m, 1);

            // 通过调用递归实现的阶乘计算，计算组合数
            //return Factorial(n - 1, 1) / Factorial(m - 1, 1) / Factorial(n - m, 1);

            // 通过调用循环实现的阶乘计算，计算组合数
            //return Factorial1(n - 1) / Factorial1(m - 1) / Factorial1(n - m);
        }

        /// <summary>
        /// 使用尾递归计算 n1 中取 n2 的组合数,n3 应等于 n1 - n2
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="t1">记录 n1 的阶乘</param>
        /// <param name="n2"></param>
        /// <param name="t2">记录 n2 的阶乘</param>
        /// <param name="n3"></param>
        /// <param name="t3">记录 n3 的阶乘</param>
        /// <returns></returns>
        static int Combination(int n1, int t1, int n2, int t2, int n3, int t3)
        {
            if (n1 == 0 && n2 == 0 && n3 == 0)
            {
                return t1 / t2 / t3;
            }
            if (n1 <= 0)
            {
                n1 = 1;
            }
            if (n2 <= 0)
            {
                n2 = 1;
            }
            if (n3 <= 0)
            {
                n3 = 1;
            }
            return Combination(n1 - 1, n1 * t1, n2 - 1, n2 * t2, n3 - 1, n3 * t3);
        }

        /// <summary>
        /// 使用尾递归计算 n 的阶乘
        /// </summary>
        /// <param name="n"></param>
        /// <param name="total">记录中间变量</param>
        /// <returns></returns>
        static int Factorial(int n, int total)
        {
            if (n == 1)
            {
                return total;
            }
            else
            {
                return Factorial(n - 1, n * total);
            }
        }

        /// <summary>
        /// 使用循环计算 n 的阶乘
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int Factorial1(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
