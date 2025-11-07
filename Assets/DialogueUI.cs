using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
public class DialogueUI : MonoBehaviour
{
    private TypeWriterEffect typeWriterEffect;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;

    public bool isOpen { get; private set;}
    void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        closeDialogueBox();
    }

    public void showDialogue(DialogueObject dialogueObject)
    {
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(routine:StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typeWriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        closeDialogueBox();
    }
    
    private void closeDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
