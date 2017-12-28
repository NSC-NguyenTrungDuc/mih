package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P99JusaSerialTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P99JusaSerialRequest request = DrgsServiceProto.DRG3010P99JusaSerialRequest.newBuilder()
				.setSerialText("1")
				.setJubsuDate("2011/11/18")
				.setDrgBunho("3006")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
