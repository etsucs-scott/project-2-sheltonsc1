using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    /// <summary>
    /// interface for comparing two cards
    /// </summary>
    /// <typeparam name="Card">class holding the suit and rank enums (the actual values being compared)</typeparam>
    public interface IComparing<Card> where Card : class
    {
        int CompareTo(Card card);
    }
}
