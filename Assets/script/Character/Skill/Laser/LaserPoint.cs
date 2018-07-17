using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPoint : MonoBehaviour
{
    public LayerMask mask;

    private void Start()
    {
        mask = -1;   
    }

    public void Point(Ray ray)
    {
        //あたったものの情報が入るRaycastHitを準備
        RaycastHit hit;

        //物理コリジョン判定をさせるためにレイをレイキャストしてあたったかどうか返す
        bool isHit = Physics.Raycast(ray, out hit, 1000.0f, mask);

        //あたっているなら
        if (isHit)
        {
            //あたったゲームオブジェクトを取得
            GameObject hitobject = hit.collider.gameObject;

            //マテリアルカラー変更
            //hitobject.GetComponent().material.color = Color.green;

            //あたったオブジェクト削除
            //Destroy(hitobject);

            //レイがあたった座標
            Vector3 position = hit.point;

            //レイがあたった当たり判定オブジェクトの面の法線
            Vector3 normal = hit.normal;

            //レイの方向ベクトル
            Vector3 direction = ray.direction;

            //反射ベクトル（反射方向を示すベクトル）
            Vector3 reflect_direction = 2 * normal * Vector3.Dot(normal, -direction) + direction;

            //レイと反射ベクトルのなす角度(ラジアン）
            float rad = Mathf.Acos(Vector3.Dot(-ray.direction, reflect_direction) / ray.direction.magnitude * reflect_direction.magnitude);

            //ラジアンを度に変換
            float deg = rad * Mathf.Rad2Deg;

            //反射角度が90度以上だったら・・・
            //if(deg>90)
            //{  
            //}

            ////////////// デバッグ用 ////////////////

            //（デバッグ用）角度を表示
            Debug.Log(deg);

            //（デバッグ用）新しい反射用レイを作成する
            Ray reflect_ray = new Ray(position, reflect_direction);

            //（デバッグ用）レイを画面に表示する
            Debug.DrawLine(reflect_ray.origin, reflect_ray.origin + reflect_ray.direction * 100, Color.blue, 0);

        }

        ////////////// デバッグ用 ////////////////

        //（デバッグ用）発射レイを表示
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red, 0);

    }
}

