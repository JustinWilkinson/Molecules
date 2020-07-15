using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Molecules
{
    /// <summary>
    /// Represents a molecule. Contains static methods to parse strings into molecule objects.
    /// </summary>
    public class Molecule
    {
        /// <summary>
        /// The collection of elements in a molecule and their respective frequencies.
        /// </summary>
        public IReadOnlyDictionary<string, ElementFrequency> ElementFrequencies { get; }

        /// <summary>
        /// The molecular mass of the molecule.
        /// </summary>
        public double Mass { get; }

        /// <summary>
        /// Chemical Formula for molecule.
        /// </summary>
        public string ChemicalFormula { get; }

        /// <summary>
        /// Name of the molecule.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructs a new Molecule with the specified formula and dictionary of element frequencies.
        /// </summary>
        /// <param name="elementFrequencies">Dictionary of element symbols/frequencies.</param>
        private Molecule(string formula, IDictionary<string, ElementFrequency> elementFrequencies)
        {
            ChemicalFormula = formula;
            ElementFrequencies = new ReadOnlyDictionary<string, ElementFrequency>(elementFrequencies);
            Mass = ElementFrequencies.Values.Sum(x => x.Frequency * x.Element.AtomicMass);
        }

        /// <summary>
        /// Overrides the default <see cref="object.ToString"/> implementation.
        /// </summary>
        /// <returns>The chemical formula of the molecule.</returns>
        public override string ToString() => ChemicalFormula;

        #region Parse
        /// <summary>
        /// Parses a string representation of a chemical formula into a Molecule Object using <see cref="ElementCollection.PeriodicTable"/> as a reference.
        /// </summary>
        /// <param name="formula">Formula to parse.</param>
        /// <returns>A molecule parsed from the formula.</returns>
        /// <exception cref="ArgumentNullException">Thrown when formula is null.</exception>
        /// <exception cref="ArgumentException">Thrown when formula is empty or all whitespace</exception>
        /// <exception cref="FormatException"> Thrown when formula:
        /// * Contains nested or unmatched parentheses.
        /// * Contains a non letter/digit character that is not a ( or )
        /// * Contains a "component" (a section of the string, either inside or outside parentheses) which starts with a lowercase 
        /// </exception>
        public static Molecule Parse(string formula) => Parse(formula, ElementCollection.PeriodicTable);

        /// <summary>
        /// Parses a string representation of a chemical formula into a Molecule Object using the provided elementCollection as a reference.
        /// </summary>
        /// <param name="formula">Formula to parse.</param>
        /// <param name="elementCollection">Element collection to use.</param>
        /// <returns>A molecule parsed from the formula.</returns>
        /// <exception cref="ArgumentNullException">Thrown when formula is null.</exception>
        /// <exception cref="ArgumentException">Thrown when formula is empty or all whitespace</exception>
        /// <exception cref="FormatException"> Thrown when formula:
        /// * Contains nested or unmatched parentheses.
        /// * Contains a non letter/digit character that is not a ( or )
        /// * Contains a "component" (a section of the string, either inside or outside parentheses) which starts with a lowercase 
        /// </exception>
        public static Molecule Parse(string formula, ElementCollection elementCollection)
        {
            if (formula == null)
            {
                throw new ArgumentNullException("Formula should not be null!");
            }
            else if (string.IsNullOrWhiteSpace(formula))
            {
                throw new ArgumentException("Formula should not be empty or all whitespace!");
            }

            var elementFrequencies = new Dictionary<string, ElementFrequency>();
            foreach ((string component, int multiplier) in GetComponents(formula))
            {
                foreach ((string symbol, int frequency) in ParseComponent(component))
                {
                    if (elementFrequencies.TryGetValue(symbol, out var elementFrequency))
                    {
                        elementFrequency.Frequency += multiplier * frequency;
                    }
                    else
                    {
                        elementFrequencies.Add(symbol, new ElementFrequency
                        {
                            Element = elementCollection[symbol],
                            Frequency = multiplier * frequency
                        });
                    }
                }
            }

            return new Molecule(formula, elementFrequencies);
        }

        /// <summary>
        /// Parses a string representation of a chemical formula into a Molecule Object using the <see cref="ElementCollection.PeriodicTable"/> as a reference.
        /// </summary>
        /// <param name="formula">Formula to parse.</param>
        /// <param name="molecule">The output molecule, will be null if false returned.</param>
        /// <returns>True if parse completed successfully, otherwise false..</returns>
        public static bool TryParse(string formula, out Molecule molecule) => TryParse(formula, ElementCollection.PeriodicTable, out molecule);

        /// <summary>
        /// Parses a string representation of a chemical formula into a Molecule Object using the provided elementCollection as a reference.
        /// </summary>
        /// <param name="formula">Formula to parse.</param>
        /// <param name="molecule">The output molecule, will be null if false returned.</param>
        /// <returns>True if parse completed successfully, otherwise false..</returns>
        public static bool TryParse(string formula, ElementCollection elementCollection, out Molecule molecule)
        {
            try
            {
                molecule = Parse(formula, elementCollection);
                return true;
            }
            catch
            {
                molecule = null;
                return false;
            }
        }
        #endregion

        #region Private Helpers
        private static IEnumerable<(string Component, int Multiplier)> GetComponents(string formula)
        {
            var componentBuilder = new StringBuilder();
            var inParentheses = false;
            for (int i = 0; i < formula.Length; i++)
            {
                var character = formula[i];

                if (char.IsLetterOrDigit(character))
                {
                    componentBuilder.Append(character); // Append character.
                }
                else if (character == '(')
                {
                    if (inParentheses) // Do not support nested parentheses.
                    {
                        throw new FormatException($"Formula: {formula} contains an unexpected opening bracket at position {i + 1}! Nested parentheses are not supported.");
                    }
                    else
                    {
                        inParentheses = true;
                        if (componentBuilder.Length > 0)
                        {
                            yield return (componentBuilder.ToString(), 1);
                        }
                        componentBuilder = new StringBuilder();
                    }
                }
                else if (character == ')')
                {
                    if (!inParentheses)
                    {
                        throw new FormatException($"Formula: {formula} contains an unexpected closing bracket at position {i + 1}!");
                    }
                    else
                    {
                        inParentheses = false;
                        i = i < formula.Length - 1 ? i + 1 : i; // Skip brace before handling multiplier if relevant.
                        yield return (componentBuilder.ToString(), GetMultiplier(formula, ref i));
                        componentBuilder = new StringBuilder();
                    }
                }
                else // Chemical formula should not contain non letter/digit except parentheses.
                {
                    throw new FormatException($"Formula: {formula} contains an invalid character at position {i + 1}!");
                }
            }

            if (componentBuilder.Length > 0)
            {
                yield return (componentBuilder.ToString(), 1);
            }
        }

        private static IEnumerable<(string Symbol, int Frequency)> ParseComponent(string component)
        {
            var elementBuilder = new StringBuilder();
            for (int i = 0; i < component.Length; i++)
            {
                var character = component[i];
                if (i == 0)
                {
                    if (!char.IsLetter(character) || !char.IsUpper(character))
                    {
                        throw new FormatException($"Component: {component} must start with an uppercase letter!");
                    }
                    else
                    {
                        elementBuilder.Append(character);
                    }
                }
                else
                {
                    if (char.IsUpper(character)) // Start of new element.
                    {
                        if (elementBuilder.Length > 0)
                        {
                            yield return (elementBuilder.ToString(), 1);
                        }
                        elementBuilder = new StringBuilder(character.ToString());
                    }
                    else if (char.IsDigit(character)) // End current element - need to extract multiplier for element.
                    {
                        yield return (elementBuilder.ToString(), GetMultiplier(component, ref i));
                        elementBuilder = new StringBuilder();
                    }
                    else // Lowercase letter.
                    {
                        elementBuilder.Append(character);
                    }
                }
            }

            if (elementBuilder.Length > 0)
            {
                yield return (elementBuilder.ToString(), 1);
            }
        }

        private static int GetMultiplier(string containingString, ref int index)
        {
            var firstChar = containingString[index];
            if (char.IsDigit(firstChar)) // Expected end digit is 
            {
                var multiplierBuilder = new StringBuilder(firstChar.ToString());
                while (index++ < containingString.Length - 1)
                {
                    var next = containingString[index];
                    if (char.IsDigit(next))
                    {
                        multiplierBuilder.Append(next);
                    }
                    else
                    {
                        break;
                    }
                }
                index--; // One off deduction, as we have increased i by one more than the number of characters that are digits.

                return int.Parse(multiplierBuilder.ToString());
            }

            return 1;
        }
        #endregion
    }
}