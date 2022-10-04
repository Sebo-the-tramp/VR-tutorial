using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankController : MonoBehaviour
{

    public GameObject handle;
    public GameObject pivot;
    public HingeJoint joint;

    private IEnumerator turningCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        turningCoroutine = TurningCoroutine();
    }
    public void StartTurning()
    {
        StartCoroutine(turningCoroutine);
    }
    
    public void StopTurning()
    {        
        StopCoroutine(turningCoroutine);
    }

    private IEnumerator TurningCoroutine()
    {
        while (true)
        {

            //Always keep the handle in the same position
            handle.transform.rotation = Quaternion.Euler(90, -90, -90);

            //block any backward movement
            Vector3 currentAngle = pivot.transform.localEulerAngles;
            if (currentAngle.y >= 175 && currentAngle.y <= 185)
            {
                joint.useLimits = false;
            }
            else
            {
                joint.useLimits = true;
                if (currentAngle.y >= 0 && currentAngle.y <= 180)
                {
                    joint.limits = new JointLimits() { min = -pivot.transform.localEulerAngles.y, max = 1 };                   
                }
                else
                {                    
                    joint.limits = new JointLimits() { min = 360 - pivot.transform.localEulerAngles.y, max = 180 };
                }
            }

            yield return null;
        }
    }



}
