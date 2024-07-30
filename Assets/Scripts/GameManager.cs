using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Currency {  get; private set; } = 0;
    public List<MissionSO> Missions { get; private set; }
    public MissionSO CurrentMission { get; private set; }

    private void Awake()
    {
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
}