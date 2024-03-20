using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    Vector2 velocity;
    Vector2 frameVelocity;
    bool cameraMovementEnabled = true; // Agrega esta variable
    Quaternion lastsaveTL;
    Quaternion lastsaveCL;
    

    void Reset()
    {
        // Obtén el personaje desde el componente FirstPersonMovement en los padres.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Bloquea el cursor del mouse dentro de la ventana del juego.
        Cursor.lockState = CursorLockMode.Locked;
        
            // Obtiene la velocidad suavizada del mouse.
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);
        // Rota la cámara hacia arriba y abajo (transform.localRotation) y el controlador izquierda-derecha (character.localRotation) según la velocidad calculada.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        lastsaveCL=character.localRotation;
        lastsaveTL=transform.localRotation;
    }

    void Update()
    {
        // Verifica si la tecla Alt Izquierdo está presionada.
        
        cameraMovementEnabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            cameraMovementEnabled = true; // Desactiva el movimiento de la cámara
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (cameraMovementEnabled)
        {
            // Obtiene la velocidad suavizada del mouse.
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
            frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
            velocity += frameVelocity;
            velocity.y = Mathf.Clamp(velocity.y, -90, 90);

            // Rota la cámara hacia arriba y abajo (transform.localRotation) y el controlador izquierda-derecha (character.localRotation) según la velocidad calculada.
            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
            lastsaveCL=character.localRotation;
            lastsaveTL=transform.localRotation;
        }
        character.localRotation=lastsaveCL;
        transform.localRotation=lastsaveTL;
    }
}
