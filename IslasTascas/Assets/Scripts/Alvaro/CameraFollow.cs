using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    MovimientoTomi player;
    void Start()
    {
        player = FindObjectOfType<MovimientoTomi>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newCamPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = new Vector3(newCamPosition.x, newCamPosition.y,-10);
    }
}
