using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private SoundBankSO SoundBankSO;

    private void Start()
    {
        Ball.Instance.onSolidHit += Ball_onSolidHit;
    }

    private void Ball_onSolidHit(object sender, System.EventArgs e)
    {
        Debug.Log("SoundPlayed");
        PlaySound();
    }

    private void PlaySound()
    {
        AudioSource.PlayClipAtPoint(GetRandomSoundClip(), Ball.Instance.transform.position, 1f);
    }

    private AudioClip GetRandomSoundClip()
    {
        return SoundBankSO.pongAudioClips[Random.Range(0, SoundBankSO.pongAudioClips.Count)];
    }
}
