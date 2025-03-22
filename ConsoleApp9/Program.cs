// See https://aka.ms/new-console-template for more information

// string listTypeName = "System.Collections.Generic.List`1";
// Type defByName = Type.GetType(listTypeName);
// Type closedByName = Type.GetType(listTypeName+"[System.String]");
// Type closedByMethod = defByName.MakeGenericType(typeof(string));
// Type closedByTypeof = typeof(List<string>);
// Console.WriteLine (closedByMethod==closedByName);
// Console.WriteLine (closedByName==closedByTypeof);
// Type defByTypeof = typeof(List<>);
// Type defByMethod = closedByName.GetGenericTypeDefinition();
// Console.WriteLine (defByMethod==defByName);
// Console.WriteLine (defByName==defByTypeof);
//

/*string listTypeName = "System.Collections.Generic.List`1";
Type defByName = Type.GetType(listTypeName);
Type closedByName = Type.GetType(listTypeName+"[System.String]");
Type closedByMethod = defByName.MakeGenericType(typeof(int));
Type closedByTypeof = typeof(List<string>);
Console.WriteLine (closedByMethod==closedByName);


Console.WriteLine("Hello, World!");*/


using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        const int count = 1_000_000; // 1 milyon eleman
        
        // 1️⃣ Liste ile performans testi
        Stopwatch sw1 = Stopwatch.StartNew();
        var listNumbers = GetNumbersList(count);
        sw1.Stop();
        Console.WriteLine($"List<T>: {sw1.ElapsedMilliseconds} ms, Bellek: {GC.GetTotalMemory(true) / 1024 / 1024} MB");

        var number = (from numbe in listNumbers
            where numbe > 500008 && numbe < 500010 select numbe).FirstOrDefault();
        // 2️⃣ Yield return ile performans testi
        Stopwatch sw2 = Stopwatch.StartNew();
        var yieldNumbers = GetNumbersYield(count);
        int sum = 0;
        foreach (var num in yieldNumbers) // Değerleri üretmek için iterasyon gerekiyor
        {
            sum += num;
        }
        sw2.Stop();
        Console.WriteLine($"Yield: {sw2.ElapsedMilliseconds} ms, Bellek: {GC.GetTotalMemory(true) / 1024 / 1024} MB");
    }

    // 🔹 Liste ile tüm elemanları bellekte tutan yöntem
    static List<int> GetNumbersList(int count)
    {
        List<int> numbers = new List<int>();
        for (int i = 1; i <= count; i++)
        {
            numbers.Add(i);
        }
        return numbers;
    }

    // 🔹 Yield return ile elemanları sadece çağrıldığında üreten yöntem
    static IEnumerable<int> GetNumbersYield(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            yield return i; // Elemanları bellekte tutmadan üret
        }
    }
    
}
