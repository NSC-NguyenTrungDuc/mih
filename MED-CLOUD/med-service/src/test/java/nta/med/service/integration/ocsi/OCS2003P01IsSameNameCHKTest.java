package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003P01IsSameNameCHKTest extends MessageRequestTest{

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003P01IsSameNameCHKRequest request = OcsiServiceProto.OCS2003P01IsSameNameCHKRequest.newBuilder()
				.setBunho("000000045")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
