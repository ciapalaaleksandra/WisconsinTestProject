using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcst.Models
{
    public class CardList
    {
        public static List<Card> GetCards()
        {
            var cards = new List<Card>
            {
                //Circles
            new Card
            {
                CardID="circle1r.png",
                CardNumber=1,
                CardColor="red",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle1b.png",
                CardNumber=1,
                CardColor="blue",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle1g.png",
                CardNumber=1,
                CardColor="green",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle1y.png",
                CardNumber=1,
                CardColor="yellow",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle2r.png",
                CardNumber=2,
                CardColor="red",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle2b.png",
                CardNumber=2,
                CardColor="blue",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle2g.png",
                CardNumber=2,
                CardColor="green",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle2y.png",
                CardNumber=2,
                CardColor="yellow",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle3r.png",
                CardNumber=3,
                CardColor="red",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle3b.png",
                CardNumber=3,
                CardColor="blue",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle3g.png",
                CardNumber=3,
                CardColor="green",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle3y.png",
                CardNumber=3,
                CardColor="yellow",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle4r.png",
                CardNumber=4,
                CardColor="red",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle4b.png",
                CardNumber=4,
                CardColor="blue",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle4g.png",
                CardNumber=4,
                CardColor="green",
                CardShape="circle"
            },
            new Card
            {
                CardID="circle4y.png",
                CardNumber=4,
                CardColor="yellow",
                CardShape="circle"
            },
             //Stars
            new Card
            {
                CardID="star1r.png",
                CardNumber=1,
                CardColor="red",
                CardShape="star"
            },
            new Card
            {
                CardID="star1b.png",
                CardNumber=1,
                CardColor="blue",
                CardShape="star"
            },
            new Card
            {
                CardID="star1g.png",
                CardNumber=1,
                CardColor="green",
                CardShape="star"
            },
            new Card
            {
                CardID="star1y.png",
                CardNumber=1,
                CardColor="yellow",
                CardShape="star"
            },
            new Card
            {
                CardID="star2r.png",
                CardNumber=2,
                CardColor="red",
                CardShape="star"
            },
            new Card
            {
                CardID="star2b.png",
                CardNumber=2,
                CardColor="blue",
                CardShape="star"
            },
            new Card
            {
                CardID="star2g.png",
                CardNumber=2,
                CardColor="green",
                CardShape="star"
            },
            new Card
            {
                CardID="star2y.png",
                CardNumber=2,
                CardColor="yellow",
                CardShape="star"
            },
            new Card
            {
                CardID="star3r.png",
                CardNumber=3,
                CardColor="red",
                CardShape="star"
            },
            new Card
            {
                CardID="star3b.png",
                CardNumber=3,
                CardColor="blue",
                CardShape="star"
            },
            new Card
            {
                CardID="star3g.png",
                CardNumber=3,
                CardColor="green",
                CardShape="star"
            },
            new Card
            {
                CardID="star3y.png",
                CardNumber=3,
                CardColor="yellow",
                CardShape="star"
            },
            new Card
            {
                CardID="star4r.png",
                CardNumber=4,
                CardColor="red",
                CardShape="star"
            },
            new Card
            {
                CardID="star4b.png",
                CardNumber=4,
                CardColor="blue",
                CardShape="star"
            },
            new Card
            {
                CardID="star4g.png",
                CardNumber=4,
                CardColor="green",
                CardShape="star"
            },
            new Card
            {
                CardID="star4y.png",
                CardNumber=4,
                CardColor="yellow",
                CardShape="star"
            },
            //Rectangles
            new Card
            {
                CardID="rectangle1r.png",
                CardNumber=1,
                CardColor="red",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle1b.png",
                CardNumber=1,
                CardColor="blue",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle1g.png",
                CardNumber=1,
                CardColor="green",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle1y.png",
                CardNumber=1,
                CardColor="yellow",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle2r.png",
                CardNumber=2,
                CardColor="red",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle2b.png",
                CardNumber=2,
                CardColor="blue",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle2g.png",
                CardNumber=2,
                CardColor="green",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle2y.png",
                CardNumber=2,
                CardColor="yellow",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle3r.png",
                CardNumber=3,
                CardColor="red",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle3b.png",
                CardNumber=3,
                CardColor="blue",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle3g.png",
                CardNumber=3,
                CardColor="green",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle3y.png",
                CardNumber=3,
                CardColor="yellow",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle4r.png",
                CardNumber=4,
                CardColor="red",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle4b.png",
                CardNumber=4,
                CardColor="blue",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle4g.png",
                CardNumber=4,
                CardColor="green",
                CardShape="rectangle"
            },
            new Card
            {
                CardID="rectangle4y.png",
                CardNumber=4,
                CardColor="yellow",
                CardShape="rectangle"
            },
            //Crosses
            new Card
            {
                CardID="cross1r.png",
                CardNumber=1,
                CardColor="red",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross1b.png",
                CardNumber=1,
                CardColor="blue",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross1g.png",
                CardNumber=1,
                CardColor="green",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross1y.png",
                CardNumber=1,
                CardColor="yellow",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross2r.png",
                CardNumber=2,
                CardColor="red",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross2b.png",
                CardNumber=2,
                CardColor="blue",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross2g.png",
                CardNumber=2,
                CardColor="green",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross2y.png",
                CardNumber=2,
                CardColor="yellow",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross3r.png",
                CardNumber=3,
                CardColor="red",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross3b.png",
                CardNumber=3,
                CardColor="blue",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross3g.png",
                CardNumber=3,
                CardColor="green",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross3y.png",
                CardNumber=3,
                CardColor="yellow",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross4r.png",
                CardNumber=4,
                CardColor="red",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross4b.png",
                CardNumber=4,
                CardColor="blue",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross4g.png",
                CardNumber=4,
                CardColor="green",
                CardShape="cross"
            },
            new Card
            {
                CardID="cross4y.png",
                CardNumber=4,
                CardColor="yellow",
                CardShape="cross"
            },
            };
            return cards;
        }
    }
}