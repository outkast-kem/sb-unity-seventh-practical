using UnityEngine;
using UnityEngine.UI;

public class CreateWarriorButtonComponent : MonoBehaviour
{
    [SerializeField] private DeferredTimer createWarriorTimer;
    [SerializeField] private ResourcesManagerComponent resourcesManagerComponent;
    [SerializeField] private int warriorCost;

    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
    }

    private void Update()
    {
        if (resourcesManagerComponent.WheatCount >= warriorCost)
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    public void CreateWarrior()
    {
        createWarriorTimer.TimerStart();
    }
}
