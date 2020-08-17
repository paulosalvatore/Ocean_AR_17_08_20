using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{
    public ARRaycastManager rayManager;

    public GameObject targetMarker;

    public GameObject spherePrefab;

    void Start()
    {
        targetMarker.SetActive(false);
    }

    void Update()
    {
        var x = Screen.width / 2;
        var y = Screen.height / 2;

        var screenCenter = new Vector2(x, y);

        var hitResults = new List<ARRaycastHit>();

        var trackableType = TrackableType.Planes;

        rayManager.Raycast(screenCenter, hitResults, trackableType);

        // Atualizar a posição do target marker
        if (hitResults.Count > 0)
        {
            transform.SetPositionAndRotation(
                hitResults[0].pose.position,
                hitResults[0].pose.rotation
            );

            if (!targetMarker.activeInHierarchy) {
                targetMarker.SetActive(true);
            }
        }

        // Detectar que o usuário clicou na tela e fazer uma ação
        if (Input.GetMouseButtonDown(0))
        {
            var obj = Instantiate(spherePrefab, transform.position, Quaternion.identity);

            obj.transform.Translate(obj.transform.up);
        }
    }
}
