using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float raycastDistance;
    [SerializeField] Text displayNameText;
    [SerializeField] Text instructionsText;

    private void Update()
    {
        LookAtObject();
    }

    void LookAtObject()
    {
        //raycast in the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if(hit.collider.gameObject.GetComponent<PickUpObject>())
            {
                //change the text to match the PickUpObject's name
                //activate the text (displaying the name)
                //activate the text (displaying "Press "___" to pick up)
            }
        }
    }
}
