using UnityEngine;
using System.Collections;

public class SkillSuperArrow : SkillBase
{
    protected override void OnSetup()
    {

    }

    protected override void OnShot()
    {
        StartCoroutine(CoShot());
    }   


    private IEnumerator CoShot()
    {
        int shotCount = 10;
        while (shotCount > 0)
        {
            shotCount--;
            Managers.Object.CreateArrow(Owner, Owner.Target.transform.position);

            yield return new WaitForSeconds(0.1f);
        }
    }

}