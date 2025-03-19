using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class PlayerSounds : MonoBehaviour
{
    public static PlayerSounds Instance { get; private set; }

    [SerializeField] private AudioClip footstep;
    [SerializeField] private float footstepTimerMax;
    [SerializeField] private Transform footPosition;
    [SerializeField] private AudioClip looseGameSound;
    [SerializeField] private AudioClip winGameSound;
    [SerializeField] private AudioClip startGameCue;

    private const float FootstepVolume = 0.5f;
    private float _footstepTimer;
    private AudioSource _source;

    private void Awake()
    {
        Instance = this;

        _source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        YG2.TryGetFlagAsFloat("playerFootstepTimerMax", out footstepTimerMax);
       StartCoroutine(PlayCueAfterWait(startGameCue));
    }

    private void Update()
    {
        _footstepTimer -= Time.deltaTime;
        if (_footstepTimer < 0f)
        {
            _footstepTimer = footstepTimerMax;

            if (PlayerMotor.Instance.IsMoving && PlayerStateMachine.Instance.PlayerState != PlayerState.Hiding)
            {
                AudioSource.PlayClipAtPoint(footstep, footPosition.position, FootstepVolume);
            }
        }
    }

    private IEnumerator PlayCueAfterWait(AudioClip audioClip)
    {
        yield return new WaitForSeconds(1f);
        PlayCue(audioClip);
    }
    
    public void PlayCue(AudioClip audioClip)
    {
        if (!_source.isPlaying)
        {
            _source.PlayOneShot(audioClip);
        }
    }

    public void PlayLooseSound()
    {
        _source.PlayOneShot(looseGameSound);
    }

    public void PlayWinSound()
    {
        _source.PlayOneShot(winGameSound);
    }
}