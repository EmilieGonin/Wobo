using UnityEngine;
using UnityEngine.UI;

public class CharacterHUD : MonoBehaviour
{
    [SerializeField] private Image _health;

    public void UpdateHealthbar(int maxPv, int pv)
    {
        float healthValue = Mathf.Clamp((float)pv / (float)maxPv, 0f, 1f);
        _health.transform.localScale = new(healthValue, _health.transform.localScale.y, _health.transform.localScale.z);
    }
}