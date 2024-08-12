using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class InkKarmaManager : MonoBehaviour
{
    private int karma = 0;

    [SerializeField]
    private TextAsset inkJSONAsset = null;
    private Story story;

    [SerializeField]
    private Canvas canvas = null;

    [SerializeField]
    private Text textPrefab = null;
    [SerializeField]
    private Button buttonPrefab = null;

    private Text uiText;
    private Transform buttonParent;

    void Start()
    {
        InitializeStory();
        SetupUI();
        ContinueStory();
    }

    private void InitializeStory()
    {
        if (inkJSONAsset != null)
        {
            story = new Story(inkJSONAsset.text);
        }
        else
        {
            Debug.LogError("Ink JSON asset not assigned.");
        }
    }

    private void SetupUI()
    {
        uiText = Instantiate(textPrefab, canvas.transform);
        uiText.gameObject.SetActive(true);

        buttonParent = new GameObject("Choices").transform;
        buttonParent.SetParent(canvas.transform, false);
    }

    public void ChooseOption(int optionIndex)
    {
        if (story == null) return;

        // Choisir l'option dans l'histoire
        story.ChooseChoiceIndex(optionIndex);

        // Appliquer les changements de karma
        ApplyKarmaChangeFromTags();

        // Continuer l'histoire après le choix
        ContinueStory();
    }

    private void ApplyKarmaChangeFromTags()
    {
        foreach (var tag in story.currentTags)
        {
            if (tag.StartsWith("karma_change:"))
            {
                if (int.TryParse(tag.Substring(13), out int changeAmount))
                {
                    ApplyKarmaChange(changeAmount);
                }
            }
        }
    }

    private void ApplyKarmaChange(int changeAmount)
    {
        karma += changeAmount;
        Debug.Log($"Karma modifié de {changeAmount}. Nouveau karma : {karma}");
    }

    private void ContinueStory()
    {
        // Nettoyer les anciens choix
        foreach (Transform child in buttonParent)
        {
            Destroy(child.gameObject);
        }

        // Afficher le texte de l'histoire
        if (story != null && story.canContinue)
        {
            uiText.text = story.Continue();
        }

        // Afficher les choix disponibles
        CreateChoices();
    }

    private void CreateChoices()
    {
        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            var choice = story.currentChoices[i];
            var button = Instantiate(buttonPrefab, buttonParent);
            button.GetComponentInChildren<Text>().text = choice.text;
            button.onClick.RemoveAllListeners(); // Nettoyer les anciens listeners
            button.onClick.AddListener(() => ChooseOption(i));
        }
    }
}
