using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySounds : MonoBehaviour
{
    [SerializeField] private AudioClip chaseStartCue;
    [SerializeField] private AudioClip lostTargetCue;
    [SerializeField] private AudioClip[] findingCues;
    [SerializeField] private float maxTimeCue;

    private EnemyAI _enemy;
    private float _timeCue;
    private AudioSource _audioSource;

    private void Awake()
    {
        _enemy = GetComponent<EnemyAI>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _enemy.OnStateChanged += PlayCueOnStateChanged;
    }

    private void OnDisable()
    {
        _enemy.OnStateChanged -= PlayCueOnStateChanged;
    }

    private void Update()
    {
        if (_timeCue < maxTimeCue)
        {
            _timeCue += Time.deltaTime;
        }
        else
        {
            _timeCue = 0;
            PlayAudioClip(findingCues[Random.Range(0, findingCues.Length)]);
        }
    }

    void PlayCueOnStateChanged()
    {
        switch (_enemy.EnemyState)
        {
            case EnemyState.Chasing:
                AudioSource.PlayClipAtPoint(chaseStartCue, PlayerSounds.Instance.transform.position, 1f); //unique case when her voice should be in player's head
                break;
            case EnemyState.LostTarget:
                PlayAudioClip(lostTargetCue);
                break;
        }
    }

    private void PlayAudioClip(AudioClip clip)
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}