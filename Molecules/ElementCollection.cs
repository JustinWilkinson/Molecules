using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Molecules
{
    /// <summary>
    /// Represents a collection of <see cref="Element"/> objects.
    /// </summary>
    public class ElementCollection : ICollection<Element>
    {
        /// <summary>
        /// Backing collection.
        /// </summary>
        private readonly ICollection<Element> _elements = new List<Element>();
        
        /// <summary>
        /// Used for more performant lookups by atomic number.
        /// </summary>
        private readonly IDictionary<int, Element> _elementsByAtomicNumber = new Dictionary<int, Element>();

        /// <summary>
        /// Used for more performant lookups by symbol.
        /// </summary>
        private readonly IDictionary<string, Element> _elementsBySymbol = new Dictionary<string, Element>();

        /// <summary>
        /// Retrieves an element from the collection by <see cref="Element.AtomicNumber"/>.
        /// </summary>
        /// <param name="atomicNumber">Atomic number of element to retrieve.</param>
        /// <returns>The element in the collection with the corresponding atomic number.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when there is no element in the collection with the corresponding atomic number.</exception>
        public Element this[int atomicNumber] => _elementsByAtomicNumber[atomicNumber];

        /// <summary>
        /// Retrieves an element from the collection by <see cref="Element.Symbol"/>.
        /// </summary>
        /// <param name="symbol">Symbol of element to retrieve.</param>
        /// <returns>The element in the collection with the corresponding symbol.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when there is no element in the collection with the corresponding symbol.</exception>
        public Element this[string symbol] => _elementsBySymbol[symbol];

        /// <summary>
        /// Retrieves an element from the collection by <see cref="Element.AtomicMass"/>.
        /// </summary>
        /// <param name="symbol">Atomic mass of element to retrieve.</param>
        /// <returns>The element in the collection with the corresponding atomic mass.</returns>
        /// <exception cref="InvalidOperationException">Thrown when there is no element in the collection with the corresponding atomic mass.</exception>
        public Element this[double atomicMass] => _elements.Single(e => e.AtomicMass == atomicMass);

        /// <summary>
        /// Retrieves an element from the collection by <see cref="Element.Name"/>
        /// </summary>
        /// <param name="name">Name of element to retrieve.</param>
        /// <returns>The element in the collection with the corresponding atomic name.</returns>
        /// <exception cref="InvalidOperationException">Thrown when there is no element in the collection with the corresponding name.</exception>
        public Element GetByName(string name) => _elements.Single(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        #region ICollection<Element> Implementation
        /// <inheritdoc/>
        public int Count => _elements.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => _elements.IsReadOnly;

        /// <inheritdoc/>
        public void Add(Element item)
        {
            _elements.Add(item);
            _elementsByAtomicNumber.Add(item.AtomicNumber, item);
            _elementsBySymbol.Add(item.Symbol, item);
        }

        /// <inheritdoc/>
        public void Clear()
        {
            _elements.Clear();
            _elementsByAtomicNumber.Clear();
            _elementsBySymbol.Clear();
        }

        /// <inheritdoc/>
        public bool Contains(Element item) => _elements.Contains(item);

        /// <inheritdoc/>
        public void CopyTo(Element[] array, int arrayIndex) => _elements.CopyTo(array, arrayIndex);

        /// <inheritdoc/>
        public bool Remove(Element item) => _elementsByAtomicNumber.Remove(item.AtomicNumber) && _elementsBySymbol.Remove(item.Symbol) && _elements.Remove(item);

        /// <inheritdoc/>
        public IEnumerator<Element> GetEnumerator() => _elements.GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_elements).GetEnumerator();
        #endregion

        #region KnownElementCollection
        /// <summary>
        /// A collection containing the 118 known elements.
        /// </summary>
        public static ElementCollection PeriodicTable { get; } = new ElementCollection
        {
            Element.H,
            Element.He,
            Element.Li,
            Element.Be,
            Element.B,
            Element.C,
            Element.N,
            Element.O,
            Element.F,
            Element.Ne,
            Element.Na,
            Element.Mg,
            Element.Al,
            Element.Si,
            Element.P,
            Element.S,
            Element.Cl,
            Element.Ar,
            Element.K,
            Element.Ca,
            Element.Sc,
            Element.Ti,
            Element.V,
            Element.Cr,
            Element.Mn,
            Element.Fe,
            Element.Co,
            Element.Ni,
            Element.Cu,
            Element.Zn,
            Element.Ga,
            Element.Ge,
            Element.As,
            Element.Se,
            Element.Br,
            Element.Kr,
            Element.Rb,
            Element.Sr,
            Element.Y,
            Element.Zr,
            Element.Nb,
            Element.Mo,
            Element.Tc,
            Element.Ru,
            Element.Rh,
            Element.Pd,
            Element.Ag,
            Element.Cd,
            Element.In,
            Element.Sn,
            Element.Sb,
            Element.Te,
            Element.I,
            Element.Xe,
            Element.Cs,
            Element.Ba,
            Element.La,
            Element.Ce,
            Element.Pr,
            Element.Nd,
            Element.Pm,
            Element.Sm,
            Element.Eu,
            Element.Gd,
            Element.Tb,
            Element.Dy,
            Element.Ho,
            Element.Er,
            Element.Tm,
            Element.Yb,
            Element.Lu,
            Element.Hf,
            Element.Ta,
            Element.W,
            Element.Re,
            Element.Os,
            Element.Ir,
            Element.Pt,
            Element.Au,
            Element.Hg,
            Element.Tl,
            Element.Pb,
            Element.Bi,
            Element.Po,
            Element.At,
            Element.Rn,
            Element.Fr,
            Element.Ra,
            Element.Ac,
            Element.Th,
            Element.Pa,
            Element.U,
            Element.Np,
            Element.Pu,
            Element.Am,
            Element.Cm,
            Element.Bk,
            Element.Cf,
            Element.Es,
            Element.Fm,
            Element.Md,
            Element.No,
            Element.Lr,
            Element.Rf,
            Element.Db,
            Element.Sg,
            Element.Bh,
            Element.Hs,
            Element.Mt,
            Element.Ds,
            Element.Rg,
            Element.Cn,
            Element.Nh,
            Element.Fl,
            Element.Mc,
            Element.Lv,
            Element.Ts,
            Element.Og
        };
        #endregion
    }
}