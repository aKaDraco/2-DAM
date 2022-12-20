package examen;

import java.io.IOException;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

import org.xml.sax.SAXException;

public class Sax {
	public static void getSax(String entradaXML) throws ParserConfigurationException, SAXException, IOException {

		SAXParserFactory factory = SAXParserFactory.newInstance();
		SAXParser parser = factory.newSAXParser();
		NombreS parserSax = new NombreS();
		RacesS parserSax2 = new RacesS();
		parser.parse(entradaXML, parserSax);
		System.out.println("-----------------------------------------------------------------------------");
		parser.parse(entradaXML, parserSax2);
	}

	public static void main(String[] args) {
		try {
			getSax("examen\\src\\main\\java\\examen\\Alonso.xml");
		} catch (Exception e) {
			System.out.println("ERROR");
		}
	}
}
