package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003U03getPRNCURTest extends MessageRequestTest{
	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003U03getPRNCURRequest request = OcsiServiceProto.OCS2003U03getPRNCURRequest.newBuilder()
				.setJubsuDate("2016/07/05")
				.setDrgBunho("3031")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
