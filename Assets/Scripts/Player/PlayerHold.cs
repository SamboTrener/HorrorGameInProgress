using UnityEngine;

public class PlayerHold : MonoBehaviour
{
    public static PlayerHold Instance { get; private set; }

    [SerializeField] private Transform holdPoint;

    private Holdable CurrentHoldable { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void TakeHoldable(Holdable holdable)
    {
        if (CurrentHoldable)
        {
            CurrentHoldable.gameObject.transform.SetParent(null, true); 
            CurrentHoldable.gameObject.GetComponent<Rigidbody>().isKinematic = false; 
        }

        CurrentHoldable = holdable;
        holdable.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        holdable.gameObject.transform.SetParent(holdPoint, false);
        holdable.gameObject.transform.rotation = holdPoint.rotation * holdable.GetInHandRotationOffset();
        holdable.gameObject.transform.position = holdPoint.position;
    }

    public bool CheckIfCurrentHoldable(GameObject objectToCompare)
    {
        if (!CurrentHoldable) 
            return false;
        return CurrentHoldable.gameObject == objectToCompare;
    }

    public HoldableType GetCurrentHoldableType()
    {
        return CurrentHoldable?.GetHoldableType() ?? HoldableType.None;
    }

    public void DestroyCurrentHoldable()
    {
        Destroy(CurrentHoldable.gameObject);
        CurrentHoldable = null;
    }
}
