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
        Vector3 targetPos = Owner.Target.transform.position;
        Vector3 startPosition = targetPos - (Owner.transform.position - targetPos).normalized * 2f;
        Vector3 endPosition = targetPos + (Owner.transform.position - targetPos).normalized * 2f;

        int shotCount = 10;
        while (shotCount > 0)
        {
            shotCount--;
            Managers.Object.CreateArrow(Owner, Vector3.Lerp(startPosition, endPosition, shotCount / 10f));

            yield return new WaitForSeconds(0.1f);
        }
    }

}