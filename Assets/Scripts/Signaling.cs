using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
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
        _audioClip.volume = (Mathf.Sin(_runningTime) + 1) / 2;
    }
}