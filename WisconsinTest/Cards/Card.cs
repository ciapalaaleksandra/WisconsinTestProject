using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcst.Models
{
    //klasa z własnościami karty
    public class Card
    {
        public string CardID { get; set; }
        public int CardNumber { get; set; }
        public string CardColor { get; set; }
        public string CardShape { get; set; }
    }
}