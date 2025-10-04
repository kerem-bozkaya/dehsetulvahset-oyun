using UnityEngine;

public class pressed : MonoBehaviour,IInteractable
{
    public Transform ts;
    public float translateAmount;
    public void Interact()
    {
        ts.Translate(0, translateAmount, 0);
    }
}
