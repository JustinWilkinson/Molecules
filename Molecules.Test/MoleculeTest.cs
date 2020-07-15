using System;
using System.Linq;
using Xunit;

namespace Molecules.Test
{
    public class MoleculeTest
    {
        [Fact]
        public void Parse_NullFormula_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Molecule.Parse(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        public void Parse_EmptyOrWhitespaceFormula_ThrowsArgumentException(string formula)
        {
            Assert.Throws<ArgumentException>(() => Molecule.Parse(formula));
        }

        [Fact]
        public void Parse_FormulaWithNestedParentheses_ThrowsFormatExceptionWithCorrectMessage()
        {
            var ex = Assert.Throws<FormatException>(() => Molecule.Parse("((Nested)Parentheses)Inside"));
            Assert.Equal("Formula: ((Nested)Parentheses)Inside contains an unexpected opening bracket at position 2! Nested parentheses are not supported.", ex.Message);
        }

        [Fact]
        public void Parse_FormulaWithUnmatchedClosingBracket_ThrowsFormatExceptionWithCorrectMessage()
        {
            var ex = Assert.Throws<FormatException>(() => Molecule.Parse("FormulaWithUnmatchedClosingBracket)"));
            Assert.Equal("Formula: FormulaWithUnmatchedClosingBracket) contains an unexpected closing bracket at position 35!", ex.Message);
        }

        [Fact]
        public void Parse_FormulaWithUnrecognizedCharacter_ThrowsFormatExceptionWithCorrectMessage()
        {
            var ex = Assert.Throws<FormatException>(() => Molecule.Parse("FormulaWithInvalidCharacter!"));
            Assert.Equal("Formula: FormulaWithInvalidCharacter! contains an invalid character at position 28!", ex.Message);
        }

        [Fact]
        public void Parse_FormulaWithLowerCaseComponentStart_ThrowsFormatExceptionWithCorrectMessage()
        {
            var ex = Assert.Throws<FormatException>(() => Molecule.Parse("(lowerCase)ComponentStart"));
            Assert.Equal("Component: lowerCase must start with an uppercase letter!", ex.Message);
        }

        [Fact]
        public void Parse_FormulaWithNumericComponentStart_ThrowsFormatExceptionWithCorrectMessage()
        {
            var ex = Assert.Throws<FormatException>(() => Molecule.Parse("(1Number)ComponentStart"));
            Assert.Equal("Component: 1Number must start with an uppercase letter!", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("Formula(With(Nested)Parentheses)Inside)")]
        [InlineData("FormulaWithUnmatchedClosingBracket)")]
        [InlineData("FormulaWithInvalidCharacter!")]
        [InlineData("(lowerCase)ComponentStart")]
        [InlineData("(1Number)ComponentStart")]
        public void TryParse_InvalidData_ReturnsFalseAndMoleculeIsNull(string formula)
        {
            Assert.False(Molecule.TryParse(formula, out var molecule));
            Assert.Null(molecule);
        }

        [Fact]
        public void Parse_SingleAtom_ReturnsCorrectMolecule()
        {
            // Arrange
            var formula = "H";

            // Act
            var molecule = Molecule.Parse(formula);
            var frequencies = molecule.ElementFrequencies.Select(x => x.Value).ToList();

            // Assert
            Assert.Equal(1, molecule.ElementFrequencies.Count);
            Assert.Equal(Element.H, frequencies[0].Element);
            Assert.Equal(1, frequencies[0].Frequency);
            Assert.Equal(1.00794, molecule.Mass);
        }

        [Fact]
        public void Parse_SingleAtomWithTwoLetters_ReturnsCorrectMolecule()
        {
            // Arrange
            var formula = "He";

            // Act
            var molecule = Molecule.Parse(formula);
            var frequencies = molecule.ElementFrequencies.Select(x => x.Value).ToList();

            // Assert
            Assert.Equal(1, molecule.ElementFrequencies.Count);
            Assert.Equal(Element.He, frequencies[0].Element);
            Assert.Equal(1, frequencies[0].Frequency);
            Assert.Equal(4.002602, molecule.Mass);
        }

        [Fact]
        public void Parse_SimpleFormula_ReturnsCorrectMolecule()
        {
            // Arrange
            var formula = "H2O";

            // Act
            var molecule = Molecule.Parse(formula);
            var frequencies = molecule.ElementFrequencies.Select(x => x.Value).ToList();

            // Assert
            Assert.Equal(2, molecule.ElementFrequencies.Count);
            Assert.Equal(Element.H, frequencies[0].Element);
            Assert.Equal(2, frequencies[0].Frequency);
            Assert.Equal(Element.O, frequencies[1].Element);
            Assert.Equal(1, frequencies[1].Frequency);
            Assert.Equal(18.01528, molecule.Mass);
        }

        [Fact]
        public void Parse_SimpleFormulaWithTwoLetterElement_ReturnsCorrectMolecule()
        {
            // Arrange
            var formula = "CaCO3";

            // Act
            var molecule = Molecule.Parse(formula);
            var frequencies = molecule.ElementFrequencies.Select(x => x.Value).ToList();

            // Assert
            Assert.Equal(3, molecule.ElementFrequencies.Count);
            Assert.Equal(Element.Ca, frequencies[0].Element);
            Assert.Equal(1, frequencies[0].Frequency);
            Assert.Equal(Element.C, frequencies[1].Element);
            Assert.Equal(1, frequencies[1].Frequency);
            Assert.Equal(Element.O, frequencies[2].Element);
            Assert.Equal(3, frequencies[2].Frequency);
            Assert.Equal(100.0869, molecule.Mass);
        }

        [Fact]
        public void Parse_FormulaWithBrackets_ReturnsCorrectMolecule()
        {
            // Arrange
            var formula = "Al2(SO4)3";

            // Act
            var molecule = Molecule.Parse(formula);
            var frequencies = molecule.ElementFrequencies.Select(x => x.Value).ToList();

            // Assert
            Assert.Equal(3, molecule.ElementFrequencies.Count);
            Assert.Equal(Element.Al, frequencies[0].Element);
            Assert.Equal(2, frequencies[0].Frequency);
            Assert.Equal(Element.S, frequencies[1].Element);
            Assert.Equal(3, frequencies[1].Frequency);
            Assert.Equal(Element.O, frequencies[2].Element);
            Assert.Equal(12, frequencies[2].Frequency);
            Assert.Equal(342.1509, Math.Round(molecule.Mass, 4));
        }

        [Fact]
        public void Parse_LongerFormula_ReturnsCorrectResult()
        {
            // Arrange
            var formula = "C11H12N2O2"; // This is Tryptophan  https://en.wikipedia.org/wiki/Tryptophan.

            // Act
            var molecule = Molecule.Parse(formula);
            var frequencies = molecule.ElementFrequencies.Select(x => x.Value).ToList();

            // Assert
            Assert.Equal(4, molecule.ElementFrequencies.Count);
            Assert.Equal(Element.C, frequencies[0].Element);
            Assert.Equal(11, frequencies[0].Frequency);
            Assert.Equal(Element.H, frequencies[1].Element);
            Assert.Equal(12, frequencies[1].Frequency);
            Assert.Equal(Element.N, frequencies[2].Element);
            Assert.Equal(2, frequencies[2].Frequency);
            Assert.Equal(Element.O, frequencies[3].Element);
            Assert.Equal(2, frequencies[3].Frequency);
            Assert.Equal(204.22518, molecule.Mass);
        }

        [Fact]
        public void Parse_LongerFormulaWithRepeatedElements_ReturnsCorrectResult()
        {
            // Arrange
            var formula = "H2NCH2COOH"; // This is Glycine https://en.wikipedia.org/wiki/Glycine.

            // Act
            var molecule = Molecule.Parse(formula);
            var frequencies = molecule.ElementFrequencies.Select(x => x.Value).ToList();

            // Assert
            Assert.Equal(4, molecule.ElementFrequencies.Count);
            Assert.Equal(Element.H, frequencies[0].Element);
            Assert.Equal(5, frequencies[0].Frequency);
            Assert.Equal(Element.N, frequencies[1].Element);
            Assert.Equal(1, frequencies[1].Frequency);
            Assert.Equal(Element.C, frequencies[2].Element);
            Assert.Equal(2, frequencies[2].Frequency);
            Assert.Equal(Element.O, frequencies[3].Element);
            Assert.Equal(2, frequencies[3].Frequency);
            Assert.Equal(75.0666, molecule.Mass);
        }
    }
}