using UnityEngine;
using Ink.Runtime;

public class InkManager : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJSONAsset; // Fichier Ink en JSON
    [SerializeField] private Character _character;

    private Story _inkStory;

    public enum InkVariable
    {
        Karma,
        Pv
    }

    private void Awake()
    {
        if (_inkJSONAsset == null)
        {
            Debug.LogError("Ink JSON Asset n'est pas assigné");
            return;
        }

        // Assigne le script Character s'il n'est pas assigné manuellement (facultatif?)
        _character ??= GetComponent<Character>();
        if (_character == null)
        {
            Debug.LogError("Character script non assigné et/ou non trouvé sur ce GameObject");
        }
    }

    private void Start()
    {
        // Initialise l'histoire Ink
        _inkStory = new Story(_inkJSONAsset.text);

        SyncInkVariables(InkVariable.Karma, _character.GetKarma());
        SyncInkVariables(InkVariable.Pv, _character.GetPv());
    }

    private void Update()
    {
        if (_inkStory.canContinue)
        {
            string text = _inkStory.Continue();
            Debug.Log(text);
        }

        SyncCharacterStatWithInk(InkVariable.Karma, _character.GetKarma(), _character.AdjustKarma);
        SyncCharacterStatWithInk(InkVariable.Pv, _character.GetPv(), _character.AdjustPv);

        DisplayChoices();
    }

    private string GetInkVariableName(InkVariable variable)
    {
        return variable switch
        {
            InkVariable.Karma => "karma",
            InkVariable.Pv => "pv",
            _ => throw new System.ArgumentException("Variable Ink inconnue")
        };
    }

    private void SyncInkVariables(InkVariable variable, int characterValue)
    {
        // Synchronise une variable d'Ink avec la valeur actuelle du Character
        try
        {
            string variableName = GetInkVariableName(variable);
            _inkStory.variablesState[variableName] = characterValue;
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning($"Erreur lors de la synchronisation de {variable} avec Ink: {ex.Message}");
        }
    }

    private void SyncCharacterStatWithInk(InkVariable variable, int currentStatValue, System.Action<int> adjustStatAction)
    {
        // Accès direct à une variable et synchronisation si nécessaire
        try
        {
            string variableName = GetInkVariableName(variable);
            object value = _inkStory.variablesState[variableName];
            if (value is int newValue && newValue != currentStatValue)
            {
                adjustStatAction(newValue - currentStatValue);
            }
            else if (!(value is int))
            {
                Debug.LogWarning($"La valeur de {variableName} dans Ink n'est pas un entier.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning($"Erreur lors de l'accès à la variable '{variable}': {ex.Message}");
        }
    }

    private void DisplayChoices()
    {
        if (_inkStory.currentChoices.Count > 0)
        {
            for (int i = 0; i < _inkStory.currentChoices.Count; i++)
            {
                Debug.Log($"Choice {i}: {_inkStory.currentChoices[i].text}");
            }
        }
    }
}
