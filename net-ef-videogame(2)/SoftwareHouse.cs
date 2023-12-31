﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame_2_
{
    public class SoftwareHouse
    {
        public long SoftwareHouseId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }


        //RELAZIONE 1 A MOLTI: MOLTI VIDEOGAME X 1 SOFTWAREHOUSE
        public List<Videogame> Videogames { get; set; }

        // COSTRUTTORE
        public SoftwareHouse(long softwareHouseId, string name, string country)
        {
            Name = name;
            SoftwareHouseId = softwareHouseId;
            Country = country;
        }
    }
}
