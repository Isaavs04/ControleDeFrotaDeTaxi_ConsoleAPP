using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] faturamento = new double[20];
            int[] taxi = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            double preco, total = 0, maior, menor;
            string choice;
            int carro, num = 0, num2 = 0;

            do
            {
                Console.Write("Controle de Frota\n1. Lançar corrida\n2. Mostrar faturamento\n3. Informar carro com maior faturamento\n4. Informar carro com menor faturamento\n5. Zerar faturamento\n0. Finalizar\nSua opção:  ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        do
                        {
                            Console.Write("\nNúmero do carro (1 a 20):  ");
                            carro = int.Parse(Console.ReadLine());
                            if (carro > faturamento.Length || carro < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Número de carro inválido, tente novamente.\n");
                                Console.ResetColor();
                            }
                        } while (carro > faturamento.Length || carro < 1);

                        do
                        {
                            Console.Write("Digite o valor da sua corrida:  ");
                            preco = double.Parse(Console.ReadLine());
                            if (preco < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("O valor é inválido, tente novamente.\n");
                                Console.ResetColor();
                            }
                        } while (preco < 0);

                        faturamento[carro - 1] = preco + faturamento[carro - 1];

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Valor Registrado com Sucesso!");
                        Console.ResetColor();
                        total = preco + total;
                        break;

                    case "2":
                        Console.WriteLine("================================");
                        Console.WriteLine("| TAXI |      FATURAMENTO      |");
                        Console.WriteLine("|------+-----------------------|");
                        for (int i = 0; i < faturamento.Length; i++)
                        {
                            Console.WriteLine($"|  {taxi[i]:00}  | {faturamento[i],21:C2} |");
                        }
                        Console.WriteLine("|------+-----------------------|");
                        Console.WriteLine($"| TOTAL| {total,21:C2} |");
                        Console.WriteLine("================================");
                        break;

                    case "3":
                        maior = faturamento[0];
                        num = 0;
                        for (int j = 1; j < faturamento.Length; j++)
                        {
                            if (maior < faturamento[j])
                            {
                                maior = faturamento[j];
                                num = j;
                            }
                        }
                        if (maior == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nNenhum faturamento registrado ainda (todos são R$ 0,00).");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("\nO táxi que mais faturou foi o " + taxi[num].ToString("00") + " com " + faturamento[num].ToString("C2") + "\nE ele equivale a " + ((faturamento[num] * 100) / (total == 0 ? 1 : total)).ToString("F2") + "% do faturamento total");
                        }
                        break;

                    case "4":
                        int primeiroValido = -1;
                        for (int i = 0; i < faturamento.Length; i++)
                        {
                            if (faturamento[i] > 0)
                            {
                                primeiroValido = i;
                                break;
                            }
                        }

                        if (primeiroValido == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nNenhum faturamento registrado ainda (todos são R$ 0,00).");
                            Console.ResetColor();
                        }
                        else
                        {
                            menor = faturamento[primeiroValido];
                            num2 = primeiroValido;

                            for (int h = primeiroValido + 1; h < faturamento.Length; h++)
                            {
                                if (faturamento[h] > 0 && faturamento[h] < menor)
                                {
                                    menor = faturamento[h];
                                    num2 = h;
                                }
                            }
                            Console.Write("\nO táxi que menos faturou foi o " + taxi[num2].ToString("00") + " com " + menor.ToString("C2") + "\nE ele equivale a " + ((faturamento[num2] * 100) / (total == 0 ? 1 : total)).ToString("F2") + "% do total");
                        }
                        break;

                    case "5":
                        for (int g = 0; g < faturamento.Length; g++)
                        {
                            faturamento[g] = 0;
                        }
                        total = 0;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Faturamento zerado com sucesso!");
                        Console.ResetColor();
                        break;

                    case "0":
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Opção inválida");
                        Console.ResetColor();
                        break;
                }
                if (choice == "0")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Tem certeza que deseja fechar a aplicação? Digite 0 para confitmar:  ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("\n\nCaso queira sair digite 0, se não quiser, qualquer outra tecla:  ");
                    choice = Console.ReadLine();
                }
                Console.Clear();

            } while (choice != "0");
        }
    }
}