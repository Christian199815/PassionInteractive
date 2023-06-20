using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //Variables for FollowOnVertical()
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;

    //list with all the different positions for the camera to switch to
    public List<Transform> CameraRoomPositions = new List<Transform>();

    //list of booleans to check where the player is at the time
    public List<bool> playerLocs = new List<bool>();

    private void Start()
    {
        targetPos = transform.position;
    }

    void SwitchCameraPos()
    {
        if(playerLocs[0] == true)
        {
            this.transform.position = CameraRoomPositions[0].position;
        }
        else if (playerLocs[1] == true)
        {
            this.transform.position = CameraRoomPositions[1].position;
        }
        else if (playerLocs[2] == true)
        {
            this.transform.position = CameraRoomPositions[2].position;
        }
        else if (playerLocs[3] == true)
        {
            this.transform.position = CameraRoomPositions[3].position;
        }
        else if (playerLocs[4] == true)
        {
            this.transform.position = CameraRoomPositions[4].position;
        }
        else if (playerLocs[5] == true)
        {
            this.transform.position = CameraRoomPositions[5].position;
        }
        else if (playerLocs[6] == true)
        {
            this.transform.position = CameraRoomPositions[6].position;
        }
        else if (playerLocs[7] == true)
        {
            this.transform.position = CameraRoomPositions[7].position;
        }
        
    }


    private void Update()
    {
        SwitchCameraPos();
    }

    private void FixedUpdate()
    {
        if (playerLocs[8] == true)
        {
            this.transform.position = new Vector3(CameraRoomPositions[10].position.x, this.transform.position.y, this.transform.position.z);
            FollowOnVertical();
        }
    }

    public void FollowOnVertical()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);
            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, targetPos.y, transform.position.z) + offset, 0.25f);
        }
    }
}
