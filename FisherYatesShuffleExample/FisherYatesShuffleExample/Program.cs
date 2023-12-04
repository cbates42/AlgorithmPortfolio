//Referenced https://www.geeksforgeeks.org/shuffle-a-given-array-using-fisher-yates-shuffle-algorithm/

var path = Directory.GetCurrentDirectory() + @"\Read.txt";

var lines = new List<string>(File.ReadAllLines(path));

// shuffle the list with fisher-yates
Shuffle(lines);

foreach (var line in lines)
{
    Console.WriteLine(line);
}
    

    // fisher-Yates shuffle 
    static void Shuffle<T>(IList<T> list)
{
    Random rng = new Random();
    int n = list.Count;

    // Loop over the list
    for (int i = n - 1; i > 0; i--)
    {

        int j = rng.Next(i + 1);

        T temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }

    // list got randomly shuffled, each element has equal probability of being anywhere
}
