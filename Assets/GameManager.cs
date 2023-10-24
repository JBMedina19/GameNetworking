using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Unity.VisualScripting;
using Photon;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject CameraFollowGameObject;
    public List<GameObject> PlayersSpawned = new List<GameObject>();

    public void HandlePlayerJoined(NetworkTransform player)
    {
        //Instantiate the player object when a player joins the game
       CameraFollow _mc =Instantiate(CameraFollowGameObject, player.transform.position, Quaternion.identity).GetComponent<CameraFollow>();
        _mc.Target = player.InterpolationTarget;
        _mc.smoothSpeed = 10;
        _mc.offset = new Vector3(0, 3, -8);
    }




}
