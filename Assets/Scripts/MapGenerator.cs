using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    
    public GameObject prevCeilling;
    public GameObject prevFloor;
    public GameObject ceilling;
    public GameObject floor;
    public GameObject player;
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;
    public GameObject obstaclePrefab;
    public float minObstacleY;
    public float maxObstacleY;
    public float minObstacleSpace;
    public float maxObstacleSpace;
    public float minObstacleScaleY;
    public float maxObstacleScaleY;



    // Start is called before the first frame update
    void Start()
    {
        //With the generateObstacle() method, the obstacles will be instantiated in a random position
        obstacle1 = generateObstacle(player.transform.position.x + 10);

        obstacle2 = generateObstacle(obstacle1.transform.position.x);

        obstacle3 = generateObstacle(obstacle2.transform.position.x);

        obstacle4 = generateObstacle(obstacle3.transform.position.x);

        GameObject generateObstacle(float referenceX)
        {
            GameObject obstacle = GameObject.Instantiate(obstaclePrefab);
            setTransform(obstacle, referenceX);
            return obstacle;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //this if statement will generate the scenario whenever the player is approaching its end
        if(player.transform.position.x > floor.transform.position.x) 
        {
            var tempCeilling = prevCeilling; // Temporary variable that will receive the game object
            var tempFloor = prevFloor; // Temporary variable that will receive the game object
            prevCeilling = ceilling;
            prevFloor = floor;
            tempCeilling.transform.position += new Vector3(80, 0, 0); //This line updates the object's position
            tempFloor.transform.position += new Vector3(80, 0, 0); //This line updates the object's position
            ceilling = prevCeilling;
            floor = prevFloor;
        }
        if(player.transform.position.x > obstacle4.transform.position.x) 
        {
            var tempObstacle = obstacle1;
            obstacle1 = obstacle2;
            obstacle3 = obstacle2;
            setTransform(tempObstacle, obstacle3.transform.position.x);
            obstacle4 = obstacle3;
        }
    }
    void setTransform(GameObject obstacle, float referenceX)
    {
            obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpace, maxObstacleSpace), Random.Range(minObstacleY, maxObstacleY), 0);
            obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x, Random.Range(minObstacleScaleY, maxObstacleScaleY), obstacle.transform.localScale.z);
    }
}
