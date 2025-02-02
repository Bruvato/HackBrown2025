using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    private IHasProgress hasProgress;

    [SerializeField] private Image barImage;
    private void Awake()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();


    }

    private void OnEnable()
    {
        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;
        if (hasProgress == null)
        {
            Debug.LogError("game ob " + hasProgressGameObject + "does not have component that implements IHasProgress");
        }

    }
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressRatio;

        if (e.progressRatio == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
