using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    [SerializeField]
    float currentZoom = 2f;
    public float pitch = 2f;

    public float zoomSpeed = 4f;
    public float minZoom = 1f;
    public float maxZoom = 15f;

    public float currentYaw = 0f;
    public float yawSpeed = 100f;

	// Use this for initialization
	void Start () {
		
	}

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void LateUpdate () {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
	}
}
