using System;
namespace PSU_PL_LAB4_TASK7
{
    [Serializable]
    struct Toy
    {
        public string name { get; set; }
        public int price { get; set; }
        public int min_age { get; set; }
        public int max_age { get; set; }
    }
}   