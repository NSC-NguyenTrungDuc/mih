package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10PopupDAgrdOCS2006Test extends MessageRequestTest{

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS6010U10PopupDAgrdOCS2006Request request = OcsiServiceProto.OCS6010U10PopupDAgrdOCS2006Request.newBuilder()
				.setHospCode("323")
				.setOrderDate("2015/01/01")
				.setFkocs2005("163441")
				.setPkSeq("2")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
