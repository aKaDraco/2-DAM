import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import org.w3c.dom.Node;
import org.w3c.dom.Document;

public class Domm { 
	public Document creaArbol(String entradaXML) {
	    Document doc=null; 
	    try {
	        DocumentBuilderFactory factoria = DocumentBuilderFactory.newInstance();
	        factoria.setIgnoringComments(true);
	        DocumentBuilder builder = factoria.newDocumentBuilder();
	        doc=builder.parse(entradaXML);
	    } catch (Exception e) {
	        System.out.println("Error generando el árbol DOM: "+e.getMessage());
	    }
	    return doc;
	}

	public static void main(String[] args) {

	}
}
