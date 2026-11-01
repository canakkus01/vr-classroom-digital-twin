using UnityEngine;

/// <summary>
/// Starts and stops the ambient sound of the space (birds, traffic, crowd).
/// Called from the World Space UI button "Ambient Sound".
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AmbientAudioController : MonoBehaviour
{
    private AudioSource ambientSource;

    private void Awake()
    {
        ambientSource = GetComponent<AudioSource>();
        ambientSource.loop = true;
        ambientSource.playOnAwake = false;
    }

    public void ToggleAmbientAudio()
    {
        if (ambientSource.isPlaying)
        {
            ambientSource.Stop();
        }
        else
        {
            ambientSource.Play();
        }
    }
}
