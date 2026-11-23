using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawn : MonoBehaviour
{
    public GameObject prefab;
    public List<Transform> spawners = new List<Transform>();
    public List<Color> spawnColors = new List<Color>();
    [SerializeField] private int maxDucks = 6;
    [SerializeField] private float spawnInterval = 4f;

    private readonly List<GameObject> ducks = new List<GameObject>();
    private int colorIndex = 0;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitUntil(() => GlobalVariables.gameStarted);

            ducks.RemoveAll(d => d == null);

            if (ducks.Count < maxDucks)
                SpawnDuck();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnDuck()
    {
        if (prefab == null || spawners.Count == 0 || spawnColors.Count == 0) return;

        Transform point = spawners[Random.Range(0, spawners.Count)];
        GameObject duck = Instantiate(prefab, point.position, point.rotation);

        Color c = spawnColors[colorIndex];
        foreach (Renderer r in duck.GetComponentsInChildren<Renderer>())
            r.material.color = c;

        colorIndex = (colorIndex + 1) % spawnColors.Count;

        ducks.Add(duck);
    }
}