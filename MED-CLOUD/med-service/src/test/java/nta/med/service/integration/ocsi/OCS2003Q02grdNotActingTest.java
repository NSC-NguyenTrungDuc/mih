package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003Q02grdNotActingTest extends MessageRequestTest {

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003Q02grdNotActingRequest request = OcsiServiceProto.OCS2003Q02grdNotActingRequest.newBuilder()
				.setBunho("000003227")
				.setHoDong("T")
				.setGwa("01")
				.setDoctor("0110323")
				.setTimeGubun("ALL")
				.setOrderDate("2016/11/22")
				.setInputGubun("NR")
				.setOrderGubun("08")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
