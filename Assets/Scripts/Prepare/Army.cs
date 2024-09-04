using System.Collections.Generic;

public class Army
{
    public List<Row> Rows { get; private set; }

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

        Rows[rowIndex].AddUnit(columnIndex, unitIndex, unit);
    }
}

public class Row
{
    public List<Column> Columns;

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
}

