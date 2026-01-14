namespace DesignPatterns.Web.Components.Common;

public class BreadcrumbItem
{
    public string Label { get; set; } = "";
    public string Url { get; set; } = "";

    public BreadcrumbItem() { }

    public BreadcrumbItem(string label, string url = "")
    {
        Label = label;
        Url = url;
    }
}