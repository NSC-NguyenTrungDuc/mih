package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P99OrdPrnSerialTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P99OrdPrnSerialRequest request = DrgsServiceProto.DRG3010P99OrdPrnSerialRequest.newBuilder()
				.setDrgBunho("30004")
				.setSerialText("1")
				.setJubsuDate("2013/10/02")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
