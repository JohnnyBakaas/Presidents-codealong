namespace Presidents
{
    internal class App
    {
        private President[] _presidents;

        public App()
        {
            _presidents = GetPresidents();
        }

        public void Show()
        {
            foreach (var president in _presidents)
            {
                president.Show();
            }
        }

        public List<President> getPresidentInYear()
        {
            string userInput = Console.ReadLine();
            // legg til ting som gjør at det ikke kræsjer XD

            int yearFromUser = int.Parse(userInput);

            List<President> presidentene = new List<President>();
            for (int i = 0; i < _presidents.Length; i++)
            {
                if (_presidents[i].YearFrom <= yearFromUser && _presidents[i].YearTo >= yearFromUser)
                { presidentene.Add(_presidents[i]); }
            }
            return presidentene;
        }

        public void showThePatys()
        {
            List<Party> partys = new List<Party>();
            foreach (var president in _presidents)
            {
                var party = getParty(partys, president.Party);
                party.Presidents.Add(president);
            }
            foreach (var party in partys) { Console.WriteLine(party.Name); }
        }

        private Party getParty(List<Party> partys, string partyName)
        {
            for (int i = 0; i < partys.Count; i++)
            {
                if (partys[i].Name == partyName) { return partys[i]; }
            }
            partys.Add(new Party(partyName));
            return partys[partys.Count - 1];
        }

        private static President[] GetPresidents()
        {
            return new[]
            {
                new President("George Washington", "Federalist", "1789–97"),
                new President("John Adams", "Federalist", "1797–1801"),
                new President("Thomas Jefferson", "Democratic-Republican", "1801–09"),
                new President("James Madison", "Democratic-Republican", "1809–17"),
                new President("James Monroe", "Democratic-Republican", "1817–25"),
                new President("John Quincy Adams", "National Republican", "1825–29"),
                new President("Andrew Jackson", "Democratic", "1829–37"),
                new President("Martin Van Buren", "Democratic", "1837–41"),
                new President("William Henry Harrison", "Whig", "1841*"),
                new President("John Tyler", "Whig", "1841–45"),
                new President("James K. Polk", "Democratic", "1845–49"),
                new President("Zachary Taylor", "Whig", "1849–50*"),
                new President("Millard Fillmore", "Whig", "1850–53"),
                new President("Franklin Pierce", "Democratic", "1853–57"),
                new President("James Buchanan", "Democratic", "1857–61"),
                new President("Abraham Lincoln", "Republican", "1861–65*"),
                new President("Andrew Johnson", "Democratic (Union)", "1865–69"),
                new President("Ulysses S. Grant", "Republican", "1869–77"),
                new President("Rutherford B. Hayes", "Republican", "1877–81"),
                new President("James A. Garfield", "Republican", "1881*"),
                new President("Chester A. Arthur", "Republican", "1881–85"),
                new President("Grover Cleveland", "Democratic", "1885–89"),
                new President("Benjamin Harrison", "Republican", "1889–93"),
                new President("Grover Cleveland", "Democratic", "1893–97"),
                new President("William McKinley", "Republican", "1897–1901*"),
                new President("Theodore Roosevelt", "Republican", "1901–09"),
                new President("William Howard Taft", "Republican", "1909–13"),
                new President("Woodrow Wilson", "Democratic", "1913–21"),
                new President("Warren G. Harding", "Republican", "1921–23*"),
                new President("Calvin Coolidge", "Republican", "1923–29"),
                new President("Herbert Hoover", "Republican", "1929–33"),
                new President("Franklin D. Roosevelt", "Democratic", "1933–45*"),
                new President("Harry S. Truman", "Democratic", "1945–53"),
                new President("Dwight D. Eisenhower", "Republican", "1953–61"),
                new President("John F. Kennedy", "Democratic", "1961–63*"),
                new President("Lyndon B. Johnson", "Democratic", "1963–69"),
                new President("Richard M. Nixon", "Republican", "1969–74**"),
                new President("Gerald R. Ford", "Republican", "1974–77"),
                new President("Jimmy Carter", "Democratic", "1977–81"),
                new President("Ronald Reagan", "Republican", "1981–89"),
                new President("George Bush", "Republican", "1989–93"),
                new President("Bill Clinton", "Democratic", "1993–2001"),
                new President("George W. Bush", "Republican", "2001–09"),
                new President("Barack Obama", "Democratic", "2009–17"),
                new President("Donald Trump", "Republican", "2017–21"),
                new President("Joe Biden", "Democratic", "2021–"),
            };
        }
    }
}
