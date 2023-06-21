using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    // public float pipeSpeed;
    public float killPosition = -40;
    private LogicScript logic;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * logic.gameSpeed * Time.deltaTime;
        // transform.position += Vector3.left * 7 * Time.deltaTime;

        if (transform.position.x < killPosition) {
            Destroy(gameObject);
        }
    }
}
