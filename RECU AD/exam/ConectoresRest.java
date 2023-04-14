package exam;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class ConectoresRest {

	public Connection conexion;

	public void abrirConexion(String bd, String servidor, String usuario, String password) {
		try {

			try {
				Class.forName("org.mariadb.jdbc.Driver");
			} catch (ClassNotFoundException e) {
				e.printStackTrace();
			}
			String url = String.format("jdbc:mariadb://%s:3306/%s", servidor, bd);

			this.conexion = DriverManager.getConnection(url, usuario, password);
			if (this.conexion != null && !this.conexion.isClosed()) {
				System.out.println("Conectado a " + bd + " en " + servidor);
			} else {
				System.out.println("No conectado a " + bd + " en " + servidor);
			}
		} catch (SQLException e) {
			System.out.println("SQLException: " + e.getLocalizedMessage());
			System.out.println("SQLState: " + e.getSQLState());
			System.out.println("Código error: " + e.getErrorCode());
		}
	}

	public void cerrarConexion() {
		try {
			this.conexion.close();
		} catch (SQLException e) {
			System.out.println("Error al cerrar la conexión: " + e.getLocalizedMessage());
		}
	}

	public static void main(String[] args) {

	}

}
