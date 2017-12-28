package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P99grdPrnJusaTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P99grdPrnJusaRequest request = DrgsServiceProto.DRG3010P99grdPrnJusaRequest.newBuilder()
				.setHoDong("T")
				.setOrderDate("2013/12/01")
				.setHopeDate("2013/12/01")
				.setHopeTime("0000")
				.setBunho("000001532")
				.setResident("0110040")
				.setEmergency("N")
				.build();
		
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
