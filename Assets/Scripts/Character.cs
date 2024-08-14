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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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

    public int GetKarma()
    {
        return m_karma;
    }

    public void AdjustKarma(int amount)
    {
        m_karma += amount;
        Debug.Log("Karma ajusté à : " + m_karma);
    }
}
