using UnityEngine;

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
        _treeAnimator?.SetTrigger(StaticVariables.RUFFLE);
        _audioSource?.Play();
    }
}