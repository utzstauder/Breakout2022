using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SnapshotControl : MonoBehaviour
{
    public AudioMixerSnapshot standardSnapshot;
    public AudioMixerSnapshot combatSnapshot;
    public AudioMixerSnapshot storySnapshot;

    public float snapshotTransitionTime = 1f;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            standardSnapshot.TransitionTo(snapshotTransitionTime);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            combatSnapshot.TransitionTo(snapshotTransitionTime);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            storySnapshot.TransitionTo(snapshotTransitionTime);
        }
    }
}
