using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

public class ForceBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform muzzle;

    private const int value = 0;
    private float Axis;
    private float OldAxis = 0.0f;

    private bool FireFlag = false;
    private bool Reloadflag = false;

    private float bulletPower;//弾の速さ
    private int ActiveBullet;//弾の段数

    private float ReloadTime = 1.0f;

    private GameObject root;
    private int MyNumber=1;
 
    void Start()
    {
        bulletPower = SceneGlobalVariables.Instance.gunStatus.GetBulletPower();

        GameObject parentObject = transform.root.gameObject;

        
        if(parentObject.name== "Player(Clone)")
        {
            PlayerMainProcess playerMainProcess = parentObject.GetComponent<PlayerMainProcess>();
            MyNumber = playerMainProcess.MyNumber;
        }
        else
        {
            EnemyMainProcess enemyMainProcess = parentObject.GetComponent<EnemyMainProcess>();
            MyNumber = enemyMainProcess.MyNumber;
        }
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;

        //rayをカメラの中心からマウスの場所に飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(ray.direction);

        Axis = Input.GetAxis("Fire");
        FireFlag = FireJudge(OldAxis, Axis);

        if (FireFlag)
        {
            if (ActiveBullet == 0 && !Reloadflag)
            {
                Reloadflag = true;
                StartCoroutine("Reload");
            }
            else if(ActiveBullet>0)
            {
                Reloadflag = false;
                Fire();
                SceneGlobalVariables.Instance.gunStatus.SetBulletsNum(1);
            }
        }
        OldAxis = Axis;
    }

    //入力処理 1回押すと1発球が出る
    private bool FireJudge(float oldAxis, float axis)
    {
        bool flag = false;
        ActiveBullet = SceneGlobalVariables.Instance.gunStatus.GetActiveBullet();
        if (oldAxis == value && axis < value)
        {
            flag = true;
        }
        return flag;
    }

    private void Fire()
    {
        //Rigitbodyを使って球を飛ばす
        var bulletInstance = GameObject.Instantiate(bulletPrefab, muzzle.position, muzzle.rotation) as GameObject;
        BulletProcess bulletProcess = bulletInstance.GetComponent<BulletProcess>();
        bulletProcess.MyNumber = MyNumber;
        bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(ReloadTime);
        SceneGlobalVariables.Instance.gunStatus.Reloading();
    }
}
