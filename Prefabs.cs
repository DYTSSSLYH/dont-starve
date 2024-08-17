public class Asset
{
    public string type;
    public string file;
    public object param;

    public Asset(string type, string file, object param = null)
    {
        this.type = type;
        this.file = file;
        this.param = param;
    }
}