package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2004U00proCreateJisiTest extends MessageRequestTest{

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2004U00proCreateJisiRequest request = OcsiServiceProto.OCS2004U00proCreateJisiRequest.newBuilder()
				.setFkinp1001("1606664")
				.setBunho("000003227")
				.setInputGubun("I")
				.setInputId("10323")
				.setInputGwa("01")
				.setInputDoctor("10323")
				.setOrderDate("2016/01/01")
				.setOrderTime("1020")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
