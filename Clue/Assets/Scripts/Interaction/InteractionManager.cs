using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private RaycastHit hit;
    private Ray mouseRay;

    private void Update()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction, Mathf.Infinity, layerMask);

        if(hit.collider != null)
        {
            if(Input.GetButtonUp("Fire1"))
            {
                hit.transform.GetComponent<Interaction>().PrimaryButton();
            }
            else if(Input.GetButtonUp("Fire2"))
            {
                hit.transform.GetComponent<Interaction>().SecondaryButton();
            }
        }
    }
}
