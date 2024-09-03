using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army
{
    public List<Row> ThisArmy = new List<Row>(5);
}

public class Row
{
    public List<Unit> Column1 = new List<Unit>(6);
    public List<Unit> Column2 = new List<Unit>(6);
    public List<Unit> Column3 = new List<Unit>(6);
}
