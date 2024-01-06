using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Variables

    [SerializeField] private float movementSpeed;
    private List<Vector3> pathCheckpoints = new List<Vector3>();
    private Vector3 origin = new Vector3(-12,1,0);

    private void Start() {

        // Generate a random path to follow in order to reach the end
        GeneratePath();
        StartCoroutine(FollowPath());

    }

    private void Update() {

        for(int i = 0; i < pathCheckpoints.Count - 1; i++){
            Debug.DrawLine(pathCheckpoints[i], pathCheckpoints[i+1], Color.red);
        }



        // Follow the generated path
        FollowPath();

    }

    // Generate a random path
    private void GeneratePath(){

        // Adding first point to the path    
        pathCheckpoints.Add(new Vector3(Random.Range(-10,-6),1,0));

        // Deciding first turn and adding second point to the path
        if(Random.Range(0,2) == 0){ 
            // If 0 then left
            pathCheckpoints.Add(new Vector3(pathCheckpoints[0].x,1,Random.Range(8,11)));
        } 
        else{
            // If 1 then right
            pathCheckpoints.Add(new Vector3(pathCheckpoints[0].x,1,Random.Range(-8,-11)));
        }

        // Adding third point to the path
        pathCheckpoints.Add(new Vector3(Random.Range(-3,4),1,pathCheckpoints[1].z));

        // Adding fourth point to the path.
        if(pathCheckpoints[2].z > 0){

            // Enemy on the upper side of the screen
            // Deciding whether taking turn or not
            if(Random.Range(0,2) == 0){ 
                // If 0 then turn
                pathCheckpoints.Add(new Vector3(pathCheckpoints[2].x,1,Random.Range(-8,-11)));
            } 
            else{
                // If 1 then do not turn
                pathCheckpoints.Add(new Vector3(Random.Range(7,11),1,pathCheckpoints[2].z));
            }
            
            

        }
        else if((pathCheckpoints[2].z < 0)){

            // Enemy on the lower side of the screen
            // Deciding whether taking turn or not
            if(Random.Range(0,2) == 0){ 
                // If 0 then turn
                pathCheckpoints.Add(new Vector3(pathCheckpoints[2].x,1,Random.Range(8,11)));
            } 
            else{
                // If 1 then do not turn
                pathCheckpoints.Add(new Vector3(Random.Range(7,11),1,pathCheckpoints[2].z));
            }

        }

        // Adding fifth point to the path
        pathCheckpoints.Add(new Vector3(Random.Range(7,11),1,pathCheckpoints[3].z));

        // Adding sixth point to the path
        pathCheckpoints.Add(new Vector3(pathCheckpoints[4].x,1,Random.Range(-1,2)));

        // Adding seventh point to the path
        pathCheckpoints.Add(new Vector3(15,1,pathCheckpoints[5].z));       


    }

    // Follow the path

    IEnumerator FollowPath(){
        foreach (Vector3 targetPoint in pathCheckpoints){
            Vector3 targetPosition = targetPoint;

            while (Vector3.Distance(transform.position, targetPosition) > 0.01f){
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }

}
