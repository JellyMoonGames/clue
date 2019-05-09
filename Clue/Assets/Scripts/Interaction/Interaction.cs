using UnityEngine;
using System.Collections;

public abstract class Interaction : MonoBehaviour
{
    /// <summary>
    /// The base abstract class for all interaction classes.
    /// </summary>

    #region Methods

    public abstract void PrimaryButton();
    public abstract void SecondaryButton();

    #endregion
}