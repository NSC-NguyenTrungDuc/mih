package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003P01LayQueryLayoutTest extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003P01LayQueryLayoutRequest request = OcsiServiceProto.OCS2003P01LayQueryLayoutRequest.newBuilder()
				.setBunho("000114117")
				.setFkinp1001("104")
				.setOrderDate("2016/12/13")
				.setQueryGubun("D")
				.setInputDoctor("0110323")
				.setInputGubun("D%")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
