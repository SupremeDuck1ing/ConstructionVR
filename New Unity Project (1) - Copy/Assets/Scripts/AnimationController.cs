using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{ 
    public Animator npcAnim;
    private bool kneelBool;
    private bool isLerping; 
    public Transform npcTransform; 
    public Transform npcStart;
    public Transform npcMove1; 
    public Transform npcMove2;  
    public Transform npcMove3;  
    public Transform npcMove4; 
    public Transform npcMove5;  
    public Transform npcMove6;  
    public Transform npcMove7;  
    public Transform npcMove8;  

    public GameObject box; 
    public Transform hand;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        npcAnim = GetComponent<Animator>();
        npcTransform = GetComponent<Transform>(); 
        box = GameObject.Find("npcBox"); 
        hand = GameObject.Find("mixamorig:RightHand").GetComponent<Transform>();
        kneelBool = true; 
        MovementTest();
    }

    // Update is called once per frame
    void Update()
    {
    }  

    /*public void StartTask1() { 
        StartCoroutine(Task1Coroutine());
    } */

    public void MovementTest() { 
        StartCoroutine(MoveTestCoroutine());
    } 

    IEnumerator MoveTestCoroutine() { 
        //Start-TransformMove1
        StartCoroutine(Lerp(npcTransform, npcStart, npcMove1, duration)); 
        while (isLerping) { 
            yield return null;
        }
        StartCoroutine(RotationLerp(npcTransform, npcStart, npcMove1, 2)); 
        while (isLerping) { 
            yield return null;
        } 
  
        //TransformMove1-TransformMove2 (Grab Box From Table)
        StartCoroutine(Lerp(npcTransform, npcMove1, npcMove2, duration)); 
        while (isLerping) { 
            yield return null;
        }
        StartCoroutine(RotationLerp(npcTransform, npcMove1, npcMove2, 2)); 
        while (isLerping) { 
            yield return null;
        } 

        //Return to TransformMove1
        StartCoroutine(Lerp(npcTransform, npcMove2, npcMove1, duration)); 
        while (isLerping) { 
            yield return null;
        }
        StartCoroutine(RotationLerp(npcTransform, npcMove2, npcStart, 2)); 
        while (isLerping) { 
            yield return null;
        } 

        //TransformMove1-TransformMove3 
        StartCoroutine(Lerp(npcTransform, npcMove1, npcMove3, duration)); 
        while (isLerping) { 
            yield return null;
        }  
        StartCoroutine(RotationLerp(npcTransform, npcStart, npcMove3, 2)); 
        while (isLerping) { 
            yield return null;
        } 

        //TransformMove3-TransformMove4 (Set Box Next to Road) 
        StartCoroutine(Lerp(npcTransform, npcMove3, npcMove4, duration)); 
        while (isLerping) { 
            yield return null;
        } 
        StartCoroutine(RotationLerp(npcTransform, npcMove3, npcMove4, 2)); 
        while (isLerping) { 
            yield return null;
        } 

        //Return to TransformMove3 
        StartCoroutine(Lerp(npcTransform, npcMove4, npcMove3, duration)); 
        while (isLerping) { 
            yield return null;
        } 
        StartCoroutine(RotationLerp(npcTransform, npcMove4, npcMove5, 2)); 
        while (isLerping) { 
            yield return null;
        } 

        //TransformMove3-TransformMove5 
        StartCoroutine(Lerp(npcTransform, npcMove3, npcMove5, duration)); 
        while (isLerping) { 
            yield return null;
        } 

        //TransformMove5-TransformMove6 (Pick up Trash) 
        StartCoroutine(Lerp(npcTransform, npcMove5, npcMove6, duration)); 
        while (isLerping) { 
            yield return null;
        } 

        //Return to TransformMove6 
        StartCoroutine(Lerp(npcTransform, npcMove6, npcMove5, duration)); 
        while (isLerping) { 
            yield return null;
        }

        //TransformMove6-TransformMove7 
        StartCoroutine(Lerp(npcTransform, npcMove5, npcMove7, duration)); 
        while (isLerping) { 
            yield return null;
        }

        //TransformMove7-Transform8 (Put Down Trash) 
        StartCoroutine(Lerp(npcTransform, npcMove7, npcMove8, duration)); 
        while (isLerping) { 
            yield return null;
        }
    }

/*    IEnumerator Task1Coroutine() {   Will Need Variable Renamings
        StartCoroutine(Lerp(npcTransform, task1Start, task1End, duration)); 
        while (isLerping) { 
            yield return null;
        }
        npcAnim.SetTrigger("KneelTrig");
        yield return new WaitForSeconds(3f); 
        box.transform.position = hand.position;
        box.transform.parent = hand; 
        npcAnim.ResetTrigger("KneelTrig"); 
        npcAnim.SetTrigger("WalkTrig");
        yield return new WaitForSeconds(5f);
        StartCoroutine(Lerp(npcTransform, task1End, task2, duration));  
        while (isLerping) { 
            yield return null;
        } 
        npcAnim.ResetTrigger("WalkTrig"); 
        npcAnim.SetTrigger("KneelTrig"); 
        yield return new WaitForSeconds(3f); 
        box.transform.position = task2.position;
        box.transform.parent = null;  
        npcAnim.ResetTrigger("KneelTrig"); 
        npcAnim.SetTrigger("WalkTrig");
        yield return new WaitForSeconds(5f);
        StartCoroutine(Lerp(npcTransform, task2, task2End, duration));
        npcAnim.ResetTrigger("WalkTrig");
        npcAnim.SetTrigger("EndTrig");
    } */



    IEnumerator Lerp(Transform objectToLerp, Transform start, Transform stop, float duration)
    {
        isLerping = true;
        float time = 0;
        
        while (time < duration)
        {
            objectToLerp.position = Vector3.Lerp(start.position, stop.position, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        objectToLerp.position = stop.position;
        isLerping = false;
    }

    IEnumerator RotationLerp(Transform objectToLerp, Transform start, Transform stop, float duration)
    {
        isLerping = true;
        float time = 0;
        
        while (time < duration)
        {
            objectToLerp.rotation = Quaternion.Lerp(start.rotation, stop.rotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        objectToLerp.rotation = stop.rotation;
        isLerping = false;
    }
}
