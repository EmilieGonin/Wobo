using UnityEngine;
using Ink.Runtime;

public class InkManager : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJSONAsset; // Fichier Ink en JSON
    [SerializeField] private Character _character;

    private Story _inkStory;

    private void Awake()
    {
        if (_inkJSONAsset == null)
        {
            Debug.LogError("Ink JSON Asset n'est pas assign�");
            return;
        }

        if (_character == null)
        {
            _character = GetComponent<Character>();
            if (_character == null)
            {
                Debug.LogError("Character script non assign� et/ou non trouv� sur ce GameObject");
                return;
            }
        }
    }

    private void Start()
    {
        // Initialiser l'histoire Ink
        _inkStory = new Story(_inkJSONAsset.text);

        UpdateInkKarma();
    }

    private void Update()
    {
        if (_inkStory.canContinue)
        {
            string text = _inkStory.Continue();
            Debug.Log(text);
        }

        SyncKarma();
        DisplayChoices();
    }

    private void UpdateInkKarma()
    {
        // Synchroniser la variable karma d'Ink avec la valeur actuelle du Character
        try
        {
            _inkStory.variablesState["karma"] = _character.GetKarma();
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning($"Erreur lors de la synchronisation du karma avec Ink: {ex.Message}");
        }
    }

    private void SyncKarma()
    {
        // Acc�der directement � la variable karma
        try
        {
            object karmaValue = _inkStory.variablesState["karma"];
            if (karmaValue is int newKarma)
            {
                int currentKarma = _character.GetKarma();
                if (newKarma != currentKarma)
                {
                    _character.AdjustKarma(newKarma - currentKarma); // Ajuster le karma en fonction de la diff�rence
                }
            }
            else
            {
                Debug.LogWarning("La valeur de karma dans Ink n'est pas un entier.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning($"Erreur lors de l'acc�s � la variable 'karma': {ex.Message}");
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
