public class StateContainer
{
	private int savedint=0;

	public int Property
	{

		get => savedint ;
		set
		{
			savedint = value;
			NotifyStateChanged();
		}
	}

	public event Action? OnChange;

	private void NotifyStateChanged() => OnChange?.Invoke();
}