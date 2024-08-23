using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _battleEntityPrefab;
    [SerializeField] private GameObject _battleEntityPrefabEmptySlot;

    [Header("Dependencies")]
    [SerializeField] private Transform _battlegroundEnemies;
    [SerializeField] private Transform _battlegroundAllies;

    public Character PlayingEntity {  get; private set; }

    public List<Character> Enemies { get; private set; } = new();
    public List<Character> Allies { get; private set; } = new(); // temp - use game manager later
    public List<Character> TurnOrder { get; private set; } = new();

    private BattleState _currentState;

    private void Awake()
    {
        SpawnEntities();
        StartNewTurn();
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
        else if (!isEmpty) Allies.Add(sprite.AddComponent<Character>()); // temp
    }

    private void Update()
    {
        _currentState?.OnUpdate();
    }

    private void ChangeState(BattleState state)
    {
        _currentState?.OnExit();
        _currentState = state;
        Debug.Log($"New battle state : {_currentState}");
        _currentState?.OnEnter(this);
    }

    public void SetNextPlayingEntity()
    {
        // Check win/lose conditions
        foreach (var ally in Allies)
        {
            if (ally.IsAlive) break;
            ChangeState(new BSLose());
            return;
        }

        int enemyNumber = Enemies.Count;

        foreach (var enemy in Enemies)
        {
            if (enemy.IsAlive) break;
            enemyNumber--;

            if (enemyNumber > 0) continue;
            ChangeState(new BSWin());
            return;
        }

        // Check which entity play with speed

        if (TurnOrder.Count == 0)
        {
            StartNewTurn();
            return;
        }

        PlayingEntity = TurnOrder.FirstOrDefault();
        TurnOrder.Remove(PlayingEntity);

        ChangeState(Allies.Contains(PlayingEntity) ? new BSPlayerTurn() : new BSEnemyTurn());
    }

    private void StartNewTurn()
    {
        TurnOrder.AddRange(Allies);
        TurnOrder.AddRange(Enemies);
        SetNextPlayingEntity();
    }
}