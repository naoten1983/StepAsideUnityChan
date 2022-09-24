using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;

    //Unity�����ƃJ�����̋���
    private float differrence;

    //�ŏ��ɐݒ肵������
    private float posY;




    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");


        //Unity�����ƈʒu�iz���W�j�̍������߂�
        this.differrence = unitychan.transform.position.z - this.transform.position.z;


        //�ŏ��ɐݒ肵����������
        posY = this.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        //Unity�����̈ʒu�ɍ��킹�Ĉʒu���ړ�
        this.transform.position = new Vector3(0, this.posY, this.unitychan.transform.position.z - differrence);

    }

    //***************************************************************************
    //���j�e�B����񂪒ʂ�߂��ĉ�ʊO�ɏo���A�C�e���𒼂��ɔj��
    //***************************************************************************
    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag")
        {
            //�Փˑ���̃Q�[���I�u�W�F�N�g��j��
            Destroy(other.gameObject);
        }

            
    }
}
