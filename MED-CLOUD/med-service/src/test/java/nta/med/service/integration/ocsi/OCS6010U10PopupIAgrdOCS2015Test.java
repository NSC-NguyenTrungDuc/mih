package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAgrdOCS2015Request;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10PopupIAgrdOCS2015Test extends MessageRequestTest{

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS6010U10PopupIAgrdOCS2015Request request = OcsiServiceProto.OCS6010U10PopupIAgrdOCS2015Request.newBuilder()
				.setHospCode("323")
				.setBunho("000042278")
				.setFkinp1001("1608969")
				.setOrderDate("2014/5/26 12:00:00 AM")
				.setInputGubun("D0")
				.setPkSeq("2")
				.setActDate("2014/5/26 12:00:00 AM")
				.setOffset("")
				.setPageNumber("")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
