using UnityEngine;
using NUnit.Framework;

public class SoundManager : MonoBehaviour
{
    [Header("Player Audio")]
    [SerializeField] private AudioClip playerHurtSound;
    [SerializeField] private AudioClip playerDeathSound;

    [Header("Enemy Audio")]
    [SerializeField] private AudioClip alienDeathSound;

    [Header("Shot Audio")]
    [SerializeField] private AudioClip bulletShotSound;
    [SerializeField] private AudioClip missileShotSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        var EventChannels = Finder.EventChannels;
        EventChannels.OnPlayerHurt += PlayHurtSound;
        EventChannels.OnPlayerDead += PlayDeathSound;
        EventChannels.OnBulletHitAlien += PlayAlienDeathSound;
        EventChannels.OnPlayerHitAlien += PlayAlienDeathSound;
        EventChannels.OnFireBullet += PlayBulletShotSound;
        EventChannels.OnFireMissile += PlayMissileShotSound;
    }

    private void PlayHurtSound()
    {
        audioSource.PlayOneShot(playerHurtSound);
    }

    private void PlayDeathSound()
    {
        audioSource.PlayOneShot(playerDeathSound);
    }

    private void PlayAlienDeathSound()
    {
        audioSource.PlayOneShot(alienDeathSound);
    }

    private void PlayBulletShotSound()
    {
        audioSource.PlayOneShot(bulletShotSound);
    }

    private void PlayMissileShotSound()
    {
        audioSource.PlayOneShot(missileShotSound);
    }


}
