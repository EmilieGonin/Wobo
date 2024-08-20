using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _battleEntityPrefab;
    [SerializeField] private GameObject _battleEntityPrefabEmptySlot;

    [Header("Dependencies")]
    [SerializeField] private Transform _battleSlotsEnemies;
    [SerializeField] private Transform _battleSlotsAllies;

    public TempEntity PlayingEntity {  get; private set; }

    // Add list of allies and ennemies

    public struct TempEntity { }

    public List<Character> Enemies { get; private set; } = new();

    private BattleState _currentState;

    private void Awake()
    {
        SpawnEntities();
        SetNextPlayingEntity();
    }

    private void SpawnEntities()
    {
        // temp - use missionSO later
        Enemies.Clear();

        for (int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(_battleEntityPrefab, _battleSlotsEnemies);
            Enemies.Add(go.AddComponent<Character>());
        }

        // temp - use game manager allies later
        Instantiate(_battleEntityPrefabEmptySlot, _battleSlotsAllies);
        Instantiate(_battleEntityPrefab, _battleSlotsAllies);
        Instantiate(_battleEntityPrefabEmptySlot, _battleSlotsAllies);
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