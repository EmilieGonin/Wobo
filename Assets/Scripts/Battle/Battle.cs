using UnityEngine;

public class Battle : MonoBehaviour
{
    public TempEntity PlayingEntity {  get; private set; }

    // Add list of allies and ennemies

    public struct TempEntity { }

    private BattleState _currentState;

    private void Awake()
    {
        SetNextPlayingEntity();
    }

    private void Update()
    {
        _currentState?.OnUpdate();
    }

    private void ChangeState(BattleState state)
    {
        _currentState?.OnExit();
        _currentState = state;
        _currentState?.OnEnter(this);
    }

    public void SetNextPlayingEntity()
    {
        // Check win/lose conditions
        // Check which entity play
        PlayingEntity = new TempEntity { };
        ChangeState(new BSPlayerTurn());
    }
}