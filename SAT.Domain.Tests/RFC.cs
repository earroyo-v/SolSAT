using SAT.Domain.Domain;

namespace SAT.Domain.Tests
{
    public class RFC
    {
        [Fact]
        public void CrearRFC()
        {
            // Arrange
            string nombre = "Juan";
            string apellidoPaterno = "Perez";
            string apellidoMaterno = "Lopez";
            DateTime fechaNacimiento = new DateTime(1990, 5, 15);

            var rfc = new Contribuyente(0,nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento,null);

            // Act
            rfc.CrearRFC();

            // Assert
            Assert.Equal("PELJ900515", rfc.RFC); // Cambia esto según el resultado esperado

        }
    }
}