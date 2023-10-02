using System.Xml;

namespace lw3;

public class Task18
{
    public void run()
    {
        Realty realty = Parser.parse();

        foreach (Location loc in realty.getLocations())
        {
            Console.WriteLine(loc);
        }
    }
    
    static class Parser
    {
        private static String path = "task18.xml";
        internal static Realty parse() {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlElement xmlElement = xmlDocument.DocumentElement;
            Realty realty = new Realty();

            foreach (XmlElement elem in xmlElement)
            {
                Location location = new Location();
                
                foreach (XmlNode node in elem.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "country":
                            location.Country = node.InnerText;
                            break;
                        case "region":
                            location.Region = node.InnerText;
                            break;
                        case "district":
                            location.District = node.InnerText;
                            break;
                        case "locality-name":
                            location.LocalityName = node.InnerText;
                            break;
                        case "sub-locality-name":
                            location.SubLocalityName = node.InnerText;
                            break;
                        case "non-admin-sub-locality":
                            location.NonAdminSubLocality = node.InnerText;
                            break;
                        case "address":
                            location.Address = node.InnerText;
                            break;
                        case "direction":
                            location.Direction = node.InnerText;
                            break;
                        case "distance":
                            location.Distance = node.InnerText;
                            break;
                    }
                }
                
                realty.add(location);
            }

            return realty;
        }
    }

    class Realty
    {
        private List<Location> locations;

        internal Realty()
        {
            locations = new List<Location>();
        }

        public void add(Location element)
        {
            locations.Add(element);
        }

        public List<Location> getLocations()
        {
            return locations;
        }
    }

    class Location
    {
        private string? country; 
        private string? region; 
        private string? district; 
        private string? localityName; 
        private string? subLocalityName; 
        private string? nonAdminSubLocality; 
        private string? address; 
        private string? direction;
        private string? distance;

        public Location()
        {
        }

        public string? Country
        {
            get => country;
            set => country = value;
        }

        public string? Region
        {
            get => region;
            set => region = value;
        }

        public string? District
        {
            get => district;
            set => district = value;
        }

        public string? LocalityName
        {
            get => localityName;
            set => localityName = value;
        }

        public string? SubLocalityName
        {
            get => subLocalityName;
            set => subLocalityName = value;
        }

        public string? NonAdminSubLocality
        {
            get => nonAdminSubLocality;
            set => nonAdminSubLocality = value;
        }

        public string? Address
        {
            get => address;
            set => address = value;
        }

        public string? Direction
        {
            get => direction;
            set => direction = value;
        }

        public string? Distance
        {
            get => distance;
            set => distance = value;
        }

        public Location(string? country, string? region, string? district, string? localityName, string? subLocalityName, string? nonAdminSubLocality, string? address, string? direction, string? distance)
        {
            this.country = country;
            this.region = region;
            this.district = district;
            this.localityName = localityName;
            this.subLocalityName = subLocalityName;
            this.nonAdminSubLocality = nonAdminSubLocality;
            this.address = address;
            this.direction = direction;
            this.distance = distance;
        }
        
        public override string ToString()
        {
            String s = "Location {";
            if (country != null) s += "\n\tCountry: " + country;
            if (region != null) s += "\n\tRegion: " + region;
            if (district != null) s += "\n\tDistrict: " + district;
            if (localityName != null) s += "\n\tLocality name: " + localityName;
            if (subLocalityName != null) s += "\n\tSub locality name: " + subLocalityName;
            if (nonAdminSubLocality != null) s += "\n\tNon admin sub locality: " + nonAdminSubLocality;
            if (address != null) s += "\n\tAddress: " + address;
            if (direction != null) s += "\n\tDirection: " + direction;
            if (distance != null) s += "\n\tDistance: " + distance;
            return s + "\n}";
        }
    }
}