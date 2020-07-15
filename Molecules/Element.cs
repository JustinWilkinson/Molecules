using System;

namespace Molecules
{
    /// <summary>
    /// Represents an element. 
    /// </summary>
    public class Element : IEquatable<Element>
    {
        /// <summary>
        /// The atomic number of the element, this must be unique within an <see cref="ElementCollection"/>.
        /// </summary>
        public int AtomicNumber { get; set; }

        /// <summary>
        /// The full (English) name of the element.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The symbol for the element, this must be unique within an <see cref="ElementCollection"/>.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Atomic mass of an element.
        /// </summary>
        public double AtomicMass { get; set; }

        /// <summary>
        /// Overrides the default <see cref="object.ToString"/> implementation.
        /// </summary>
        /// <returns>The atomic number, name and symbol of the element in the format "AtomicNumber Name (Symbol)".</returns>
        public override string ToString() => $"{AtomicNumber} {Name} ({Symbol})";

        /// <summary>
        /// Checks if elements are equal by comparing property values.
        /// </summary>
        /// <param name="other">Other element to compare to.</param>
        /// <returns>True if equal, false if not.</returns>
        public bool Equals(Element other) => AtomicNumber == other.AtomicNumber && Symbol == other.Symbol && Name == other.Name && AtomicMass == other.AtomicMass;

