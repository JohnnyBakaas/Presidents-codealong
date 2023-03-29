namespace Presidents
{
    internal class App
    {
        private President[] _presidents;
        private List<Party> _partyes;


        public App()
        {
            _presidents = GetPresidents();
            _partyes = GetPartyLists();
        }

        private void PritnAlternativesForUser()
        {
            Console.WriteLine("Data om presidenter");
            Console.WriteLine("Hva vil du vite?");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Trykk                          For");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1            Vis alle presidentene");
            Console.WriteLine("2            List opp alle partier");
            Console.WriteLine("3      Vis presidenter etter parti");
            Console.WriteLine("4         Hvem var presiden i år X");
            Console.WriteLine("X                             EXIT");
            Console.WriteLine("----------------------------------");
        }

        private int GetUserInput()
        {
            PritnAlternativesForUser();
            string userInput = Console.ReadLine();
            if (userInput.ToUpper() == "X") return 0;
            try
            {
                Console.Clear();
                int userInputRefined = int.Parse(userInput);
                if (userInputRefined > 4) int.Parse("Tall mellom 1 og 4");
                return userInputRefined;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Venligst følg instruksjonene");
                for (int i = 0; i < 6; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(500);
                }
                Console.Clear();
                return GetUserInput();
            }
        }

        public void Run()
        {
            bool exit = false;
            int selectedAction = GetUserInput();
            switch (selectedAction)
            {
                case 0:
                    exit = true;
                    break;
                case 1:
                    ShowAllPresidents();
                    break;
                case 2:
                    ShowAllParys();
                    break;
                case 3:
                    ShowAllPresidentsAfterPartys();
                    break;
                case 4:
                    DisplayPresidentInSelectedYear();
                    break;
            }
            if (!exit) Run();
        }

        private void DisplayPresidentInSelectedYear()
        {
            List<President> presidntsOfTheYear = GetPresidentInYear();
            Console.WriteLine();
            if (presidntsOfTheYear.Count != 1) Console.WriteLine("Dette var ett overgangs år, så både");

            for (int i = 0; i < presidntsOfTheYear.Count; i++)
            {
                if (i != 0) Console.WriteLine("og");
                presidntsOfTheYear[i].Show();
            }

            Console.WriteLine("Var president dette året");
            Console.WriteLine();
        }

        private void ShowAllPresidentsAfterPartys()
        {
            foreach (var party in _partyes)
            {
                Console.WriteLine(party.Name);
                foreach (var pres in party.Presidents)
                {
                    pres.ShowWithoutParty();
                }
            }
        }

        private void ShowAllParys()
        {
            foreach (var party in _partyes)
            {
                Console.WriteLine(party.Name);
            }
        }

        private void ShowAllPresidents()
        {
            foreach (var president in _presidents)
            {
                president.Show();
            }
        }

        private List<President> GetPresidentInYear()
        {
            Console.WriteLine("Skriv inn ett år du lurer på");
            string userInput = Console.ReadLine();

            try
            {
                int yearFromUser = int.Parse(userInput);

                List<President> presidentene = new List<President>();

                for (int i = 0; i < _presidents.Length; i++)
                {
                    if (_presidents[i].YearFrom <= yearFromUser && _presidents[i].YearTo >= yearFromUser)
                    { presidentene.Add(_presidents[i]); }
                }
                return presidentene;
            }
            catch
            {
                Console.WriteLine("Dette med instruksjoner da");
                Thread.Sleep(1000);
                return GetPresidentInYear();
            }
        }

        private List<Party> GetPartyLists()
        {
            List<Party> partys = new List<Party>();
            foreach (var president in _presidents)
            {
                var party = GetParty(partys, president.Party);
                party.Presidents.Add(president);
            }
            return partys;
        }

        private Party GetParty(List<Party> partys, string partyName)
        {
            for (int i = 0; i < partys.Count; i++)
            {
                if (partys[i].Name == partyName) return partys[i];
            }
            Party newParty = new Party(partyName);
            partys.Add(newParty);
            return newParty;
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
