public class BattleState
{
    protected Battle _battle;

    public virtual void OnEnter(Battle battle)
    {
        _battle = battle;
    }

    public virtual void OnUpdate() { }
    public virtual void OnExit() { }
}