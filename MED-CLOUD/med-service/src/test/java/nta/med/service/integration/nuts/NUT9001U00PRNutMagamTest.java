package nta.med.service.integration.nuts;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUT9001U00PRNutMagamTest extends MessageRequestTest{

	@Test
	public void test () throws Exception{
		
		NutsServiceProto.NUT9001U00PRNutMagamRequest request = NutsServiceProto.NUT9001U00PRNutMagamRequest.newBuilder()
				.setUpdId("10323")
				.setMagamDate("2016/11/13")
				.setBldGubun("SEOK")
				.setNutMagamGubun("Y")
				.build();
		sentRequestToMedApp(request, NutsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
