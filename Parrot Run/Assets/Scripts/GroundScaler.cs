using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Hoehe berechnen
        float height = Camera.main.orthographicSize * 2f;
        // Breite berechnen
        float width = height * Screen.width / Screen.height;

        
        if (gameObject.name == "Ground") {
            // GameObject (Ground) skalieren
                transform.localScale = new Vector3(width, 2, 0);
            }     
    }

}
