using BlazorApp2_syncfusion.Client;

public class StateContainer
{
    private List<DataModel> savedlist = new List<DataModel>();

    public List<DataModel> Property
    {

        get => savedlist;
        set
        {
            savedlist = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();

}

