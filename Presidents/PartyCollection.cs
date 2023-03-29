namespace Presidents
{
    public class PartyCollection
    {
        private List<Party> _partyes;

        public PartyCollection(President[] allThePresidents)
        {
            _partyes = GetPartyLists(allThePresidents);
        }

        private List<Party> GetPartyLists(President[] allThePresidentspresidents)
        {
            List<Party> partys = new List<Party>();
            foreach (var president in allThePresidentspresidents)
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

        public void ShowPartys()
        {
            foreach (var party in _partyes)
            {
                Console.WriteLine(party.Name);
            }
        }

        public void ShowPresidents()
        {
            foreach (var party in _partyes)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine(party.Name);
                Console.WriteLine("-------------------------------------");
                foreach (President president in party.Presidents)
                {
                    president.ShowWithoutParty();
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine();
            }
        }
    }
}
