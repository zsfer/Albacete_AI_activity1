using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    CharacterController _cc;
    Vector2 _lookRot;

    [SerializeField] float _mouseSens = 2.5f, _moveSpeed = 7;

    void Start()
    {
        _cc = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        var mov = (transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical")).normalized * _moveSpeed;
        _cc.SimpleMove(mov);

        _lookRot.x = Input.GetAxisRaw("Mouse X") * _mouseSens;
        _lookRot.y -= Input.GetAxisRaw("Mouse Y") * _mouseSens;
        _lookRot.y = Mathf.Clamp(_lookRot.y, -90, 90);

        transform.Rotate(0, _lookRot.x, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(_lookRot.y, 0, 0);
    }
}
