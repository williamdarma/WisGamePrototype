using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class uiController : MonoBehaviour
{
    [SerializeField] GameObject upgradePanel;
    [SerializeField] float hidePosition, showPosition;
    [SerializeField] bool showPanel;
    float duration = .5f;
    [SerializeField] List<Button> listButton = new List<Button>();
    [SerializeField] Color defaultColor, chosenColor;
    [SerializeField] Image[] icons;
    [SerializeField] Button selectedMenu;

    // Start is called before the first frame update
    void Start()
    {
        addListener();
    }


    public void showHideUpgradePanel()
    {
        showPanel = !showPanel;
        float temp = 0;
        float tempicon = 180;
        if (showPanel)
        {
            temp = showPosition;
        }
        else
        {
            temp = hidePosition;
        }
        LeanTween.moveY(upgradePanel.GetComponent<RectTransform>(), temp, duration).setEaseInOutQuart();
        foreach(Image i in icons)
        {
            i.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, tempicon));
        }
    }


    public void chooseMenu()
    {
        foreach(Button b in listButton)
        {
            b.GetComponent<Image>().color = defaultColor;
        }
        Image temp = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        temp.color = chosenColor;
    }

    void addListener()
    {
        foreach(Button b in listButton)
        {
            b.onClick.AddListener(() => chooseMenu());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
