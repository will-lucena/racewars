using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject winAnimation;
    [SerializeField] private GameObject loseAnimation;

    private Vector3 offset = new Vector3(0, 0, -1);
    private int baseCullingMask;
    private Camera cam;

    private void Start()
    {
        if (target.GetComponent<PlayerController>().getPlayerNumber() == 1)
        {
            GetComponent<Camera>().rect = PersistanceScript.INSTANCE.cam1Rect;
        }
        else
        {
            GetComponent<Camera>().rect = PersistanceScript.INSTANCE.cam2Rect;
        }
        cam = GetComponent<Camera>();
        baseCullingMask = cam.cullingMask;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            target.transform.position.x + offset.x,
            target.transform.position.y + offset.y,
            -10);
    }

    public void setTarget(GameObject gameObject)
    {
        target = gameObject;
    }

    public IEnumerator activateWinMessage()
    {
        Instantiate(winAnimation, transform);
        cam.cullingMask = 1 << LayerMask.NameToLayer("winMessageLayer");
        yield return new WaitForSeconds(3);
        target.GetComponent<PlayerController>().SendMessage("endLoop");
    }

    public void activateLoseMessage()
    {
        Instantiate(loseAnimation, transform);
        cam.cullingMask = 1 << LayerMask.NameToLayer("loseMessageLayer");
    }
}
