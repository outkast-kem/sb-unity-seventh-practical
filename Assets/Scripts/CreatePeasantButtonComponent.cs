using UnityEngine;
using UnityEngine.UI;

public class CreatePeasantButtonComponent : MonoBehaviour
{
    [SerializeField] private ResourcesManagerComponent resources;
    [SerializeField] private DeferredTimer createPeasantTimer;
    [SerializeField] private int peasantCost;

    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (resources.WheatCount >= peasantCost)
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    public void CreatePeasant()
    {
        Debug.Log("Start create peasant");
        createPeasantTimer.TimerStart();
    }
}
