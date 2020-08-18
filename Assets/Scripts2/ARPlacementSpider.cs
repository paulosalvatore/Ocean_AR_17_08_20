using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementSpider : MonoBehaviour
{
    public GameObject targetMarker;

    public ARRaycastManager rayManager;

    public SpiderMovement spider;

    private bool firstHit;

    private void Update()
    {
        var hitResults = new List<ARRaycastHit>();

        var screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        rayManager.Raycast(screenCenter, hitResults, TrackableType.Planes);

        if (hitResults.Count > 0) {
            var hit = hitResults[0];

            transform.position = hit.pose.position;
            transform.rotation = hit.pose.rotation;

            if (!targetMarker.activeInHierarchy)
            {
                targetMarker.SetActive(true);
            }

            if (!firstHit) {
                firstHit = true;
            }
        }

        if (Input.GetMouseButtonDown(0) && firstHit)
        {
            spider.targetPosition = transform.position;

            if (!spider.gameObject.activeInHierarchy) {
                spider.transform.position = transform.position;
                spider.gameObject.SetActive(true);
            }
        }
    }
}
