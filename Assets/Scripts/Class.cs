using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AllClass
{
    GUERRIER, MAGE, ARCHER, ROUBLARD
}

public enum AllSubClass
{
    PALADIN, BARBARE, MAGE_BLANC, MAGE_NOIR, RODEUR, CHASSEUR, VOLEUR, ASSASSIN
}

public class Class : MonoBehaviour
{
    [SerializeField] private AllClass m_className { get; set; }
    [SerializeField] private AllSubClass m_subClass { get; set; }
    [SerializeField] private Skill m_firstSkill { get; set; }
    [SerializeField] private Skill m_secondSkill { get; set; }
    [SerializeField] private Skill m_thirdSkill { get; set; }
    [SerializeField] private Skill m_fourthSkill { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AllClass getName() { return m_className; }

    public void setSubClass(AllSubClass amount)
    {
        m_subClass= amount;
    }
}
