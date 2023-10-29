using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultipleChoice : MonoBehaviour
{
    public GameObject Panel;
    public GameObject MenuButton;
    public GameObject Title;
    public GameObject TextBox;
    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public int ChoiceMade;

    public void Activate()
    {
        Panel.SetActive(true);
    }

    public void Choice0ption1 () {
        TextBox.GetComponent<TMP_Text>().text = "ZOSTAŁEŚ OSZUKANY! PRZEKLĘTA STÓPKA OKAZAŁA SIĘ PRZEBIEGŁYM DEMONEM. GINIESZ MARNIE!";
        ChoiceMade = 1;
    }

    public void Choice0ption2 () {
        TextBox.GetComponent<TMP_Text>().text = "RÓWNOWAGA MIĘDZY ŚWIATEM ASTRALNYM I MATERIALNYM ZOSTAŁA PRZYWRÓCONA. NIECH DZIADY (I STÓPKI) BĘDĄ Z TOBĄ!";
        ChoiceMade = 2;
    }

    public void Choice0ption3 () {
        TextBox.GetComponent<TMP_Text>().text = "DOPEŁNIŁEŚ NAJWYŻSZEGO STÓPKOWEGO PROROCTWA. WIWAT DLA ZBAWICIELA STÓPEK, POGROMCY DEMONÓW!";
        ChoiceMade = 3;
    }

    void Update() {
        if (ChoiceMade >= 1) {
            Choice01.SetActive (false);
            Choice02.SetActive (false);
            Choice03.SetActive (false);
            Title.SetActive(false);
            MenuButton.SetActive(true);
        }
    }
}
