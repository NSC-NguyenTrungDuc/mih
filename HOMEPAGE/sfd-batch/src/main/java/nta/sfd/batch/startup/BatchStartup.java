package nta.sfd.batch.startup;

import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

/**
 * @author dainguyen.
 */
public final class BatchStartup {

    private static ConfigurableApplicationContext context;
    private static final String[] configs = new String[] {"classpath:META-INF/core-spring.xml", "classpath:META-INF/spring-batch.xml"};

    public static void main(String[] args) throws InterruptedException {
        context = new ClassPathXmlApplicationContext(configs);
        //context.close();
    }
}
