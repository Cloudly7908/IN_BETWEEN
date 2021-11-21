using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    
    public Transform[] Target;
    public GameObject TurretView;
    public Transform Barrel;
    //---------------------------------
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider turretTarget)
    {
        if (turretTarget.tag == "Player")
        {
            float TargetPosX = turretTarget.transform.position.x;
            float TargetPosY = turretTarget.transform.position.y;
            float TargetPosZ = turretTarget.transform.position.z;
            Vector3 TargetPos = turretTarget.transform.position;


           

            // Store the other object's position in a temporary variable
            var temp = TargetPos;
            // Deflate it's x and z coordinate
            temp.x = temp.z = uint.MinValue;
            var lookRotation = Quaternion.LookRotation(temp);
            Barrel.rotation = Quaternion.Slerp(Barrel.rotation, lookRotation, 5 * Time.deltaTime);

        }

        
    }
}
