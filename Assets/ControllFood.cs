using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllFood : MonoBehaviour
{
    public BoxCollider2D gridArea;
    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }
    
    public void RandomPos()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            RandomPos();
        }
    }
}
