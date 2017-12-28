package nta.med.service.integration.emr;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2015U09GetTemplateComboBoxTest extends MessageRequestTest{

	@Test
	public void oCS2015U09GetTemplateComboBoxTest() throws InterruptedException {
		
		EmrServiceProto.OCS2015U09GetTemplateComboBoxRequest request = EmrServiceProto.OCS2015U09GetTemplateComboBoxRequest
				.newBuilder()   
				.setUserId("K01OCS")
				.build();    
		sentRequestToMedApp(request, EmrServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
