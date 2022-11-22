using UnityEngine;


/// <summary>
/// inherate from the general properties and add the extra attributes (Age, Diet)
/// </summary>
public class LlamaProperties : GeneralPropertiesClass
{
    [Header("Llama properties")]
    [SerializeField]
    int age;
    enum DietTypeEnum
    {
        Grass,
        Flower,
        Shrub
    }
    [SerializeField]
    DietTypeEnum dietType;

    #region Get and Set
    public int GetAge()
    {
        return age;
    }
    
    public void SetAge(int _age)
    {
        age = _age;
    }

    public void SetDietType(int _number)
    {
        dietType = (DietTypeEnum)_number;
    }

    public string GetDietType()
    {
        return dietType.ToString();
    }
    #endregion
}

