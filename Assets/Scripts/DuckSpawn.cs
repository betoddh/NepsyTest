using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawn : MonoBehaviour
{
    public GameObject prefab;
    public List<Transform> spawners = new List<Transform>();
    public List<Color> spawnColors = new List<Color>();
    [SerializeField] private int maxDucks = 6;
    [SerializeField] private float spawnInterval = 4;
    private readonly List<GameObject> ducks = new List<GameObject>();




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnLoop());

    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            ducks.RemoveAll(d => d == null);

            if (ducks.Count < maxDucks)
                SpawnDuck();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnDuck()
    {
        if (prefab == null || spawners.Count == 0) return;

        Transform point = spawners[Random.Range(0, spawners.Count)];
        GameObject duck = Instantiate(prefab, point.position, point.rotation);

        if (spawnColors.Count > 0)
        {
            Color c = spawnColors[Random.Range(0, spawnColors.Count)];
            foreach (Renderer r in duck.GetComponentsInChildren<Renderer>())
                r.material.color = c;
        }

        ducks.Add(duck);
    }
}
