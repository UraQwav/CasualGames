using UnityEngine;
using UnityEngine.EventSystems;

public class MoveControl : MonoBehaviour
{
    public bool _isMoving;
    public float speed = 8f;
    private Vector3 touchPosition;
    private Vector3 direction;
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rigidbody.velocity = new Vector2(direction.x, direction.y) * speed;
            if (touch.phase == TouchPhase.Ended)
                rigidbody.velocity = Vector2.zero;
            _isMoving = true;
        }
        else _isMoving = false;
    }

}