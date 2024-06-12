using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrow : MonoBehaviour
{
    public ObjectData objectData;
    
    public Transform shadowItem;
    public Transform end;
    public bool objectThrow;
    
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
        
        if(objectThrow == true)
        {
            
            end.gameObject.SetActive(true);
            end.transform.localPosition = new Vector2(objectData.throwDistance, objectData.myCurve.Evaluate(1f));
        }
        else
        {
            end.gameObject.SetActive(false);
        }
    }

    IEnumerator ThrowItem(GameObject item)
    {
        item.GetComponent<Item>().isThrow = true;
        Vector3 startPosition = item.transform.position;
        shadowItem.transform.position = startPosition;
        

        float timer = objectData.travelDuration;
        float chrono = 0f;

        int step = 25;
        float intervalMeter = objectData.throwDistance / step;
        float intervalTime = 1f / step;


        while (chrono / timer < 1f)
        {

            Vector2 curveItem = new Vector2(chrono / timer * objectData.throwDistance * item.transform.right.x, objectData.myCurve.Evaluate(chrono / timer));
            Vector2 curveShadow = new Vector2( 0 , -Mathf.Clamp(objectData.myCurve.Evaluate(chrono / timer) - objectData.myCurve.Evaluate(1f) , 0 , 100));
            item.transform.position = startPosition + (Vector3)curveItem;
            shadowItem.transform.localPosition =(Vector3)curveShadow;
            yield return new WaitForEndOfFrame();
            chrono += Time.deltaTime;
        }
        
        item.GetComponent<Item>().isThrow = false;
        StopCoroutine(ThrowItem(item));
    }

    IEnumerator Bonk(GameObject item)
    {
        item.GetComponent<Item>().isThrow = true;
        Vector3 startPosition = item.transform.position;
        shadowItem.transform.localPosition = Vector3.zero;

        float timer = objectData.travelDuration;
        float chrono = 0f;

        int step = 25;
        float intervalMeter = objectData.bonkDistance / step;
        float intervalTime = 1f / step;


        while (chrono / timer < 1f)
        {
            
            Vector2 curveItem = new Vector2(chrono / timer * objectData.bonkDistance * -item.transform.right.x, objectData.BonkCurve.Evaluate(chrono / timer));
            Vector2 curveShadow = new Vector2(0, -Mathf.Clamp(objectData.BonkCurve.Evaluate(chrono / timer) -objectData.BonkCurve.Evaluate(0.8f), 0, 100));
            
            item.transform.position = startPosition + (Vector3)curveItem;
            shadowItem.transform.localPosition = (Vector3)curveShadow;
            yield return new WaitForEndOfFrame();
            chrono += Time.deltaTime;

        }
        item.GetComponent<Item>().isThrow = false;
        StopCoroutine(ThrowItem(item));

    }

    public void Bonked() 
    {
        StopCoroutine(ThrowItem(this.gameObject));
        StartCoroutine(Bonk(this.gameObject));
    }

    public void Grabed()
    {
        StopAllCoroutines();
    }
}
