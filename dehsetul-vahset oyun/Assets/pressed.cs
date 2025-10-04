using UnityEngine;

public class pressed : MonoBehaviour,IInteractable
{
    public Transform transform;
    public void Interact()
    {
        transform.Translate(0, -0.036f, 0);
    }
}
