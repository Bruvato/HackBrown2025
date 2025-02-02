using DG.Tweening;
using UnityEngine;

public class ShipCruise : MonoBehaviour
{
    public float cruiseSpeed = 5f;  // Speed of cruise movement
    public float rotationSpeed = 30f;  // Rotation speed for idle movement
    public float idlePulseScale = 1.2f;  // Pulse scale for idle effect

    private void Start()
    {
        // Call the animation function when the script starts
        StartCruiseAnimation();
    }

    void StartCruiseAnimation()
    {
        // Create a sequence to animate idle/cruise movement
        //Sequence cruiseSequence = DOTween.Sequence();

        // Move the spaceship in a smooth idle motion (slightly moving on the X-axis for example)
        //cruiseSequence.Append(transform.DOMoveX(2f, cruiseSpeed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine));

        // Slightly rotate the spaceship to create idle rotation effect
        transform.DORotate(new Vector3(0, 0, 10), rotationSpeed, RotateMode.LocalAxisAdd)
                        .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);

        // Pulse the scale for a subtle idle scale effect
        //cruiseSequence.Join(transform.DOScale(idlePulseScale, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine));
    }
}
