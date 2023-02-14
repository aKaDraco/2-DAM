import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.ResultSet;
import java.sql.Statement;

public class Conexion {
    private Connection conexion;

    public Conexion() {
        abConex("add", "localhost", "root", "");
    }

    public void abConex(String bd, String servidor, String usuario, String pass) {
        try {
            String url = String.format("jdbc:mariadb://%s:3306/%s", servidor, bd);

            // ESTABLECEMOS LA CONEXIÓN
            this.conexion = DriverManager.getConnection(url, usuario, pass);
            if (conexion != null) {
                System.out.println("Conectado a " + bd + " en " + servidor);
            } else {
                System.out.println("No conectado");
            }
        } catch (SQLException e) {
            System.out.println("SQLExceptio: " + e.getLocalizedMessage());
            System.out.println("SQLState: " + e.getSQLState());
            System.out.println("Codigo error: " + e.getErrorCode());
        }
    }

    public void cerrarConexion() {
        try {
            this.conexion.close();
        } catch (SQLException e) {
            System.out.println("Error al cerrar la conexion: " + e.getLocalizedMessage());
        }
    }

    public void consultaAlumnos(String bd) {
        abConex("add", "localhost", "root", "");
        // El Statement se cierra solo al salir de catch
        try (Statement stmt = this.conexion.createStatement()) {
            // Consulta a ejecutar
            String query = "select * from aulas";
            // Se ejecuta la consulta
            ResultSet rs = stmt.executeQuery(query);
            // Mientras queden filas en rs (el método next devuelve true) recorremos las
            // filas
            while (rs.next()) {
                // Se obtiene datos en función del número de columna o de su nombre
                System.out.println(rs.getInt(1) + "\t" +
                        rs.getString("nombreAula") + "\t" + rs.getInt("puestos")); //
            }
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            cerrarConexion(); // Se cierra la conexión
        }
    }

    public void insertaFila() {
        try (Statement sta = this.conexion.createStatement()) {
            String query = "INSERT INTO aulas VALUES (5, 'Física', 23), (6, 'Química', 34)";
            // Se ejecuta la sentencia de inserción mediante executeUpdate
            int filasAfectadas = sta.executeUpdate(query);
            System.out.println("Filas insertadas: " + filasAfectadas);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        }
    }
}
