using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "amelioration/creer nouvelle amelioration")]
public class inventaire : ScriptableObject
{
    public bool enPossesion;
    public string nom;
    public bool actif;
    [TextArea]
    public string description;
}
