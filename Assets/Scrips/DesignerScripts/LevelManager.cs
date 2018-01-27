using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public string SceneName;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<RoombaControl>().controller.tag == "Player")
        {
            Debug.Log("YOU DID IT");
            SceneManager.LoadScene(SceneName);

        }
    }
}
