using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _battleEntityPrefab;
    [SerializeField] private GameObject _battleEntityPrefabEmptySlot;

    [Header("Dependencies")]
    [SerializeField] private Transform _battlegroundEnemies;
    [SerializeField] private Transform _battlegroundAllies;

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

        float spacing = 2.0f;

        for (int i = 0; i < 3; i++)
        {
            Vector3 battlegroundPos = _battlegroundEnemies.position;
            Vector3 position = battlegroundPos + new Vector3(i * spacing, 0, 0);
            GameObject sprite = Instantiate(_battleEntityPrefab, position, Quaternion.identity);
            Enemies.Add(sprite.AddComponent<Enemy>());
            sprite.transform.SetParent(_battlegroundEnemies);
        }

        for (int i = 0; i < 3; i++)
        {
            Vector3 battlegroundPos = _battlegroundAllies.position;
            Vector3 position = battlegroundPos + new Vector3(i * spacing, 0, 0);
            GameObject sprite = Instantiate(_battleEntityPrefab, position, Quaternion.identity);
            sprite.transform.SetParent(_battlegroundAllies);
        }
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