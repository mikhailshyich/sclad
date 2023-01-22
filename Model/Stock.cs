using System.Collections.Generic;

namespace Sclad.Model
{
    public class Stock
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public List<Goods> Goods { get; set; }
    }
}
