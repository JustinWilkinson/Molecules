using System;

namespace Molecules
{
    /// <summary>
    /// Represents the frequency of an element within a molecule.
    /// </summary>
    public class ElementFrequency
    {
        /// <summary>
        /// Element associated with frequency.
        /// </summary>
        public Element Element { get; set; }

        /// <summary>
        /// Number of occurrences of an element within a molecule.
        /// </summary>
        public int Frequency { get; set; }
    }
}