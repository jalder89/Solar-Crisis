using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 target;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float shrinkSpeed = 5f;
    [SerializeField] private GameObject destination;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        target = new Vector2(destination.transform.position.x, destination.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime * shrinkSpeed * 1.5f, transform.localScale.y - Time.deltaTime * shrinkSpeed, 1);
    }
}
