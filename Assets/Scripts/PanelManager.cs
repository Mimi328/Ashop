using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject HOME;
    public GameObject CONTACT;
    public GameObject ABOUT;
   public GameObject GLASSES;
  

    public void ActivateContactPanel()
    {
        HOME.SetActive(false);
        CONTACT.SetActive(true);
    }
     public void ActivateAboutPanel()
    {
        HOME.SetActive(false);
        ABOUT.SetActive(true);
    }
     public void ActivateHomePanel()
    {
        HOME.SetActive(false);
        HOME.SetActive(true);
    }
     public void ActivateGlassesPanel()
    {
        HOME.SetActive(false);
        GLASSES.SetActive(true);
    }
   public void ActivateHomePanel1()
    {
        CONTACT.SetActive(false);
        HOME.SetActive(true);
    }
    public void ActivateGlassesPanel1()
    {
        CONTACT.SetActive(false);
        GLASSES.SetActive(true);
    }
    public void ActivateAboutPanel1()
    {
        CONTACT.SetActive(false);
        ABOUT.SetActive(true);
    }
    public void ActivateHomePanel2()
    {
        ABOUT.SetActive(false);
        HOME.SetActive(true);
    }
    public void ActivateGlassesPanel2()
    {
        ABOUT.SetActive(false);
        GLASSES.SetActive(true);
    }
    public void ActivateContactPanel2()
    {
        ABOUT.SetActive(false);
        CONTACT.SetActive(true);
    }
}

