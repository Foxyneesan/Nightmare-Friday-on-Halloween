using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{


    float amount;
    public GameObject player;
    Vector3 direction;
    Vector3 runPoint;

    //Reference to waypoints
    public List<Transform> points;
    //The int value for next point index
    public int nextID = 0;
    //The value of that applies to ID for changing
    int idChangeValue = 1;
    //Speed of movement or flying
    public float speed = 2;

    void Start()
    {
        runPoint = transform.position;
    }

    private void Update()
    {
        MoveToNextPoint();

        amount = ((player.transform.position) - (transform.position)).magnitude;
        direction = ((player.transform.position) - (transform.position)).normalized;

        if (amount > 100)
        {
            MoveToNextPoint();
        }

        else
        {
            run();
        }
    }

    void run()
    {
        if ((runPoint - transform.position).magnitude < 5) ;

    }

    void MoveToNextPoint()
    {
        //Get the next Point transform
        Transform goalPoint = points[nextID];
        //Flip the enemy transform to look into the point's direction
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
        //Move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //Check the distance between enemy and goal point to trigger next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
        {
            //Check if we are at the end of the line (make the change -1)
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            //Check if we are at the start of the line (make the change +1)
            if (nextID == 0)
                idChangeValue = 1;
            //Apply the change on the nextID
            nextID += idChangeValue;
        }
    }



}