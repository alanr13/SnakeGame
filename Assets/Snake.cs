using JetBrains.Annotations;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPre;
    LogicManager logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
        segments.Add(this.gameObject.transform);
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
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + direction.x, Mathf.Round(this.transform.position.y)
            + direction.y, 0.0f);
    }

    void Grow()
    {
        Transform segment = Instantiate(segmentPre);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Grow();
        }
        else if (collision.gameObject.tag == "Wall")
        {
            logic.GameOver();
            this.gameObject.SetActive(false);
        }
    }
}
