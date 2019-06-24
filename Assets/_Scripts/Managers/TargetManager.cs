using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// This class manages a collection of target controllers
/// </summary>
public class TargetManager : SingletonBase<TargetManager>
{
    /// <summary>
    /// a list with references to targets in the field.
    /// </summary>
    public List<TargetController> targets = new List<TargetController>();

    /// <summary>
    /// maximum amount of targets that can come out of hiding in one moment, new ones won't spawn if the current amount of targets in the field are higher or equal to this number.
    /// </summary>
    private int _maxTargetsShowing = 5;

    /// <summary>
    /// minimum amount of targets to show at one time, if there are less targets than this number currently in the game field a new one will come out of hiding.
    /// </summary>
    private int _minTargetsShowing = 1;

    /// <summary>
    /// the current amount of targets out showing in the game field.
    /// </summary>
    private int _currentShowingTargets = 0;

    /// <summary>
    /// the minimal amount of time it takes for a target to show up.
    /// </summary>
    private float _minAppearTimer = 1;

    /// <summary>
    /// the maximum possible amount of time it takes for a target to show up.
    /// </summary>
    private float _maxAppearTimer = 3;

    /// <summary>
    /// a variable to keep the time for when a new target will show up.
    /// </summary>
    private float _currentNewTargetTime = 0;

    /// <summary>
    /// a boolean that tells this manager if the game is paused or not.
    /// </summary>
    private bool _isGameRunning = false;

    protected override void Awake()
    {
        base.Awake();
        // if there are more max targets showing in the targets list, set max targets showing to the amount of elements in the list to prevent index errors.
        if (_maxTargetsShowing > targets.Count)
        {
            _maxTargetsShowing = targets.Count;
        }
    }
    /// <summary>
    /// subcribes Resumes spawning om het GamestartEvent
    /// Subcribes het PauseSpawning op het GameEndedEvent
    /// </summary>
    private void Start()
    {
        EventCatalogue.GameStartedEvent += ResumeSpawning;
        EventCatalogue.GameEndedEvent += PauseSpawning;
    }
    /// <summary>
    /// Unsubscribes all the subcribed events in dit script
    /// </summary>
    private void OnDestroy()
    {
        EventCatalogue.GameStartedEvent -= ResumeSpawning;
        EventCatalogue.GameEndedEvent -= PauseSpawning;
    }

    private void Update()
    {
        if (!_isGameRunning) // don't execute any update logic if the game isn't running
        {
            return;
        }

        UpdateTimer();
        CheckToSeeIfTargetWillSpawn();
    }

    /// <summary>
    /// this functions decrements the targetTimer with the unity deltaTime each frame.
    /// </summary>
    private void UpdateTimer()
    {
        _currentNewTargetTime -= Time.deltaTime;
    }

    /// <summary>
    /// this function will run through a few checks to see if it's the right moment to call for a new target
    /// </summary>
    private void CheckToSeeIfTargetWillSpawn()
    {
        //less than the minimum amount of targets in the field, force a target to show.
        if (_currentShowingTargets < _minTargetsShowing)
        {
            ShowNewTarget();
            return;
        }

        //it's not yet time to spawn to spawn a target, exit function.
        if (_currentNewTargetTime >= 0)
        {
            return;
        }

        //there already are enough targets out on the field, exit function.
        if (_currentShowingTargets >= _maxTargetsShowing)
        {
            return;
        }

        ShowNewTarget();
        ResetTargetTimer();
    }

    /// <summary>
    /// this function calls a random hidden target to show itself.
    /// </summary>
    private void ShowNewTarget()
    {
        int randomIndex = Random.Range(0, targets.Count);
        targets[randomIndex].Show();
    }

    /// <summary>
    /// randomly set a time for a new target to appear, the random number is based on the min and max appear time.
    /// </summary>
    private void ResetTargetTimer()
    {
        _currentNewTargetTime = Random.Range(_minAppearTimer, _maxAppearTimer);
    }

    /// <summary>
    /// increment the counter of how many targets currently are in the field.
    /// </summary>
    public void TargetShown()
    {
        _currentShowingTargets++;
    }

    /// <summary>
    /// decrements the counter of how many targets currently are in the field.
    /// </summary>
    public void TargetHiding()
    {
        _currentShowingTargets--;
    }

    /// <summary>
    /// pauses the spawning of targets
    /// </summary>
    private void PauseSpawning()
    {
        _isGameRunning = false;
    }

    /// <summary>
    /// resumes the spawning of targets
    /// </summary>
    private void ResumeSpawning()
    {
        _isGameRunning = true;
    }
}