package nta.med.service.integration.ocsa;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

@RunWith(SpringJUnit4ClassRunner.class)                                                                                    
@ContextConfiguration(locations = { "classpath:META-INF/spring/spring-master.xml" })                          
public class OCS0103U13GrdSpecimenListTest extends MessageRequestTest{                                                                                          
	@Test
	public void testXRT9001R03Lay9003RRequest() throws InterruptedException {
		
		OcsaServiceProto.OCS0103U13GrdSpecimenListRequest request = OcsaServiceProto.OCS0103U13GrdSpecimenListRequest
				.newBuilder()
				.setCplCodeYn("U")
				.setMode("1")
				.setSlipCode("04/ADMIN/7/1")
				.setSearchWord("%")
				.setWonnaeDrgYn("%")
				.setOrderDate("2015/10/20")
				.setInputTab("04")
				.setUser("")
				.setPageNumber("1")
				.setOffset("200")
				.build();
		sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}                                                                                                                        