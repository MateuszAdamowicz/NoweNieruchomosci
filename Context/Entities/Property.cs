﻿using Context.PartialModels;

namespace Context.Entities
{
    public class Property: BusinessObject
    {
        public virtual Advert Advert { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}