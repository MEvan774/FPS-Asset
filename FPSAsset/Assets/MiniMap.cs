using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private GameObject player;

    [Header("Edit Y value")]
    public Vector3 CamHeight;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //transform.position = player.transform.position;
        transform.position = new Vector3(player.transform.position.x, CamHeight.y, player.transform.position.z);

    }

}
