using UnityEngine;

public class PlayerHold : MonoBehaviour
{
    public static PlayerHold Instance { get; private set; }

    [SerializeField] Transform holdPoint;

    public Holdable CurrentHoldable { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void TakeHoldable(Holdable holdable)
    {
        if (CurrentHoldable != null)
        {
            CurrentHoldable.gameObject.transform.SetParent(null, true); //Вынос за холд поинт
            CurrentHoldable.gameObject.GetComponent<Rigidbody>().isKinematic = false; //возврат физики
        }

        CurrentHoldable = holdable;
        holdable.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        holdable.gameObject.transform.SetParent(holdPoint, false);
        holdable.gameObject.transform.rotation = holdPoint.rotation * holdable.GetInHandRotationOffset();
        holdable.gameObject.transform.position = holdPoint.position;
    }

    public bool CheckIfCurrentHoldable(GameObject gameObject)
    {
        if (CurrentHoldable != null)
        {
            if (CurrentHoldable.gameObject == gameObject)
            {
                return true;
            }
        }
        return false;
    }

    public HoldableType GetCurrentHoldableType()
    {
        if (CurrentHoldable != null)
        {
            return CurrentHoldable.GetHoldableType();
        }
        else
        {
            return HoldableType.None;
        }
    }

    public void DestroyCurrentHoldable()
    {
        Destroy(CurrentHoldable.gameObject);
    }
}
