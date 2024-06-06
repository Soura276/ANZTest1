using ANZTest.Interfaces;
using ANZTest.Models;
using ANZTest.Service;
using ANZTest.Validation;
using Moq;
using Xunit;
using static ANZTest.Helpers.UtilityHelper;

namespace ANZTest.UnitTest
{
    public class GameServiceTest
    {
        private readonly Mock<ITableModel> _tableMock;
        private readonly Mock<IToyModel> _toyMock;
        private readonly InputValidation _inputValidation;
        private readonly GameService _gameService;

        public GameServiceTest()
        {
            _tableMock = new Mock<ITableModel>();
            _toyMock = new Mock<IToyModel>();
            _inputValidation = new InputValidation(_tableMock.Object);
            _gameService = new GameService(this._toyMock.Object, this._tableMock.Object, _inputValidation);
        }

        [Fact]
        private void ProcessInput_Place_Test()
        {
            // Arrange
            var input = "Place 1,2,north";
            _tableMock.Setup(x => x.YMaxPosition).Returns(5);
            _tableMock.Setup(x => x.XMaxPosition).Returns(5);
            _tableMock.Setup(x => x.YMinPosition).Returns(0);
            _tableMock.Setup(x => x.XMinPosition).Returns(0);

            // Act
            _gameService.ProcessInput(input);

            //Assert
            _toyMock.Verify(x => x.place(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Facing>()), Times.Once);
        }

        [Fact]
        private void ProcessInput_Move_Test()
        {
            // Arrange
            var input = "Move";

            // Act
            _gameService.ProcessInput(input);

            //Assert
            _toyMock.Verify(x => x.Move(), Times.Once);
        }

        [Fact]
        private void ProcessInput_Left_Test()
        {
            // Arrange
            var input = "left";

            // Act
            _gameService.ProcessInput(input);

            //Assert
            _toyMock.Verify(x => x.left(), Times.Once);
        }

        [Fact]
        private void ProcessInput_Right_Test()
        {
            // Arrange
            var input = "right";

            // Act
            _gameService.ProcessInput(input);

            //Assert
            _toyMock.Verify(x => x.right(), Times.Once);
        }


        [Fact]
        private void ProcessInput_Report_Test()
        {
            // Arrange
            var input = "report";

            // Act
            _gameService.ProcessInput(input);

            //Assert
            _toyMock.Verify(x => x.report(), Times.Once);
        }

        [Fact]
        private void ProcessInput_Invalid_Test()
        {
            // Arrange
            var input = "invalid";

            // Act
            _gameService.ProcessInput(input);

            //Assert
            _toyMock.Verify(x => x.report(), Times.Never);
            _toyMock.Verify(x => x.left(), Times.Never);
            _toyMock.Verify(x => x.right(), Times.Never);
            _toyMock.Verify(x => x.Move(), Times.Never);
            _toyMock.Verify(x => x.place(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Facing>()), Times.Never);
        }
    }

}