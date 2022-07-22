using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  [SerializeField] BossHealth bossHealthCar;
  [SerializeField] GameObject boss1;
   private bool isSecondBossInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (bossHealthCar.ReturnHealth()<=0 && !isSecondBossInstantiated)
		{
      Vector2 bossPosition = bossHealthCar.gameObject.transform.position;
      Quaternion bossRotation = bossHealthCar.gameObject.transform.rotation;

      Instantiate(boss1,bossPosition,bossRotation);
         isSecondBossInstantiated = true;
		}
    }


}
