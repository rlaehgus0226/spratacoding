using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        
    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        //if (GameManager.instance.secondCard! = null) return;

        audioSource.PlayOneShot(clip);
        front.SetActive(true);
        back.SetActive(false);
        anim.SetBool("isOpen", true);

        // firstCard가 비었다면,
        if (GameManager.instance.firstCard == null)
        {
            // furstCard에 내 정보를 넘겨준다.
            GameManager.instance.firstCard = this;
        }
        //firstCard가 비어있찌 않다면,
        else
        {
            //secondCard에 내 정보를 넘겨준다.
            GameManager.instance.secondCard = this;
            // Mached 함수를 호출해 준다.
            GameManager.instance.Mached();
        }
    }

    public void DestoryCard()
        {
        Invoke("DestroyCardInvoke", 0.25f);
        }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }


    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }

       

    }
