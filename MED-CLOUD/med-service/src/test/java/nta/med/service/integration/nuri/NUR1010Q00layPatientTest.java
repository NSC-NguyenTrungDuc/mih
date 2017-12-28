package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR1010Q00layPatientTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		NuriServiceProto.NUR1010Q00layPatientRequest request = NuriServiceProto.NUR1010Q00layPatientRequest.newBuilder()
				.setHoDong("T")
				.build();
		
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
