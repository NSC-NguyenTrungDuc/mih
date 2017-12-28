package nta.med.service.integration.bass;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class HOTCODEMASTERGetGrdListTest extends MessageRequestTest {

	@Test
	public void testHOTCODEMASTERGetGrdList() throws InterruptedException {
		BassServiceProto.HOTCODEMASTERGetGrdListRequest request = BassServiceProto.HOTCODEMASTERGetGrdListRequest
				.newBuilder().setHotCode("1003").setHangmogName("局").build();

		sentRequestToMedApp(request, BassServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
