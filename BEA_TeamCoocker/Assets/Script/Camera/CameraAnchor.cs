using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;

    // Update is called once per frame
    void Update()
    {
        Vector2 desiredPosition = playerBody.position + playerBody.velocity;

        
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, playerBody.position.y - 1.5f, playerBody.position.y + 3f);
        
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, playerBody.position.x - 5f, playerBody.position.x + 5f);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Mathf.SmoothStep(0f, 1f, 0.1f));

        transform.position = new Vector3(transform.position.x, 0, 0);
    }
}
