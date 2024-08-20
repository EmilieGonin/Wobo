using System.Linq;

public class BSEnemyTurn : BattleState
{
    public override void OnEnter(Battle battle)
    {
        base.OnEnter(battle);

        // Choose random target
        // Choose attack or skill
        // Deal damage
        _battle.Allies.First().DealDamage(5); // temp damages
        _battle.SetNextPlayingEntity();
    }
}