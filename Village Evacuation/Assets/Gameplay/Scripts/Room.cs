using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour{
    
    public GameObject debugVolumeViewer;
    public GameObject[] rooms;

    public void Start(){
        this.debugVolumeViewer.SetActive(false);
        int index = this.getRandomRoomIndex();
        this.rooms[index].SetActive(true);
    }

    private int getRandomRoomIndex(){
        return Random.Range(0, rooms.Length);
    }
}
