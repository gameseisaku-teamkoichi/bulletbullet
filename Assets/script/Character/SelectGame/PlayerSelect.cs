using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{

    Animator anime;
    
    //時間を示すupdate内でインクリメント
    private int loopCount;

    //モーションを切り替える秒数
    private int changeSecond;

    //モーションを変える三種類
    private int[] changeCount = new int[3];

    // Use this for initialization
    void Start()
    {

        anime = GetComponent<Animator>();

        loopCount = 0;

        //今回は120秒で切り替え
        changeSecond = 120;
        
        for(int i=0;i<3;i++)
        {
            changeCount[i] = i * 10;
        }

        anime.SetInteger("changeCount", changeCount[0]);

    }

    // Update is called once per frame
    void Update()
    {

        if(loopCount%120==0)
        {
            anime.SetInteger("changeCount", changeCount[0]);
        }

        

        loopCount++;
    }
}
