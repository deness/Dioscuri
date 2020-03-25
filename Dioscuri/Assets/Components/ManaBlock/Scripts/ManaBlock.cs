
using System.Collections.Generic;
using UnityEngine.UI;

//
// Would like to get other's thought on the best way to store and represent the data. Should a grid just be a block
// What should a ManaCell store
// How do we invision working with this in Unity??
//


public class ManaBlock
{
    // What do I really want to store in here????
    public List<ManaCell> ManaCells { get; set; }
}

public class ManaCell
{
    public ManaCell(int row, int column, Image sprite)
    {
        Row = row;
        Column = column;
        ManaCellSprite = sprite;
    }

    public int Row { get; set; }
    public int Column { get; set; }
    public Image ManaCellSprite  { get; set; }
}