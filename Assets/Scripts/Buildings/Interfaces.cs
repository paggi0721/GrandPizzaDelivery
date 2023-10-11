using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoliceNS.PolicePathNS;
using PoliceNS.PoliceStateNS;
using BuildingAddressNS;
using BuildingNS.HouseNS;

// 한석호 작성

public interface IAddress
{
    public void InitAddress(int number, List<AddressS> addressSList);
    public int GetAddress();
    public void SetIMap(IMap iMap);
    public void SetIDeliveryPanelControl(IDeliveryPanelControl iDeliveryPanelControl);
    public void SetIHouseActiveUIControl(IHouseActiveUIControl iHouseActiveControl);
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
    //public void SetPoliceSmokeEffect(ISetTransform iSetTransform);
    public Rigidbody2D GetRigidBody2D();
    public float GetSpeed();
    public PoliceState GetPoliceState();
    public void SetMap(IStop iStop);
    public void SetIsStop(bool bo);

    public void SetBanana(GameObject banana);

}
/// <summary>
/// 경찰차 제어에 관한 인터페이스
/// </summary>
public interface IMovingPoliceCarControl
{
    public void SetIsBehaviour(bool bo);
    //public int GetPoliceCarCode();
}
/// <summary>
/// 경찰차 우선순위 번호와 관련된 인터페이스
/// </summary>
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
public interface IHouseActiveUIControl
{
    public void ActiveTrueKeyExplainPanel(bool bo);
    public void SetHouseType(HouseType houseType);

}
public interface IInspectingUIText
{
    public void ChoiceText(int num);
}

public interface IEndInspecting
{
    public void EndInspecting();
}
public interface IHouse
{
    public void EnableHouse();
    public void DisableHouse();
    public bool GetIsEnable();
    public void SetHouseType(Sprite mark, HouseType houseType);
    public HouseType GetHouseType();
    public Transform GetLocation();

}
public interface IActiveHouse
{ 
    public bool ActiveHouse(bool bo);
    public void IntoHouse(bool bo);
}
public interface IMap
{
    public void AddAddress(AddressS addressS);
    public float RemoveAddress(AddressS addressS);
}
public interface IStop
{
    public void StopMap(bool bo);
    public void RemovePoliceList(IPoliceCar iPoliceCar);
}
public interface IIngredientSlot
{
    public void IngredientExplain(int ingNum);
    public void ChoiceIngredient(int ingNum, int index);
}

public interface IAddPizza
{
    public void SetAddPizzaExplain(int num);
    public void SetTemSlotNumber(int num);
}
/// <summary>
/// 피자집에서 생성된 피자에 관한 정보를 전달하는 인터페이스
/// </summary>
public interface IMakingPizzaPanel
{
    public void SetPizza(Pizza pizza);
    public bool ComparePizza(Pizza pizza);
}
/// <summary>
/// 화면 상단에 알람을 띄우는 인터페이스
/// </summary>
public interface IAlarmMessagePanel
{
    /// <summary>
    /// 알림 창 열고닫기. 알림창에 보여줄 텍스트도 설정해야됨
    /// </summary>
    /// <param name="isOn"></param>
    /// <param name="text">띄울 텍스트를 적는다.</param>
    public void ControlAlarmMessageUI(bool isOn, string text);
}
/// <summary>
/// 추격 경찰차를 소환하는 인터페이스
/// </summary>
public interface ISpawnCar
{
    /// <summary>
    /// 추격 경찰차를 count 수 만큼 소환합니다.
    /// </summary>
    /// <param name="count">소환할 추격 경찰차의 수입니다.</param>
    public void SpawnCar(int count);
}
/// <summary>
/// 트랜스폼을 가져오는 인터페이스
/// </summary>
public interface ISetTransform
{
    public void SetTransform(Transform trans);
}
/// <summary>
/// boolean 값을 반환하는 인터페이스
/// </summary>
public interface IGetBool
{
    public bool GetBool();
}
/// <summary>
/// 추격 경찰차 근처에 방해되는 오브젝트가 있는지 확인하기 위한 인터페이스
/// </summary>
public interface ICheckCol
{
    public void InitNumber(int num, IUpdateCheckList iUpdateCheckList);
}
/// <summary>
/// 추격 경찰차 근처에서 탐지한 것을 전달 혹은 사라졌음을 알리는 인터페이스
/// </summary>
public interface IUpdateCheckList
{
    public void UpdateCheck(int num, bool isAdd);
}
/// <summary>
/// 주사위 돌리는 코루틴을 가진 인터페이스
/// </summary>
public interface ICoroutineDice
{
    public IEnumerator DiceRoll(int num);
}