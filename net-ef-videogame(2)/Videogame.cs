using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame_2_
{
    public class Videogame
    {
        public long VideogameId { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }


        //RELAZIONE MOLTI AD 1: UNA SOFTWAREHOUSE PER MOLTI VIDEOGAME 

        public long SoftwareHouseId { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }

        // COSTRUTTORE
        public Videogame(long id, string name, string overview, DateTime release_date, long softwareHouseId)
        {
            VideogameId = id;
            Name = name;
            Overview = overview;
            ReleaseDate = release_date;
            SoftwareHouseId = softwareHouseId;
        }

        public override string ToString()
        {
            return $"{VideogameId}: {Name} {Overview} - {ReleaseDate}";
        }

    }
}