        #region PeriodicTable
        public static Element H { get; } = new Element { AtomicNumber = 1, Name = "Hydrogen", Symbol = "H", AtomicMass = 1.00794 };
        public static Element He { get; } = new Element { AtomicNumber = 2, Name = "Helium", Symbol = "He", AtomicMass = 4.002602 };
        public static Element Li { get; } = new Element { AtomicNumber = 3, Name = "Lithium", Symbol = "Li", AtomicMass = 6.941 };
        public static Element Be { get; } = new Element { AtomicNumber = 4, Name = "Beryllium", Symbol = "Be", AtomicMass = 9.012182 };
        public static Element B { get; } = new Element { AtomicNumber = 5, Name = "Boron", Symbol = "B", AtomicMass = 10.811 };
        public static Element C { get; } = new Element { AtomicNumber = 6, Name = "Carbon", Symbol = "C", AtomicMass = 12.0107 };
        public static Element N { get; } = new Element { AtomicNumber = 7, Name = "Nitrogen", Symbol = "N", AtomicMass = 14.0067 };
        public static Element O { get; } = new Element { AtomicNumber = 8, Name = "Oxygen", Symbol = "O", AtomicMass = 15.9994 };
        public static Element F { get; } = new Element { AtomicNumber = 9, Name = "Fluorine", Symbol = "F", AtomicMass = 18.9984032 };
        public static Element Ne { get; } = new Element { AtomicNumber = 10, Name = "Neon", Symbol = "Ne", AtomicMass = 20.1797 };
        public static Element Na { get; } = new Element { AtomicNumber = 11, Name = "Sodium", Symbol = "Na", AtomicMass = 22.98976928 };
        public static Element Mg { get; } = new Element { AtomicNumber = 12, Name = "Magnesium", Symbol = "Mg", AtomicMass = 24.305 };
        public static Element Al { get; } = new Element { AtomicNumber = 13, Name = "Aluminium", Symbol = "Al", AtomicMass = 26.9815386 };
        public static Element Si { get; } = new Element { AtomicNumber = 14, Name = "Silicon", Symbol = "Si", AtomicMass = 28.0855 };
        public static Element P { get; } = new Element { AtomicNumber = 15, Name = "Phosphorus", Symbol = "P", AtomicMass = 30.973762 };
        public static Element S { get; } = new Element { AtomicNumber = 16, Name = "Sulfur", Symbol = "S", AtomicMass = 32.065 };
        public static Element Cl { get; } = new Element { AtomicNumber = 17, Name = "Chlorine", Symbol = "Cl", AtomicMass = 35.453 };
        public static Element Ar { get; } = new Element { AtomicNumber = 18, Name = "Argon", Symbol = "Ar", AtomicMass = 39.948 };
        public static Element K { get; } = new Element { AtomicNumber = 19, Name = "Potassium", Symbol = "K", AtomicMass = 39.0983 };
        public static Element Ca { get; } = new Element { AtomicNumber = 20, Name = "Calcium", Symbol = "Ca", AtomicMass = 40.078 };
        public static Element Sc { get; } = new Element { AtomicNumber = 21, Name = "Scandium", Symbol = "Sc", AtomicMass = 44.955912 };
        public static Element Ti { get; } = new Element { AtomicNumber = 22, Name = "Titanium", Symbol = "Ti", AtomicMass = 47.867 };
        public static Element V { get; } = new Element { AtomicNumber = 23, Name = "Vanadium", Symbol = "V", AtomicMass = 50.9415 };
        public static Element Cr { get; } = new Element { AtomicNumber = 24, Name = "Chromium", Symbol = "Cr", AtomicMass = 51.9961 };
        public static Element Mn { get; } = new Element { AtomicNumber = 25, Name = "Manganese", Symbol = "Mn", AtomicMass = 54.938045 };
        public static Element Fe { get; } = new Element { AtomicNumber = 26, Name = "Iron", Symbol = "Fe", AtomicMass = 55.845 };
        public static Element Co { get; } = new Element { AtomicNumber = 27, Name = "Cobalt", Symbol = "Co", AtomicMass = 58.933195 };
        public static Element Ni { get; } = new Element { AtomicNumber = 28, Name = "Nickel", Symbol = "Ni", AtomicMass = 58.6934 };
        public static Element Cu { get; } = new Element { AtomicNumber = 29, Name = "Copper", Symbol = "Cu", AtomicMass = 63.546 };
        public static Element Zn { get; } = new Element { AtomicNumber = 30, Name = "Zinc", Symbol = "Zn", AtomicMass = 65.409 };
        public static Element Ga { get; } = new Element { AtomicNumber = 31, Name = "Gallium", Symbol = "Ga", AtomicMass = 69.723 };
        public static Element Ge { get; } = new Element { AtomicNumber = 32, Name = "Germanium", Symbol = "Ge", AtomicMass = 72.64 };
        public static Element As { get; } = new Element { AtomicNumber = 33, Name = "Arsenic", Symbol = "As", AtomicMass = 74.9216 };
        public static Element Se { get; } = new Element { AtomicNumber = 34, Name = "Selenium", Symbol = "Se", AtomicMass = 78.96 };
        public static Element Br { get; } = new Element { AtomicNumber = 35, Name = "Bromine", Symbol = "Br", AtomicMass = 79.904 };
        public static Element Kr { get; } = new Element { AtomicNumber = 36, Name = "Krypton", Symbol = "Kr", AtomicMass = 83.798 };
        public static Element Rb { get; } = new Element { AtomicNumber = 37, Name = "Rubidium", Symbol = "Rb", AtomicMass = 85.4678 };
        public static Element Sr { get; } = new Element { AtomicNumber = 38, Name = "Strontium", Symbol = "Sr", AtomicMass = 87.62 };
        public static Element Y { get; } = new Element { AtomicNumber = 39, Name = "Yttrium", Symbol = "Y", AtomicMass = 88.90585 };
        public static Element Zr { get; } = new Element { AtomicNumber = 40, Name = "Zirconium", Symbol = "Zr", AtomicMass = 91.224 };
        public static Element Nb { get; } = new Element { AtomicNumber = 41, Name = "Niobium", Symbol = "Nb", AtomicMass = 92.90638 };
        public static Element Mo { get; } = new Element { AtomicNumber = 42, Name = "Molybdenum", Symbol = "Mo", AtomicMass = 95.94 };
        public static Element Tc { get; } = new Element { AtomicNumber = 43, Name = "Technetium", Symbol = "Tc", AtomicMass = 98.9063 };
        public static Element Ru { get; } = new Element { AtomicNumber = 44, Name = "Ruthenium", Symbol = "Ru", AtomicMass = 101.07 };
        public static Element Rh { get; } = new Element { AtomicNumber = 45, Name = "Rhodium", Symbol = "Rh", AtomicMass = 102.9055 };
        public static Element Pd { get; } = new Element { AtomicNumber = 46, Name = "Palladium", Symbol = "Pd", AtomicMass = 106.42 };
        public static Element Ag { get; } = new Element { AtomicNumber = 47, Name = "Silver", Symbol = "Ag", AtomicMass = 107.8682 };
        public static Element Cd { get; } = new Element { AtomicNumber = 48, Name = "Cadmium", Symbol = "Cd", AtomicMass = 112.411 };
        public static Element In { get; } = new Element { AtomicNumber = 49, Name = "Indium", Symbol = "In", AtomicMass = 114.818 };
        public static Element Sn { get; } = new Element { AtomicNumber = 50, Name = "Tin", Symbol = "Sn", AtomicMass = 118.71 };
        public static Element Sb { get; } = new Element { AtomicNumber = 51, Name = "Antimony", Symbol = "Sb", AtomicMass = 121.76 };
        public static Element Te { get; } = new Element { AtomicNumber = 52, Name = "Tellurium", Symbol = "Te", AtomicMass = 127.6 };
        public static Element I { get; } = new Element { AtomicNumber = 53, Name = "Iodine", Symbol = "I", AtomicMass = 126.90447 };
        public static Element Xe { get; } = new Element { AtomicNumber = 54, Name = "Xenon", Symbol = "Xe", AtomicMass = 131.293 };
        public static Element Cs { get; } = new Element { AtomicNumber = 55, Name = "Caesium", Symbol = "Cs", AtomicMass = 132.9054519 };
        public static Element Ba { get; } = new Element { AtomicNumber = 56, Name = "Barium", Symbol = "Ba", AtomicMass = 137.327 };
        public static Element La { get; } = new Element { AtomicNumber = 57, Name = "Lanthanum", Symbol = "La", AtomicMass = 138.90547 };
        public static Element Ce { get; } = new Element { AtomicNumber = 58, Name = "Cerium", Symbol = "Ce", AtomicMass = 140.116 };
        public static Element Pr { get; } = new Element { AtomicNumber = 59, Name = "Praseodymium", Symbol = "Pr", AtomicMass = 140.90765 };
        public static Element Nd { get; } = new Element { AtomicNumber = 60, Name = "Neodymium", Symbol = "Nd", AtomicMass = 144.242 };
        public static Element Pm { get; } = new Element { AtomicNumber = 61, Name = "Promethium", Symbol = "Pm", AtomicMass = 146.9151 };
        public static Element Sm { get; } = new Element { AtomicNumber = 62, Name = "Samarium", Symbol = "Sm", AtomicMass = 150.36 };
        public static Element Eu { get; } = new Element { AtomicNumber = 63, Name = "Europium", Symbol = "Eu", AtomicMass = 151.964 };
        public static Element Gd { get; } = new Element { AtomicNumber = 64, Name = "Gadolinium", Symbol = "Gd", AtomicMass = 157.25 };
        public static Element Tb { get; } = new Element { AtomicNumber = 65, Name = "Terbium", Symbol = "Tb", AtomicMass = 158.92535 };
        public static Element Dy { get; } = new Element { AtomicNumber = 66, Name = "Dysprosium", Symbol = "Dy", AtomicMass = 162.5 };
        public static Element Ho { get; } = new Element { AtomicNumber = 67, Name = "Holmium", Symbol = "Ho", AtomicMass = 164.93032 };
        public static Element Er { get; } = new Element { AtomicNumber = 68, Name = "Erbium", Symbol = "Er", AtomicMass = 167.259 };
        public static Element Tm { get; } = new Element { AtomicNumber = 69, Name = "Thulium", Symbol = "Tm", AtomicMass = 168.93421 };
        public static Element Yb { get; } = new Element { AtomicNumber = 70, Name = "Ytterbium", Symbol = "Yb", AtomicMass = 173.04 };
        public static Element Lu { get; } = new Element { AtomicNumber = 71, Name = "Lutetium", Symbol = "Lu", AtomicMass = 174.967 };
        public static Element Hf { get; } = new Element { AtomicNumber = 72, Name = "Hafnium", Symbol = "Hf", AtomicMass = 178.49 };
        public static Element Ta { get; } = new Element { AtomicNumber = 73, Name = "Tantalum", Symbol = "Ta", AtomicMass = 180.9479 };
        public static Element W { get; } = new Element { AtomicNumber = 74, Name = "Tungsten", Symbol = "W", AtomicMass = 183.84 };
        public static Element Re { get; } = new Element { AtomicNumber = 75, Name = "Rhenium", Symbol = "Re", AtomicMass = 186.207 };
        public static Element Os { get; } = new Element { AtomicNumber = 76, Name = "Osmium", Symbol = "Os", AtomicMass = 190.23 };
        public static Element Ir { get; } = new Element { AtomicNumber = 77, Name = "Iridium", Symbol = "Ir", AtomicMass = 192.217 };
        public static Element Pt { get; } = new Element { AtomicNumber = 78, Name = "Platinum", Symbol = "Pt", AtomicMass = 195.084 };
        public static Element Au { get; } = new Element { AtomicNumber = 79, Name = "Gold", Symbol = "Au", AtomicMass = 196.966569 };
        public static Element Hg { get; } = new Element { AtomicNumber = 80, Name = "Mercury", Symbol = "Hg", AtomicMass = 200.59 };
        public static Element Tl { get; } = new Element { AtomicNumber = 81, Name = "Thallium", Symbol = "Tl", AtomicMass = 204.3833 };
        public static Element Pb { get; } = new Element { AtomicNumber = 82, Name = "Lead", Symbol = "Pb", AtomicMass = 207.2 };
        public static Element Bi { get; } = new Element { AtomicNumber = 83, Name = "Bismuth", Symbol = "Bi", AtomicMass = 208.9804 };
        public static Element Po { get; } = new Element { AtomicNumber = 84, Name = "Polonium", Symbol = "Po", AtomicMass = 208.9824 };
        public static Element At { get; } = new Element { AtomicNumber = 85, Name = "Astatine", Symbol = "At", AtomicMass = 209.9871 };
        public static Element Rn { get; } = new Element { AtomicNumber = 86, Name = "Radon", Symbol = "Rn", AtomicMass = 222.0176 };
        public static Element Fr { get; } = new Element { AtomicNumber = 87, Name = "Francium", Symbol = "Fr", AtomicMass = 223.0197 };
        public static Element Ra { get; } = new Element { AtomicNumber = 88, Name = "Radium", Symbol = "Ra", AtomicMass = 226.0254 };
        public static Element Ac { get; } = new Element { AtomicNumber = 89, Name = "Actinium", Symbol = "Ac", AtomicMass = 227.0278 };
        public static Element Th { get; } = new Element { AtomicNumber = 90, Name = "Thorium", Symbol = "Th", AtomicMass = 232.03806 };
        public static Element Pa { get; } = new Element { AtomicNumber = 91, Name = "Protactinium", Symbol = "Pa", AtomicMass = 231.03588 };
        public static Element U { get; } = new Element { AtomicNumber = 92, Name = "Uranium", Symbol = "U", AtomicMass = 238.02891 };
        public static Element Np { get; } = new Element { AtomicNumber = 93, Name = "Neptunium", Symbol = "Np", AtomicMass = 237.0482 };
        public static Element Pu { get; } = new Element { AtomicNumber = 94, Name = "Plutonium", Symbol = "Pu", AtomicMass = 244.0642 };
        public static Element Am { get; } = new Element { AtomicNumber = 95, Name = "Americium", Symbol = "Am", AtomicMass = 243.0614 };
        public static Element Cm { get; } = new Element { AtomicNumber = 96, Name = "Curium", Symbol = "Cm", AtomicMass = 247.0703 };
        public static Element Bk { get; } = new Element { AtomicNumber = 97, Name = "Berkelium", Symbol = "Bk", AtomicMass = 247.0703 };
        public static Element Cf { get; } = new Element { AtomicNumber = 98, Name = "Californium", Symbol = "Cf", AtomicMass = 251.0796 };
        public static Element Es { get; } = new Element { AtomicNumber = 99, Name = "Einsteinium", Symbol = "Es", AtomicMass = 252.0829 };
        public static Element Fm { get; } = new Element { AtomicNumber = 100, Name = "Fermium", Symbol = "Fm", AtomicMass = 257.0951 };
        public static Element Md { get; } = new Element { AtomicNumber = 101, Name = "Mendelevium", Symbol = "Md", AtomicMass = 258.0986 };
        public static Element No { get; } = new Element { AtomicNumber = 102, Name = "Nobelium", Symbol = "No", AtomicMass = 259.1009 };
        public static Element Lr { get; } = new Element { AtomicNumber = 103, Name = "Lawrencium", Symbol = "Lr", AtomicMass = 260.1053 };
        public static Element Rf { get; } = new Element { AtomicNumber = 104, Name = "Rutherfordium", Symbol = "Rf", AtomicMass = 261.1087 };
        public static Element Db { get; } = new Element { AtomicNumber = 105, Name = "Dubnium", Symbol = "Db", AtomicMass = 262.1138 };
        public static Element Sg { get; } = new Element { AtomicNumber = 106, Name = "Seaborgium", Symbol = "Sg", AtomicMass = 263.1182 };
        public static Element Bh { get; } = new Element { AtomicNumber = 107, Name = "Bohrium", Symbol = "Bh", AtomicMass = 262.1229 };
        public static Element Hs { get; } = new Element { AtomicNumber = 108, Name = "Hassium", Symbol = "Hs", AtomicMass = 265 };
        public static Element Mt { get; } = new Element { AtomicNumber = 109, Name = "Meitnerium", Symbol = "Mt", AtomicMass = 266 };
        public static Element Ds { get; } = new Element { AtomicNumber = 110, Name = "Darmstadtium", Symbol = "Ds", AtomicMass = 269 };
        public static Element Rg { get; } = new Element { AtomicNumber = 111, Name = "Roentgenium", Symbol = "Rg", AtomicMass = 272 };
        public static Element Cn { get; } = new Element { AtomicNumber = 112, Name = "Copernicium", Symbol = "Cn", AtomicMass = 285 };
        public static Element Nh { get; } = new Element { AtomicNumber = 113, Name = "Nihonium", Symbol = "Nh", AtomicMass = 286 };
        public static Element Fl { get; } = new Element { AtomicNumber = 114, Name = "Flerovium", Symbol = "Fl", AtomicMass = 289 };
        public static Element Mc { get; } = new Element { AtomicNumber = 115, Name = "Moscovium", Symbol = "Mc", AtomicMass = 290 };
        public static Element Lv { get; } = new Element { AtomicNumber = 116, Name = "Livermorium", Symbol = "Lv", AtomicMass = 293 };
        public static Element Ts { get; } = new Element { AtomicNumber = 117, Name = "Tennessine", Symbol = "Ts", AtomicMass = 294 };
        public static Element Og { get; } = new Element { AtomicNumber = 118, Name = "Oganesson", Symbol = "Og", AtomicMass = 294 };


        #endregion
    }
}