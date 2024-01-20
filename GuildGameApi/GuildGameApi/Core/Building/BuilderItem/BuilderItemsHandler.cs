namespace com.Halcyon.API.Core.Building.BuilderItem;

public class BuilderItemsHandler<T> where T : IBuilderItem
{
    public List<T> FirstFloorItems { get; }
    public List<T> SecondFloorItems { get; }
    public List<T> ThirdFloorItems { get; }

    public BuilderItemsHandler()
    {
        FirstFloorItems = new List<T>();
        SecondFloorItems = new List<T>();
        ThirdFloorItems = new List<T>();
    }

    public BuilderItemsHandler(List<T> firstFloorItems, List<T> secondFloorItems, List<T> thirdFloorItems)
    {
        FirstFloorItems = firstFloorItems;
        SecondFloorItems = secondFloorItems;
        ThirdFloorItems = thirdFloorItems;
    }

    public void Add(int floorIndex, T item)
    {
        switch (floorIndex)
        {
            case 1:
                FirstFloorItems.Add(item);
                break;
            case 2:
                SecondFloorItems.Add(item);
                break;
            case 3:
                ThirdFloorItems.Add(item);
                break;
        }
    }

    public void Add(int floorIndex, T[] items)
    {
        foreach (T item in items)
        {
            Add(floorIndex, item);
        }
    }

    public void Add(int floorIndex, List<T> items)
    {
        Add(floorIndex, items.ToArray());
    }
    
    public void Remove(int floorIndex, T item)
    {
        switch (floorIndex)
        {
            case 1:
                FirstFloorItems.Remove(item);
                break;
            case 2:
                SecondFloorItems.Remove(item);
                break;
            case 3:
                ThirdFloorItems.Remove(item);
                break;
        }
    }

    public void Remove(int floorIndex, T[] items)
    {
        foreach (T item in items)
        {
            Remove(floorIndex, item);
        }
    }

    public void Remove(int floorIndex, List<T> items)
    {
        Remove(floorIndex, items.ToArray());
    }
}