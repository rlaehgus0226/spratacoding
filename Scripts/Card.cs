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

        // firstCard�� ����ٸ�,
        if (GameManager.instance.firstCard == null)
        {
            // furstCard�� �� ������ �Ѱ��ش�.
            GameManager.instance.firstCard = this;
        }
        //firstCard�� ������� �ʴٸ�,
        else
        {
            //secondCard�� �� ������ �Ѱ��ش�.
            GameManager.instance.secondCard = this;
            // Mached �Լ��� ȣ���� �ش�.
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
