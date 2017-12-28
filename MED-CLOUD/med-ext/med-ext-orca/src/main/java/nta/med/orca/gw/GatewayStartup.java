package nta.med.orca.gw;

import org.springframework.context.support.ClassPathXmlApplicationContext;

/**
 * @author dainguyen.
 */
public class GatewayStartup {

    public static void main(String[] args) throws InterruptedException {
        ClassPathXmlApplicationContext springContext = new ClassPathXmlApplicationContext(new String[]{"META-INF/spring/spring-master-orca.xml"});
        springContext.registerShutdownHook();
        Runtime.getRuntime().addShutdownHook(new Thread(() -> {
            System.out.println("STOPPING .......");
        }));
    }
}
