using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Vehicle : MonoBehaviour {
    private Direction dir = Direction.right;
    private enum Direction { left, right, up, down };
    private float speed = 5.0f;
    private Vector3 curPos;

    // Use this for initialization
    void Start() {
        curPos = this.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision");
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (dir != Direction.left) dir = Direction.right;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (dir != Direction.right) dir = Direction.left;
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (dir != Direction.down) dir = Direction.up;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (dir != Direction.up) dir = Direction.down;
        }

        switch (dir) {
            case Direction.left:
                MoveLeft();
                break;
            case Direction.right:
                MoveRight();
                break;
            case Direction.up:
                MoveUp();
                break;
            case Direction.down:
                MoveDown();
                break;
            default:
                break;
        }
        curPos = this.transform.position;

        Instantiate(Resources.Load("wall", typeof(GameObject)), curPos, this.transform.rotation);
    }

    private void MoveUp() {
        this.transform.position += Vector3.up * this.speed * Time.deltaTime;
        this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }

    private void MoveDown() {
        this.transform.position += Vector3.down * this.speed * Time.deltaTime;
        this.transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
    }

    private void MoveRight() {
        this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        this.transform.rotation = Quaternion.AngleAxis(270, Vector3.forward);
    }

    private void MoveLeft() {
        this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        this.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
    }
}
