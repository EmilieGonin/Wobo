public class BSPlayerTurn : BSTurn
{
    public override void OnEnter(Battle battle)
    {
        base.OnEnter(battle);

        // Subscribe to UI events
        BattleActions.OnAttackAction += OnAttack;
    }

    public override void OnExit()
    {
        base.OnExit();

        // Unsubscribe to UI events
        BattleActions.OnAttackAction -= OnAttack;
    }

    private void OnAttack()
    {
        //
    }

    private void OnSkill()
    {
        //
    }
}