using JetBrains.Annotations;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    LogicManager logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
        }
    }

    void FixedUpdate()
    {
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + direction.x, Mathf.Round(this.transform.position.y)
            + direction.y, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            logic.GameOver();
            this.gameObject.SetActive(false);
        }
    }
}
