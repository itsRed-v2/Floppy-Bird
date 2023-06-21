using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;

    [Header("Settings")]
    public float heightOffset = 5;

    private float timer = 0;
    private LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > logic.spawnDelay) {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe() {
        float maxHeight = transform.position.y + heightOffset;
        float minHeight = transform.position.y - heightOffset;
        
        Vector3 pipePos = new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), 0);

        Instantiate(pipe, pipePos, transform.rotation);
    }
}
