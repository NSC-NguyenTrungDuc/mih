package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS6010U10LoadDetailDataTest extends MessageRequestTest{

	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS6010U10LoadDetailDataRequest request = OcsiServiceProto.OCS6010U10LoadDetailDataRequest.newBuilder()
				.setBunho("000114117")
				.setFkinp1001("104")
				.setFromDate("2016/12/14")
				.setToDate("2016/12/20")
				.setAllSiji("N")
				.setEmerTreat("Y")
				.setInsteadOrdDisp("N")
				.setBVal("Y")
				.setCVal("Y")
				.setDVal("Y")
				.setHVal("Y")
				.setGVal("Y")
				.setMVal("Y")
				.setFVal("Y")
				.setOVal("Y")
				.setNVal("Y")
				.setEVal("Y")
				.setLVal("Y")
				.setKVal("Y")
				.setIVal("Y")
				.setZVal("Y")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
