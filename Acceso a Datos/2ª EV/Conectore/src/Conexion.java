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

    public Connection getConexion() {
        return conexion;
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

    public ResultSet consultaAlumnos(String query) {
        try (Statement stmt = this.conexion.createStatement()) {
            ResultSet rs = stmt.executeQuery(query);
            return rs;
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        }
        return null;
    }

    public int insertaFila(String query) {
        try (Statement sta = this.conexion.createStatement()) {
            return sta.executeUpdate(query);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        }
        return 0;
    }

    public void addColumna() {
        Statement sta = null;
        try {
            sta = this.conexion.createStatement();
            String query = "ALTER TABLE aulas MODIFY nombreAula VARCHAR(25) DEFAULT NULL";
            // Se ejecuta la modificación de la tabla
            int filasAfectadas = sta.executeUpdate(query);
            System.out.println("Filas afectadas: " + filasAfectadas);
        } catch (SQLException e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());
        } finally {
            if (sta != null) {
                try {
                    sta.close(); // Se cierra el Statement
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }
        }
    }
}
