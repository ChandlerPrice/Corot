using Corot.Items.Item_DataTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corot.Items
{
    public class Item
    {
        public int ID;
        public string Name;
        public string Type;
        public double Increase;
        public int Worth;
    }
    class Items
    {
        Game_ItemsTableAdapter items = new Game_ItemsTableAdapter();
        Item_Data dataSet = new Item_Data();

        public Items()
        {
            items.Fill(dataSet.Game_Items);
            items.GetData();
            int ID = dataSet.Game_Items[1].ID;
        }

        public Item GetItem(int index)
        {
            Item item = new Item();
            item.ID = dataSet.Game_Items[index].ID;
            return item;
        }

        public Item QueryItem(int ID)
        {
            var query = from item in dataSet.Game_Items
                        where (item.ID == ID)
                        select new Item() {ID = item.ID, 
                                           Name = item.Item_Name, 
                                           Type = item.Item_Type, 
                                           Increase = item.Item_Increase_Amount, 
                                           Worth = item.Item_Worth };

            return (query.Count() > 0) ? query.First() : null;
        }
    }
}
