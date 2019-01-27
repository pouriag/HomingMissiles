using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

    public GameObject road;
    public List<GameObject> spawnables;
    public List<GameObject> items;

    public int min, max;
    public int finalMin, finalMax;
    public int minItems, maxItems;
    public float timeInterval;

    private List<float> xGrids, yGrids;

    private List<KeyValuePair<int, int>> usedGrids;

    private float locStartTime = 0;

    // Use this for initialization
    void Start()
    {
        xGrids = new List<float>() { 9.55f, 10.9f, 12.25f, 13.6f, 14.95f, 16.3f, 17.65f, 19f, 20.35f, 21.7f, 23.05f, 24.4f, 25.75f, 27.1f, 28.45f};
        yGrids = new List<float>() { 4.5f, 3.15f, 1.8f, 0.45f, -0.9f, -2.25f, -3.6f, -4.95f };

        usedGrids = new List<KeyValuePair<int, int>>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad - locStartTime > timeInterval)
        {
            locStartTime = Time.timeSinceLevelLoad;

            if (min < finalMin)
            {
                min ++;
            }

            if (max < finalMax)
            {
                max ++;
            }
        }
    }

    public void SpawnObjects()
    {
        int spawnNum = Random.Range(min, max);
        int itemNum = Random.Range(minItems, maxItems);

        while (spawnNum > 0)
        {
            spawnNum--;

            int i = Random.Range(0, spawnables.Count);

            int xInd;
            int yInd;
            do
            {
                xInd = Random.Range(0, xGrids.Count);
                yInd = Random.Range(0, yGrids.Count);
            } while (usedGrids.Contains(new KeyValuePair<int, int>(xInd, yInd)));

            usedGrids.Add(new KeyValuePair<int, int>(xInd, yInd));
            float x = xGrids[xInd];
            float y = yGrids[yInd];

            GameObject newObj = Instantiate(spawnables[i], new Vector3(x, y, 0f), Quaternion.Euler(0f, -90f, 90f));
            newObj.transform.parent = road.transform;
        }

        while (itemNum > 0)
        {
            itemNum--;

            int i = Random.Range(0, items.Count);

            int xInd;
            int yInd;
            do
            {
                xInd = Random.Range(0, xGrids.Count);
                yInd = Random.Range(0, yGrids.Count);
            } while (usedGrids.Contains(new KeyValuePair<int, int>(xInd, yInd)));

            usedGrids.Add(new KeyValuePair<int, int>(xInd, yInd));
            float x = xGrids[xInd];
            float y = yGrids[yInd];

            GameObject newObj = Instantiate(items[i], new Vector3(x, y, 0f), Quaternion.identity);
            newObj.transform.parent = road.transform;
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Background")
        {
            other.transform.position = new Vector3(31.6f, 0f, 0f);

            SpawnObjects();
        }
        else
        {
            int index = yGrids.IndexOf(other.transform.position.y);

            foreach(KeyValuePair<int, int> pair in usedGrids.ToArray())
            {
                if (pair.Value == index)
                {
                    usedGrids.Remove(pair);
                }
            }

            Destroy(other.gameObject);
        }
    }
}
