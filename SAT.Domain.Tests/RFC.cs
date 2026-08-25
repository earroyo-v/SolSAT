using SAT.Domain.Domain;

namespace SAT.Domain.Tests
{
    public class RFC
    {
        [Fact]
        public void CrearRFC_DeberiaGenerarRFCValido()
        {
            // Arrange
            string nombre = "Juan";
            string apellidoPaterno = "Perez";
            string apellidoMaterno = "Lopez";
            DateTime fechaNacimiento = new DateTime(1990, 5, 15);

            var rfc = new Contribuyente(0, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, null);

            // Act
            rfc.GenerarRfc();

            // Assert
            Assert.Equal("PELJ900515", rfc.RFC); // Ajusta según el formato esperado
        }

        [Fact]
        public void CrearRFC_SinApellidoMaterno_DeberiaGenerarRFCValido()
        {
            // Arrange
            string nombre = "Maria";
            string apellidoPaterno = "Gomez";
            string apellidoMaterno = ""; // Sin apellido materno
            DateTime fechaNacimiento = new DateTime(1985, 3, 10);

            var rfc = new Contribuyente(0, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, null);

            // Act
            rfc.GenerarRfc();

            // Assert
            Assert.Equal("GOXM850310", rfc.RFC); // Ajusta según el formato esperado
        }

        [Fact]
        public void CrearRFC_NombresCompuestos_DeberiaGenerarRFCValido()
        {
            // Arrange
            string nombre = "Juan Carlos";
            string apellidoPaterno = "Hernandez";
            string apellidoMaterno = "Martinez";
            DateTime fechaNacimiento = new DateTime(1975, 12, 25);

            var rfc = new Contribuyente(0, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, null);

            // Act
            rfc.GenerarRfc();

            // Assert
            Assert.Equal("HEMJ751225", rfc.RFC); // Ajusta según el formato esperado
        }

        [Fact]
        public void CrearRFC_NombresConCaracteresEspeciales_DeberiaGenerarRFCValido()
        {
            // Arrange
            string nombre = "José";
            string apellidoPaterno = "O'Connor";
            string apellidoMaterno = "López";
            DateTime fechaNacimiento = new DateTime(2000, 1, 1);

            var rfc = new Contribuyente(0, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, null);

            // Act
            rfc.GenerarRfc();

            // Assert
            Assert.Equal("OOLJ000101", rfc.RFC); // Ajusta según el formato esperado
        }

        [Fact]
        public void CrearRFC_FechaNacimientoEnOtroSiglo_DeberiaGenerarRFCValido()
        {
            // Arrange
            string nombre = "Luis";
            string apellidoPaterno = "Fernandez";
            string apellidoMaterno = "Gomez";
            DateTime fechaNacimiento = new DateTime(1899, 7, 15);

            var rfc = new Contribuyente(0, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, null);

            // Act
            rfc.GenerarRfc();

            // Assert
            Assert.Equal("FEGL990715", rfc.RFC); // Ajusta según el formato esperado
        }
    }
}