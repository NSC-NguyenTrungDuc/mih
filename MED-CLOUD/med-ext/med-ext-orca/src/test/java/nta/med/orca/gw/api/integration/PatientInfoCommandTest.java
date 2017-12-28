package nta.med.orca.gw.api.integration;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.orca.gw.api.command.PatientInfoCommand;
import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;
import nta.med.orca.gw.api.contracts.service.PatientInfoRequest;
import nta.med.orca.gw.api.contracts.service.PatientInfoResponse;
import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = { "classpath:META-INF/spring/spring-master.xml" })
public class PatientInfoCommandTest {
	private PatientInfoCommand patientInfoCommand;

//	@Before
//	public void setUp() throws Exception {
//		patientInfoCommand = SpringBeanFactory.beanFactory.getBean(PatientInfoCommand.class);
//		patientInfoCommand.start();
//	}

	@Test
	public void testExecute() throws Exception {
		OrcaEnvInfo orcaEnvInfo = new OrcaEnvInfo("", "10.1.20.173", "8000", "ormaster", "ormaster123");
		PatientInfoRequest request = new PatientInfoRequest("000000380", orcaEnvInfo);
		PatientInfoResponse response = patientInfoCommand.execute(request);
		Assert.assertNotNull("response shouldn't be null", response);
	}

//	@After
//	public void tearDown() throws Exception {
//		patientInfoCommand.stop();
//	}
}
