using UnityEngine;

[RequireComponent(typeof(AudioSource))]
/// <summary>
/// A simple audio manager singleton template to keep all your audio clips in one place.
/// </summary>
public abstract class AudioManagerBase<T> : Singleton<T> where T : UnityEngine.Object
{
    public AudioClip[] audioClip;
    
    private void Start()
    {
    }

    private void Update()
    {
    }

    /// <summary>
    /// Plays a clip from the default audio clip array in the manager at the index provided.
    /// </summary>
    /// <param name="clipNumber">Clip number.</param>
    ///     /// <param name = "volume">Volume</param>
    public void PlayOneShot(int clipNumber, float volume = 1.0f)
    {
        GetComponent<AudioSource>().volume = volume;
        GetComponent<AudioSource>().PlayOneShot(audioClip[clipNumber]);
    }

    /// <summary>
    /// Plays a clip from the specified clip array at the index provided.
    /// </summary>
    /// <param name="clipArray">Clip array.</param>
    /// <param name="index">Index.</param>
    /// <param name = "volume">Volume</param>
    public void PlayOneShot(AudioClip[] clipArray, int index, float volume = 1.0f)
    {
        GetComponent<AudioSource>().volume = volume;
        GetComponent<AudioSource>().PlayOneShot(clipArray[index]);
    }

    /// <summary>
    /// Plays the specific clip one-shot and at volume
    /// </summary>
    /// <param name="clip">Clip.</param>
    /// <param name="volume">Volume.</param>
    public void PlayOneShot(AudioClip clip, float volume = 1.0f)
    {
        GetComponent<AudioSource>().volume = volume;
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}