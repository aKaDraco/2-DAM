package exam;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.DefaultValue;
import javax.ws.rs.GET;
import javax.ws.rs.HEAD;
import javax.ws.rs.HeaderParam;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

@Path("/api")
public class Examen{
	public static ArrayList<Maravilla> maravillas = new ArrayList<Maravilla>();
	private ConectoresRest cntRest = new ConectoresRest();
	
	/**
	 * http://localhost:8080/examenrest/rest/api
	 * Produce XML y JSON 
	 * @return maravilla en su forma JSON o XML
	 */
	@GET
	@Produces({MediaType.APPLICATION_JSON,MediaType.APPLICATION_XML})
	public Response ejercicio7() {
		Maravilla maravillaNueva = new Maravilla(10, "Maccu-Piccu", 30, 12, "Yucatecas", "Perú", "Barro", 3.2);
		maravillas.add(maravillaNueva);
		return Response.ok(maravillaNueva).build();
	}
	
	/**
	 * http://localhost:8080/examenrest/rest/api/{id}
	 * Produce XML y JSON 
	 * Parámetros de cabecera
	 * @param id Es el pathParam 
	 * @return Número de filas borradas en forma de json o xml
	 */
	
	@Path("/{id}")
	@DELETE
	@Produces({MediaType.APPLICATION_XML,MediaType.APPLICATION_JSON})
	public Response ejercicio8(@PathParam("id") int id) {
		int borradas=0;
		for (int i = 0; i < maravillas.size(); i++) {
			if(maravillas.get(i).getCodmaravilla()==id) {
				maravillas.remove(i);
				i--;
				borradas++;
			}
		}
		
		return Response.ok(String.format("%d",borradas)).build();
	}
	
	/**
	 * http://localhost:8080/examenrest/rest/api/tabla
	 * Produce array de todas las maravillas a JSON
	 * No recibe valores
	 */
	
	@Path("/tabla")
	@GET
	@Produces({MediaType.APPLICATION_JSON})
	public Response ejercicio9() {
		

		ArrayList<Maravilla> maravillasBase = new ArrayList<Maravilla>();
		cntRest.abrirConexion("admarzo23", "localhost", "root", "");
		try {
			String query = "SELECT * from maravillas";
			Statement stmt = cntRest.conexion.createStatement();
			ResultSet rslt = stmt.executeQuery(query);
			while(rslt.next()) {
				maravillasBase.add(new Maravilla(rslt.getInt("codmaravilla"),rslt.getString("nombre"),rslt.getInt("sigloAcConstruccion"),rslt.getInt("codCivilizacion"),rslt.getString("nombreCiv"),rslt.getString("zonaOrigen"),rslt.getString("material"),rslt.getDouble("valoracion")));
			}
		}catch(SQLException e) {
			return Response.serverError().build();
		}finally {
			cntRest.cerrarConexion();
		}
		return Response.ok(maravillasBase).build();
		
	}
	
	/**
	 *  http://localhost:8080/examenrest/rest/api/consulta?nombre=valor1&valoracion=valor2
	 *  Parámetros de cabecera
	 * @param nombre Cadena que debe contener el nombre
	 * @param valoracion Valoracion a la que tiene que ser superior
	 * @return Array en json con maravillas que cumplen requisito
	 */
	
	@Path("/consulta")
	@GET
	@Produces({MediaType.APPLICATION_JSON})
	@HeaderParam("Cant")
	public Response ejercicio10(@DefaultValue("sin valor") @QueryParam("nombre") String nombre,@DefaultValue("0") @QueryParam("valoracion") String valoracion) {
		ConectoresRest cntRest = new ConectoresRest();

		ArrayList<Maravilla> maravillasBase = new ArrayList<Maravilla>();
		cntRest.abrirConexion("admarzo23", "localhost", "root", "");
		try {
			String query = "SELECT * from maravillas WHERE nombre LIKE \"%"+nombre+"%\" AND valoracion>"+valoracion;
			
			Statement stmt = cntRest.conexion.createStatement();
			ResultSet rslt = stmt.executeQuery(query);
			while(rslt.next()) {
				maravillasBase.add(new Maravilla(rslt.getInt("codmaravilla"),rslt.getString("nombre"),rslt.getInt("sigloAcConstruccion"),rslt.getInt("codCivilizacion"),rslt.getString("nombreCiv"),rslt.getString("zonaOrigen"),rslt.getString("material"),rslt.getDouble("valoracion")));
			}
		}catch(SQLException e) {
			return Response.serverError().build();
		}

		return Response.ok(maravillasBase).build();
		
	}
	
	
	
	
	
	
	
	
}