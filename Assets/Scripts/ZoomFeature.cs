using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomFeature : MonoBehaviour
{
    Vector2[] touchStart = new Vector2[2];

    public Transform selectedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(Input.touchCount)
        {
            case 1:
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                        touchStart[0] = touch.position;
                }
                break;
            case 2:
                {
                    Touch touch0 = Input.GetTouch(0);
                    if (touch0.phase == TouchPhase.Began)
                        touchStart[0] = touch0.position;
                    Touch touch1 = Input.GetTouch(1);
                    if (touch1.phase == TouchPhase.Began)
                        touchStart[1] = touch1.position;

                    float origDistance = (touchStart[0] - touchStart[1]).magnitude;
                    float newDistance = (touch0.position - touch1.position).magnitude;
                    float scale = newDistance / origDistance;

                    selectedObject.localScale = Vector3.one * scale;
                }
                break;
        }
    }
        
}
