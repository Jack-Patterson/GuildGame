namespace com.Halkyon.Items
{
    public class Item
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public string SubCategory { get; private set; }
        public int Value { get; private set; }
        public ItemRank Rank { get; private set; }
        public bool IsStackable { get; private set; }

        public Item(string id, string name, string category, string subCategory, int value, ItemRank rank,
            bool isStackable)
        {
            Id = id;
            Name = name;
            Category = category;
            SubCategory = subCategory;
            Value = value;
            Rank = rank;
            IsStackable = isStackable;
        }

        public override string ToString()
        {
            return $"{Name} - {Category} - {SubCategory} - {Value} - {Rank} - {IsStackable}";
        }
    }
}