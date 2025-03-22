// See https://aka.ms/new-console-template for more information


TypeWithFields<int> a = new TypeWithFields<int>();


TypeWithFields<string> b = new TypeWithFields<string>();

TypeWithFields<Guid> c = new TypeWithFields<Guid>();


Console.WriteLine(a);

Console.WriteLine(b);

Console.WriteLine(c);
struct TypeWithFields<T>
{

    public TypeWithFields()
    {
        Console.WriteLine( typeof(T).Name);
    }
}