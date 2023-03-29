namespace Presidents
{
    public class Party
    {
        public string Name;
        public List<President> Presidents;
        public Party(string name)
        {
            Name = name;
            Presidents = new List<President>();
        }
    }
}
