using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KarmaSubClass
{
    LIGHT, NONE, DARK
}
public class Character : MonoBehaviour
{
    [SerializeField] private string m_name { get; set; }
    [SerializeField] private int m_pv { get; set; }
    [SerializeField] private int m_magicPower { get; set; }
    [SerializeField] private int m_physicPower { get; set; }
    [SerializeField] private int m_speed { get; set; }
    [SerializeField] private int m_pm { get; set; }
    [SerializeField] private int m_karma { get; set; }
    [SerializeField] private KarmaSubClass m_karmaSubClass { get; set; }
    [SerializeField] private Class m_class { get; set; }

    public void InitCharacterStats(string name, int pv, int magicPower, int physicPower, int speed, int pm, int karma, Class characterClass)
    {
        m_name = name;
        m_pv = pv;
        m_magicPower = magicPower;
        m_physicPower = physicPower;
        m_speed = speed;
        m_pm = pm;
        m_karma = karma;
        m_class = characterClass;
    }


    //Code a optimiser/modifier selon les prochaines modification apporter à la base du script Character
    public int GetKarma()
    {
        return m_karma;
    }

    public int GetPv()
    {
        return m_pv;
    }

    public void AdjustKarma(int amount)
    {
        m_karma += amount;
        if (m_karma >= 50) AddSubClass(true);
        else if (m_karma <= -50) AddSubClass(false);
        Debug.Log("Karma ajusté à : " + m_karma);
    }

    public void AddSubClass(bool karmaBool)
    {
        switch (m_class.getName())
        {
            case AllClass.GUERRIER:
                if (karmaBool) m_class.setSubClass(AllSubClass.PALADIN);
                else m_class.setSubClass(AllSubClass.BARBARE);
                break;

            case AllClass.MAGE:
                if (karmaBool) m_class.setSubClass(AllSubClass.MAGE_BLANC);
                else m_class.setSubClass(AllSubClass.MAGE_NOIR);
                break;

            case AllClass.ARCHER:
                if (karmaBool) m_class.setSubClass(AllSubClass.RODEUR);
                else m_class.setSubClass(AllSubClass.CHASSEUR);
                break;

            case AllClass.ROUBLARD:
                if (karmaBool) m_class.setSubClass(AllSubClass.VOLEUR);
                else m_class.setSubClass(AllSubClass.ASSASSIN);
                break;

            default:
                break;
        }
    }
    public void AdjustPv(int amount)
    {
        m_pv += amount;
        Debug.Log("Pv ajusté à : " + m_pv);
    }
}
