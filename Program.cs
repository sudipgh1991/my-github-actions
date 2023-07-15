using Newtonsoft.Json;
using System.Text;
if (args.Length > 0)
{
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("authorization", "Bearer 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");
    var content = new StringContent(
        JsonConvert.SerializeObject(new GPT("text-davinci-001", args[0], 1, 100)),
        encoding: Encoding.UTF8,
        mediaType: "application/json");

    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content);

    string responseString = await response.Content.ReadAsStringAsync();
    // System.Console.WriteLine(responseString);

    Console.ForegroundColor = ConsoleColor.Green;
    Output message = JsonConvert.DeserializeObject<Output>(responseString)!;
    System.Console.WriteLine("-------Answers from GPT");
    foreach (var choice in message.choices)
    {
        System.Console.WriteLine(GuessCommand(choice.text));
    }
    Console.ResetColor();
}
else
{
    System.Console.WriteLine("--> You need to provide some input");
}


static string GuessCommand(string input)
{

    var lastIndex = input.LastIndexOf('\n');
    string guess = input.Substring(lastIndex + 1);

    TextCopy.ClipboardService.SetText(guess);

    return guess;
}