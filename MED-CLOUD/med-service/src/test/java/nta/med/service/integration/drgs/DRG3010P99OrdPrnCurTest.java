package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P99OrdPrnCurTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P99OrdPrnCurRequest request = DrgsServiceProto.DRG3010P99OrdPrnCurRequest.newBuilder()
				.setJubsuDate("2013/12/21")
				.setDrgBunho("7002")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
