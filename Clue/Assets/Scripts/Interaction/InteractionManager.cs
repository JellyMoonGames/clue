using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    // Author - Daniel Kean

    /// <summary>
    /// Manages what interactable objects have been clicked on by
    /// the player and firing their corresponding methods.
    /// </summary>

    #region Inspector Variables

    [SerializeField] private LayerMask layerMask;

    #endregion

    #region Private Variables

    private RaycastHit hit;
    private Ray mouseRay;

    #endregion

    #region Methods

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

    #endregion
}
