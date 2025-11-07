using UnityEngine;

public class DialogueActivater : MonoBehaviour, Interactible
{
    [SerializeField] private DialogueObject dialogueObject;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.TryGetComponent(out PlayerController player))
        {
            player.Interactible = this;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.TryGetComponent(out PlayerController player))
        {
            if(player.Interactible is DialogueActivater dialogueActivater && (bool)dialogueActivater == this)
            {
                player.Interactible = null;
            }
        }
    }
    public void Interact(PlayerController player)
    {
        player.DialogueUI.showDialogue(dialogueObject);
    }
}   
