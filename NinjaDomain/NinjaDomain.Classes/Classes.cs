﻿using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;
using NinjaDomain.Classes.Enums;

namespace NinjaDomain.Classes
{
    public class Ninja
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool ServedInOniwaban { get; set; }

        public Clan Clan { get; set; }

        public int ClanId { get; set; }

        public List<NinjaEquipment> EquipmentOwned { get; set; }

        public DateTime DateOfBirth { get; set; }
    }

    public class Clan
    {
        public int Id { get; set; }
        public string ClanName { get; set; }
        public List<Ninja> Ninjas { get; set; }
    }

    public class NinjaEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }

        [Required]
        public Ninja Ninja { get; set; }
    }
}