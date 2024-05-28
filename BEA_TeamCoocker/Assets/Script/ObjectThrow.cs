using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrow : MonoBehaviour
{
    public ObjectData objectData;
    // Start is called before the first frame update
    
    public void ThrowObject()
    {
        StartCoroutine(ThrowItem(this.gameObject));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ThrowItem(GameObject item)
    {

        Vector3 startPosition = item.transform.position;

        float timer = objectData.travelDuration;
        float chrono = 0f;

        int step = 25;
        float intervalMeter = objectData.throwDistance / step;
        float intervalTime = 1f / step;


        while (chrono / timer < 1f)
        {

            Vector2 curve = new Vector2(chrono / timer * objectData.throwDistance * item.transform.right.x, objectData.myCurve.Evaluate(chrono / timer));
            Debug.Log(curve);
            item.transform.position = startPosition + (Vector3)curve;
            yield return new WaitForEndOfFrame();
            chrono += Time.deltaTime;
        }
       
        StopCoroutine(ThrowItem(item));
    }
}
