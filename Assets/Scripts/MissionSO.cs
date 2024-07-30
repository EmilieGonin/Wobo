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

    public void Complete()
    {
        State = MissionState.DONE;
        OnMissionComplete?.Invoke(this);
    }

    [Button]
    private void UpdateAssetName()
    {
        string id = ID < 10 ? 0 + ID.ToString() : ID.ToString();
        string assetPath = AssetDatabase.GetAssetPath(GetInstanceID());
        AssetDatabase.RenameAsset(assetPath, $"{id} - {Name}");
    }
}