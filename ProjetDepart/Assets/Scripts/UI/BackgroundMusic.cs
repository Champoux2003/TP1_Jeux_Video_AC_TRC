using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [Header("Background Music")]
    [SerializeField, Range(0, 1)] private float minVolume = 0.1f;
    [SerializeField, Range(0,1)] private float maxVolume = 0.5f;
    [SerializeField] private AudioClip[] backgroundMusic;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        playRandomMusic();

    }

    private void playRandomMusic()
    {
        audioSource.clip = backgroundMusic[Random.Range(0, backgroundMusic.Length)];
        audioSource.volume = Mathf.Lerp(minVolume, maxVolume, Random.value);
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
            playRandomMusic();
    }
}
