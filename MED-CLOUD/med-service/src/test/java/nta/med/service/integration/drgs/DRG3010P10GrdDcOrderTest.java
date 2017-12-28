package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P10GrdDcOrderTest extends MessageRequestTest{

	@Test
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P10GrdDcOrderRequest request = DrgsServiceProto.DRG3010P10GrdDcOrderRequest.newBuilder()
				.setBunho("000003488")
				.setDrgBunho("8044")
				.setJubsuDate("2014/05/22")
				.setMagamBunryu("1")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
