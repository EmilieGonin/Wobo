using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Currency {  get; private set; } = 0;
    public List<MissionSO> Missions { get; private set; }
    public MissionSO CurrentMission { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        MissionSO.OnMissionComplete += MissionSO_OnMissionComplete;

        Missions = Resources.LoadAll<MissionSO>("SO/Missions").ToList();
        Missions.OrderBy(item => item.name);
        CurrentMission = Missions.FirstOrDefault();
    }

    private void OnDestroy()
    {
        MissionSO.OnMissionComplete -= MissionSO_OnMissionComplete;
    }

    private void MissionSO_OnMissionComplete(MissionSO mission)
    {
        Currency += mission.Reward;
        CurrentMission = Missions.Find(item => item.ID == CurrentMission.ID + 1);
        CurrentMission.State = MissionState.UNLOCK;
    }

    public bool HasEnoughCurrency(int amount)
    {
        if (Currency < amount)
        {
            ShowError("Not enough currency !");
            return false;
        }

        Currency -= amount;
        return true;
    }

    private void ShowError(string message)
    {
        Debug.LogError(message);
    }
}