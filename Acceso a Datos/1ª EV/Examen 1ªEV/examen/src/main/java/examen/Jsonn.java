package examen;

import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;

import javax.json.Json;
import javax.json.JsonNumber;
import javax.json.JsonObject;
import javax.json.JsonReader;
import javax.json.JsonValue;
import javax.net.ssl.HttpsURLConnection;

public class Jsonn {

       public JsonValue leeJSON(String ruta) {
              JsonReader reader = null;
              JsonValue jsonV = null;
              try {
                     if (ruta.toLowerCase().startsWith("http://")) {
                            URL url = new URL(ruta);
                            InputStream is = url.openStream();
                            reader = Json.createReader(is);
                     } else if (ruta.toLowerCase().startsWith("https://")) {
                            URL url = new URL(ruta);
                            HttpsURLConnection conn = (HttpsURLConnection) url.openConnection();
                            InputStream is = conn.getInputStream();
                            reader = Json.createReader(is);
                     } else {
                            reader = Json.createReader(new FileReader(ruta));
                     }
                     jsonV = reader.read();
              } catch (IOException e) {
                     System.out.println("Error procesando documento Json" + e.getLocalizedMessage());
              }
              if (reader != null)
                     reader.close();
              return jsonV;
       }

       public void ejercicio1() {// vamo a ver que pide
              // nombre del pilote
              // no me acuerda como era la ruta
              JsonObject piloto = (JsonObject) leeJSON(
                            "C:\\Users\\Hugo\\OneDrive\\Documentos\\DAM GitHub\\2-DAM\\Acceso a Datos\\1ª EV\\Examen 1ªEV\\FicherosExamen\\Ficheros Datos\\Alonso.json");
              String nombre = piloto.getString("Name");
              int numero = piloto.getInt("Number");
              int cont = 0;
              String escuderia = piloto.getJsonObject("Constructor").getString("name");
              System.out.println("Nombre: " + nombre + "\n" + "Número: " + numero + "\n" + "Nombre de la escuderia: "
                            + escuderia + "\n");
              for (int i = 0; i < piloto.getJsonObject("RaceTable").getJsonArray("Races").size(); i++) {
                     String nombre_carrera = piloto.getJsonObject("RaceTable").getJsonArray("Races").get(i)
                                   .asJsonObject().getString("Name");
                     JsonNumber lat_carrera = piloto.getJsonObject("RaceTable").getJsonArray("Races").get(i)
                                   .asJsonObject().getJsonObject("Circuit").getJsonObject("Location")
                                   .getJsonNumber("lat");
                     Double lat_double = Double.parseDouble(lat_carrera + "");

                     JsonNumber long_carrera = piloto.getJsonObject("RaceTable").getJsonArray("Races").get(i)
                                   .asJsonObject().getJsonObject("Circuit").getJsonObject("Location")
                                   .getJsonNumber("long");
                     Double long_double = Double.parseDouble(long_carrera + "");
                     cont++;
                     System.out.println("Circuito" + cont + ": " + nombre_carrera + "\n\tLat: " + lat_double
                                   + "\n\tLong: " + long_carrera);
              }

       }
}
