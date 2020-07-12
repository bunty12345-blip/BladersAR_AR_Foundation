using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ARPlacementManager : MonoBehaviour
{
    ARRaycastManager m_ARrayRaycastManager;
    static List<ARRaycastHit> raycast_Hits = new List<ARRaycastHit>();
    public Camera ARcamera;
    public GameObject battleArenaGameobject;

    private void Awake()
    {
        m_ARrayRaycastManager = GetComponent<ARRaycastManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centerOfScreen = new Vector3(Screen.width / 2, Screen.height / 2);
        Ray ray = ARcamera.ScreenPointToRay(centerOfScreen); // this way we gert rays coming from center of screen

        if (m_ARrayRaycastManager.Raycast(ray, raycast_Hits,TrackableType.PlaneWithinPolygon))
        {
            // inside this means, a ray is sent and it intersects with the detected plane
            Pose hitPose = raycast_Hits[0].pose;

            Vector3 positionToBePlaced = hitPose.position;
            battleArenaGameobject.transform.position = positionToBePlaced;
        }
    }
}
