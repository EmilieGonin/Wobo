using NaughtyAttributes;
using System;
using UnityEditor;
using UnityEngine;

public enum MissionState
{
    LOCK, UNLOCK, DONE
}

[CreateAssetMenu(fileName = "New Mission", menuName = "Wobo/Mission")]
public class MissionSO : ScriptableObject
{
    public static event Action<MissionSO> OnMissionComplete;

    public int ID;
    public string Name;
    public MissionState State;
    public int Reward;

    [Button("Debug - Complete Mission")]
    public void Complete()
    {
        State = MissionState.DONE;
        OnMissionComplete?.Invoke(this);
    }
}