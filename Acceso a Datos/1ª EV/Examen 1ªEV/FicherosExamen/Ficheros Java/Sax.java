import java.io.IOException;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

import org.xml.sax.SAXException;

public class Sax {
	public void getSax(String entradaXML) throws ParserConfigurationException, SAXException, IOException {

		SAXParserFactory factory = SAXParserFactory.newInstance();
		SAXParser parser = factory.newSAXParser();
		// ParserSAX parserSax = new ParserSAX(); 
		// parser.parse(entradaXML, parserSax); 
	}

	public static void main(String[] args) {

	}
}
