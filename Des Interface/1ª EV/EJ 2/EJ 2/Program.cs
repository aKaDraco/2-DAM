// See https://aka.ms/new-console-template for more information
#define FRASE 
Console.WriteLine("Introduce la 1ª frase:\n");
string? f1 = Console.ReadLine();
Console.WriteLine();
Console.WriteLine("Introduce la 2ª frase:\n");
string? f2 = Console.ReadLine();
Console.WriteLine();
#if FRASE
Console.WriteLine("\"{0}\"\t\\{1}\\", f1, f2);
#else
Console.WriteLine("{0}\t{1}\n{0}\n{1}", f1, f2);
#endif