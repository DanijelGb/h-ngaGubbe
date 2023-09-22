using System.Diagnostics.Metrics;

Console.WriteLine("Välj ett ord");


String[] wordsFromFile = File.ReadAllLines("C:/Users/DaciBaci/Downloads/words.txt");

for (int i = 0; i < wordsFromFile.Length; i++)
{
    Console.WriteLine(wordsFromFile[i] + " [" + (i + 1) + "]");
}


Random rand = new Random();
int rndNumber = rand.Next(0, wordsFromFile.Length - 1);

var word = wordsFromFile[rndNumber];
var lives = 10;
var streck = "";
var wonGame = false;

while (streck.Length != word.Length)
{
    streck += "_";
}

while (lives > 0)
{
    Console.WriteLine(streck);
    Console.WriteLine("Gissa (" + lives + " kvar)");
    var guess = Console.ReadLine().ToLower();
    var rättGissning = false;

    while (guess.Length != 1 && guess.Length != word.Length)
    {
        Console.WriteLine("Skriv EN bokstav eller hela ordet!");
        guess = Console.ReadLine().ToLower();
    }

    if (guess == word)
    {
        lives = 0;
        wonGame = true;
        streck = word;
    }
    for (int i = 0; i < streck.Length; i++)
    {
        if (guess == word[i].ToString())
        {
            Console.WriteLine();
            Console.WriteLine("Rätt bokstav!");
            rättGissning = true;
            streck = streck.Remove(i, 1).Insert(i, guess);
        }
    }
    if (streck == word)
    {
        lives = 0;
        wonGame = true;
    }
    if (!rättGissning)
    {
        Console.WriteLine();
        Console.WriteLine("Ooops! Fel");
        lives--;
    }
    Console.Clear();
}

if (!wonGame)
{
    Console.WriteLine(streck);
    Console.WriteLine();
    Console.WriteLine("Du förlorade!");
}
else
{
    Console.WriteLine("Rätt ord: " + streck);
    Console.WriteLine();
    Console.WriteLine("Grattis! Du vann.");
}

