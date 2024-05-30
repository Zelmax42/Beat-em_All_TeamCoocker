using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamping: MonoBehaviour
{ 
   
        public Transform target; 
        public Vector3 offset; 
        public float smoothSpeed = 0.125f; 
        public float minY; 
        public float maxY; 
        public float minX; 
        public float maxX;
        private float _width;
        private Vector3 _clamp;

        public void Start()
         {
            _width = Camera.main.pixelWidth * Camera.main.orthographicSize / Camera.main.pixelHeight;
            _clamp = new Vector3(_width, -Camera.main.pixelHeight, Camera.main.pixelHeight - maxY);
         }
        void LateUpdate()
        {
            
                /*Vector3 desiredPosition = target.position + offset;

            
                desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
                desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);

            
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition; 
                */
               
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