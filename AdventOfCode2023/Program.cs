using System.Reflection;

namespace com.fabioscagliola.AdventOfCode2023;

class Program
{
    static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        List<Type> typeList = assembly.GetTypes().Where(type => type.GetInterface(nameof(ISolvable)) != null).ToList();

        typeList.Sort((a, b) => a.FullName!.CompareTo(b.FullName));

        foreach (Type type in typeList)
        {
            string path = type.Namespace!.Split('.').Last();

            string input = File.ReadAllText($"{path}\\Input1.txt");

            ISolvable solvable = (ISolvable)Activator.CreateInstance(type);

            Console.WriteLine($"{type.FullName}: {solvable.Solve(input)}");
        }
    }
}
