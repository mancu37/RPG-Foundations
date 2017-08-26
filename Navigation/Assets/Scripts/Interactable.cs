using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public bool isFocus = false;
    public bool hasInteracted = false;
    public Transform player;

    public virtual void Interact()
    {
        //Esta funcion es virtual para que cada objeto interactuable interactue a su manera.
        //Esta funcion hay que sobreescribirla en cada clase

        Debug.Log("Interact from: " + transform.name);
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if(distance <= radius)
            {
                Interact();
                Debug.Log("Interact");
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform transform)
    {
        isFocus = true;
        player = transform;
        hasInteracted = false;
    }

    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
