using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] float playerSpeed = 1f;

    List<Node> path = new List<Node>();

    GridManager gridmanager;
    PathFinder pathFinder;

    Animator animator;
    bool done = true;
    public bool Done{get{return done;}}

    void Awake()
    {
        gridmanager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
        animator = GetComponent<Animator>();
    }

    public void start()
    {
        //StartWalking();
    }

    void FindPath()
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates = gridmanager.GetCoordinatesFromPosition(transform.position);

        StopAllCoroutines();
        path.Clear();
        path = pathFinder.GetNewPath(coordinates);

        StartCoroutine(FollowPath());
    }

    void ReturnToStart()
    {
        transform.position = gridmanager.GetPositionFromCoordinates(pathFinder.StartCoordinates);
    }

    IEnumerator FollowPath()
    {
        animator.SetBool("isMoving", true);
        done = false;
        for(int i = 1; i < path.Count; i++)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = gridmanager.GetPositionFromCoordinates(path[i].coordinates);
            float travelTime = 0f;

            transform.LookAt(endPos);

            while(travelTime < 1f){
                travelTime += Time.deltaTime * playerSpeed;
                transform.position = Vector3.Lerp(startPos, endPos, travelTime);
                yield return new WaitForEndOfFrame();
            }
        }
        animator.SetBool("isMoving", false);
        done = true;
    }

    public bool Walking()
    {
        return done;
    }
}
