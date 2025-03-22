// See https://aka.ms/new-console-template for more information



 static void HandleDomeEvent(object sender, EventArgs e)  
{
    
    Console.WriteLine("Hello, HandleDomeEvent!");
}

 EventHandler eventHandler = new EventHandler(HandleDomeEvent);
eventHandler(null, EventArgs.Empty); 
 eventHandler =HandleDomeEvent;
eventHandler(null, EventArgs.Empty);

 
 Func<int,string,int,string> func2 =(int a,string b ,int c)=> {return a+b+c;};
 Console.WriteLine(func2.Invoke(1,"2",3));
 
 Func<int,int,string,int> func =(int a,int b,string c)=>{return a+b+c.Length;};
 Console.WriteLine("Hello, World!");


string testreverse ="nakres";
string[] result = testreverse.Split(",").ToArray();
Console.WriteLine("{0}, {1}",testreverse, result[0].Reverse());  