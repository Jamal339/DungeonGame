using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    //save the facing dir somewhere on the room when spawning room look dir of previous room and lock the one out that would go back

    //public GameObject[] spawnPoints;
    public List<GameObject> spawnpoints = new List<GameObject>();

    private RoomTemplates roomTemplates;

    //private bool spawned = false;
    void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        //Choose one of the spawnpoints and spawn it
        Invoke("SpawnRoom", 0.1f);

    }
    void SpawnRoom()
    {
        if (roomTemplates.shouldSpawn)
        {
            doSpawn(spawnpoints);
        }
    }
    void doSpawn(List<GameObject> spawnpoints)
    {
        int randRoom = Random.Range(0, roomTemplates.genRooms.Length);
        int randSpawn = Random.Range(0, spawnpoints.Count);
        Debug.Log(randSpawn);

        if (!Physics2D.OverlapBox(spawnpoints[randSpawn].transform.position, new Vector2(10, 10), 0))
        {
            //use this spawnpoint

            if (roomTemplates.roomNum >= roomTemplates.maxRooms)
            {
                //Spawn Boss Room
            }

            GameObject room = Instantiate(roomTemplates.genRooms[randRoom], spawnpoints[randSpawn].transform.position, roomTemplates.genRooms[randRoom].transform.rotation);

            room.name = room.name + Random.Range(0, 9999).ToString();

            if (roomTemplates.roomNum >= roomTemplates.maxRooms)
            {
                roomTemplates.shouldSpawn = false;
                //Spawn all Walls
                GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
                Debug.Log("Spawning Walls1...");
                Debug.Log(walls.Length);
                for (int i = 0; i < walls.Length; i++)
                {
                    
                    WallSpawner spawner;
                    spawner = walls[i].GetComponent<WallSpawner>();
                    spawner.SpawnWall();
                    Debug.Log("Spawned Wall");
                }
            }
            else
            {
                //spawned = true;
                roomTemplates.roomNum++;
            }
            return;
        }
        else
        {
            //remove form array
            spawnpoints.RemoveAt(randSpawn);
            //Debug print here
            randSpawn = Random.Range(0, spawnpoints.Count);

            if (!Physics2D.OverlapBox(spawnpoints[randSpawn].transform.position, new Vector2(10, 10), 0))
            {
                //use this one

                GameObject room = Instantiate(roomTemplates.genRooms[randRoom], spawnpoints[randSpawn].transform.position, roomTemplates.genRooms[randRoom].transform.rotation);

                room.name = room.name + Random.Range(0, 9999).ToString();

                if (roomTemplates.roomNum >= roomTemplates.maxRooms)
                {
                    roomTemplates.shouldSpawn = false;
                    //Spawn all Walls
                    GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
                    Debug.Log("Spawning Walls...");
                    for (int i = 0; i < walls.Length; i++)
                    {
                        WallSpawner spawner;
                        spawner = walls[i].GetComponent<WallSpawner>();
                        spawner.SpawnWall();
                    }
                }
                else
                {
                    //spawned = true;
                    roomTemplates.roomNum++;
                }
                return;
            }
            else
            {
                spawnpoints.RemoveAt(randSpawn);
                //Debug print here
                randSpawn = Random.Range(0, spawnpoints.Count);
                if (!Physics2D.OverlapBox(spawnpoints[randSpawn].transform.position, new Vector2(10, 10), 0))
                {
                    //use this one

                    GameObject room = Instantiate(roomTemplates.genRooms[randRoom], spawnpoints[randSpawn].transform.position, roomTemplates.genRooms[randRoom].transform.rotation);

                    room.name = room.name + Random.Range(0, 9999).ToString();

                    if (roomTemplates.roomNum >= roomTemplates.maxRooms)
                    {
                        roomTemplates.shouldSpawn = false;
                        //Spawn all Walls
                        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
                        Debug.Log("Spawning Walls...");
                        for (int i = 0; i < walls.Length; i++)
                        {
                            WallSpawner spawner;
                            spawner = walls[i].GetComponent<WallSpawner>();
                            spawner.SpawnWall();
                        }
                    }
                    else
                    {
                        //spawned = true;
                        roomTemplates.roomNum++;
                    }
                    return;
                }
                else
                {
                    spawnpoints.RemoveAt(randSpawn);

                    randSpawn = Random.Range(0, spawnpoints.Count);
                    if (!Physics2D.OverlapBox(spawnpoints[randSpawn].transform.position, new Vector2(10, 10), 0))
                    {
                        //use this one

                        GameObject room = Instantiate(roomTemplates.genRooms[randRoom], spawnpoints[randSpawn].transform.position, roomTemplates.genRooms[randRoom].transform.rotation);

                        room.name = room.name + Random.Range(0, 9999).ToString();

                        if (roomTemplates.roomNum >= roomTemplates.maxRooms)
                        {
                            roomTemplates.shouldSpawn = false;
                            //Spawn all Walls
                            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
                            Debug.Log("Spawning Walls...");
                            for (int i = 0; i < walls.Length; i++)
                            {
                                WallSpawner spawner;
                                spawner = walls[i].GetComponent<WallSpawner>();
                                spawner.SpawnWall();
                            }
                        }
                        else
                        {
                            //spawned = true;
                            roomTemplates.roomNum++;
                        }
                        return;
                    }
                }
            }
        }

    }
}

