using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string m_name { get; set; }
    [SerializeField] private int m_pv { get; set; }
    [SerializeField] private int m_magicPower { get; set; }
    [SerializeField] private int m_physicPower { get; set; }
    [SerializeField] private int m_speed { get; set; }
    [SerializeField] private int m_pm { get; set; }
    [SerializeField] private int m_karma { get; set; }
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
        Debug.Log("Karma ajusté à : " + m_karma);
    }

    public void AdjustPv(int amount)
    {
        m_pv += amount;
        Debug.Log("Pv ajusté à : " + m_pv);
    }
}
