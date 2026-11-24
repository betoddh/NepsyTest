
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

    // 0 = Red, 1 = Blue, 2 = Yellow
    private const int RedIndex = 0;
    private const int BlueIndex = 1;
    private const int YellowIndex = 2;

    private readonly Dictionary<GameObject, int> ducks =
        new Dictionary<GameObject, int>();

    private bool firstDuckSpawned = false;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private void Update()
    {
        if (!GlobalVariables.gameStarted)
            return;

        CleanDestroyed();

        // CASE B
        if (GlobalVariables.caseB)
        {
            EnsureRequiredDuck();
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitUntil(
                () => GlobalVariables.gameStarted
            );

            CleanDestroyed();

            if (ducks.Count < maxDucks)
            {
                int colorIndex = -1;

                // CASE A
                if (GlobalVariables.caseA)
                {
                    colorIndex = PickCaseAColor();
                }
                // CASE B
                else if (GlobalVariables.caseB)
                {
                    colorIndex = PickColorWithMinimum();
                }

                if (colorIndex >= 0)
                {
                    SpawnDuck(colorIndex);
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }


    private int PickCaseAColor()
    {
        if (!firstDuckSpawned)
        {
            firstDuckSpawned = true;
            return RedIndex;
        }

        return PickColorWithMinimum();
    }

    private int PickColorWithMinimum()
    {
        int[] counts = CountDucks();

        List<int> missing = new List<int>();

        for (int i = 0; i < spawnColors.Count; i++)
        {
            if (counts[i] < minPerColor)
            {
                missing.Add(i);
            }
        }

        if (missing.Count > 0)
        {
            return missing[Random.Range(0, missing.Count)];
        }

        return Random.Range(0, spawnColors.Count);
    }

    private int[] CountDucks()
    {
        int[] counts = new int[spawnColors.Count];

        foreach (var pair in ducks)
        {
            if (pair.Value >= 0 &&
                pair.Value < counts.Length)
            {
                counts[pair.Value]++;
            }
        }

        return counts;
    }

    private void EnsureRequiredDuck()
    {
        int requiredColor = -1;

        if (GlobalVariables.isRed)
            requiredColor = RedIndex;
        else if (GlobalVariables.isBlue)
            requiredColor = BlueIndex;
        else if (GlobalVariables.isYellow)
            requiredColor = YellowIndex;

        if (requiredColor < 0 ||
            requiredColor >= spawnColors.Count)
            return;

        int[] counts = CountDucks();


        if (counts[requiredColor] > 0)
            return;


        if (ducks.Count < maxDucks)
        {
            SpawnDuck(requiredColor);
            return;
        }

        List<GameObject> candidates = new List<GameObject>();

        foreach (var pair in ducks)
        {
            int index = pair.Value;

            if (index != requiredColor &&
                counts[index] > minPerColor)
            {
                candidates.Add(pair.Key);
            }
        }

        if (candidates.Count > 0)
        {
            GameObject oldDuck = candidates[
                Random.Range(0, candidates.Count)
            ];

            ducks.Remove(oldDuck);
            Destroy(oldDuck);

            SpawnDuck(requiredColor);
        }
    }

    private void SpawnDuck(int colorIndex)
    {
        if (prefab == null ||
            spawners.Count == 0 ||
            colorIndex < 0 ||
            colorIndex >= spawnColors.Count)
            return;

        CleanDestroyed();

        if (ducks.Count >= maxDucks)
            return;

        Transform point = spawners[
            Random.Range(0, spawners.Count)
        ];

        GameObject duck = Instantiate(
            prefab,
            point.position,
            point.rotation
        );

        Color c = spawnColors[colorIndex];

        foreach (Renderer r in duck.GetComponentsInChildren<Renderer>())
        {
            r.material.color = c;
        }

        ducks.Add(duck, colorIndex);
    }

    private void CleanDestroyed()
    {
        List<GameObject> dead = new List<GameObject>();

        foreach (var pair in ducks)
        {
            if (pair.Key == null)
            {
                dead.Add(pair.Key);
            }
        }

        foreach (GameObject d in dead)
        {
            ducks.Remove(d);
        }
    }
}
