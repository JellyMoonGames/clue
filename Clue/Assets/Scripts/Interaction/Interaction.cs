using UnityEngine;
using System.Collections;

public abstract class Interaction : MonoBehaviour
{
    // Author - Daniel Kean

    /// <summary>
    /// The base abstract class for all interaction classes.
    /// </summary>

    #region Methods

    // Called when the player left clicks on this object.
    public abstract void PrimaryButton();

    // Called when the player right clicks on this object.
    public abstract void SecondaryButton();

    #endregion
}