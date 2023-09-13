using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarCollisionCheck : MonoBehaviour
{
    private IMovingPoliceCarControl iPoliceCarControl;
    private List<IMovingPoliceCarControl> otherIPoliceCarIsBehaviourList = new List<IMovingPoliceCarControl>();
    //경찰차가 다른 경찰차끼리 충돌할 우려가 있는지 체크한다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌할 우려가 있다면 자동차의 행동을 제어한다.
        if (collision.gameObject.GetComponent<IMovingPoliceCarControl>() != null)
        {
            otherIPoliceCarIsBehaviourList.Add(collision.gameObject.GetComponent<IMovingPoliceCarControl>());
            // 즉시 우선수위를 고려한다.
            CheckPriority();
        }
    }

    // 근처에 있는 경찰차들과 충돌하지 않게끔하기 위해 우선순위에 따라 먼저 움직일 자동차를 정해주는 함수이다.
    private void CheckPriority()
    {
        if (iPoliceCarControl == null) { return; }

        if (otherIPoliceCarIsBehaviourList.FindIndex(a => a.GetPoliceCarCode() > iPoliceCarControl.GetPoliceCarCode()) != -1)
        {
            iPoliceCarControl.SetIsBehaviour(false);
        }
        else
        {
            iPoliceCarControl.SetIsBehaviour(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IMovingPoliceCarControl>() != null)
        {
            otherIPoliceCarIsBehaviourList.Remove(collision.gameObject.GetComponent<IMovingPoliceCarControl>());
            Invoke("CheckPriority", 1f);
        }
    }

    public void SetIPoliceCarIsBehaviour(IMovingPoliceCarControl iPoliceCarIsBehaviour)
    {
        this.iPoliceCarControl = iPoliceCarIsBehaviour;
    }
}
