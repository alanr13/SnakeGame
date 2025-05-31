using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D GridArea;
    LogicManager logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomPosition()
    {
        Bounds bounds = GridArea.bounds;

        this.transform.position = new Vector3(Mathf.Round(Random.Range(bounds.min.x, bounds.max.x)), Mathf.Round(Random.Range(bounds.min.y, bounds.max.y)), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RandomPosition();
            logic.AddScore();
        }
    }
}
