public class BSEnemyTurn : BattleState
{
    public override void OnEnter(Battle battle)
    {
        base.OnEnter(battle);

        // Choose random target
        // Choose attack or skill
        // Deal damage
        _battle.SetNextPlayingEntity();
    }
}