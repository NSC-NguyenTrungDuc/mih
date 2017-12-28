package nta.med.service.integration.bass;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class HOTCODEMASTERSaveOCS0103Test extends MessageRequestTest {
	@Test
	public void testHOTCODEMASTERSaveOCS0103() throws InterruptedException {
	BassServiceProto.HOTCODEMASTERSaveOCS0103Request request = BassServiceProto.HOTCODEMASTERSaveOCS0103Request
			.newBuilder()
			.setHospCode("K01")
			.setUserId("ADM0001")
			.build();
	sentRequestToMedApp(request, BassServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
