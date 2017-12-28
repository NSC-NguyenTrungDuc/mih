package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003U03grdOrderdateTest extends MessageRequestTest {
	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003U03grdOrderdateRequest request = OcsiServiceProto.OCS2003U03grdOrderdateRequest.newBuilder()
				.setBunho("000003227")
				.setOrderDate("2016/07/05")
				.setFkinp1001("1606664")
				.setGaiyouYn("Y")
				.setInputGubun("H0")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
