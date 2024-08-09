using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AllClass
{
    GUERRIER, MAGE, ARCHER, ROUBLARD
}

public class Class : MonoBehaviour
{
    [SerializeField] private string m_className { get; set; }
    [SerializeField] private string m_subClass { get; set; }
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
}
