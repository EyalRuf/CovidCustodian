using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnParent;
    public List<GameObject> spawnables;
    public CoronaMetersManager cm;

    public float spawnTimeMin = 1f;
    public float spawnTimeMax = 4f;

    public float spawnMoveSpeedMin = 1f;
    public float spawnMoveSpeedMax = 2.5f;

    public float leftSpawnX = 0;
    public float rightSpawnX = 0;
    public float spawnYMin = 0;
    public float spawnYMax = 0;

    void Start()
    {
        StartCoroutine(SpawnCycle());
    }

    IEnumerator SpawnCycle ()
    {
        // Wait random time before spawning
        float spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
        yield return new WaitForSeconds(spawnTimer);

        // Spawn with randomized values & start another spawn cycle
        RandomizeAndSpawn();
        StartCoroutine(SpawnCycle());
    }

    void RandomizeAndSpawn()
    {
        GameObject spawned = spawnables[Random.Range(0, spawnables.Count)];
        float movespeed = Random.Range(spawnMoveSpeedMin, spawnMoveSpeedMax);
        float spawnX = leftSpawnX;
        float spawnY = Random.Range(spawnYMin, spawnYMax);
        int dir = Random.Range(0, 2);
        Vector2 moveVec = new Vector2(1, 0);

        if (dir == 0)
        {
            moveVec *= -1;
            spawnX = rightSpawnX;
        }

        SpawnMovingInteractable(spawned, movespeed, moveVec, spawnX, spawnY);
    }

    public MovingInteractable SpawnMovingInteractable (GameObject prefab, float movespeed, Vector2 moveVec, float spawnX, float spawnY)
    {
        GameObject spawned = Instantiate(prefab, spawnParent);
        MovingInteractable spawnedMI = spawned.GetComponent<MovingInteractable>();
        spawnedMI.movementSpeed = movespeed;
        spawnedMI.transform.position = new Vector2(spawnX, spawnY);
        spawnedMI.movementVec = moveVec;
        spawnedMI.cm = cm;

        if (spawnedMI.GetType().Equals(typeof(Couple))) {
            ((Couple) spawnedMI).sm = this;
        }

        return spawnedMI;
    }
}
