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

    [Header("Power Up Audio")]
    [SerializeField] private AudioClip powerUpSpawnSound;
    [SerializeField] private AudioClip powerUpCollectSound;

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
        EventChannels.OnPowerUpSpawn += PlayPowerUpSpawnSound;
        EventChannels.OnHealthPowerUp += PlayPowerUpCollectSound;
        EventChannels.OnMissilePowerUp += PlayPowerUpCollectSound;
        EventChannels.OnBulletPowerUp += PlayPowerUpCollectSound;
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

    private void PlayPowerUpSpawnSound()
    {
        audioSource.PlayOneShot(powerUpSpawnSound);
    }

    private void PlayPowerUpCollectSound() {
        audioSource.PlayOneShot(powerUpCollectSound);
    }

}
