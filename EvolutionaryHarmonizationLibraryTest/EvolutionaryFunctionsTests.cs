using EvolutionrayHarmonizationLibrary.Helpers.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EvolutionaryHarmonizationLibraryTest
{
    public class EvolutionaryFunctionsTests
    {
        private readonly Mock<IRandom> randomMock;

        public EvolutionaryFunctionsTests()
        {
            randomMock = new Mock<IRandom>();
            randomMock.Setup(r => r.NextDouble()).Returns(0);
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
        }

        [Fact]
        public void MutateCompositionReturnsEveryNoteChanged()
        {

        }
    }
}
