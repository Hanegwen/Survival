using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour
{
    [SerializeField]
    Transform onHand;
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    float maxDistance = 3.0f;


    //BIGGEST CHANGE: Will be to create a notification the first time a player picks up the item


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        float distance = Vector3.Distance(onHand.position, transform.position);
        if (distance < maxDistance)
        {
            GetComponent<Rigidbody>().useGravity = false;
            //this.transform.position = onHand.position;
            //this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
            if (this.transform.position != onHand.position)
            {
                Debug.Log("Outside of onHand");
                //this.transform.position = Vector3.Lerp(this.transform.position, onHand.position, speed);
                this.transform.position = Vector3.MoveTowards(this.transform.position, onHand.position, speed * Time.deltaTime);
            }
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            ReleaseObject();
        }


    }

    void OnMouseUp()
    {
        ReleaseObject();
    }

    private void ReleaseObject()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
