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
        if (!readJournal)
        {
            audioSource.Play();
            mouseHoverColor = new Color(255f, 255f, 255f);
            anim.Play();
            button.SetActive(true);
            readJournal = true;
            image.color = ogColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!readJournal)
        {
            image.color = mouseHoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)

    {
        if (!readJournal)
        {
            image.color = ogColor;
        }
    }
}
