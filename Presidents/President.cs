namespace Presidents
{
    internal class President
    {
        public string Name { get; }
        public string Party { get; }
        public int YearFrom { get; }
        public int? YearTo { get; }
        public President(string name, string party, string years)
        {
            Name = name;
            Party = party;
            var parts = years.Replace("*", string.Empty).Split('-', '–');
            var yearFrom = parts[0];
            YearFrom = Convert.ToInt32(yearFrom);
            if (parts.Length < 2)
            {
                if (!years.Contains('-') && !years.Contains('–'))
                {
                    YearTo = YearFrom;
                }
                return;
            }
            var yearTo = parts[1];
            if (yearTo.Length == 0) return;
            yearTo = yearFrom.Substring(0, 4 - yearTo.Length) + yearTo;
            YearTo = Convert.ToInt32(yearTo);
        }

        public void Show()
        {
            var yearTo = YearTo.ToString() ?? "";
            Console.WriteLine($"{Name} ({Party}) {YearFrom} - {yearTo}");
        }

        public void ShowWithoutParty()
        {
            var yearTo = YearTo.ToString() ?? "";
            Console.WriteLine($"{Name} {YearFrom} - {yearTo}");
        }
    }
}
