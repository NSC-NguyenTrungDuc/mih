package nta.med.ext.emr;

import nta.med.ext.emr.api.AbstractApplication;
import nta.med.ext.emr.api.rest.RestApplication;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;

/**
 * @author dainguyen.
 */
public class ApiEmrStartup {

    public static void main(String[] args) throws IOException {
        ClassPathXmlApplicationContext springContext = new ClassPathXmlApplicationContext(new String[]{"META-INF/spring/spring-master-emr.xml"});
        springContext.registerShutdownHook();
        Runtime.getRuntime().addShutdownHook(new Thread(() -> {
            System.out.println("STOPPING .......");
            try {
                List<Class<? extends AbstractApplication>> apps = Arrays.asList(RestApplication.class);
                for (Class<? extends AbstractApplication> r : apps) {
                    AbstractApplication application = springContext.getBean(r);
                    application.stop();
                }
            } catch (Exception e) {
                System.out.println(e.getMessage());
                System.out.println(e.getStackTrace());
            } finally {
                springContext.close();
            }
        }));

        /*EmrService service = springContext.getBean(EmrService.class);

        ExaminationHistory history = service.findHistoryDetail("K01", "bcd29628-9993-42f6-b7b5-d1eb4ace6a1e", "1");

        List<HistoryListModel> models = service.findAllHistories("K01", "bcd29628-9993-42f6-b7b5-d1eb4ace6a1e");

        System.out.println(models.size());
        System.out.println(history.toString());*/
    }
}
