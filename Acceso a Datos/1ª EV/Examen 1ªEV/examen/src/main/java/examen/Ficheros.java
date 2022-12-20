package examen;

import java.io.File;
import java.util.Scanner;

public class Ficheros {
	
	public static void main(String[] args) {
 
		File doc = new File("C:\\Users\\Hugo\\OneDrive\\Documentos\\DAM GitHub\\2-DAM\\Acceso a Datos\\1ª EV\\Examen 1ªEV\\FicherosExamen\\Ficheros Datos\\Juegos.txt");

		System.out.println();
	}

	public static String readTab(File doc, int pos) {
		int line = 0;
		String contenido ;

		try (Scanner sc = new Scanner(doc)){
			while(sc.hasNextLine()) {
				line++;
				if(line > 1) {
				}
			}
		} catch (Exception e) {
			System.out.println("ERROR EN EL ARCHIVO");
		}
	}
}
