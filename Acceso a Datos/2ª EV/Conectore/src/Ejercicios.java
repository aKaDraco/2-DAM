import java.sql.ResultSet;
import java.sql.SQLException;

public class Ejercicios {

    Conexion conex;

    private int filasAfectadas;

    public Ejercicios() {
        conex = new Conexion();
    }

    public void ejercicio1(String cadena) {
        ResultSet st = conex.consultaAlumnos("SELECT * FROM alumnos WHERE nombre LIKE '" + cadena + "'");
        int filasAfectadas = 0;
        try {
            while (st.next()) {
                filasAfectadas++;
                try {
                    System.out.println(st.getString("nombre").toUpperCase());
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }
            System.out.println("Filas afectadas: " + filasAfectadas);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void ejercicio2a(String nombre, String apellidos, int altura, int aula) {
        filasAfectadas = conex.insertaFila(
                "INSERT INTO alumnos (nombre,apellidos,altura,aula) VALUES ( '" + nombre + "', '" + apellidos + "', "
                        + altura + ", " + aula + " );");
        System.out.println("Filas afectadas: " + filasAfectadas);
    }

    public void ejercicio2b(String asignatura) {
        filasAfectadas = conex.insertaFila("INSERT INTO asignaturas (NOMBRE) VALUES ( '" + asignatura + "' );");
        System.out.println("Filas afectadas: " + filasAfectadas);
    }

    public void ejercicio3a(String nombre, String apellidos) {
        filasAfectadas = conex.insertaFila("DELETE FROM alumnos WHERE nombre = '" + nombre + "' AND apellidos = '" + apellidos + "';");
        System.out.println("Filas afectadas: " + filasAfectadas);
    }

    public void ejercicio3b(String asignatura) {
        filasAfectadas = conex.insertaFila("DELETE FROM asignaturas WHERE NOMBRE = '" + asignatura + "';");
        System.out.println("Filas afectadas: " + filasAfectadas);
    }
}