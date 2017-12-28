package nta.med.orca.gw.api.integration;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.orca.gw.api.command.ShunouCommand;
import nta.med.orca.gw.api.contracts.service.ShunouRequest;
import nta.med.orca.gw.api.contracts.service.ShunouResponse;
import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

/**
 * @author dainguyen.
 */
@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations={"classpath:META-INF/spring/spring-master.xml"})
public class ShunouCommandTest {

    private ShunouCommand shunouCommand;

    @Before
    public void setUp() throws Exception {
        shunouCommand = SpringBeanFactory.beanFactory.getBean(ShunouCommand.class);
        shunouCommand.start();
    }

    @Test
    //@Ignore
    public void testExecute() throws Exception {
        ShunouRequest request = new ShunouRequest("2", "", "", "");
        ShunouResponse response = shunouCommand.execute(request);
        Assert.assertNotNull("response shouldn't be null", response);
    }

    @After
    public void tearDown() throws Exception {
        shunouCommand.stop();
    }
}
