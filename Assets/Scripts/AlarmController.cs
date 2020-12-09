using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    private AudioSource _audioClip;
    private float _runningTime;

    private void Awake()
    {
        _audioClip = GetComponentInChildren<AudioSource>();
        _audioClip.volume = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<CharacterController>(out CharacterController characterController))
        {
            _audioClip.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController characterController))
        {
            _audioClip.Stop();
        }
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;
        if (_runningTime <= 5)
        {
            _audioClip.volume += 0.2f * Time.deltaTime;
        }
        if (_runningTime > 5 && _runningTime < 10)
        {
            _audioClip.volume -= 0.2f * Time.deltaTime;
        }
        if(_runningTime >= 10)
        {
            _runningTime = 0;
        }
    }
}