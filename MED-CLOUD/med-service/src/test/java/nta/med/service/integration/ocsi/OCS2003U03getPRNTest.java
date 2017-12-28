package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003U03getPRNTest extends MessageRequestTest{
	@Test
	public void test() throws Exception {

		OcsiServiceProto.OCS2003U03getPRNRequest request = OcsiServiceProto.OCS2003U03getPRNRequest.newBuilder()
				.setJubsuDate("2013/10/02")
				.setNameControl("serial")
				.setDrgBunho("30004")
				.setSerialText("1")
				//.setNameControl("serial2003")
				//.setSerialV("t")
				//.setFkocs2003("8059021")
				.build();
		
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
