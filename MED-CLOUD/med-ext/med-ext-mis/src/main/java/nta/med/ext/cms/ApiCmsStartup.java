package nta.med.ext.cms;

import nta.med.common.glossary.Lifecyclet;
import nta.med.ext.cms.restful.RestApplication;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;

/**
 * @author dainguyen.
 */
public class ApiCmsStartup {

    public static void main(String[] args) throws IOException {
        ClassPathXmlApplicationContext springContext = new ClassPathXmlApplicationContext(new String[]{"META-INF/spring/spring-startup-mis.xml"});
        springContext.registerShutdownHook();
        Runtime.getRuntime().addShutdownHook(new Thread(() -> {
            System.out.println("STOPPING .......");
            try {
                List<Class<? extends Lifecyclet>> apps = Arrays.asList(RestApplication.class);
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
