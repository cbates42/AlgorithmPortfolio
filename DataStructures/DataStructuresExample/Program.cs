// See https://aka.ms/new-console-template for more information
var path = Directory.GetCurrentDirectory() + @"\Read.txt";

string[] lines = File.ReadAllLines(path);

var array = new string[lines.Length];
var map = new Dictionary<int, string>();
var stack = new Stack<string>();
var queue = new Queue<string>();

for (int i = 0; i < lines.Length; i++)
{
    array[i] = lines[i];
    map.Add(i, lines[i]);
    stack.Push(lines[i]);
    queue.Enqueue(lines[i]);
}

//arrays have determined sized when they're declared, and have a fixed capacity that can't be changed, you have to make a new array to increase capacity.
Console.WriteLine("\nArray output:");
foreach (var thing in array)
{
    Console.WriteLine(thing);
}

//weakly typed objects get stored together with keys. as it gets bigger performance suffers.
Console.WriteLine("\nMap output:");
foreach (var thing in map)
{
    Console.WriteLine($"{thing.Key}: {thing.Value}");
}

//stores items last-in, first-out order.
Console.WriteLine("\nStack output:");
while (stack.Count > 0)
{
    Console.WriteLine(stack.Pop());
}

//stores items first-in first-out order, first item in is the first item handled. each operation takes the same amount of time.
Console.WriteLine("\nQueue output:");
while (queue.Count > 0)
{
    Console.WriteLine(queue.Dequeue());
}

