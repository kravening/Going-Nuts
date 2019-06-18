using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: this needs to be looked at a bit more, see if it could come to be more abstract

/// <summary>
/// This class contains the functionality needed to ruffle the tree.
/// </summary>
    public class TreeRuffleBehaviour : MonoBehaviour
    {    /// <summary>
         /// Gets the particleSystem
         /// </summary>
        [SerializeField] private ParticleSystem _particleSystem;

         /// <summary>
         /// Gets the TreeAnimator
         /// </summary>
        [SerializeField] private Animator _treeAnimator;

         /// <summary>
         /// Get the audioSource to play sound on demand
         /// </summary>
        [SerializeField] private AudioSource _audioSource;

        
        /// <summary>
        /// Makes the tree shake, play audio and particle come out,
        /// </summary>
        public void RuffleTree()
        {
            _particleSystem?.Play(true);
            _treeAnimator?.SetTrigger("Ruffle");
            _audioSource?.Play();
        }
    }