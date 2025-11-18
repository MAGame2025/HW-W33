using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter : ClickSpawner
{
    [SerializeField]
    [Tooltip("How many points to add to the shooter, if the laser hits its target")]
    int pointsToAdd = 1;

    // A reference to the field that holds the score that has to be updated when the laser hits its target.
    [SerializeField] private NumberField scoreField;

    // audio source for laser shot
    [SerializeField] private AudioSource laserAudioSource;

    private void Start()
    {
        // If not set in Inspector, try to find in children (fallback)
        if (!scoreField)
        {
            scoreField = GetComponentInChildren<NumberField>();
        }

        if (!scoreField)
            Debug.LogError($"No child of {gameObject.name} has a NumberField component!");

        if (!laserAudioSource)
        {
            laserAudioSource = GetComponent<AudioSource>();
        }
    }

    private void AddScore()
    {
        if (scoreField != null)
        {
            scoreField.AddNumber(pointsToAdd);
        }
    }

    protected override GameObject spawnObject()
    {
        // Play shot sound
        if (laserAudioSource != null)
        {
            laserAudioSource.Play();
        }

        GameObject newObject = base.spawnObject();  // base = super

        DestroyOnTrigger2D newObjectDestroyer = newObject.GetComponent<DestroyOnTrigger2D>();
        if (newObjectDestroyer)
            newObjectDestroyer.onHit += AddScore;

        return newObject;
    }
}
