public class NumericSpinner : Spinner
{
    public int max;

    protected override int GetMaxIndex()
    {
        return max;
    }

    protected override string GetSelectedText()
    {
        return selectedIndex.ToString();
    }
    public override object GetSelectedData()
    {
        return selectedIndex;
    }
}