using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using GoogleARCore;

public class ARcontroller : MonoBehaviour
{
    private List<DetectedPlane> allplanes = new List<DetectedPlane>();
    private TrackableHitFlags TrackableHitFlagsraycastFilter;

    public Camera FirstPersonCamera;


    public GameObject prefab;

    void Update()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }
        Session.GetTrackables<DetectedPlane>(allplanes, TrackableQueryFilter.All);
        

        Touch myTouch = Input.GetTouch(0);
        if (Input.touchCount < 1 || (myTouch.phase != TouchPhase.Began))
        {
            return;
        }
        else
        {
            TrackableHit hit;
            TrackableHitFlagsraycastFilter = TrackableHitFlags.PlaneWithinPolygon;
            Ray touchPos = FirstPersonCamera.ScreenPointToRay(myTouch.position);
            RaycastHit Rayhit;
            if (Physics.Raycast(touchPos, out Rayhit))
            {
                if (Frame.Raycast(myTouch.position.x, myTouch.position.y, TrackableHitFlagsraycastFilter, out hit))
                {
                    if (hit.Trackable is DetectedPlane && Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position, hit.Pose.rotation * Vector3.up) > 0)
                    {
                        var bp = Instantiate(prefab, Rayhit.point, Quaternion.identity);
                        bp.transform.position = new Vector3(bp.transform.position.x, bp.transform.position.y + 3, bp.transform.position.z);
                        Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);
                        bp.transform.parent = anchor.transform;
                    }
                }
            }
        }
        if (EventSystem.current.IsPointerOverGameObject(myTouch.fingerId))
        {
            return;
        }
    }
}

