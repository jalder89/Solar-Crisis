using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class UseIt : MonoBehaviour
{
    public DialogueSystemTrigger dialogueTrigger;
    public DialogueSystemTrigger getCloserBark;
    public DialogueSystemTrigger powerOnBark;
    public Collider2D triggerCollider;
    public GameObject nameCanvas;
    private Ray mouseRay;
    

    private void Update()
    {

        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        MouseOverCollider(mouseRay);
    }

    private void MouseOverCollider(Ray mouseRay)
    {
        if (triggerCollider.bounds.IntersectRay(mouseRay))
        {
            if (nameCanvas)
            {
                nameCanvas.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                dialogueTrigger.OnUse();

                if (getCloserBark)
                {
                    getCloserBark.OnUse();
                }

                if (powerOnBark)
                {
                    powerOnBark.OnUse();
                }
                
            }
        } else
        {
            if (nameCanvas)
            {
                nameCanvas.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Interact"))
        {
            dialogueTrigger.OnUse();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Player" && nameCanvas)
        {
            nameCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && nameCanvas)
        {
            nameCanvas.SetActive(false);
        }
    }
}
