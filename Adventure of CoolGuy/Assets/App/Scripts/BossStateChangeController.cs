using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateChangeController : MonoBehaviour
{

  [SerializeField] BossHealth bossHealthCar;

  [SerializeField] GameObject boss1;

  [SerializeField] GameObject emptyCarPrefab;

  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void BossStateChange()
  {
    if (bossHealthCar.ReturnHealth() <= 0)
    {
      Vector2 bossPosition = bossHealthCar.gameObject.transform.position;
      Quaternion bossRotation = bossHealthCar.gameObject.transform.rotation;

      Instantiate(boss1, bossPosition, bossRotation);
      Instantiate(emptyCarPrefab, bossPosition, bossRotation);
    }
  }
}
