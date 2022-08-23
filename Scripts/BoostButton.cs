using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoostButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsHolding = false;
    //public Image buttonImage;
    public Image backgroundImage;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!IsHolding)
        {
            IsHolding = true;
            Level.instance.players[0].boost = true;
            Level.instance.players[0].OneClickBehaviourUp = false;
            if (GlobalSettings.instance.boostButtonBehaviour == BoostButtonBehaviour.OneClick)
            {
                if (buttonPop != null)
                    StopCoroutine(buttonPop);
                buttonPop = enableDisableButton(false);
                StartCoroutine(buttonPop);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (GlobalSettings.instance.boostButtonBehaviour == BoostButtonBehaviour.Hold)
        {
            IsHolding = false;
            Level.instance.players[0].boost = false;
        }
        else
        {
            backgroundImage.raycastTarget = false;
            Level.instance.players[0].OneClickBehaviourUp = true;
            StartCoroutine(Timer());
        }
    }
    IEnumerator buttonPop;

    IEnumerator enableDisableButton(bool enable)
    {
        if (enable)
        {
            //buttonImage.enabled = true;
            backgroundImage.enabled = true;
            backgroundImage.transform.localScale = Vector3.zero;
            while (backgroundImage.transform.localScale.magnitude < 1.73f)
            {
                backgroundImage.transform.localScale = Vector3.MoveTowards(backgroundImage.transform.localScale, Vector3.one, 10f * Time.deltaTime);
                yield return null;
            }
        }
        else
        {
            while (backgroundImage.transform.localScale.magnitude < 2.2f)
            {
                backgroundImage.transform.localScale = Vector3.MoveTowards(backgroundImage.transform.localScale, Vector3.one*1.3f, 10f * Time.deltaTime);
                yield return null;
            }
            while (backgroundImage.transform.localScale.magnitude > 0f)
            {
                backgroundImage.transform.localScale = Vector3.MoveTowards(backgroundImage.transform.localScale, Vector3.zero, 10f * Time.deltaTime);
                yield return null;
            }
            backgroundImage.enabled = false;
            //buttonImage.enabled = false;
        }

    }
    private IEnumerator Timer()
    {
        while (UIManager.instance.CanBoost())
        {
            yield return null;
        }
        IsHolding = false;

        //buttonImage.enabled = true;
        backgroundImage.raycastTarget = true;
        backgroundImage.enabled = true;
    }

    private void OnEnable()
    {
        if (buttonPop != null)
            StopCoroutine(buttonPop);
        buttonPop = enableDisableButton(true);
        StartCoroutine(buttonPop);
    }

    private void OnDisable()
    {
        IsHolding = false;

        //buttonImage.enabled = true;
        backgroundImage.raycastTarget = true;
        backgroundImage.enabled = true;
    }
}
