namespace com.Halcyon.API.Core.Building.BuilderItem;

public class BuilderItemsHandler<T> : LoggerUtil where T : IBuilderItem
{
    public List<T> FirstFloorItems { get; }
    public List<T> SecondFloorItems { get; }
    public List<T> ThirdFloorItems { get; }

    public BuilderItemsHandler()
    {
        FirstFloorItems = new List<T>();
        SecondFloorItems = new List<T>();
        ThirdFloorItems = new List<T>();

        GameManagerBase.Instance.Builder.FloorHandler.OnFloorChanged += OnFloorChanged;
    }

    public BuilderItemsHandler(List<T> firstFloorItems, List<T> secondFloorItems, List<T> thirdFloorItems)
    {
        FirstFloorItems = firstFloorItems;
        SecondFloorItems = secondFloorItems;
        ThirdFloorItems = thirdFloorItems;

        GameManagerBase.Instance.Builder.FloorHandler.OnFloorChanged += OnFloorChanged;
        ShowFloorsBasedOnIndex(GameManagerBase.Instance.Builder.FloorHandler.CurrentFloor);
    }

    public void Add(int floorIndex, T item)
    {
        switch (floorIndex)
        {
            case 1:
                FirstFloorItems.Add(item);
                ShowItemBasedOnFloorIndex(floorIndex, item);
                break;
            case 2:
                SecondFloorItems.Add(item);
                ShowItemBasedOnFloorIndex(floorIndex, item);
                break;
            case 3:
                ThirdFloorItems.Add(item);
                ShowItemBasedOnFloorIndex(floorIndex, item);
                break;
        }
    }

    public void Add(int floorIndex, T[] items)
    {
        if (items.Length <= 0) return;

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

    private void OnFloorChanged(int index)
    {
        ShowFloorsBasedOnIndex(index);
    }

    private void ShowFloorsBasedOnIndex(int index)
    {
        switch (index)
        {
            case 1:
                ShowAllItemsOnFloor(FirstFloorItems);
                HideAllItemsOnFloor(SecondFloorItems);
                HideAllItemsOnFloor(ThirdFloorItems);
                break;
            case 2:
                ShowAllItemsOnFloor(FirstFloorItems);
                ShowAllItemsOnFloor(SecondFloorItems);
                HideAllItemsOnFloor(ThirdFloorItems);
                break;
            case 3:
                ShowAllItemsOnFloor(FirstFloorItems);
                ShowAllItemsOnFloor(SecondFloorItems);
                ShowAllItemsOnFloor(ThirdFloorItems);
                break;
        }
    }

    private void ShowItemBasedOnFloorIndex(int floorIndex, T item)
    {
        int currentFloor = GameManagerBase.Instance.Builder.FloorHandler.CurrentFloor;
        if (floorIndex <= currentFloor) item.Show();
        else item.Hide();
    }

    private void ShowAllItemsOnFloor(List<T> items)
    {
        foreach (T item in items)
        {
            item.Show();
        }
    }

    private void HideAllItemsOnFloor(List<T> items)
    {
        foreach (T item in items)
        {
            item.Hide();
        }
    }
}