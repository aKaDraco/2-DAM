import java.io.File;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.w3c.dom.Element;

public class DOM {

    public static void main(String[] args) {
        // EJERCIIO 1
        Document doc = creaArbol("peliculas.xml");

        // EJERCICIO 2
        // getTitulos(doc);

        // EJERCICIO 3
        getTDG(doc);
    }

    // EJERCICIO 1
    public static Document creaArbol(String ruta) {
        Document doc = null;
        try {
            DocumentBuilderFactory facto = DocumentBuilderFactory.newInstance();
            facto.setIgnoringComments(true);
            DocumentBuilder build = facto.newDocumentBuilder();
            doc = build.parse(new File(ruta));
        } catch (Exception e) {
            System.out.println("Error generando el árbol DOM: " + e.getMessage());
        }
        return doc;
    }

    // EJERCICIO 2
    public static void getTitulos(Document doc) {
        NodeList titulos = doc.getElementsByTagName("titulo");
        for (int i = 0; i < titulos.getLength(); i++) {
            System.out.println(titulos.item(i).getFirstChild().getNodeValue());
        }
    }

    // EJERCICIO 3
    public static void getTDG(Document doc) {
        NamedNodeMap atributos;
        NodeList titulos, directores, hijos_de_director;
        Node titulo, atributo, nombre_director, apellido_director;
        titulos = doc.getElementsByTagName("titulo");
        for (int i = 0; i < titulos.getLength(); i++) {
            titulo = titulos.item(i);
            directores = ((Element) titulo.getParentNode()).getElementsByTagName("director");
            System.out.println("\n\nPelicula:\n" + "\tTitulo: " + titulo.getFirstChild().getNodeValue());
            if (((Element) titulo.getParentNode()).hasAttributes()) {
                atributos = ((Element) titulo.getParentNode()).getAttributes();
                for (int k = 0; k < atributos.getLength(); k++) {
                    atributo = atributos.item(k);
                    if (atributo.getNodeName().equals("genero")) {
                        System.out.println("\tGenero: " + atributo.getNodeValue());
                    }
                }
            }
            for (int j = 0; j < directores.getLength(); j++) {
                hijos_de_director = directores.item(j).getChildNodes();
                System.out.println("Director:");
                for (int j2 = 0; j2 < hijos_de_director.getLength(); j2++) {
                    if (hijos_de_director.item(j2).getNodeName().equals("nombre")) {
                        nombre_director = hijos_de_director.item(j2);
                        System.out.println("\tNombre: " + nombre_director.getFirstChild().getNodeValue());
                    }
                    if (hijos_de_director.item(j2).getNodeName().equals("apellido")) {
                        apellido_director = hijos_de_director.item(j2);
                        System.out.println("\tApellido: " + apellido_director.getFirstChild().getNodeValue());
                    }
                }
            }
        }
    }

    // EJERCICIO 5
    public static void numDirectores(Document doc, int numero) {
        
        NodeList elementos;
        
    }
}