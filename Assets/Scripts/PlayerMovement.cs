using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxXPos;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                if (Mathf.Abs(playerTransform.position.x + touch.deltaPosition.x * moveSpeed) > maxXPos) return;
                playerTransform.position += Vector3.right * touch.deltaPosition.x * moveSpeed;
            }
        }
    }
}
