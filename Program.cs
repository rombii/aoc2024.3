using System.Text;

using var inputReader = new StreamReader(Path.Join(Directory.GetCurrentDirectory(), "input.txt"));
long part1Answer = 0;
long part2Answer = 0;
var mulActive = true;
const string doMul = "do()";
const string dontMul = "don't()";
while (!inputReader.EndOfStream)
{
    var line = await inputReader.ReadLineAsync();
    var s = new StringBuilder("mul(");
    for (var i = 0; i < line!.Length; i++)
    {
        if (line.Substring(i, i + 3 >= line.Length ? line.Length - i - 1 : 4) == s.ToString())
        {
            var j = i + 4;
            var numberSBuilder = new StringBuilder();
            while (j < line.Length && line[j] != ',')
            {
                numberSBuilder.Append(line[j]);
                j++;
            }
            if (int.TryParse(numberSBuilder.ToString(), out int item1))
            {
                j++; //Skip comma sign
                numberSBuilder.Clear();
                while (j < line.Length && line[j] != ')')
                {
                    numberSBuilder.Append(line[j]);
                    j++;
                }
                if (int.TryParse(numberSBuilder.ToString(), out int item2))
                {
                    part1Answer += item1 * item2;
                    if (mulActive)
                    {
                        part2Answer += item1 * item2;
                    }
                }
            }
        }
        else if (line.Substring(i, i + 3 >= line.Length ? line.Length - i - 1 : 4) == doMul)
        {
            mulActive = true;
        }
        else if (line.Substring(i, i + 6 >= line.Length ? line.Length - i - 1 : 7) == dontMul)
        {
            mulActive = false;
        }
    }
    
}

Console.WriteLine($"First part: {part1Answer}");
Console.WriteLine($"Second part: {part2Answer}");
