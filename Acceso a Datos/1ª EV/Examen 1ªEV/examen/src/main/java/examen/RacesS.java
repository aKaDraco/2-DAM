package examen;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class RacesS extends DefaultHandler {
    private String qname = "";
    private String apellido;
    private String race_name;
    private boolean is_circuit;

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
        this.qname = qName;
        if (qname.equals("Circuit")) {
            is_circuit = true;
        }

        if (qname.equals("Location")) {
            for (int i = 0; i < attributes.getLength(); i++) {
                System.out.printf("\t%s: %s", attributes.getLocalName(i), attributes.getValue(i));
            }
        }

        if(qname.equals("Result")) {
            for (int i = 0; i < attributes.getLength(); i++) {
                if(attributes.getLocalName(i).equals("position")) {
                    System.out.printf("\t%s: %s%n",attributes.getLocalName(i),attributes.getValue(i));
                }
            }
        }
        super.startElement(uri, localName, qName, attributes);
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException {
        String cad = new String(ch, start, length);

        if (qname.equals("Surname")) {
            apellido = cad;
            System.out.println("Apellido: " + apellido);
        }

        if (is_circuit && qname.equals("Name")) {
            race_name = cad;
            System.out.println("Nombre:" + race_name);
            is_circuit = false;
        }
        super.characters(ch, start, length);
    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
        // if (qname.equals("Circuit")) {
        //     is_circuit = false;
        // }
        qname = "";
        super.endElement(uri, localName, qName);
    }

    @Override
    public void endDocument() throws SAXException {
        super.endDocument();
    }
}
