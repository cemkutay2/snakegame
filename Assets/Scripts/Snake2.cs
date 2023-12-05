using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

// add 2p
public class Snake2 : MonoBehaviour
{
    private Vector2 _direction = Vector2.left;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;
    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        // assign _direction based on keypress  
        if (Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down)
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up)
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left)
        {
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right)
        {
            _direction = Vector2.left;
        }
    }
    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        // update snakehead based on _direction (rounded up to fit in "grid")
        this.transform.position = new Vector3(
            Mathf.Round(transform.position.x) + _direction.x,
            Mathf.Round(transform.position.y) + _direction.y,
            0.0f
        );
    }
    private void Grow()
    {
        // create SnakeSegments
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
    private void ResetState()
    {
        // delete SnakeSegment objects
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        // clear list and create default snake
        _segments.Clear();
        _segments.Add(this.transform);
        for (int i = 1; i < initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // collision
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            ResetState();
        }
        // wall TP
        else if (other.tag == "Wall")
        {
            if (_direction == Vector2.up)
            {
                this.transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y - 23f,
                    0.0f
                );
            }
            else if (_direction == Vector2.down)
            {
                this.transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y + 23f,
                    0.0f
                );
            }
            else if (_direction == Vector2.right)
            {
                this.transform.position = new Vector3(
                    transform.position.x - 47f,
                    transform.position.y,
                    0.0f
                );
            }
            else if (_direction == Vector2.left)
            {
                this.transform.position = new Vector3(
                    transform.position.x + 47f,
                    transform.position.y,
                    0.0f
                );
            }
        }
    }
}
