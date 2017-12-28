package nta.med.service.integration.ocsi;

import org.junit.Test;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02SetTabTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		OcsiServiceProto.OCS2005U02SetTabRequest request = OcsiServiceProto.OCS2005U02SetTabRequest.newBuilder()
				.setBldGubun("1")
				.setMpressedJaewonYn("N")
				.setBunho("000030566")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
