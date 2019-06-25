using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// in this class elements are compared.
/// </summary>
public abstract class ElementComparerBase : MonoBehaviour
{
    /// <summary>
    /// elements to compare against
    /// </summary>
    [SerializeField] protected List<ScriptableObject> _elementsRegister;

    /// <summary>
    /// stores the last compared element
    /// </summary>
    protected ScriptableObjectElement _lastElement;

    /// <summary>
    /// if the given element is legal, call OnLegalElementFound, if not call OnIllegalElementFound.
    /// </summary>
    /// <param name="CheckElementLegality"></param>
    protected virtual void CheckElementLegality(ScriptableObjectElement element)
    {
        if (!element) // given element is null, stop function.
        {
            return;
        }

        _lastElement = element;

        if (CompareElement(_lastElement))
        {
            OnLegalElementFound();
            return;
        }
        else
        {
            OnIllegalElementFound();
        }
    }

    /// <summary>
    /// compares element
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    private bool CompareElement(ScriptableObjectElement elementContainer)
    {
        for (int i = 0; i < _elementsRegister.Count; i++)
        {
            if (_elementsRegister[i] == elementContainer.element)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// this function is to be overridden with the wanted logic
    /// </summary>
    protected abstract void OnLegalElementFound();

    /// <summary>
    /// this function is to be overridden with the wanted logic
    /// </summary>
    protected abstract void OnIllegalElementFound();
}
