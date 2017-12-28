package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10frmARActinggrdOCS2015Test extends MessageRequestTest{

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS6010U10frmARActinggrdOCS2015Request request = OcsiServiceProto.OCS6010U10frmARActinggrdOCS2015Request.newBuilder()
				.setBunho("000042278")
				.setFkinp1001("1608969")
				.setFkocs2005("43842")
				.setKijunDate("2016/01/01")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
