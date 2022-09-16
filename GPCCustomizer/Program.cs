using GPCCustomizer.Model;
using GPCCustomizer.Servises;

string jsonFilePath = @"E:\GPCCustomizer\Files\In\GPC.json";
string ResultJsonFilePath = @"E:\GPCCustomizer\Files\Out\MyGPC.json";

root source = new root();

using (StreamReader r = new StreamReader(jsonFilePath))
{
    string json = r.ReadToEnd();
    source = System.Text.Json.JsonSerializer.Deserialize<root>(json);
}
string jsonString = "[";
foreach (var item in source.Schema)
{
    jsonString += GPCCustomiz.GetGPC(item) + ",";
}
jsonString = jsonString.Remove(jsonString.Length - 1, 1) + "]";
using (StreamWriter outputFile = new StreamWriter(ResultJsonFilePath))
{
    outputFile.WriteLine(jsonString);
}
