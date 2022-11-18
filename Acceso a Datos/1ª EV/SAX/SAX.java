import java.io.IOException;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

import org.xml.sax.SAXException;


public class SAX {

    public static void main(String[] args) throws ParserConfigurationException, SAXException, IOException {
        String entradaXML = "peliculas.xml";
        getSax(entradaXML);
    }

    public static void getSax(String entradaXML) throws ParserConfigurationException, SAXException, IOException {
        SAXParserFactory factory = SAXParserFactory.newInstance();
        SAXParser parser = factory.newSAXParser();
        ParserSAX1 parserSax = new ParserSAX1(); // ParserSAX es la clase que se deberá
        parser.parse(entradaXML, parserSax); // implementar y que hereda de DafaultHandler
    }
}