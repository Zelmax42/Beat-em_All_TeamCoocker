using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Clamping: MonoBehaviour
{ 
   
    public Transform target; 
    public Vector3 offset;
    public Transform player;
    public float smoothSpeed = 0.125f; 
    public float minY; 
    public float maxY; 
    public float minX; 
    public float maxX;
    private float _width;
    private Vector4 _clamp;
    public bool isTracking;
    public Vector2 boundaries;

    public void Start()
        {
        _width = Camera.main.pixelWidth * Camera.main.orthographicSize / Camera.main.pixelHeight;
        _clamp = new Vector4(-_width,_width, -Camera.main.orthographicSize, Camera.main.orthographicSize - maxY);
        }
    void LateUpdate()
    {
        /*Vector3 desiredPosition = target.position + offset;


        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);


        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition; 
        */
        _clamp = new Vector4(-_width + transform.position.x, _width + transform.position.x, -Camera.main.orthographicSize, Camera.main.orthographicSize - maxY) ;
        
        if (isTracking)
        {
            Vector3 newpos = new Vector3(0, target.position.y, -10);
            newpos.x = Mathf.Clamp(target.position.x, boundaries.x, boundaries.y);
            transform.position = newpos;

        } 
    }

    public void SwitchMode()
    {
        isTracking = !isTracking; 
    }
    public void ClampPosition (Transform pos)
    {
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(pos.position.x, _clamp.x, _clamp.y);
        newPosition.y = Mathf.Clamp(pos.position.y,_clamp.z, _clamp.w);
        pos.position = newPosition;
    }

    void OnDrawGizmos()
    {
            
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(minX, maxY, 0));
        Gizmos.DrawLine(new Vector3(maxX, minY, 0), new Vector3(maxX, maxY, 0));
        Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(maxX, minY, 0));
        Gizmos.DrawLine(new Vector3(minX, maxY, 0), new Vector3(maxX, maxY, 0));
    }

    public void ConstrainObjectWithinView(Transform obj)
    {
        Vector3 pos = obj.position;

            
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        obj.position = pos;
    }
}