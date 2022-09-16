using GPCCustomizer.Model;
using System.Text.Json;
using System.Web;

namespace GPCCustomizer.Servises;
static class GPCCustomiz
{
    public static string GetGPC(MyGPC gcd)
    {
        foreach (var item in gcd.Childs)
        {
            if (item.Level == 4)
            {
                TranslateProps(item);
                foreach (var i in item.Childs)
                {
                    TranslateProps(i);
                    foreach (var j in i.Childs)
                        TranslateProps(j);
                }
                return JsonSerializer.Serialize(item, typeof(MyGPC), new JsonSerializerOptions() { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All) });
            }
            else
                return GetGPC(item);
        }
        return null;
    }

    public static void TranslateProps(MyGPC gcd)
    {
        gcd.TitleAr = TranslateText(gcd.Title);
        gcd.DefinitionAr = TranslateText(gcd.Definition);
    }

    public static string TranslateText(string input)
    {
        var fromLanguage = "en";//English
        var toLanguage = "ar";//Arabic 
        var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(input)}";
        HttpClient httpClient = new HttpClient();
        string result = httpClient.GetStringAsync(url).Result;
        result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
        return result;
    }
}
