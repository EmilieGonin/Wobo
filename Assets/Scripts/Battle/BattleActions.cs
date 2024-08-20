using System;
using UnityEngine;

public class BattleActions : MonoBehaviour
{
    public static event Action OnAttackAction;

    public void Attack()
    {
        OnAttackAction?.Invoke();
    }

    public void Spell()
    {
        //
    }
}