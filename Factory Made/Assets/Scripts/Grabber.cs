using UnityEngine;

public class Grabber : MonoBehaviour
{
    public Camera playerCam;
    private GameObject selectedObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(selectedObject == null)
            {
                RaycastHit hit = CastRay();
                if(hit.collider != null)
                {
                    if (!hit.collider.CompareTag("drag"))
                    {
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            else
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCam.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = playerCam.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(worldPosition.x, 0f, worldPosition.z);

                selectedObject = null;
                Cursor.visible = true;
            }

        }
        if(selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCam.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = playerCam.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, 0.25f, worldPosition.z);
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePositionFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCam.farClipPlane);
        Vector3 screenMousePositionNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCam.nearClipPlane);

        Vector3 worldMousePositionFar = playerCam.ScreenToWorldPoint(screenMousePositionFar);
        Vector3 worldMousePositionNear = playerCam.ScreenToWorldPoint(screenMousePositionNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePositionNear, worldMousePositionFar - worldMousePositionNear, out hit);

        return hit;
    }

}
