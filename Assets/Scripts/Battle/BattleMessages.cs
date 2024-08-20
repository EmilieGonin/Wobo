using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleMessages : MonoBehaviour
{
    [SerializeField] private Image _messageBackground;
    [SerializeField] private TMP_Text _messageText;

    private void Awake()
    {
        BattleActions.OnAttackAction += OnAttack;
        Enemy.OnTargetChoice += Hide;
    }

    private void OnDestroy()
    {
        BattleActions.OnAttackAction -= OnAttack;
        Enemy.OnTargetChoice -= Hide;
    }

    private void OnAttack()
    {
        _messageBackground.enabled = true;
        _messageText.text = "Choose a target !";
    }

    private void Hide(Character target)
    {
        _messageBackground.enabled = false;
        _messageText.text = string.Empty;
    }
}