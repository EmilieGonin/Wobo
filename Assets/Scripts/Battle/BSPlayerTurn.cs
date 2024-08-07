public class BSPlayerTurn : BSTurn
{
    public override void OnEnter(Battle battle)
    {
        base.OnEnter(battle);
        // Subscribe to UI events
    }

    public override void OnExit()
    {
        base.OnExit();
        // Unsubscribe to UI events
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