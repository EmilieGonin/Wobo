using System;

public class Enemy : Character
{
    public static event Action<Character> OnTargetChoice;
    private bool _canBeTargeted = false;

    private void Awake()
    {
        BattleActions.OnAttackAction += BattleActions_OnAttackAction;
        OnTargetChoice += Enemy_OnTargetChoice;
    }

    private void OnDestroy()
    {
        BattleActions.OnAttackAction -= BattleActions_OnAttackAction;
        OnTargetChoice += Enemy_OnTargetChoice;
    }

    private void BattleActions_OnAttackAction()
    {
        _canBeTargeted = true;
    }

    private void Enemy_OnTargetChoice(Character obj)
    {
        _canBeTargeted = false;
    }

    private void OnMouseUp()
    {
        if (!_canBeTargeted) return;
        OnTargetChoice?.Invoke(this);
    }
}