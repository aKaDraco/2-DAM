package examen;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

public class Domm {
	public static Document creaArbol(String entradaXML) {
		Document doc = null;
		try {
			DocumentBuilderFactory factoria = DocumentBuilderFactory.newInstance();
			factoria.setIgnoringComments(true);
			DocumentBuilder builder = factoria.newDocumentBuilder();
			doc = builder.parse(entradaXML);
		} catch (Exception e) {
			System.out.println("Error generando el árbol DOM: " + e.getMessage());
		}
		return doc;
	}

	public static void main(String[] args) {
		Document doc = creaArbol("examen\\src\\main\\java\\examen\\Alonso.xml");
		RacesD(doc);
	}

	public static void RacesD(Document doc) {
		NodeList nombre = doc.getElementsByTagName("Name");
		NodeList numero = doc.getElementsByTagName("Number");
		NodeList circuito = doc.getElementsByTagName("Circuit");
		NodeList hijos_de_circuito;
		Node location;
		NamedNodeMap atributos;
		// Node lat, longi;

		if (nombre != null) {
			for (int i = 0; i < nombre.getLength(); i++) {
				if (nombre.item(i).getParentNode().getNodeName().equals("Data")) {
					System.out.println("Nombre del piloto: " + nombre.item(i).getFirstChild().getNodeValue());
				}
			}
		}

		if (numero != null) {
			for (int i = 0; i < numero.getLength(); i++) {
				if (numero.item(i).getParentNode().getNodeName().equals("Data")) {
					System.out.println("Numero del piloto: " + numero.item(i).getFirstChild().getNodeValue());
				}
			}
		}

		if (nombre != null) {
			for (int i = 0; i < nombre.getLength(); i++) {
				if (nombre.item(i).getParentNode().getNodeName().equals("Constructor")) {
					System.out.println("Escuderia: " + nombre.item(i).getFirstChild().getNodeValue());
				}
			}
		}

		if (circuito != null) {
			for (int i = 0; i < circuito.getLength(); i++) {
				hijos_de_circuito = circuito.item(i).getChildNodes();
				for (int j = 0; j < hijos_de_circuito.getLength(); j++) {
					if (hijos_de_circuito.item(j).getNodeName().equals("Name")) {
						System.out.println(
								"NOMBRE DE CICUITO: " + hijos_de_circuito.item(j).getFirstChild().getNodeValue());
					}

					if (hijos_de_circuito.item(j).getNodeName().equals("Location")) {
						location = hijos_de_circuito.item(j);
						if (location.hasAttributes()) {
							atributos = location.getAttributes();
							for (int j2 = 0; j2 < atributos.getLength(); j2++) {
								if (atributos.item(j2).getNodeName().equals("lat")) {
									System.out.println("Lat" + atributos.item(j2).getNodeValue());
								}

								if (atributos.item(j2).getNodeName().equals("long")) {
									System.out.println("Long" + atributos.item(j2).getNodeValue());
								}
							}
						}
					}
				}
			}
		}

	}
}
