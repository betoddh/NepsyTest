using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawn : MonoBehaviour
{
    public GameObject prefab;
    public List<Transform> spawners = new List<Transform>();
    public List<Color> spawnColors = new List<Color>();
    [SerializeField] private int maxDucks = 6;
    [SerializeField] private int minPerColor = 2;
    [SerializeField] private float spawnInterval = 4f;

    // Cada pato vivo y el índice de su color
    private readonly Dictionary<GameObject, int> ducks = new Dictionary<GameObject, int>();

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitUntil(() => GlobalVariables.gameStarted);

            CleanDestroyed();

            if (ducks.Count < maxDucks)
                SpawnDuck();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void CleanDestroyed()
    {
        // Un GameObject destruido compara como null
        List<GameObject> dead = new List<GameObject>();
        foreach (var pair in ducks)
            if (pair.Key == null) dead.Add(pair.Key);

        foreach (GameObject d in dead)
            ducks.Remove(d);
    }

    private int PickColorIndex()
    {
        // Cuántos patos vivos hay de cada color
        int[] counts = new int[spawnColors.Count];
        foreach (int idx in ducks.Values)
            counts[idx]++;

        // Colores que no llegan al mínimo
        List<int> missing = new List<int>();
        for (int i = 0; i < counts.Length; i++)
            if (counts[i] < minPerColor) missing.Add(i);

        if (missing.Count > 0)
            return missing[Random.Range(0, missing.Count)];

        // Si todos cumplen el mínimo, cualquier color
        return Random.Range(0, spawnColors.Count);
    }

    private void SpawnDuck()
    {
        if (prefab == null || spawners.Count == 0 || spawnColors.Count == 0) return;

        Transform point = spawners[Random.Range(0, spawners.Count)];
        GameObject duck = Instantiate(prefab, point.position, point.rotation);

        int colorIndex = PickColorIndex();
        Color c = spawnColors[colorIndex];
        foreach (Renderer r in duck.GetComponentsInChildren<Renderer>())
            r.material.color = c;

        ducks.Add(duck, colorIndex);
    }
}