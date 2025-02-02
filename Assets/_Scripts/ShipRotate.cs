using DG.Tweening;
using UnityEngine;

public class ShipRotate : MonoBehaviour
{
    [SerializeField] private int _cycleLength;
    private void Start()
    {
        transform.DORotate(new Vector3(360, 360, 0), _cycleLength, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }

    private void OnDestroy()
    {
        
    }
}
