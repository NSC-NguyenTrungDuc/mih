package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P99grdMiMagamJusaOrderTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P99grdMiMagamJusaOrderRequest request = DrgsServiceProto.DRG3010P99grdMiMagamJusaOrderRequest.newBuilder()
				.setHoDong("T")
				.setOrderDate("2013/12/01")
				.setHopeDate("2013/12/01")
				.setBunho("000001532")
				.setResident("0110040")
				.setMagamGubun("%")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
