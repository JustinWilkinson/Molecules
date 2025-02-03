namespace Molecules;

/// <summary>
/// Represents an element. 
/// </summary>
/// <param name="AtomicNumber">The atomic number of the element, this must be unique within an <see cref="ElementCollection"/>.</param>
/// <param name="Name">The full (English) name of the element.</param>
/// <param name="Symbol">The symbol for the element, this must be unique within an <see cref="ElementCollection"/>.</param>
/// <param name="AtomicMass">Atomic mass of an element.</param>
public sealed record Element(int AtomicNumber, string Name, string Symbol, double AtomicMass)
{
    /// <summary>
    /// Overrides the default <see cref="object.ToString"/> implementation.
    /// </summary>
    /// <returns>The atomic number, name and symbol of the element in the format "AtomicNumber Name (Symbol)".</returns>
    public override string ToString() => $"{AtomicNumber} {Name} ({Symbol})";

    #region PeriodicTable
    public static Element H { get; } = new Element(1, "Hydrogen", "H",  1.00794);
    public static Element He { get; } = new Element(2, "Helium", "He",  4.002602);
    public static Element Li { get; } = new Element(3, "Lithium", "Li",  6.941);
    public static Element Be { get; } = new Element(4, "Beryllium", "Be",  9.012182);
    public static Element B { get; } = new Element(5, "Boron", "B",  10.811);
    public static Element C { get; } = new Element(6, "Carbon", "C",  12.0107);
    public static Element N { get; } = new Element(7, "Nitrogen", "N",  14.0067);
    public static Element O { get; } = new Element(8, "Oxygen", "O",  15.9994);
    public static Element F { get; } = new Element(9, "Fluorine", "F",  18.9984032);
    public static Element Ne { get; } = new Element(10, "Neon", "Ne",  20.1797);
    public static Element Na { get; } = new Element(11, "Sodium", "Na",  22.98976928);
    public static Element Mg { get; } = new Element(12, "Magnesium", "Mg",  24.305);
    public static Element Al { get; } = new Element(13, "Aluminium", "Al",  26.9815386);
    public static Element Si { get; } = new Element(14, "Silicon", "Si",  28.0855);
    public static Element P { get; } = new Element(15, "Phosphorus", "P",  30.973762);
    public static Element S { get; } = new Element(16, "Sulfur", "S",  32.065);
    public static Element Cl { get; } = new Element(17, "Chlorine", "Cl",  35.453);
    public static Element Ar { get; } = new Element(18, "Argon", "Ar",  39.948);
    public static Element K { get; } = new Element(19, "Potassium", "K",  39.0983);
    public static Element Ca { get; } = new Element(20, "Calcium", "Ca",  40.078);
    public static Element Sc { get; } = new Element(21, "Scandium", "Sc",  44.955912);
    public static Element Ti { get; } = new Element(22, "Titanium", "Ti",  47.867);
    public static Element V { get; } = new Element(23, "Vanadium", "V",  50.9415);
    public static Element Cr { get; } = new Element(24, "Chromium", "Cr",  51.9961);
    public static Element Mn { get; } = new Element(25, "Manganese", "Mn",  54.938045);
    public static Element Fe { get; } = new Element(26, "Iron", "Fe",  55.845);
    public static Element Co { get; } = new Element(27, "Cobalt", "Co",  58.933195);
    public static Element Ni { get; } = new Element(28, "Nickel", "Ni",  58.6934);
    public static Element Cu { get; } = new Element(29, "Copper", "Cu",  63.546);
    public static Element Zn { get; } = new Element(30, "Zinc", "Zn",  65.409);
    public static Element Ga { get; } = new Element(31, "Gallium", "Ga",  69.723);
    public static Element Ge { get; } = new Element(32, "Germanium", "Ge",  72.64);
    public static Element As { get; } = new Element(33, "Arsenic", "As",  74.9216);
    public static Element Se { get; } = new Element(34, "Selenium", "Se",  78.96);
    public static Element Br { get; } = new Element(35, "Bromine", "Br",  79.904);
    public static Element Kr { get; } = new Element(36, "Krypton", "Kr",  83.798);
    public static Element Rb { get; } = new Element(37, "Rubidium", "Rb",  85.4678);
    public static Element Sr { get; } = new Element(38, "Strontium", "Sr",  87.62);
    public static Element Y { get; } = new Element(39, "Yttrium", "Y",  88.90585);
    public static Element Zr { get; } = new Element(40, "Zirconium", "Zr",  91.224);
    public static Element Nb { get; } = new Element(41, "Niobium", "Nb",  92.90638);
    public static Element Mo { get; } = new Element(42, "Molybdenum", "Mo",  95.94);
    public static Element Tc { get; } = new Element(43, "Technetium", "Tc",  98.9063);
    public static Element Ru { get; } = new Element(44, "Ruthenium", "Ru",  101.07);
    public static Element Rh { get; } = new Element(45, "Rhodium", "Rh",  102.9055);
    public static Element Pd { get; } = new Element(46, "Palladium", "Pd",  106.42);
    public static Element Ag { get; } = new Element(47, "Silver", "Ag",  107.8682);
    public static Element Cd { get; } = new Element(48, "Cadmium", "Cd",  112.411);
    public static Element In { get; } = new Element(49, "Indium", "In",  114.818);
    public static Element Sn { get; } = new Element(50, "Tin", "Sn",  118.71);
    public static Element Sb { get; } = new Element(51, "Antimony", "Sb",  121.76);
    public static Element Te { get; } = new Element(52, "Tellurium", "Te",  127.6);
    public static Element I { get; } = new Element(53, "Iodine", "I",  126.90447);
    public static Element Xe { get; } = new Element(54, "Xenon", "Xe",  131.293);
    public static Element Cs { get; } = new Element(55, "Caesium", "Cs",  132.9054519);
    public static Element Ba { get; } = new Element(56, "Barium", "Ba",  137.327);
    public static Element La { get; } = new Element(57, "Lanthanum", "La",  138.90547);
    public static Element Ce { get; } = new Element(58, "Cerium", "Ce",  140.116);
    public static Element Pr { get; } = new Element(59, "Praseodymium", "Pr",  140.90765);
    public static Element Nd { get; } = new Element(60, "Neodymium", "Nd",  144.242);
    public static Element Pm { get; } = new Element(61, "Promethium", "Pm",  146.9151);
    public static Element Sm { get; } = new Element(62, "Samarium", "Sm",  150.36);
    public static Element Eu { get; } = new Element(63, "Europium", "Eu",  151.964);
    public static Element Gd { get; } = new Element(64, "Gadolinium", "Gd",  157.25);
    public static Element Tb { get; } = new Element(65, "Terbium", "Tb",  158.92535);
    public static Element Dy { get; } = new Element(66, "Dysprosium", "Dy",  162.5);
    public static Element Ho { get; } = new Element(67, "Holmium", "Ho",  164.93032);
    public static Element Er { get; } = new Element(68, "Erbium", "Er",  167.259);
    public static Element Tm { get; } = new Element(69, "Thulium", "Tm",  168.93421);
    public static Element Yb { get; } = new Element(70, "Ytterbium", "Yb",  173.04);
    public static Element Lu { get; } = new Element(71, "Lutetium", "Lu",  174.967);
    public static Element Hf { get; } = new Element(72, "Hafnium", "Hf",  178.49);
    public static Element Ta { get; } = new Element(73, "Tantalum", "Ta",  180.9479);
    public static Element W { get; } = new Element(74, "Tungsten", "W",  183.84);
    public static Element Re { get; } = new Element(75, "Rhenium", "Re",  186.207);
    public static Element Os { get; } = new Element(76, "Osmium", "Os",  190.23);
    public static Element Ir { get; } = new Element(77, "Iridium", "Ir",  192.217);
    public static Element Pt { get; } = new Element(78, "Platinum", "Pt",  195.084);
    public static Element Au { get; } = new Element(79, "Gold", "Au",  196.966569);
    public static Element Hg { get; } = new Element(80, "Mercury", "Hg",  200.59);
    public static Element Tl { get; } = new Element(81, "Thallium", "Tl",  204.3833);
    public static Element Pb { get; } = new Element(82, "Lead", "Pb",  207.2);
    public static Element Bi { get; } = new Element(83, "Bismuth", "Bi",  208.9804);
    public static Element Po { get; } = new Element(84, "Polonium", "Po",  208.9824);
    public static Element At { get; } = new Element(85, "Astatine", "At",  209.9871);
    public static Element Rn { get; } = new Element(86, "Radon", "Rn",  222.0176);
    public static Element Fr { get; } = new Element(87, "Francium", "Fr",  223.0197);
    public static Element Ra { get; } = new Element(88, "Radium", "Ra",  226.0254);
    public static Element Ac { get; } = new Element(89, "Actinium", "Ac",  227.0278);
    public static Element Th { get; } = new Element(90, "Thorium", "Th",  232.03806);
    public static Element Pa { get; } = new Element(91, "Protactinium", "Pa",  231.03588);
    public static Element U { get; } = new Element(92, "Uranium", "U",  238.02891);
    public static Element Np { get; } = new Element(93, "Neptunium", "Np",  237.0482);
    public static Element Pu { get; } = new Element(94, "Plutonium", "Pu",  244.0642);
    public static Element Am { get; } = new Element(95, "Americium", "Am",  243.0614);
    public static Element Cm { get; } = new Element(96, "Curium", "Cm",  247.0703);
    public static Element Bk { get; } = new Element(97, "Berkelium", "Bk",  247.0703);
    public static Element Cf { get; } = new Element(98, "Californium", "Cf",  251.0796);
    public static Element Es { get; } = new Element(99, "Einsteinium", "Es",  252.0829);
    public static Element Fm { get; } = new Element(100, "Fermium", "Fm",  257.0951);
    public static Element Md { get; } = new Element(101, "Mendelevium", "Md",  258.0986);
    public static Element No { get; } = new Element(102, "Nobelium", "No",  259.1009);
    public static Element Lr { get; } = new Element(103, "Lawrencium", "Lr",  260.1053);
    public static Element Rf { get; } = new Element(104, "Rutherfordium", "Rf",  261.1087);
    public static Element Db { get; } = new Element(105, "Dubnium", "Db",  262.1138);
    public static Element Sg { get; } = new Element(106, "Seaborgium", "Sg",  263.1182);
    public static Element Bh { get; } = new Element(107, "Bohrium", "Bh",  262.1229);
    public static Element Hs { get; } = new Element(108, "Hassium", "Hs",  265);
    public static Element Mt { get; } = new Element(109, "Meitnerium", "Mt",  266);
    public static Element Ds { get; } = new Element(110, "Darmstadtium", "Ds",  269);
    public static Element Rg { get; } = new Element(111, "Roentgenium", "Rg",  272);
    public static Element Cn { get; } = new Element(112, "Copernicium", "Cn",  285);
    public static Element Nh { get; } = new Element(113, "Nihonium", "Nh",  286);
    public static Element Fl { get; } = new Element(114, "Flerovium", "Fl",  289);
    public static Element Mc { get; } = new Element(115, "Moscovium", "Mc",  290);
    public static Element Lv { get; } = new Element(116, "Livermorium", "Lv",  293);
    public static Element Ts { get; } = new Element(117, "Tennessine", "Ts",  294);
    public static Element Og { get; } = new Element(118, "Oganesson", "Og",  294);


    #endregion
}