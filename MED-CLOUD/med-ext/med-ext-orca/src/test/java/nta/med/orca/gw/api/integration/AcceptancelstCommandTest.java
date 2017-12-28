package nta.med.orca.gw.api.integration;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.orca.gw.api.command.AcceptancelstCommand;
import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;
import nta.med.orca.gw.api.contracts.service.AcceptancelstRequest;
import nta.med.orca.gw.api.contracts.service.AcceptlstResponse;
import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations={"classpath:META-INF/spring/spring-master.xml"})
public class AcceptancelstCommandTest {

	private AcceptancelstCommand acceptancelstCommand;

//    @Before
//    public void setUp() throws Exception {
//    	acceptancelstCommand = SpringBeanFactory.beanFactory.getBean(AcceptancelstCommand.class);
//    	acceptancelstCommand.start();
//    }
    
    @Test
    public void testExecute() throws Exception {
    	OrcaEnvInfo orcaEnvInfo = new OrcaEnvInfo("", "10.1.20.173", "8000", "ormaster", "ormaster123");
    	AcceptancelstRequest request = new AcceptancelstRequest("2016-03-11", orcaEnvInfo);
    	AcceptlstResponse response = acceptancelstCommand.execute(request);
        Assert.assertNotNull("response shouldn't be null", response);
    }

//    @After
//    public void tearDown() throws Exception {
//    	acceptancelstCommand.stop();
//    }
}
