package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P10GrdJusaDcOrderTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception {
		DrgsServiceProto.DRG3010P10GrdJusaDcOrderRequest request = DrgsServiceProto.DRG3010P10GrdJusaDcOrderRequest.newBuilder()
		        .setJubsuDate("1900/1/1")
		        .setDrgBunho("3004")
		        .setBunho("000026346")
		        .setMagamBunryu("2")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
