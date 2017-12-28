package nta.med.ext.phr;

import nta.med.common.glossary.Lifecyclet;
import nta.med.ext.phr.restful.PhrApplication;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;

/**
 * @author dainguyen.
 */
public class ApiPhrStartup {

	/**
	 * Main method.
	 * @param args
	 * @throws IOException
	 */
	public static void main(String[] args) throws IOException {
		ClassPathXmlApplicationContext springContext = new ClassPathXmlApplicationContext(
				new String[] { "META-INF/spring/spring-startup-phr.xml" });
		springContext.registerShutdownHook();
		Runtime.getRuntime().addShutdownHook(new Thread(() -> {
			System.out.println("STOPPING .......");
			try {
				List<Class<? extends Lifecyclet>> apps = Arrays.asList(PhrApplication.class);
				for (Class<? extends Lifecyclet> r : apps) {
					Lifecyclet application = springContext.getBean(r);
					application.stop();
				}
			} catch (Exception e) {
				System.out.println(e.getMessage());
				System.out.println(e.getStackTrace());
			} finally {
				springContext.close();
			}
		}));
	}
}
