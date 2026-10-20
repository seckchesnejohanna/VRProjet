using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
