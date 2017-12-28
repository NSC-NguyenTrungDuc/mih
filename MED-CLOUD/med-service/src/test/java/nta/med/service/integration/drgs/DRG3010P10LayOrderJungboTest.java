package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P10LayOrderJungboTest extends MessageRequestTest {
	@Test
	
	public void Test() throws Exception {
		DrgsServiceProto.DRG3010P10LayOrderJungboRequest request = DrgsServiceProto.DRG3010P10LayOrderJungboRequest.newBuilder()
				.setJubsuDate("2011/11/16")
				.setDrgBunho("3004")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
