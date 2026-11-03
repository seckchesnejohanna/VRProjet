using TMPro;
using UnityEngine;

public class FloatingMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private TextMeshPro tmp;

    void Start()
    {
        transform.localPosition = new Vector3(0, 0, 0.15f);
        tmp = GetComponentInChildren<TextMeshPro>();
        tmp.fontSize = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 localPos = transform.localPosition;
        Vector3 worldPos = transform.position;

        tmp.text = $"pos local: {localPos.x:F2}, {localPos.y:F2}, {localPos.z:F2}\nWorld: {worldPos.x:F2}, {worldPos.y:F2}, {worldPos.z:F2}";
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);

    }
}
