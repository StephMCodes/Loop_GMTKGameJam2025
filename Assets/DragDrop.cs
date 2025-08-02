using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Color mouseHoverColor = new Color(63f / 255f, 63f / 255f, 63f / 255f);
    private Color ogColor = new Color(255f, 255f, 255f);

    Image image;
    Animation anim;
    AudioSource audioSource;
    [SerializeField] GameObject button;

    bool readJournal = false;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        anim = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData)
    {
        anim.Play();
        button.SetActive(true);
        mouseHoverColor = new Color(255f, 255f, 255f);
        if (!readJournal)
        {
            audioSource.Play();
            readJournal = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = mouseHoverColor;
        Debug.Log("hover");
    }

    public void OnPointerExit(PointerEventData eventData)

    {
        image.color = ogColor;
    }
}
