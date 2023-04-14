import java.sql.Connection;
import java.sql.DatabaseMetaData;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class Conectores {

	private Connection conexion;

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

	public int ejercicio3(String bd,Double valMenor,Double valMayor){
		abrirConexion(bd, "localhost", "root", "");
		int nOcurrencias=0;
		try{
			Statement stmt = conexion.createStatement();
			String query = "SELECT nombre,sigloAcConstruccion,valoracion FROM maravillas WHERE valoracion>"+valMenor+" AND valoracion<"+valMayor;
			ResultSet filas = stmt.executeQuery(query);
			while(filas.next()){
				System.out.println("Nombre: "+filas.getString("nombre")+", Siglo Ac Construcción: "+filas.getInt("sigloAcConstruccion")+", Valoración: "+filas.getLong("valoracion"));
				nOcurrencias++;
			}
			return nOcurrencias;
		}catch(SQLException e){
			System.out.println("Codigo Error SQL: "+e.getErrorCode());
			System.out.println("Estado SQL: "+e.getSQLState());
			System.out.println("Tipo de excepción: "+e.getNextException());
			return-1;
		}finally{
			cerrarConexion();
		}

	}

	public int ejercicio4(String bd,int codmaravilla,String nombre,Double valoracion){
		abrirConexion(bd, "localhost", "root", "");
		int nOcurrencias=0;
		try{
			Statement stmt = conexion.createStatement();
			String query = "UPDATE table maravillas INSERT INTO (nombre,valoracion) VALUES("+nombre+","+valoracion+") WHERE codmaravilla="+codmaravilla;
			stmt.executeUpdate(query);
			
			return 1;
		}catch(SQLException e){
			if(this.conexion==null){
				return 0;
			}else{
				System.out.println("Codigo Error SQL: "+e.getErrorCode());
				System.out.println("Estado SQL: "+e.getSQLState());
				System.out.println("Tipo de excepción: "+e.getNextException());
				return -1;
			}
			
		}finally{
			cerrarConexion();
		}

	}

	public void ejercicio5(String bd,String cadenaContenida,Double valoracion){
		abrirConexion(bd, "localhost", "root", "");
		try{
			String query = "SELECT nombre,nombreCiv,valoracion FROM maravillas WHERE valoracion>? AND nombre LIKE ?";
			PreparedStatement stmt = conexion.prepareStatement(query);
			stmt.setDouble(1, valoracion);
			stmt.setString(2, cadenaContenida);
			ResultSet filas = stmt.executeQuery();

			while(filas.next()){
				System.out.println("Nombre: "+filas.getString("nombre")+", Siglo Ac Construcción: "+filas.getInt(3)+", Valoración: "+filas.getDouble("valoracion"));
			}
		}catch(SQLException e){
			System.out.println("Codigo Error SQL: "+e.getErrorCode());
			System.out.println("Estado SQL: "+e.getSQLState());
			System.out.println("Tipo de excepción: "+e.getNextException());
		}finally{
			cerrarConexion();
		}

	}

	public void ejercicio6(String bd,String nombreTabla){
		abrirConexion(bd, "localhost", "root", "");
		try{
			DatabaseMetaData dbmt = conexion.getMetaData();
			
			ResultSet table = dbmt.getColumns(bd, null, nombreTabla, null);
			while (table.next()) {
				System.out.println("Nombre de la columna: "+table.getString("COLUMN_NAME"));
				System.out.println("Tipo de dato: "+table.getString("TYPE_NAME"));
				System.out.println("Permite nulos: "+table.getString("NULLABLE"));
				System.out.println("Autoincrementado: "+table.getString("IS_AUTOINCREMENT"));
			}
		}catch(SQLException e){
			System.out.println("Codigo Error SQL: "+e.getErrorCode());
			System.out.println("Estado SQL: "+e.getSQLState());
			System.out.println("Tipo de excepción: "+e.getNextException());
		}finally{
			cerrarConexion();
		}
	}


	
	public static void main(String[] args) {
		Conectores conectores = new Conectores();
		//EJERCICIO 3 System.out.println("Número ocurrencias: "+conectores.ejercicio3("admarzo23", 0, 10));
		//EJERCICIO 4 System.out.println("Resultado: "+conectores.ejercicio4("admarzo23",5, "Athenas",9.2));
		//EJERCICIO 5 conectores.ejercicio5("admarzo23", "%stat%", 1.0);
		//EJERCICIO 6 conectores.ejercicio6("admarzo23", "maravillas");
		
		
	}

}
