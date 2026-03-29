using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum DoorType
{
    Plus,
    Minus,
    Product,
    Quotient
}

public class DoorSelect : MonoBehaviour
{
    

    public SpriteRenderer RightDoorSpriteRD;
    public SpriteRenderer LeftDoorSpriteRD;
    public TextMeshPro RightDoorText;
    public TextMeshPro LeftDoorText;
    [SerializeField]
    private DoorType RightDoorType;
    public int RightDoorNumber;
    [SerializeField]
    private DoorType LeftDoorType;
    public int LeftDoorNumber;
    public Color GoodColor;
    public Color BadColor;

    GameObject Raptor;
    private bool working = true;

    // Start is called before the first frame update
    void Start()
    {
        Raptor = GameObject.Find("NewDino");
        SettingDoors();
    }

    public void SettingDoors()
    {
        if (RightDoorType.Equals(DoorType.Plus)) {
            RightDoorSpriteRD.color = GoodColor;
            RightDoorText.text = "+" + RightDoorNumber;
        }
        else if (RightDoorType.Equals(DoorType.Minus)) {
            RightDoorSpriteRD.color = BadColor;
            RightDoorText.text = "-" + RightDoorNumber;
        }
        else if (RightDoorType.Equals(DoorType.Product)) {
            RightDoorSpriteRD.color = GoodColor;
            RightDoorText.text = "¡¿" + RightDoorNumber;
        }
        else if (RightDoorType.Equals(DoorType.Quotient)) {
            RightDoorSpriteRD.color = BadColor;
            RightDoorText.text = "¡À" + RightDoorNumber;
        }
        if (LeftDoorType.Equals(DoorType.Plus))
        {
            LeftDoorSpriteRD.color = GoodColor;
            LeftDoorText.text = "+" + LeftDoorNumber;
        }
        else if (LeftDoorType.Equals(DoorType.Minus))
        {
            LeftDoorSpriteRD.color = BadColor;
            LeftDoorText.text = "-" + LeftDoorNumber;
        }
        else if (LeftDoorType.Equals(DoorType.Product))
        {
            LeftDoorSpriteRD.color = GoodColor;
            LeftDoorText.text = "¡¿" + LeftDoorNumber;
        }
        else if (LeftDoorType.Equals(DoorType.Quotient))
        {
            LeftDoorSpriteRD.color = BadColor;
            LeftDoorText.text = "¡À" + LeftDoorNumber;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (working && Raptor.transform.position.z > this.transform.position.z)
        {
            if (Raptor.transform.position.x < 0)
            {
                if (LeftDoorType.Equals(DoorType.Plus)) { Raptor.GetComponent<ControlDinoNew>().DinoCount += LeftDoorNumber; }
                if (LeftDoorType.Equals(DoorType.Minus)) { Raptor.GetComponent<ControlDinoNew>().DinoCount -= LeftDoorNumber; }
                if (LeftDoorType.Equals(DoorType.Product)) { Raptor.GetComponent<ControlDinoNew>().DinoCount *= LeftDoorNumber; }
                if (LeftDoorType.Equals(DoorType.Quotient)) { Raptor.GetComponent<ControlDinoNew>().DinoCount /= LeftDoorNumber; }
            } else
            {
                if (RightDoorType.Equals(DoorType.Plus)) { Raptor.GetComponent<ControlDinoNew>().DinoCount += RightDoorNumber; }
                if (RightDoorType.Equals(DoorType.Minus)) { Raptor.GetComponent<ControlDinoNew>().DinoCount -= RightDoorNumber; }
                if (RightDoorType.Equals(DoorType.Product)) { Raptor.GetComponent<ControlDinoNew>().DinoCount *= RightDoorNumber; }
                if (RightDoorType.Equals(DoorType.Quotient)) { Raptor.GetComponent<ControlDinoNew>().DinoCount /= RightDoorNumber; }
            }
            working = false;
        }
        if (Raptor.transform.position.z - this.transform.position.z > 10) { Destroy(gameObject); }
    }
}
