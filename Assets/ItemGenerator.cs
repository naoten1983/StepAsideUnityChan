using System.Collections;
using System.Collections.Generic;
using UnityChan;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    //carPrefab������
    public GameObject carPreFab;

    //coinPrefab������
    public GameObject coinPreFab;

    //cornPrefab������
    public GameObject cornPreFab;

    //�X�^�[�g�n�_
    //private int startPos = 80;

    //�S�[���n�_
    private int goalPos = 360;

    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;



    //�A�C�e�������̊Ԋu���Ԃ��w��
    private float span = 1.0f;

    //�O��̃A�C�e����������̌o�ߎ��Ԃ��i�[����ϐ�
    private float delta = 0;

    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;

    //Unity�����̃I�u�W�F�N�g�ɃA�^�b�`���ꂽ�X�N���v�g
    UnityChanController script;

    //�A�C�e���𐶐�����ʒu
    private float itemPos;



    //�A�C�e���𐶐����鏈���̊֐�
    void ItemGenerate(float a)
    {
            //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
            int num = Random.Range(1, 11);

            if (num < 2)
            {
                //�R�[����x�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject corn = Instantiate(cornPreFab);
                    corn.transform.position = new Vector3(4 * j, corn.transform.position.y, a);
                }
            }
            else
            {
                //���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 11);

                    //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);


                    //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPreFab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, a + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPreFab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, a + offsetZ);
                    }
                }
            }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");

        //Unity�����̃I�u�W�F�N�g�ɃA�^�b�`����Ă���UnityChanController���擾
        script = unitychan.GetComponent<UnityChanController>();

        
    }

        // Update is called once per frame
        void Update()
    {
        //delta�ϐ��Ɍo�ߎ��Ԃ���
        this.delta += Time.deltaTime;

        //�O��̃A�C�e����������̌o�ߎ��Ԃ��w��̊��o���Ԃ𒴂�����c
        if (this.delta > this.span)
        {
            //delta�ϐ������Z�b�g����
            this.delta = 0;

            //itemPos�ϐ��Ƀ��j�e�B������50m��̈ʒu����
            this.itemPos = this.unitychan.transform.position.z + 50;


            //�A�C�e���̐����ʒu���S�[���n�_�𒴂��Ă��Ȃ��A�����j�e�B����񂪂܂�����łȂ��Ƃ�
            if (this.itemPos < goalPos�@&& script.isEnd is false)
            {
                //ItemGenerate�֐����Ăяo��
                ItemGenerate(this.itemPos);
            }
            
        }
    }
}
