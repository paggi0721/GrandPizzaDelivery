using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoliceNS.PolicePathNS;
using PoliceNS.PoliceStateNS;
using BuildingAddressNS;

// 한석호 작성

public interface IAddress
{
    public void InitAddress(int number, List<AddressS> addressSList);
    public int GetAddress();
    public void SetIMap(IMap iMap);
    public void SetIDeliveryPanelControl(IDeliveryPanelControl iDeliveryPanelControl);
}

public interface IBuilding
{
    public bool GetIsPoliceCar();
    public void SetIsPoliceCar(bool b);
    public Vector2 GetpoliceCarDis();
    public Vector2 GetBuildingPos();
    public List<PolicePath> GetPolicePath();
}

public interface IPoliceCar
{
    public void InitPoliceCarPath(List<PolicePath> policePathList);
    public void SetIInspectingPanelControl(IInspectingPanelControl iInspectingPanelControl);
    public void SetPlayerMove(PlayerMove playerMove);
    public void SetPoliceSmokeEffect(IPoliceSmokeEffect iPoliceSmokeEffect);
    public Rigidbody2D GetRigidBody2D();
    public float GetSpeed();
    public PoliceState GetPoliceState();

}
// 경찰차 제어에 관한 인터페이스
public interface IMovingPoliceCarControl
{
    public void SetIsBehaviour(bool bo);
    //public int GetPoliceCarCode();
}
public interface IPriorityCode
{
    public int GetPriorityCode();
}


public interface IInspectingPoliceCarControl
{
    public void SetPoliceState(PoliceState policeState);
}

public interface IInspectingPanelControl
{
    public void ControlInspectUI(bool isOn, IEndInspecting iEndInspecting);
}
public interface IDeliveryPanelControl
{
    public void ControlDeliveryUI(bool isOn);
    public void SetIHouseDeliveryUI(IHouse iHouse);
}
public interface IInspectingUIText
{
    public void ChoiceText(int num);
}

public interface IEndInspecting
{
    public void EndInspecting();
}

public interface IPoliceSmokeEffect
{
    public void InsPoliceSmokeEfectObj(Transform trans);
}

public interface IHouse
{
    public void EnableHouse();
    public void DisableHouse();
    public bool GetIsEnable();
}

public interface IMap
{
    public void AddAddress(AddressS addressS);
    public float RemoveAddress(AddressS addressS);
}
