using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject winAnimation;
    [SerializeField] private GameObject loseAnimation;

    private Vector3 offset = new Vector3(0, 0, -1);
    private static int seed = 0;
    private int baseCullingMask;
    private Camera cam;

    private void Start()
    {
        GetComponent<Camera>().rect = new Rect(seed * 0.5f, 0f, 0.5f, 1f);
        updateSeed();
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

    private static void updateSeed()
    {
        seed++;
    }

    public int getSeed()
    {
        return seed;
    }

    public IEnumerator activateWinMessage()
    {
        Instantiate(winAnimation, transform);
        cam.cullingMask = 1 << LayerMask.NameToLayer("winMessageLayer");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

    public void activateLoseMessage()
    {
        Instantiate(loseAnimation, transform);
        cam.cullingMask = 1 << LayerMask.NameToLayer("loseMessageLayer");
    }
}
