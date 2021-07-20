using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioClip backgroundMusic;

    private AudioSource _source;

    private void Start()
    {
        _source = gameObject.AddComponent<AudioSource>();
        _source.volume = 0.1f;
    }

    public void PlaySound(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }

    private void Update()
    {
        if (!_source.isPlaying)
        {
            _source.clip = backgroundMusic;
            _source.Play();
        }
    }
}
