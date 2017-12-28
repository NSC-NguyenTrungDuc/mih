package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003U03getPkocskeyTest extends MessageRequestTest{
	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003U03getPkocskeyRequest request = OcsiServiceProto.OCS2003U03getPkocskeyRequest.newBuilder()
				.setPkOcs2003("11205")
				.setWorkGubun("D")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
