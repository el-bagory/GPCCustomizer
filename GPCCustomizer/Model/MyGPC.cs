namespace GPCCustomizer.Model;
internal class MyGPC
{
    public int Level { get; set; }
    public int Code { get; set; }
    public string Title { get; set; }
    public string TitleAr { get; set; }
    public string Definition { get; set; }
    public string DefinitionAr { get; set; }
    public string DefinitionExcludes { get; set; }
    public bool Active { get; set; }
    public List<MyGPC> Childs { get; set; }
}
