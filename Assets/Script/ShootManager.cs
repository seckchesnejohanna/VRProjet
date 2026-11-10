using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UIElements;

public class ShootManager : MonoBehaviour
{
    [SerializeField] Transform rightController;
    private InputDevice _rightController;
    [SerializeField] float vise = 10f;
    [SerializeField] GameObject prefParticules;
    [SerializeField] AudioClip audioClip;
    [SerializeField] private GameObject[] targets;
    private bool triggerPressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        targets = GameObject.FindGameObjectsWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_rightController.isValid)
        {
            _rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            if (!_rightController.isValid) return;
        }

        _rightController.TryGetFeatureValue(CommonUsages.triggerButton, out triggerPressed);

        for (var i = 0; i < targets.Length; i++)
        {
            float dist = Vector3.Distance(rightController.transform.position, targets[i].transform.position);
            Vector3 direction = targets[i].transform.position - rightController.transform.position;
            float angle = Vector3.Angle(rightController.transform.forward, direction);

            if (angle < vise && triggerPressed)
            {
                GameObject particles = Instantiate(prefParticules, targets[i].transform.position, targets[i].transform.rotation);
                AudioSource audioSource = targets[i].GetComponent<AudioSource>();
                audioSource.PlayOneShot(audioClip);
            }
        }

    }
}
