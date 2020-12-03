using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson07_HomeWork07
{
    public class Inventory
    {
        public InventoryItem[] Items { get; set; }


        public bool isExistItem(string nameInventoryItem)
        {
            if (Items != null)
            { 
                for (int i = 0; i < Items.Length; i++)
                {
                    if (Items[i].Name == nameInventoryItem)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public void AddInventoryItem(InventoryItem newInventoryItem)
        {
            if (Items == null)
            {
                Items = new InventoryItem[1];
                Items[0] = newInventoryItem;
            }
            else 
            {
                InventoryItem[] newItems = new InventoryItem[Items.Length + 1];

                for (int i = 0; i < Items.Length; i++)
                {
                    newItems[i] = Items[i];
                }
                newItems[Items.Length] = newInventoryItem;
                Items = newItems;
            }
        }

        public void RemoveInventoryItem(string nameInventoryItem)
        {
            if (Items != null)
            {
                for (int i = 0; i < Items.Length; i++)
                {
                    if (Items[i].Name == nameInventoryItem)
                    {
                        InventoryItem[] newItems = new InventoryItem[Items.Length - 1];

                        for (int j = 0; j < Items.Length; j++)
                        {
                            if (j < i)
                                newItems[j] = Items[j];
                            else if (j > i)
                                newItems[j-1] = Items[j];
                        }
                        Items = newItems;
                        return;
                    }
                }
            }
        }

        public uint InventoryItemsCount(string nameInventoryItem)
        {
            uint count = 0;

            if (Items != null)
            {
                for (int i = 0; i < Items.Length; i++)
                {
                    if (Items[i].Name == nameInventoryItem)
                    {
                        count++;
                    }
                }
            }
            return count;
        }


    }
}
