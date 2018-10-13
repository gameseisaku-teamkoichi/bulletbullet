using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

public class ForceBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    public Transform muzzle;

    private const int value = 0;
    public float Axis = 0.0f;
    private float OldAxis = 0.0f;

    public bool FireFlag = false;
    private bool Reloadflag = false;

    private float playerBulletPower;//弾の速さ
    private float enemyBulletPower;
    private int ActiveBullet;//弾の段数

    private float ReloadTime = 1.0f;

    private GameObject root;
    private int MyNumber = 1;

    public Quaternion quaternion;
    void Start()
    {
        playerBulletPower = SceneGlobalVariables.Instance.gunStatus.GetBulletPower();
        enemyBulletPower = playerBulletPower / 10;

        GameObject parentObject = transform.root.gameObject;


        if (parentObject.name == "Player(Clone)")
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

    public void StartFire()
    {
        FireFlag = FireJudge(OldAxis, Axis);

        if (FireFlag)
        {
            if (MyNumber == 0)
            {
                PlyerShoot();
            }
            else
            {

                Fire();
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
        if (bulletProcess.MyNumber == 0)
        {
            bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * playerBulletPower);
        }
        else
        {
            bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * enemyBulletPower);
        }
    }

    //プレイヤーが球を撃つ処理
    private void PlyerShoot()
    {
        if (ActiveBullet == 0 && !Reloadflag)
        {
            Reloadflag = true;
            StartCoroutine("Reload");
        }
        else if (ActiveBullet > 0)
        {
            Reloadflag = false;
            Fire();
            SceneGlobalVariables.Instance.gunStatus.SetBulletsNum(1);
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(ReloadTime);
        SceneGlobalVariables.Instance.gunStatus.Reloading();
    }
}
