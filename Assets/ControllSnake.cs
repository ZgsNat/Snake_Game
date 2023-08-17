using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllSnake : MonoBehaviour
{   
    public InsideMenu insideMenu;
    public Vector2 move = Vector2.right;
    private bool canrebUp, canrebDown, canrebRight, canrebLeft;
    // Start is called before the first frame update
    private bool canPress;
    private List<Transform> Segments = new List<Transform>();
    public Transform segmentPrefab;
    public AudioSource eating;
    public AudioSource death;
    void Start()
    {
        canrebDown = canrebLeft = canrebRight = canrebUp = true;
        RestartState();
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(canPress)
            if (Input.GetKeyDown(KeyCode.W) && canrebUp)
            {
                move = Vector2.up;
                canrebDown = canPress = false;
                canrebLeft = canrebRight = true;
            }
            else if (Input.GetKeyDown(KeyCode.S) && canrebDown)
            {
                move = Vector2.down;
                canrebUp = canPress = false;
                canrebLeft = canrebRight = true;
            }
            else if (Input.GetKeyDown(KeyCode.A) && canrebLeft)
            {
                move = Vector2.left;
                canrebRight = canPress = false;
                canrebDown = canrebUp = true;
            }
            else if (Input.GetKeyDown(KeyCode.D) && canrebRight)
            {
                move = Vector2.right;
                canrebLeft = canPress = false;
                canrebDown = canrebUp = true;
            }
        
    }

    private void FixedUpdate()
    {
        for(int i = Segments.Count - 1; i > 0; i--)
        {
            Segments[i].position = Segments[i - 1].position; 
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + move.x,
            Mathf.Round(this.transform.position.y) + move.y,
            0.0f
        );
        canPress = true;
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = Segments[Segments.Count - 1].position;
        Segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Food")
        {
            Grow();
            eating.Play();
            ScoreManager.instance.AddPoint();
        }else{
            if(other.tag == "Wall")
            {
                death.Play();
                insideMenu.SetGame();
                Time.timeScale = 0;
                ScoreManager.instance.UpdateHighScore();
                ScoreManager.instance.ResetPoint();
                ScoreManager.instance.Start();
                
            }
        }
    }

    public void RestartState()
    {
        for(int i = 1; i < Segments.Count; i++)
        {
            Destroy(Segments[i].gameObject);
        }
        Segments.Clear();
        Segments.Add(this.transform);
        this.transform.position = new Vector3(0,0,0);
    }
}

