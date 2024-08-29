public class BalanceView : TextView<int>
{
    private void HandleEnabled()
    {
        Balance.Updated += UpdateText;
        UpdateText(Balance.Value);
    }

    private void HandleDisabled()
    {
        Balance.Updated -= UpdateText;
    }
}