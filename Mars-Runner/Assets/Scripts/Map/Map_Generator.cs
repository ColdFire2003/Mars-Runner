using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Generator : MonoBehaviour
{
    private const float Spawn_part_away_from_player_distance = 200f;
    
    [Header("Level Parts")]
    [SerializeField] private Transform Part_LevelStart;
    [SerializeField] private List<Transform> Level_PartsList;

    [Header("player controller")]
    [SerializeField] private Player_Controller Player;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        Player = FindObjectOfType<Player_Controller>();

        lastEndPosition = Part_LevelStart.Find("End").position; // sets the end pos from the start levelpart

        //when the game starts 5 level part will be spawned
        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        //If player gets close a new levelpart will spawn
        if (Vector3.Distance(Player.GetPosition(), lastEndPosition) < Spawn_part_away_from_player_distance)
        {
            SpawnLevelPart();
        }
    }

    //Spawns a random selected level part and adds it to the map
    private void SpawnLevelPart()
    {
        Transform RandomLevelPart = Level_PartsList[Random.Range(0, Level_PartsList.Count)]; // takes a random levelpart form the list
        Transform LastPartPos = SpawnLevelPart(RandomLevelPart, lastEndPosition);
        lastEndPosition = LastPartPos.Find("End").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform TransformLevelPart = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return TransformLevelPart;
    }
}
