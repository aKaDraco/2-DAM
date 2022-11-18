import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class ParserSAX1 extends DefaultHandler {
    String qName = "";
    String titulo = "";

    @Override
    public void startDocument() throws SAXException {
        System.out.println("Comienzo a leer");
    }

    @Override
    public void endDocument() throws SAXException {
        System.out.println("Acabo de leer");
    }

    @Override
    public void startElement(String uri, String localName, String qName,
            Attributes attributes) throws SAXException {
        System.out.println("<" + qName + ">");
    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
       System.out.println("</" + qName + ">");
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException {
        String aa = new String(ch, start, length);
        if (aa.trim().length()>0)System.out.println("  " + aa);
    }

  
}
