using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentOpener : MonoBehaviour {

	void Trigger()
    {
        LeanTween.rotate(gameObject, new Vector3(90, 0, 0), 1).setEaseInQuad();
    }
}
