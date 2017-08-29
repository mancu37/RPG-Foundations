using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public LayerMask movementMask;

    public Camera cam;

    public PlayerMovement movement;

    public Interactable focus;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        movement = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0)) //Left mouse button
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Tomamos el click del mouse en la pantalla y lo convertimos a un Ray.
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //Debug.LogFormat("Hit: {0} - Point: {1} ", hit.collider.name, hit.point);
                movement.MoveToPoint(hit.point);

                //Quitar el foco
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1)) //Right mouse button
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Tomamos el click del mouse en la pantalla y lo convertimos a un Ray.
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>(); 
                if(interactable != null) //Chequeamos si el objecto que clickeamos es interactuable.
                {
                    //Seteamos el foco en el.
                    SetFocus(interactable);
                }
                
            }
        }
    }

    private void RemoveFocus()
    {
        if(focus != null)
            focus.OnDeFocused();
        focus = null;
        movement.UnFollowTarget();
    }

    private void SetFocus(Interactable interactable)
    {
        if(interactable != focus)
        {
            if(focus != null)
                focus.OnDeFocused();
            
            focus = interactable;
            movement.FollowTarget(interactable);
        }
        interactable.OnFocused(transform);        
    }


}
