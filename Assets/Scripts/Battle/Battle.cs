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

        for (int i = 0; i < 3; i++) SpawnEntity(i, true);

        // temp - use game manager data later
        SpawnEntity(0, false, true);
        SpawnEntity(1, false);
        SpawnEntity(2, false, true);
    }

    private void SpawnEntity(int i, bool isEnemy, bool isEmpty = false)
    {
        float spacing = 2.0f;

        Vector3 battlegroundPos = isEnemy ? _battlegroundEnemies.position : _battlegroundAllies.position;
        Vector3 position = battlegroundPos + new Vector3(i * spacing, 0, 0);
        GameObject sprite = Instantiate(isEmpty ? _battleEntityPrefabEmptySlot : _battleEntityPrefab, position, Quaternion.identity);
        sprite.transform.SetParent(isEnemy ? _battlegroundEnemies : _battlegroundAllies);

        if (isEnemy) Enemies.Add(sprite.AddComponent<Enemy>());
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