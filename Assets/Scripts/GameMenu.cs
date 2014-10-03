using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
    public bool isQuitButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp() {
        if (isQuitButton) {
            Debug.Log("quit");
            Application.Quit();
        } else {
            Application.LoadLevel(1);
        }
    }
}
