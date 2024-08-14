using System.Collections.Generic;
using UnityEngine;

public enum TempSkillRarity
{
    Common, Rare, Epic, Legendary
}

public class Gacha : MonoBehaviour
{
    [SerializeField] private int _pullCost = 10;

    public struct TempSkill
    {
        public int Id;
        public TempSkillRarity Rarity;
    }

    public Dictionary<TempSkillRarity, int> SkillDropRates { get; private set; } = new();

    private void Awake()
    {
        SkillDropRates[TempSkillRarity.Rare] = 30;
        SkillDropRates[TempSkillRarity.Epic] = 10;
        SkillDropRates[TempSkillRarity.Legendary] = 1;
    }

    private void Start()
    {
        Pull();
    }

    public void Pull()
    {
        if (!GameManager.Instance.HasEnoughCurrency(_pullCost)) return;
        GetRarity();
    }

    private TempSkillRarity GetRarity()
    {
        float random = Random.Range(0, 100);
        Debug.Log($"Random for rarity is {random}.");
        TempSkillRarity rarity = TempSkillRarity.Common;

        foreach (var item in SkillDropRates)
        {
            if (random > item.Value) continue;

            rarity = item.Key;
            break;
        }

        Debug.Log($"Skill rarity is {rarity}.");

        return rarity;
    }
}