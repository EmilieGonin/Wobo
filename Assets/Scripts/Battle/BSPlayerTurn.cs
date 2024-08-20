using UnityEngine;

public class BSPlayerTurn : BattleState
{
    private Skill _selectedSkill;

    public override void OnEnter(Battle battle)
    {
        base.OnEnter(battle);
        Enemy.OnTargetChoice += OnAttack;
    }

    public override void OnExit()
    {
        base.OnExit();
        Enemy.OnTargetChoice -= OnAttack;
    }

    private void OnAttack(Character target)
    {
        int damage = 5; // temp - get Wobo damage stat
        //if (_selectedSkill == null) damage = _selectedSkill.
        target.DealDamage(damage);
        Debug.Log($"Player dealt {damage} damages.");

        _battle.SetNextPlayingEntity();
    }
}