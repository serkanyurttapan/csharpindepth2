// See https://aka.ms/new-console-template for more information


using System.Text.Json;
using System.Text.Json.Serialization;

Person person = new Person();
Person person2 = (Person)person.Clone();
person2.Age = 22;
Console.WriteLine(JsonSerializer.Serialize(person));
Console.WriteLine(JsonSerializer.Serialize(person2));
Stream stream = new MemoryStream();
MemoryStream memoryStream = (MemoryStream) stream;
public class Person  :ICloneable{
    public Person()
    {
        Name = "John Doe";
        Age = 30;
    }
    public string Name { get; set; } 
    public int Age { get; set; }
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}