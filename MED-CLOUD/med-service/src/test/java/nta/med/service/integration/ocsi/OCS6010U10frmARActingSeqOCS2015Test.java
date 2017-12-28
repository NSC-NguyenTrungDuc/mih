package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10frmARActingSeqOCS2015Test extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS6010U10frmARActingSeqOCS2015Request request = OcsiServiceProto.OCS6010U10frmARActingSeqOCS2015Request.newBuilder()
				.setFBunho("000042278")
				.setFFkinp1001("1608969")
				.setFOrderDate("2014/05/26")
				.setFInputGubun("D0")
				.setFPkSeq("2")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
