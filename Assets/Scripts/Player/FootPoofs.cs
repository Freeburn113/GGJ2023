using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPoofs : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;

    [SerializeField] private FMODUnity.StudioEventEmitter _audio_emitter_left;
    [SerializeField] private FMODUnity.StudioEventEmitter _audio_emitter_right;

    [SerializeField] private ParticleSystem _foot_poof_left;
    [SerializeField] private ParticleSystem _foot_poof_right;
    public void FootPoofLeft()
    {
        if (_controller.isGrounded) { _foot_poof_left.Play(); }
    }

    public void FootPoofRight()
    {
        if (_controller.isGrounded) { _foot_poof_right.Play(); }
    }
}
