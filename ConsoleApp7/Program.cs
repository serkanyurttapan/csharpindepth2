// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Text.RegularExpressions;

static Dictionary<string, int> CountWords(string text)
{
    Dictionary<string, int> frequencies = new Dictionary<string, int>();
    string[] words =Regex.Split(text, @"\W+");
    foreach (string word in words)
    {
        if ( word.Replace(" ", "").Length == 0)
            continue;
        if (frequencies.ContainsKey(word))
        {
            frequencies[word]++;
            continue;
        }
        frequencies[word] = 1;
    }

    foreach (var frequency in frequencies)
    {
        Console.WriteLine("{0} {1}", frequency.Key, frequency.Value);
    }
    return frequencies;
}

Hashtable employees = new Hashtable();
employees.Add("Zara", "8");
employees.Add("Zara2", "18");
Console.WriteLine(CountWords("Bu bir test metnidir. Bu metin bir test metnidir."));

takeSquare(5);

double takeSquare(int i)
{
    return Math.Sqrt(i);
}

List<int> integers =new List<int>();
integers.Add(1);
integers.Add(2);
integers.Add(3);
integers.Add(4);
integers.Add(5);


var result =integers.ConvertAll(i => Math.Asin(60) * i);

foreach (var r in result)
{
    Console.WriteLine("result: "+r);
}
Converter<int,double> converter = takeSquare;
List<double> doubles = integers.ConvertAll(converter);

foreach (var d in doubles)
{
    Console.WriteLine("converter: "+d);
}

static bool AreReferencesEqual<T>(T first, T second)
{ 
   return ReferenceEquals(first, second);
}
EqualityComparer<int> equalityComparer = EqualityComparer<int>.Default;



