package nta.med.service.integration.emr;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2015U00GetDoctorPatientTest extends MessageRequestTest{

	@Test
	public void oCS2015U00GetDoctorPatientTest() throws InterruptedException {
		
		EmrServiceProto.OCS2015U00GetDoctorPatientReportRequest request =EmrServiceProto.OCS2015U00GetDoctorPatientReportRequest
				.newBuilder()   
				.build();    
		sentRequestToMedApp(request, EmrServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
