package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P10DsvOrderPrint4Test extends MessageRequestTest {

	@Test
	public void Test() throws Exception {
		// A table contains triggers, not update it
		DrgsServiceProto.DRG3010P10DsvOrderPrint4Request request = DrgsServiceProto.DRG3010P10DsvOrderPrint4Request.newBuilder()
				.setJubsuDate("")
				.setDrgBunho("")
				.setSerialText("")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
