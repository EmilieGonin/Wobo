using System;

public class Enemy : Character
{
    public static event Action OnTargetChoice;

    private void OnMouseUp()
    {
        OnTargetChoice?.Invoke();
    }
}