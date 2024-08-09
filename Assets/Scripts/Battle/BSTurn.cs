public class BSTurn : BattleState
{
    public override void OnExit()
    {
        base.OnExit();
        _battle.SetNextPlayingEntity();
    }
}