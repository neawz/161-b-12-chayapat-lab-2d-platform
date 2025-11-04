using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class HealthBarUI : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 1.5f, 0);
    public Image healthFill;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (target == null) return;
        Vector3 screenPos = cam.WorldToScreenPoint(target.position + offset);
        transform.position = screenPos;
    }

    public void SetHealth(float current, float max)
    {
        healthFill.fillAmount = current / max;
    }
}
