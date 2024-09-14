using System.Collections.Generic;
using UnityEngine;

public class Army
{
    public List<Row> Rows;
    public string Name;
    public int Points;

    public Army()
    {
        Rows = new List<Row>(5);
        for (int i = 0; i < 5; i++)
        {
            Rows.Add(new Row());
        }
    }

    public void AddUnit(Unit unit, CellUI cell)
    {
        int rowIndex = cell.transform.parent.parent.GetComponent<RowUI>().IndexRow;
        int columnIndex = cell.transform.parent.GetComponent<ColumnUI>().IndexColumn;
        int unitIndex = cell.transform.GetComponent<CellUI>().IndexCell;

        Points += unit.unitCharacteristics.Points;

        unit.unitCharacteristics.Value--;
        unit.Value.text = "x" + unit.unitCharacteristics.Value.ToString();

        Rows[rowIndex].AddUnit(columnIndex, unitIndex, unit);
    }

    public void RemoveUnit(Unit unit, CellUI cell)
    {
        int rowIndex = cell.transform.parent.parent.GetComponent<RowUI>().IndexRow;
        int columnIndex = cell.transform.parent.GetComponent<ColumnUI>().IndexColumn;
        int unitIndex = cell.transform.GetComponent<CellUI>().IndexCell;

        Points -= unit.unitCharacteristics.Points;

        unit.MainUnitLink.unitCharacteristics.Value++;
        unit.MainUnitLink.Value.text = "x" + unit.unitCharacteristics.Value.ToString();

        Rows[rowIndex].RemoveUnit(columnIndex, unitIndex);
    }
}

public class Row
{
    public List<Column> Columns;
    public SpeedRow SpeedRow;

    public Row()
    {
        Columns = new List<Column>(3);
        for (int i = 0; i < 3; i++)
        {
            Columns.Add(new Column());
        }
    }

    public void AddUnit(int columnIndex, int unitIndex, Unit unit)
    {
        Columns[columnIndex].AddUnit(unitIndex, unit);
    }

    public void RemoveUnit(int columnIndex, int unitIndex)
    {
        Columns[columnIndex].RemoveUnit(unitIndex);
    }
}

public class Column
{
    public List<Unit> Units;

    public Column()
    {
        Units = new List<Unit>(6);
        for (int i = 0; i < 6; i++)
        {
            Units.Add(null);
        }
    }

    public void AddUnit(int index, Unit unit)
    {
        Units[index] = unit;
    }

    public void RemoveUnit(int index)
    {
        Units[index] = null;
    }
}

public enum SpeedRow
{
    SlowPace = 0,
    Pace = 1,
    Run = 2
}

