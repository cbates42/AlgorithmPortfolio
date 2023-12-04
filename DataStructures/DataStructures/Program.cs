


var path = Directory.GetCurrentDirectory() + @"\Read.txt";

string[] lines = File.ReadAllLines(path);

var array = new string[lines.Length];
var map = new Dictionary<int, string>();
var stack = new Stack<string>();
var queue = new Queue<string>();

for(int i = 0; i < lines.Length; i++)
{
    array[i] = lines[i];
    map.Add(i, lines[i]);
    stack.Push(lines[i]);
    queue.Enqueue(lines[i]);
}

Console.WriteLine("\nArray output:");
foreach(var thing in array)
{
    Console.WriteLine(thing);
}

Console.WriteLine("\nMap output:");
foreach(var thing in map)
{
    Console.WriteLine($"{thing.Key}: {thing.Value}");
}

Console.WriteLine("\nStack output:");
   while(stack.Count > 0)
{
    Console.WriteLine(stack.Pop());
}

Console.WriteLine("\nQueue output:");
while (queue.Count > 0)
{
    Console.WriteLine(queue.Dequeue());
}
