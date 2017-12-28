package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P10GrdMagamOrdTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception {
		DrgsServiceProto.DRG3010P10GrdMagamOrdRequest request = DrgsServiceProto.DRG3010P10GrdMagamOrdRequest.newBuilder()
		        .setJubsuDate("2011/11/18")
		        .setDrgBunho("3007")
		        .setPageNumber("")
		        .setOffset("")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
